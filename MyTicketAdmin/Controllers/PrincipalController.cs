using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Authentication;
using MyTicketAdmin.Models.DatosObj;

namespace MyTicketAdmin.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Principal()
        {
            var pers = new MPersona();
            return View(pers);
        }

        public ActionResult btnMail()
        {
            EnvioMail.sendMail();
              
            return null;
        }

        /*public ActionResult logueo()
        {
            var conex = new ConPG();
            conex.abrirConexion();            
            return null;
        }*/
    }
}