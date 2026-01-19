using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public static class client_manager
    {
        private static int _id;

        public static int GetID()
        {
            return _id;
        }

        public static void SetID(int id)
        {
            _id = id;
        }
    }
}
