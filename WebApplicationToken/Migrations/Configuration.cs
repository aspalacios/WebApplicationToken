namespace WebApplicationToken.Migrations
{
    using System.Data.Entity.Migrations;
    using WebApplicationToken.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplicationToken.Models.WebApplicationTokenContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplicationToken.Models.WebApplicationTokenContext context)
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
            context.Pais.AddOrUpdate(x => x.Id,
                new Pais { Nombre = "España", Habitantes = 46000000 },
                new Pais { Nombre = "Alemania", Habitantes = 83000000 },
                new Pais { Nombre = "Francia", Habitantes = 65000000 },
                new Pais { Nombre = "Italia", Habitantes = 61000000 }
            );
        }
    }
}
