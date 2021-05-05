using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEM.FACTUR.ENTITY.Response
{
    public class ResponseLogin
    {
        public string responsetoken { get; set; }
        public string response { get; set; }

        public string username { get; set; }
        public string cargo { get; set; }
        public int cantaccesos { get; set; }
    }
}
