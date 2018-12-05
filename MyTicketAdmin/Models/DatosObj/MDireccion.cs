using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MDireccion
    {
        public int CodDireccion { get; set; }
        public int CodComuna { get; set; }
        [Required(ErrorMessage = "Debe introducir un numero valido.")]
        [Range(0,99999)]
        public int NumCasa { get; set; }
        [Required]
        [StringLength(maximumLength:200, ErrorMessage ="Maximo caracteres alcanzado.")]
        public string DescCasa { get; set; }
    }
}