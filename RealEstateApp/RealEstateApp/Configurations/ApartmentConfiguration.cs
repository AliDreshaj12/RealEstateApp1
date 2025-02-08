using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Entities;

namespace RealEstateApp.Configurations
{
    public class ApartmentsConfigurations : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasBaseType<Prona>();

            builder.Property(e => e.floor).IsRequired();
            builder.Property(e => e.nrDhomave).IsRequired();
            builder.Property(e => e.kaAnshensor).IsRequired();
            builder.ToTable("Apartments");
        }
    }
}
