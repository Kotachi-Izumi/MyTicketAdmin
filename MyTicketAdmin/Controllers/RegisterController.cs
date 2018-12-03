using MyTicketAdmin.Models.DatosObj;
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
        private string nomComuna;
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View("~\\Views\\Register\\Registro.cshtml",myTicket.mt_tab_usuario.ToList());
        }

        public ActionResult AsigRol()
        {
            return View("~\\Views\\Register\\AsigRol.cshtml");
        }
        [HttpPost]
        public ActionResult guardarPersona(MPersona per)
        {
            
            per.CodDireccion = ConPG.codDireccion();
            ConPG.ingresarPersona(per);
            return View("~\\Views\\Principal\\Principal.cshtml");
        }
        [HttpGet]
        public ActionResult IngresoPersona()
        {
            var Mper = new MPersona();
            return View("~\\Views\\Register\\IngresoPersona.cshtml",Mper);
        }
        [HttpGet]
        public ActionResult IngresoDireccion()
        {
            var dir1 = new MDireccion();
            return PartialView("~\\Views\\Register\\IngresoDireccion.cshtml",dir1);
        }
        [HttpPost]
        public ActionResult guardarDireccion(MDireccion dir)
        {
            nomComuna = Request.Form["comunas"].ToString();
            dir.CodComuna = ConPG.codComuna(nomComuna);
            ConPG.ingresarDireccion(dir);
            return View("~\\Views\\Principal\\Principal.cshtml");
        }

        [HttpGet]
        public ActionResult IngresoUsuario()
        {
            var usuario = new MUsuario();
            return PartialView(usuario);
        }
        [HttpPost]
        public ActionResult guardarUsuario(MUsuario user)
        {
            if(user != null)
            {
                ConPG.ingresarUsuario(user);
                return View("~\\Views\\Register\\Index.cshtml");
            }
            else
            {
                return PartialView("~\\Views\\Register\\IngresoUsuario.cshtml");
            }
            
        }

        [HttpGet]
        public ActionResult IngresoRolUsua()
        {
            var mRolUsua = new MRolUsuario();
            return PartialView(mRolUsua);
        }
        [HttpPost]
        public ActionResult asignarRol(MRolUsuario rolUsu)
        {
            if(rolUsu != null)
            {
                ConPG.ingresarRolUsua(rolUsu);
            }
            return View("~\\Views\\Register\\Index.cshtml");
        }
        
    }
}