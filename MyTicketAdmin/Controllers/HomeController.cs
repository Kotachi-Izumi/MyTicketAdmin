﻿using MyTicketAdmin.Models.DatosObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            var per = new MPersona();
            var dir = new MDireccion();
            

            var user = Request.Form["inUsuario"].ToString();
            var pass = Request.Form["inpPass"].ToString();
            var con = new ConPG();
            var rol = ConPG.rolUsuario(ConPG.autenticar(user, pass));
            //con.ingresarPersona(per, dir);
            if (rol == 1)
            {
                //FormsAuthentication.RedirectFromLoginPage(user, false)
                return View("~\\Views\\Principal\\Principal.cshtml");

            }else
            {
                if (rol == 3 || rol == 4)
                {
                    return View("~\\Views\\Tickets\\Index.cshtml");
                }
                else
                {
                    return View("~\\Views\\Home\\Index.cshtml");
                }
            }
                   
        }

        public ActionResult linkRegistro()
        {
            return View("Registro.cshtml");
        }
    }
}