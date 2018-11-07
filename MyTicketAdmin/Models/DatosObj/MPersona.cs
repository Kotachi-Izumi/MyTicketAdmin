using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MPersona
    {
        public string nombre { get; set; }
        public string AppPaterno { get; set; }
        public string AppMaterno { get; set; }
        public string Fono { get; set; }
        public string Celular { get; set; }
        public string Mail { get; set; }
        public DateTime Fnac { get; set; }
        public int Rut { get; set; }
        public string DV { get; set; }
        public int CodPersona { get; set; }
        public int CodDireccion { get; set; }
    }
}