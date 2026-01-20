using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.src
{
    public class enums
    {
        enum request_type
        {

            NULL_REQ = 0,

            //sessions
            ADD_SESSION = 1,
            REMOVE_SESSION = 2,

            //groups
            ADD_GROUP = 3,
            CONNECT_TO_GROUP = 4,
            DISCONNECT_FROM_GROUP = 5,

            //messages
            SEND_MESSAGE = 6
        };



    }
}
