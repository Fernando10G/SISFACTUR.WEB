using SISTEM.FACTUR.BUSINESS;
using SISTEM.FACTUR.ENTITY.Parametros;
using SISTEM.FACTUR.CLIENTS;
using SISTEM.FACTUR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISTEM.FACTUR.ENTITY.Encrypt;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace SISTEM.FACTUR.Controllers
{
    public class RegistroEmpresaController : Controller
    {
        private modelList model;
        private BUPais bupais;
        private BURegistroEmpresa buregistroempresa;



        public RegistroEmpresaController()
        {
            model = new modelList();
            bupais = new BUPais();
            buregistroempresa = new BURegistroEmpresa();

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


      
        [HttpPost]
        public ActionResult validarRegistro(ENRegistroEmpresa paramss)
        {
            string token = "";
            var rpt = buregistroempresa.validarRegistro(paramss, token);
            return Json(new { dt = rpt });
        }


        [HttpPost]
        public ActionResult insertarEmpresa(HttpPostedFileBase file, string razonsocial, string ruc, string email, int idpais, int idmoneda,
                                            string direccion, int idimpuesto, int idporcentaje, int vendeimpuesto, string username,
                                             string usuario, string contraseña)
        {
            try
            {

                var clave = Encrypt.GetSHA256(contraseña);
                var filename = "";
                if (file != null)
                {
                    string path = Server.MapPath("~/Content/img/img_empresas/" + ruc + "/");
                    string filePath = string.Empty;

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName(file.FileName);
                    file.SaveAs(filePath);
                    filename = file.FileName;
                }

                var paramss = new ENRegistroEmpresa();

                paramss.razonsocial = razonsocial;
                paramss.ruc = ruc;
                paramss.email = email;
                paramss.idpais = idpais;
                paramss.idmoneda = idmoneda;
                paramss.direccion = direccion;
                paramss.idimpuesto = idimpuesto;
                paramss.idporcentaje = idporcentaje;
                paramss.vendeimpuestos = vendeimpuesto;
                paramss.username = username;
                paramss.usuario = usuario;
                paramss.contraseña = clave;
                paramss.cantuser = 1;
                paramss.cargo = "superadmin";
                paramss.filename = filename;
                paramss.proyecto = "FACTUR";

                string token = "";
                var rpt = buregistroempresa.insertarEmpresa(paramss, token);

                if (rpt.response == "ok")
                {

                    rpt = buregistroempresa.insertarUserAdminEmpresa(paramss, token);
                    if (rpt.response == "ok")
                    {
                        string url = string.Format("https://localhost:44303/ActivarCuenta/ActivarCuenta?ruc=" + ruc);
                        string para = email;
                        string asunto = "Activación de cuenta | Sistema de facturación e inventario";
                        string mensaje = "<b> GRACIAS POR REGISTRARSE</b>" + "</br></br>" + "Estas son tus credencialesde acceso" +
                                            "</br></br>" + "Usuario:" + usuario + "</br></br>" +
                                            "Usuario:" + usuario + "</br>" +
                                            "Contraseña:" + contraseña + "</br>" +
                                            "Cargo:" + paramss.cargo + "</br></br>" +
                                            "Para poder acceder al sistema debe primero activar la cuenta. Activela <a href=\"" + url + "\"> aqui </a>" + "</br></br>" +
                                            "Recuerde esto es un periodo de prueba por 15 dias, Para obtener una licencia escribenos al correo ventas@gn.com";
                        MailMessage correo = new MailMessage();
                        correo.From = new MailAddress("fer.core1096@gmail.com");
                        correo.To.Add(para);
                        correo.Subject = asunto;
                        correo.Body = mensaje;
                        correo.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com"); //cambiar
                        string sCuentaCorreo = "fer.core1096@gmail.com";
                        string sPassword = "FERNANDOgranados1";
                        NetworkCredential credential = new NetworkCredential(sCuentaCorreo, sPassword);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = credential;
                        smtp.Port = 587;
                        smtp.EnableSsl = false;
                        smtp.Send(correo);

                        return Json(new { dt = rpt });
                    }


                    else
                    {
                        return Json(new { dt = rpt });

                    }
                }

                else
                {

                    return Json(new { dt = rpt });

                }




            }


            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
