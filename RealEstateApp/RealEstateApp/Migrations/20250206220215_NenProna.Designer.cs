﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateApp.Data;

#nullable disable

namespace RealEstateApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250206220215_NenProna")]
    partial class NenProna
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealEstateApp.Entities.Prona", b =>
                {
                    b.Property<int>("PronaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PronaID"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PronaID");

                    b.ToTable("Pronas");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("RealEstateApp.Entities.Apartment", b =>
                {
                    b.HasBaseType("RealEstateApp.Entities.Prona");

                    b.Property<int>("floor")
                        .HasColumnType("int");

                    b.Property<bool>("kaAnshensor")
                        .HasColumnType("bit");

                    b.Property<int>("nrDhomave")
                        .HasColumnType("int");

                    b.ToTable("Apartments", (string)null);
                });

            modelBuilder.Entity("RealEstateApp.Entities.Shtepia", b =>
                {
                    b.HasBaseType("RealEstateApp.Entities.Prona");

                    b.Property<bool>("kaGarazhd")
                        .HasColumnType("bit");

                    b.Property<bool>("kaPool")
                        .HasColumnType("bit");

                    b.Property<int>("nrFloors")
                        .HasColumnType("int");

                    b.Property<double>("size")
                        .HasColumnType("float");

                    b.ToTable("Shtepiat", (string)null);
                });

            modelBuilder.Entity("RealEstateApp.Entities.Toka", b =>
                {
                    b.HasBaseType("RealEstateApp.Entities.Prona");

                    b.Property<string>("LandType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TopografiaTokes")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("WaterSource")
                        .HasColumnType("bit");

                    b.Property<string>("Zona")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("Tokat", (string)null);
                });

            modelBuilder.Entity("RealEstateApp.Entities.Apartment", b =>
                {
                    b.HasOne("RealEstateApp.Entities.Prona", null)
                        .WithOne()
                        .HasForeignKey("RealEstateApp.Entities.Apartment", "PronaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstateApp.Entities.Shtepia", b =>
                {
                    b.HasOne("RealEstateApp.Entities.Prona", null)
                        .WithOne()
                        .HasForeignKey("RealEstateApp.Entities.Shtepia", "PronaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstateApp.Entities.Toka", b =>
                {
                    b.HasOne("RealEstateApp.Entities.Prona", null)
                        .WithOne()
                        .HasForeignKey("RealEstateApp.Entities.Toka", "PronaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
