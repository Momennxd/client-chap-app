using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.src
{
    public class BIT
    {
        public static void WriteInt32BE(byte[] buffer, int offset, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            Buffer.BlockCopy(bytes, 0, buffer, offset, 4);
        }

    }
}
