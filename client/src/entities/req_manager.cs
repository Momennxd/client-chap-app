using client.src.req_handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.src.entities
{
    public static class req_manager
    {
        private static request_handler _rh = new();

        public static void setRequestHandler(request_handler rh)
        {
            _rh = rh;
        }

        public static request_handler getRequestHandler()
        {
            return _rh;
        }
    }
}
