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



        public ResponseRegistroEmpresa insertarEmpresa(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(clients.Post<ENRegistroEmpresa>("RegistroEmpresa/insertarEmpresa", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public ResponseRegistroEmpresa insertarUserAdminEmpresa(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(clients.Post<ENRegistroEmpresa>("RegistroEmpresa/insertarUserAdminEmpresa", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ResponseRegistroEmpresa activarCuenta(string ruc, string token)
        {
            try
            {
                return clients.Get<ResponseRegistroEmpresa>(string.Format("RegistroEmpresa/activarCuenta?ruc={0}", ruc, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
