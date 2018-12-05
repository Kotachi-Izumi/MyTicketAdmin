using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MUsuario
    {
        [Required(ErrorMessage = "Requerido.")]
        public int codEstado { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        public int codArea { get; set; }
        public int codUsuario { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        public int codPersona { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        public string nick { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        public string pass { get; set; }

        public string tokenUsuario { get; set; }
    }
}