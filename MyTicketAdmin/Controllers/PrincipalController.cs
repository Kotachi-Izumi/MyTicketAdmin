using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Authentication;

namespace MyTicketAdmin.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Principal()
        {
            return View();
        }

        /*public ActionResult logueo()
        {
            var conex = new ConPG();
            conex.abrirConexion();            
            return null;
        }*/
    }
}