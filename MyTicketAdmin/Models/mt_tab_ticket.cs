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
    
    public partial class mt_tab_ticket
    {
        public long ticket_cod_ticket { get; set; }
        public Nullable<System.DateTime> ticket_fec_creacion { get; set; }
        public Nullable<System.DateTime> ticket_fec_respuesta { get; set; }
        public Nullable<long> ticket_cod_usuaingreso { get; set; }
        public Nullable<long> ticket_cod_usuaresponde { get; set; }
        public string ticket_dsc_detalle { get; set; }
        public Nullable<bool> ticket_es_masivo { get; set; }
        public Nullable<long> ticket_cod_tipoatencion { get; set; }
        public string ticket_dsc_asunto { get; set; }
        public Nullable<long> ticket_est_ticket { get; set; }
        public Nullable<System.DateTime> ticket_fec_vencimiento { get; set; }
        public Nullable<long> ticket_cod_gravedad { get; set; }
        public Nullable<long> usuarioasig_cod_usuarioasign { get; set; }
    }
}
