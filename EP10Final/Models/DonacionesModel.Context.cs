﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EP10Final.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DonacionesEntities : DbContext
    {
        public DonacionesEntities()
            : base("name=DonacionesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<calculos> calculos { get; set; }
        public virtual DbSet<continente> continente { get; set; }
        public virtual DbSet<donadores> donadores { get; set; }
        public virtual DbSet<gasto> gasto { get; set; }
        public virtual DbSet<gasto1> gasto1 { get; set; }
        public virtual DbSet<gasto2> gasto2 { get; set; }
        public virtual DbSet<pais> pais { get; set; }
        public virtual DbSet<porcentajes> porcentajes { get; set; }
        public virtual DbSet<productos> productos { get; set; }
    }
}
