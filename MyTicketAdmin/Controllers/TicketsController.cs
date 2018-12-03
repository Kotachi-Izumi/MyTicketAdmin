using MyTicketAdmin.Models.DatosObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTicketAdmin.Controllers
{
    public class TicketsController : Controller
    {                        
        private myticketEntities bd = new myticketEntities();
        // GET: Tickets
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string busqIdCliente)
        {
            if(busqIdCliente != null) {
                var id = Convert.ToInt32(busqIdCliente);
                var cliente = new MCliente();
                cliente = ConPG.buscarCliente(id);
                return View(cliente);
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult nuevoTicket()
        {          
                return View();            
        }
        public ActionResult guardarTicket(MTicket tick)
        {
            ConPG.ingresarTicket(tick);
            return View("~\\Views\\Tickets\\Index.cshtml");
        }
        public ActionResult editarTicket(string id)
        {
            if (id == null || id == "")
            {
                return View("~\\Views\\Tickets\\Index.cshtml");
            }
            var tickets = bd.mt_tab_ticket.Find(id);
            if(tickets == null)
            {
                return View("~\\Views\\Tickets\\Index.cshtml");
            }

            return View(tickets);
            
        }
    }
}