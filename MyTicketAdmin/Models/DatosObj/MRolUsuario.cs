using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MRolUsuario
    {
        [Required(ErrorMessage = "Requerido.")]
        public int codRol { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        public int codUsuario { get; set; }
        public int codRolUsua { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
    }
}