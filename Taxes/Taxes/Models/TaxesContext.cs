using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Taxes.Models
{
    public class TaxesContext : DbContext
    {
        public TaxesContext() : base("DefaultConnection")
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //desactivar borrado en cascada
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<PropertyType> PropertyTypes { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Municipality> Municipalities { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<TaxPaer> TaxPaers { get; set; }

        public DbSet<Property> Properties { get; set; }
    }
}