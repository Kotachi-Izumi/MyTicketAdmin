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
        private myticketEntities mteTickets = new myticketEntities();                                                                                                                                                                                                                                                                                                                                                                                                                                        
        // GET: Tickets
        public ActionResult Index()
        {
            var oTicket = new MTicket();   
            return View(mteTickets.mt_tab_ticket);
        }
    }
}