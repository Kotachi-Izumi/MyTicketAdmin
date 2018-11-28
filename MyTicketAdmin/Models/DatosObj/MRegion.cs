using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MRegion
    {
        public int region_cod_region { get; set; }
        public string region_dsc_region { get; set; }
        public DateTime region_fecha_vigencia { get; set; }
        public DateTime region_fin_vigencia { get; set; }
    }
}