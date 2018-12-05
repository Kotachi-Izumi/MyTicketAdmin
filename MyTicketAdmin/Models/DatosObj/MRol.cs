using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTicketAdmin.Models.DatosObj
{
    public class MRol
    {
        [Required]
        public int rol_cod_rol { get; set; }
        public string rol_dsc_rol { get; set; }
    }
}