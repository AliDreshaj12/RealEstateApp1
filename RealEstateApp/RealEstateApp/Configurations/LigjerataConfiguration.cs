using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateApp.Entities;

namespace RealEstateApp.Configurations
{
    public class LigjerataConfiguration : IEntityTypeConfiguration<Ligjerata>
    {
        public void Configure(EntityTypeBuilder<Ligjerata> builder)
        {
            builder.HasKey(c => c.LectureId);

            builder.HasOne(m => m.Ligjeruesi)//merret pjesa e foreign key tek tabela qe shkon foreign
                   .WithMany()
                   .HasForeignKey(m => m.LecturerID)//foreign key
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
