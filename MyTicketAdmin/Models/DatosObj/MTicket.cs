using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MTicket
    {
        public int codTicket { get; set; }
        public int codUsuarioIngreso { get; set; }
        public int codUsuarioResponde { get; set; }
        public int codGravedad { get; set; }
        public int codTipoAtencion { get; set; }
        public int codEstadoTicket { get; set; }
        public int codUsuarioAsignado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaRespuesta { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string detalleTicket { get; set; }
        public string descAsunto { get; set; }
        public bool esMasivo { get; set; }

    }
}