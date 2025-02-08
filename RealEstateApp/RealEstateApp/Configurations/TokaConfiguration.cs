using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Entities;

namespace RealEstateApp.Configurations
{
    public class TokaConfigurations : IEntityTypeConfiguration<Toka>
    {
        public void Configure(EntityTypeBuilder<Toka> builder)
        {
            builder.HasBaseType<Prona>();
            builder.Property(e => e.LandType).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Zona).IsRequired().HasMaxLength(100);
            builder.Property(e => e.TopografiaTokes).IsRequired().HasMaxLength(100);
            builder.Property(e => e.WaterSource).IsRequired();
            builder.ToTable("Tokat");
        }
    }
}
