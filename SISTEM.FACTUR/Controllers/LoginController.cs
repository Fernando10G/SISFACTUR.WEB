using SISTEM.FACTUR.BUSINESS;
using SISTEM.FACTUR.ENTITY.Encrypt;
using SISTEM.FACTUR.ENTITY.Parametros;
using SISTEM.FACTUR.ENTITY.Response;
using SISTEM.FACTUR.WEB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISTEM.FACTUR.Controllers
{
    public class LoginController : Controller
    {
        private BULogin bulogin;

        public LoginController()
        {

            bulogin = new BULogin();
        }
        [HttpPost]
        public ActionResult Acceder(ENLogin paramss)
        {
            var clave = Encrypt.GetSHA256(paramss.pass);
            paramss.pass = clave;
            var rpt = bulogin.Acceder(paramss);
            Session.Set(GlobalKey.CurrentUser, rpt);
            SetCurrentUser(rpt);
            return Json(new { dt = rpt });
        }
        protected void SetCurrentUser(ResponseLogin login)
        {
            Session["Username"] = login;
        }
    }
}
