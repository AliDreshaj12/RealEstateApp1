﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RealEstateApp.Entities;

namespace RealEstateApp.Configurations
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(c => c.RentId);
            builder.Property(e => e.BookingDate).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.PaymentMethod).IsRequired().HasMaxLength(100);

            builder.HasOne(m => m.Users)
                   .WithMany()
                   .HasForeignKey(m => m.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Pronat)
                   .WithMany()
                   .HasForeignKey(m => m.PronaID)
                   .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
