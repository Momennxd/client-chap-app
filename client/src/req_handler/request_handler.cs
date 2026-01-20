using client.src.entities;
using client.src.socket;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.src.req_handler
{
    /// <summary>
    /// prototype of a request handler class
    /// </summary>
    public class request_handler
    {

        public network_layer _network_Layer = new network_layer();

        public async Task<int> SendMessageAsync(message msg)
        {
            try
            {


                //req_type, group_id,  sender_session_id,  text size,   text bytes
                byte[] reqBytes = new byte[4 + 4 + 4 + 4 + msg.content.Length];

                BIT.WriteInt32BE(reqBytes, 0, 6);
                BIT.WriteInt32BE(reqBytes, 4, msg.group_id);
                BIT.WriteInt32BE(reqBytes, 8, client_manager.GetID());
                BIT.WriteInt32BE(reqBytes, 12, msg.content.Length);
                int offset = 12 + 4;
                for (int i = 0; i < msg.content.Length && i + offset < reqBytes.Length; ++i)
                {
                    reqBytes[i + offset] = (byte)(msg.content[i]);
                }

                await _network_Layer.SendAsync(reqBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in SendMessage: " + ex.Message);
                return -1;
            }
            return 1;
        }


        public async Task<int> ConnectToGroupAsync(int groupID)
        {
            //request format:
            // req_type, session_id , group_id

            try
            {


                byte[] reqBytes = new byte[12];

                BIT.WriteInt32BE(reqBytes, 0, 4);
                BIT.WriteInt32BE(reqBytes, 4, client_manager.GetID());
                BIT.WriteInt32BE(reqBytes, 8, groupID);

                await _network_Layer.SendAsync(reqBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in ConnectToGroupAsync: " + ex.Message);
                return -1;
            }
            return 1;
        }
    }
}
