﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wcf_fullcarwash
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class fullcarwashEntities : DbContext
    {
        public fullcarwashEntities()
            : base("name=fullcarwashEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<TypeCars> TypeCars { get; set; }
        public virtual DbSet<DetailReservation> DetailReservation { get; set; }
    
        public virtual ObjectResult<SP_SELECT_CUSTOMERS_Result> SP_SELECT_CUSTOMERS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SELECT_CUSTOMERS_Result>("SP_SELECT_CUSTOMERS");
        }
    
        public virtual ObjectResult<SP_SELECT_LOCALS_Result> SP_SELECT_LOCALS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SELECT_LOCALS_Result>("SP_SELECT_LOCALS");
        }
    
        public virtual ObjectResult<SP_SELECT_EMPLOYEES_Result> SP_SELECT_EMPLOYEES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SELECT_EMPLOYEES_Result>("SP_SELECT_EMPLOYEES");
        }
    
        public virtual ObjectResult<SP_SELECT_SERVICES_Result> SP_SELECT_SERVICES()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SELECT_SERVICES_Result>("SP_SELECT_SERVICES");
        }
    
        public virtual ObjectResult<SP_SELECT_DETAILRESERVATION_Result> SP_SELECT_DETAILRESERVATION()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SELECT_DETAILRESERVATION_Result>("SP_SELECT_DETAILRESERVATION");
        }
    
        public virtual ObjectResult<SP_SELECT_RESERVATION_Result> SP_SELECT_RESERVATION()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SELECT_RESERVATION_Result>("SP_SELECT_RESERVATION");
        }
    
        public virtual ObjectResult<SP_SELECT_TYPECARS_Result> SP_SELECT_TYPECARS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_SELECT_TYPECARS_Result>("SP_SELECT_TYPECARS");
        }
    }
}
