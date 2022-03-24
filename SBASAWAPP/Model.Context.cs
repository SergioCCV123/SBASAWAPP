﻿namespace SBASAWAPP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
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
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTS { get; set; }
        public virtual DbSet<CATEGORIES> CATEGORIES { get; set; }
        public virtual DbSet<SALES> SALES { get; set; }
        public virtual DbSet<PRODUCTSPS> PRODUCTSPS { get; set; }
        public virtual DbSet<FACTURA> FACTURA { get; set; }
        public virtual DbSet<INSTALADOR> INSTALADOR { get; set; }
        public virtual DbSet<SHOPP_CART> SHOPP_CART { get; set; }
    }
}
