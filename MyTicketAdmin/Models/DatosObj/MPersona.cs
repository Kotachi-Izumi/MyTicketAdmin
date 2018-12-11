using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MPersona
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Debe introducir un nombre.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Debe introducir un apellido.")]
        [StringLength(50)]
        [Display(Name = "Apellido paterno")]
        public string AppPaterno { get; set; }
        [StringLength(50)]
        [Display(Name = "Apellido materno")]
        public string AppMaterno { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(50)]
        [Display(Name = "Telefono fijo")]
        public string Fono { get; set; }
        [Required(ErrorMessage = "Debe Introducir un telefono")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(50)]
        [Display(Name = "Celular")]
        public string Celular { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Debe introducir un mail valido.")]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Debe introducir una fecha valida.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime Fnac { get; set; }
        [Required(ErrorMessage = "Debe introducir un rut valido.")]
        [Range(1,99999999)]
        [Display(Name = "Rut")]
        public int Rut { get; set; }
        [Required(ErrorMessage = "Debe introducir un DV valido.")]
        [StringLength(1)]
        [Display(Name = "Digito verificador")]
        public string DV { get; set; }
        public int CodPersona { get; set; }
        public int CodDireccion { get; set; }
    }
}