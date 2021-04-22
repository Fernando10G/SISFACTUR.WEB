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
    public class BURegistroEmpresa
    {
        private Client clients;

        public BURegistroEmpresa()
        {
            clients = new Client();
        }
        public ResponseRegistroEmpresa validarRegistro(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(clients.Post<ENRegistroEmpresa>("RegistroEmpresa/validarRegistro", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
