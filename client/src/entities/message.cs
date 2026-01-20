using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.src.entities
{
    public class message
    {
        public int group_id { get; set; }

        public int sender_id { get; set; }

        public string content { get; set; }


        public message(int group_id, int sender_id, string content)
        {
            this.group_id = group_id;
            this.sender_id = sender_id;
            this.content = content;
        }


    }
}
