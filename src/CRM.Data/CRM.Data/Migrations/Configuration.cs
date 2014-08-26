using System.IO;

namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRM.Data.DbContexts.CRMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
      
        protected override void Seed(CRM.Data.DbContexts.CRMContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

          var sqlfiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory+"\\..\\..\\..\\", "*.sql");
          sqlfiles.ToList().ForEach(x=> context.Database.ExecuteSqlCommand(File.ReadAllText(x)));
          
        }
    }
}
