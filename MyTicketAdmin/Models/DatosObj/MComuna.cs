using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MComuna
    {
        public int comuna_cod_comuna { get; set; }
        public string comuna_nom_comuna { get; set; }
        public string comuna_ciudad_comuna { get; set; }
        public int comuna_cod_region { get; set; }
        public DateTime comuna_fecha_vigencia { get; set; }
        public DateTime comuna_fin_vigencia { get; set; }
    }
}