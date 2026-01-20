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

        message parseMessage(byte[] msgBuf)
        {
            // Assuming the message format is:
            // group_id (4 bytes), sender_id (4 bytes), content_length (4 bytes), content (variable length)
            int group_id = BinaryPrimitives.ReadInt32BigEndian(msgBuf.AsSpan(0, 4));
            int sender_id = BinaryPrimitives.ReadInt32BigEndian(msgBuf.AsSpan(4, 4));
            int content_length = BinaryPrimitives.ReadInt32BigEndian(msgBuf.AsSpan(8, 4));
            string content = Encoding.UTF8.GetString(msgBuf, 12, content_length);
            return new message(group_id, sender_id, content);
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

                    int req_type = BinaryPrimitives.ReadInt32BigEndian(msgBuf.AsSpan(0, 4));

                    if (req_type == 6) // assuming 6 is the message type
                    {
                        message msg = parseMessage(msgBuf.AsSpan(4).ToArray());
                        MessageReceived?.Invoke(msg);
                    }

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
