using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using IceCreamApp.Models;
using IceCreamShop.Entities;

namespace IceCreamApp.DataAccess
{
    public class MigrationsContextFactory : IDbContextFactory<IceCreamDbContext>
    {
        private readonly IAppConfiguration configurationRoot;

        public MigrationsContextFactory()
        {
            this.configurationRoot = new AppConfiguration();
        }
        public IceCreamDbContext Create()
        {
            return new IceCreamDbContext(configurationRoot);
        }
    }

    public class IceCreamDbContext : DbContext
    {
        private IAppConfiguration _config;

//        public IceCreamDbContext()
//        {
//
//        }
        public IceCreamDbContext(IAppConfiguration configurationRoot) : base(configurationRoot.DefaultConnectionString)
        {
            _config = configurationRoot; 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // configures one-to-many relationship
//            modelBuilder.Entity<IceCream>()
//                .HasRequired<Store>(s => s.Store)
//                .WithMany(g => g.IceCreams)
//                .HasForeignKey<long>(s => s.StoreId);

      

            modelBuilder.Entity<Store>()
                .HasMany<IceCream>(s => s.IceCreams)
                .WithMany(c => c.Stores)
                .Map(cs =>
                {
                    cs.MapLeftKey("StoreRefId");
                    cs.MapRightKey("IceCreamRefId");
                    cs.ToTable("StoreIceCreams");
                });



            //            modelBuilder.Entity<IceCream>().Ignore(p => p.Stores);
            //            modelBuilder.Entity<Store>().Ignore(p => p.InStockItems); 


            //modelBuilder.Entity<Store>()
            //            .HasMany<IceCream>(s => s.InStockItems)
            //            .WithMany(c => c.)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("StoreId");
            //                cs.MapRightKey("IceCreamId");
            //                cs.ToTable("StoreIceCream");
            //            }); 

        }

         
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Country> Countries { get; set; }
         
        public DbSet<IceCream> IceCreams { get; set; } 

        public DbSet<State> States { get; set; }

        public DbSet<Store> Stores { get; set; }
    } 

}