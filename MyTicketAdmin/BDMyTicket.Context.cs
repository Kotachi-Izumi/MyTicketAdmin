﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class myticketEntities : DbContext
    {
        public myticketEntities()
            : base("name=myticketEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<mt_tab_ticket> mt_tab_ticket { get; set; }
        public virtual DbSet<prueba> prueba { get; set; }
        public virtual DbSet<mt_tab_comuna> mt_tab_comuna { get; set; }
        public virtual DbSet<mt_tab_direccion> mt_tab_direccion { get; set; }
        public virtual DbSet<mt_tab_persona> mt_tab_persona { get; set; }
        public virtual DbSet<mt_tab_region> mt_tab_region { get; set; }
        public virtual DbSet<mt_tab_rol> mt_tab_rol { get; set; }
        public virtual DbSet<mt_tab_rolusua> mt_tab_rolusua { get; set; }
        public virtual DbSet<mt_tab_usuario> mt_tab_usuario { get; set; }
    }
}
