using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Buffers.Binary;

namespace client.socket
{
    public class server_handler
    {
        public  int client_id = 0;
        private TcpClient _client;
        private NetworkStream _stream;
        private CancellationTokenSource _cts;
        public event Action<string> MessageReceived;
        public event Action Disconnected;


        public async Task SendAsync(string message)
        {
            if (_stream == null) return;

            byte[] data = Encoding.UTF8.GetBytes(message);
            byte[] length = BitConverter.GetBytes(data.Length);

            await _stream.WriteAsync(length, 0, length.Length);
            await _stream.WriteAsync(data, 0, data.Length);
        }
        public async Task SendAsync(IEnumerable<byte> bytes)
        {
            if (_stream == null) return;

            byte[] data = bytes.ToArray();
            byte[] length = BitConverter.GetBytes(data.Length);

            await _stream.WriteAsync(length, 0, length.Length);
            await _stream.WriteAsync(data, 0, data.Length);
        }

        public async Task ConnectAsync(string host, int port)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(host, port);

            _stream = _client.GetStream();
            _cts = new CancellationTokenSource();

            int id = await ReceiveIDAsync();
            client_manager.SetID(id);

            _ = Task.Run(ReadLoopAsync);
        }

        private async  Task<int> ReceiveIDAsync()
        {
            byte[] idBuf = await ReadExactAsync(4);
            int id = BinaryPrimitives.ReadInt32BigEndian(idBuf);
            return id;
        }

        private async Task ReadLoopAsync()
        {
            try
            {
                while (!_cts.IsCancellationRequested)
                {
                    byte[] lenBuf = await ReadExactAsync(4);
                    int length = BinaryPrimitives.ReadInt32BigEndian(lenBuf);

                    byte[] msgBuf = await ReadExactAsync(length);
                    string message = Encoding.UTF8.GetString(msgBuf);
                    MessageReceived?.Invoke(message);
                }
            }
            catch
            {
                Disconnected?.Invoke();
            }
        }

        private async Task<byte[]> ReadExactAsync(int size)
        {
            byte[] buffer = new byte[size];
            int read = 0;

            while (read < size)
            {
                int r = await _stream.ReadAsync(buffer, read, size - read);
                if (r == 0)
                    throw new Exception("Disconnected");

                read += r;
            }

            return buffer;
        }

        public void Disconnect()
        {
            _cts?.Cancel();
            _stream?.Close();
            _client?.Close();
        }
    }
}
