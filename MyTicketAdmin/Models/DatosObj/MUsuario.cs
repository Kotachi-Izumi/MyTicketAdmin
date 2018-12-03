using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MUsuario
    {
        public int codEstado { get; set; }
        public int codArea { get; set; }
        public int codUsuario { get; set; }
        public int codPersona { get; set; }
        public string nick { get; set; }
        public string pass { get; set; }
        public string tokenUsuario { get; set; }
    }
}