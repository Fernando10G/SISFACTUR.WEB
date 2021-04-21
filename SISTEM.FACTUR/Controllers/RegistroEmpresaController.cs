using SISTEM.FACTUR.BUSINESS;
using SISTEM.FACTUR.ENTITY.Parametros;
using SISTEM.FACTUR.CLIENTS;
using SISTEM.FACTUR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISTEM.FACTUR.Controllers
{
    public class RegistroEmpresaController : Controller
    {
        private modelList model;
        private BUPais bupais;



        public RegistroEmpresaController()
        {
            model = new modelList();
            bupais = new BUPais();

        }
        // GET: RegistroEmpresa
        public ActionResult RegistroEmpresa(ENRegistroEmpresa paramss)
        {
            string token = "";
            model.listPais = bupais.listarPaises(paramss,token);
            model.listMoneda = bupais.listarMoneda(paramss, token);
            model.listTImpuesto = bupais.listarTImpuestos(paramss, token);
            model.listPImpuesto = bupais.listarPImpuestos(paramss, token);
          
            return View(model);
        }

       
    }
}
