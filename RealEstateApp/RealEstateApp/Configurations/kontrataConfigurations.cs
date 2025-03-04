using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Entities;

namespace RealEstateApp.Configurations
{
    public class kontrataConfigurations : IEntityTypeConfiguration<Kontrata>
    {
        public void Configure(EntityTypeBuilder<Kontrata> builder)
        {
            builder.HasKey(c => c.KontrataId);

            builder.Property(e => e.koheZgjatja).IsRequired();
            builder.Property(e => e.Type).IsRequired().HasMaxLength(100);
            builder.HasOne(m => m.Users)
                  .WithMany()
                  .HasForeignKey(m => m.UserID)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Pronat)
                  .WithMany()
                  .HasForeignKey(m => m.PronaID)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
