using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTicketAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult btnEnviar()
        {
            ConPG con = new ConPG();
            con.abrirConexion();
            con.agregar();
            con.cerrarConexion();
            return null;       
        }
    }
}