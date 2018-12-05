using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MPersona
    {
        [Required(ErrorMessage = "Debe introducir un nombre.")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Debe introducir un apellido.")]
        public string AppPaterno { get; set; }
        public string AppMaterno { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Fono { get; set; }
        [Required(ErrorMessage = "Debe Introducir un telefono")]
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Debe introducir un mail valido.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Debe introducir una fecha valida.")]
        [DataType(DataType.Date)]
        public DateTime Fnac { get; set; }
        [Required(ErrorMessage = "Debe introducir un rut valido.")]
        [Range(1,99999999)]
        public int Rut { get; set; }
        [Required(ErrorMessage = "Debe introducir un DV valido.")]
        [StringLength(1)]
        public string DV { get; set; }
        public int CodPersona { get; set; }
        public int CodDireccion { get; set; }
    }
}