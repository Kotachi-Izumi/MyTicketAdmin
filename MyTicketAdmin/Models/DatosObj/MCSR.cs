using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MCSR
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
        public int codEstado { get; set; }
        public int codArea { get; set; }
        public int codUsuario { get; set; }
        public string nick { get; set; }
        public string pass { get; set; }
    }
}