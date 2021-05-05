using Newtonsoft.Json;
using SISTEM.FACTUR.CLIENTS;
using SISTEM.FACTUR.ENTITY.Parametros;
using SISTEM.FACTUR.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEM.FACTUR.BUSINESS
{
    public class BULogin
    {
        private Client clients;
        public BULogin()
        {
            clients = new Client();
        }

        public ResponseLogin Acceder(ENLogin paramss)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseLogin>(clients.Post<ENLogin>("Login/Acceder", paramss));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
