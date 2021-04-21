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
   public class BUPais
    {
        private Client client;
        public BUPais()
        {
            client = new Client();
        }
        public List<ResponsePais> listarPaises(ENRegistroEmpresa paramss,string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePais>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarPaises", paramss, token));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public List<ResponseMoneda> listarMoneda(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseMoneda>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarMoneda", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ResponseTImpuestos> listarTImpuestos(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseTImpuestos>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarTImpuestos", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<ResponsePImpuestos> listarPImpuestos(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePImpuestos>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarPImpuestos", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
