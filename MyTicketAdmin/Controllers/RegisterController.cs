using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTicketAdmin.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult AsigRol()
        {
            return View();
        }
    }
}