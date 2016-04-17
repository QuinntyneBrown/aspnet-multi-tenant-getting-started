namespace Chloe.Migrations
{
    using Server.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Chloe.Server.Data.ChloeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Chloe.Server.Data.ChloeContext context)
        {
            context.Tenants.AddOrUpdate(
                t => t.Host,
                new Tenant { Name = "Local Host", Host = "localhost" }
                );

            context.SaveChanges();
        }
    }
}
