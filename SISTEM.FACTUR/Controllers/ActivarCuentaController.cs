using SISTEM.FACTUR.BUSINESS;
using SISTEM.FACTUR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISTEM.FACTUR.Controllers
{
    public class ActivarCuentaController : Controller
    {
        private modelList model;
            private  BURegistroEmpresa buregistroempresa;
        public ActivarCuentaController()
        {

            model = new modelList();
            buregistroempresa = new BURegistroEmpresa();
        }
        public ActionResult ActivarCuenta(string ruc)
        {
            string token = "";
            model.msjActivarCuenta = buregistroempresa.activarCuenta(ruc, token);
            return View(model);
        }

      
    }
}
