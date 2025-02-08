using Microsoft.EntityFrameworkCore;
using RealEstateApp.Configurations;
using RealEstateApp.Entities;
using static RealEstateApp.Configurations.PronaConfiguration;

namespace RealEstateApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Prona> Pronas { get; set; }
        public DbSet<Shtepia> Shtepiat { get; set; }
        public DbSet<Toka> Tokat { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PronaConfigurations());

            builder.ApplyConfiguration(new ShtepiaConfigurations());

            builder.ApplyConfiguration(new TokaConfigurations());

            builder.ApplyConfiguration(new ApartmentsConfigurations());

        }


    }
}
