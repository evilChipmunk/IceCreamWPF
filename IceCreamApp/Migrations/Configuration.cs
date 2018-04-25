using IceCreamShop.Repositories;

namespace IceCreamApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IceCreamApp.DataAccess.IceCreamDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IceCreamApp.DataAccess.IceCreamDbContext context)
        {
            DataSeeder seeder = new DataSeeder();
            seeder.EnsureSeedData(context).GetAwaiter().GetResult();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
