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
        [Display(Name = "Codigo de rol")]
        public int codRol { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [Display(Name = "Codigo de usuario")]
        public int codUsuario { get; set; }
        public int codRolUsua { get; set; }
        public DateTime fechaInicio { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [Display(Name ="Fecha fin")]
        public DateTime fechaFin { get; set; }
    }
}