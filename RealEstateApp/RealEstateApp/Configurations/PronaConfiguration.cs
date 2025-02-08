using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Entities;

namespace RealEstateApp.Configurations
{
    public class PronaConfiguration
    {
        public class PronaConfigurations : IEntityTypeConfiguration<Prona>
        {
            public void Configure(EntityTypeBuilder<Prona> builder)
            {
                builder.HasKey(c => c.PronaID);
                builder.Property(e => e.Emri).IsRequired().HasMaxLength(100);
                builder.Property(e => e.Adresa).IsRequired().HasMaxLength(100);
                builder.Property(e => e.Price).IsRequired();
                builder.Property(e => e.Description).IsRequired().HasMaxLength(1000);
                builder.Property(e => e.Status).IsRequired().HasMaxLength(100);
                builder.Property(e => e.Type).IsRequired().HasMaxLength(100);
            }
        }
    }
}
