//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTicketAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mt_tab_usuario
    {
        public long usuario_cod_usuario { get; set; }
        public Nullable<long> usuario_cod_estado { get; set; }
        public string usuario_cod_password { get; set; }
        public string usuario_dsc_area { get; set; }
        public Nullable<long> persona_cod_persona { get; set; }
    
        public virtual mt_tab_persona mt_tab_persona { get; set; }
    }
}
