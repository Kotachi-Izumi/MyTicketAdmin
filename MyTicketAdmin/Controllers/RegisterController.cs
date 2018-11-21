﻿using MyTicketAdmin.Models.DatosObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTicketAdmin.Controllers
{
    public class RegisterController : Controller
    {
        private myticketEntities myTicket = new myticketEntities();
        // GET: Register
        public ActionResult Registro()
        {
            return View("~\\Views\\Register\\Registro.cshtml",myTicket.mt_tab_usuario.ToList());
        }

        public ActionResult AsigRol()
        {
            return View("~\\Views\\Register\\AsigRol.cshtml");
        }

        public ActionResult PruebaIngreso()
        {
            var pg = new ConPG();

            var per = new MPersona();
            var dir = new MDireccion();
                pg.ingresarPersona(per, dir);
            
            return null;
        }
    }
}