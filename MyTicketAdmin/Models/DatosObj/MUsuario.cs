using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MUsuario
    {
        [Range(1,4,ErrorMessage ="El codigo de estado debe ser entre 1 y 4")]
        [Required(ErrorMessage = "Requerido.")]
        [Display(Name ="Codigo estado")]
        public int codEstado { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [Display(Name ="Codigo area")]
        public int codArea { get; set; }
        public int codUsuario { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [Display(Name ="Codigo persona")]
        public int codPersona { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [StringLength(50,ErrorMessage ="Largo 50 maximo")]
        [Display(Name ="Nickname")]
        public string nick { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [StringLength(50, ErrorMessage = "Largo 50 maximo")]
        [Display(Name = "Password")]
        public string pass { get; set; }

        public string tokenUsuario { get; set; }
    }
}