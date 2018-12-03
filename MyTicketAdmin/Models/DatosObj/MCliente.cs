using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MCliente
    {
        public int codPersona { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public DateTime fNac { get; set; }
        public int rut { get; set; }
        public string dv { get; set; }
        public string email { get; set; }
        public string fono { get; set; }
        public string cel { get; set; }
        public string nombre { get; set; }
        public string descCasa { get; set; }
        public int numCasa { get; set; }
        public string comuna { get; set; }
        public string region { get; set; }
    }
}