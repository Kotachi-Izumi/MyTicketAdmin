//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTicketAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class mt_tab_direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mt_tab_direccion()
        {
            this.mt_tab_persona = new HashSet<mt_tab_persona>();
        }
    
        public long direccion_cod_direccion { get; set; }
        public string direccion_dsc_direccion { get; set; }
        public Nullable<decimal> direccion_num_direccion { get; set; }
        public Nullable<long> comuna_cod_comuna { get; set; }
    
        public virtual mt_tab_comuna mt_tab_comuna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mt_tab_persona> mt_tab_persona { get; set; }
    }
}
