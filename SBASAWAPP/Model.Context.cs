﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBASAWAPP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class example5_SBASAWAPPEntities : DbContext
    {
        public example5_SBASAWAPPEntities()
            : base("name=example5_SBASAWAPPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CATEGORIES> CATEGORIES { get; set; }
        public virtual DbSet<FACTURA> FACTURA { get; set; }
        public virtual DbSet<HISTORY> HISTORY { get; set; }
        public virtual DbSet<INSTALADOR> INSTALADOR { get; set; }
        public virtual DbSet<PRODUCTS> PRODUCTS { get; set; }
        public virtual DbSet<SALES> SALES { get; set; }
        public virtual DbSet<PRODUCTSPS> PRODUCTSPS { get; set; }
        public virtual DbSet<SHOPP_CART> SHOPP_CART { get; set; }
        public virtual DbSet<CONTACTO> CONTACTO { get; set; }
    
        public virtual ObjectResult<STATS_Result> STATS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<STATS_Result>("STATS");
        }
    }
}
