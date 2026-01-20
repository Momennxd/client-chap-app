using client.src.entities;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace client.src.socket
{
    public class network_layer
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private CancellationTokenSource _cts;

        //respose actions
        public event Action<message> MessageReceived;
        public event Action Disconnected;


        public network_layer()
        {
            _cts = new CancellationTokenSource();
            _client = new TcpClient();
           
        }

        private async Task<int> _ReceiveIDAsync()
        {
            byte[] idBuf = await ReadExactAsync(4);
            int id = BinaryPrimitives.ReadInt32BigEndian(idBuf);
            return id;
        }

        private async Task _ReadLoopAsync()
        {
            try
            {
                while (!_cts.IsCancellationRequested)
                {
                    byte[] lenBuf = await ReadExactAsync(4);
                    int length = BinaryPrimitives.ReadInt32BigEndian(lenBuf);

                    byte[] msgBuf = await ReadExactAsync(length);


                    //next step: parse the message
                    // Pass the raw byte array to the parser



                }
            }
            catch
            {
                Disconnected?.Invoke();
            }
        }






















        public async Task<byte[]> ReadExactAsync(int size)
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


        public async Task SendAsync(IEnumerable<byte> bytes)
        {
            if (_stream == null) return;

            byte[] data = bytes.ToArray();  

            byte[] length = new byte[4];
            BinaryPrimitives.WriteInt32BigEndian(length, data.Length);

            await _stream.WriteAsync(length);
            await _stream.WriteAsync(data);
        }


        public async Task ConnectAsync(string host, int port)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(host, port);

            _stream = _client.GetStream();
            _cts = new CancellationTokenSource();

            int id = await _ReceiveIDAsync();
            client_manager.SetID(id);

            _ = Task.Run(_ReadLoopAsync);
        }

        public void Disconnect()
        {
            _cts?.Cancel();
            _stream?.Close();
            _client?.Close();
        }
  
    }
}
