using SISTEM.FACTUR.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISTEM.FACTUR.Models
{
    public class modelList
    {
        public List<ResponsePais> listPais { get; set; }
        public List<ResponseMoneda> listMoneda { get; set; }
        public List<ResponseTImpuestos> listTImpuesto { get; set; }
        public List<ResponsePImpuestos> listPImpuesto { get; set; }
    }
}