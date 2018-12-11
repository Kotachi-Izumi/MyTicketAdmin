using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MTicket
    {

        public int codTicket { get; set; }
        public int codUsuarioIngreso { get; set; }
        public int codUsuarioResponde { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [Display(Name ="Codigo de gravedad")]
        public int codGravedad { get; set; }
        [Display(Name = "Codigo tipo atencion")]
        [Required(ErrorMessage = "Requerido.")]
        public int codTipoAtencion { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [Display(Name = "Codigo estado ticket")]
        public int codEstadoTicket { get; set; }
        public int codUsuarioAsignado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaRespuesta { get; set; }
        public DateTime fechaVencimiento { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [Display(Name = "Detalle ticket")]
        public string detalleTicket { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [Display(Name = "Descripcion asunto")]
        public string descAsunto { get; set; }
        public bool esMasivo { get; set; }
        public long codPersona { get; set; }

    }
}