using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MDireccion
    {
        public int CodDireccion { get; set; }
        public int CodComuna { get; set; }
        public int NumCasa { get; set; }
        public string DescCasa { get; set; }
    }
}