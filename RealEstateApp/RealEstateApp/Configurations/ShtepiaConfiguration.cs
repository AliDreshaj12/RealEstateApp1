using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Entities;

namespace RealEstateApp.Configurations
{
    public class ShtepiaConfigurations : IEntityTypeConfiguration<Shtepia>
    {
        public void Configure(EntityTypeBuilder<Shtepia> builder)
        {
            builder.HasBaseType<Prona>();
            builder.Property(e => e.size).IsRequired();
            builder.Property(e => e.nrFloors).IsRequired();
            builder.Property(e => e.kaGarazhd).IsRequired();
            builder.Property(e => e.kaPool).IsRequired();
            builder.ToTable("Shtepiat");
        }
    }
}
