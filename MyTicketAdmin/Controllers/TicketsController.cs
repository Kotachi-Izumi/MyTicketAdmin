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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult guardarTicket(MTicket tick)
        {
            if (ModelState.IsValid)
            {
                ConPG.ingresarTicket(tick);
                return View("~\\Views\\Tickets\\Index.cshtml");
            }
            return View("~\\Views\\Tickets\\nuevoTicket.cshtml",tick);

        }
        
        
        public ActionResult editarTicket(int? id)
        {
            if (id == null || id.Equals(string.Empty))
            {
                return View("~\\Views\\Tickets\\Index.cshtml");
            }
            var tickets = bd.mt_tab_ticket.Find(id);
            if(tickets == null)
            {
                return View("~\\Views\\Tickets\\Index.cshtml");
            }
            var TICK = ConPG.editTicket(tickets);
            return View(TICK);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editarTicket(MTicket tickets)
        {
            if (ModelState.IsValid)
            {
                var pg = new ConPG();
                if (pg.updateTicket(tickets) > 0)
                {
                    return View("~\\Views\\Tickets\\Index.cshtml");
                }
            }
            
            /*var ticket = ConPG.editTicket(tickets);
            var tick = bd.mt_tab_ticket.Find(tickets.codTicket);
            tick = ticket;
            if (ModelState.IsValid)
            {
                //bd.Entry(tick).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
                return View("~\\Views\\Tickets\\Index.cshtml");
            }*/
            return View();
        }
        
    }
}