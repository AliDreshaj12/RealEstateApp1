using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Configurations;
using RealEstateApp.Entities;
using static RealEstateApp.Configurations.PronaConfiguration;

namespace RealEstateApp.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Prona> Pronas { get; set; }
        public DbSet<Shtepia> Shtepiat { get; set; }
        public DbSet<Toka> Tokat { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Kontrata> Kontrata { get; set; }
        public DbSet<Rent> Rents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PronaConfigurations());

            builder.ApplyConfiguration(new ShtepiaConfigurations());

            builder.ApplyConfiguration(new TokaConfigurations());

            builder.ApplyConfiguration(new ApartmentsConfigurations());

            builder.ApplyConfiguration(new SellConfigurations());

            builder.ApplyConfiguration(new kontrataConfigurations());

            builder.ApplyConfiguration(new RentConfiguration());




        }


    }
}
