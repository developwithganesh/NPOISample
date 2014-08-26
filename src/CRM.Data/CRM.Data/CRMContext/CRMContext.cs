using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CRM.Data.Entities;

namespace CRM.Data.DbContexts
{
  public class CRMContext:DbContext
  {
    public CRMContext():base("CRMContext")
    {
     // Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["CRMContext"].ConnectionString;

      //var conf = new DropCreateDatabaseAlways<CRMContext>();
      //Database.SetInitializer(conf);

     // Debug.WriteLine(this.Database.Connection.ConnectionString);
    }

    public DbSet<City> Cities { get; set; } 
    public DbSet<CustomFieldValue> CustomFieldValues { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      Database.SetInitializer(
      new MigrateDatabaseToLatestVersion<CRMContext,
        CRM.Data.Migrations.Configuration>());

      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<CustomFieldValue>().ToTable("CustomFieldValue");
      modelBuilder.Entity<CustomFieldValue>().Property(x => x.ValueDateTime).HasColumnType("datetime2");
      modelBuilder.Entity<CustomFieldValue>().Property(x => x.CreatedAt).HasColumnType("datetime2");
      modelBuilder.Entity<CustomFieldValue>().Property(x => x.UpdatedAt).HasColumnType("datetime2");
      modelBuilder.Entity<CustomFieldValue>().Property(x => x.DeletedAt).HasColumnType("datetime2");


    }
  }
}
