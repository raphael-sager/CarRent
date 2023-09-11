﻿// <auto-generated />
using System;
using CarRent.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRent.API.Migrations
{
    [DbContext(typeof(CarRentContext))]
    [Migration("20230911121918_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRent.API.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarRent.API.Entities.Car", b =>
                {
                    b.Property<int>("CarNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarNr"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.HasKey("CarNr");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRent.API.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DailyFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("cat_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasDiscriminator<string>("cat_type").HasValue("Category");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CarRent.API.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarRent.API.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CarRent.API.Entities.RentalContract", b =>
                {
                    b.Property<int>("ContractNr")
                        .HasColumnType("int");

                    b.Property<int>("CarNr")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("ContractNr");

                    b.HasIndex("CarNr");

                    b.ToTable("RentalContracts");
                });

            modelBuilder.Entity("CarRent.API.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationNr"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RentalContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReservationNr");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CarRent.API.Entities.Economy", b =>
                {
                    b.HasBaseType("CarRent.API.Entities.Category");

                    b.HasDiscriminator().HasValue("Economy");
                });

            modelBuilder.Entity("CarRent.API.Entities.Luxury", b =>
                {
                    b.HasBaseType("CarRent.API.Entities.Category");

                    b.HasDiscriminator().HasValue("Luxury");
                });

            modelBuilder.Entity("CarRent.API.Entities.Midrange", b =>
                {
                    b.HasBaseType("CarRent.API.Entities.Category");

                    b.HasDiscriminator().HasValue("Midrange");
                });

            modelBuilder.Entity("CarRent.API.Entities.Brand", b =>
                {
                    b.HasOne("CarRent.API.Entities.Car", "Car")
                        .WithOne("Brand")
                        .HasForeignKey("CarRent.API.Entities.Brand", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRent.API.Entities.Car", b =>
                {
                    b.HasOne("CarRent.API.Entities.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CarRent.API.Entities.Model", b =>
                {
                    b.HasOne("CarRent.API.Entities.Car", "Car")
                        .WithOne("Model")
                        .HasForeignKey("CarRent.API.Entities.Model", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRent.API.Entities.RentalContract", b =>
                {
                    b.HasOne("CarRent.API.Entities.Car", "Car")
                        .WithMany("Contracts")
                        .HasForeignKey("CarNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRent.API.Entities.Reservation", "Reservation")
                        .WithOne("RentalContract")
                        .HasForeignKey("CarRent.API.Entities.RentalContract", "ContractNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("CarRent.API.Entities.Reservation", b =>
                {
                    b.HasOne("CarRent.API.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRent.API.Entities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CarRent.API.Entities.Car", b =>
                {
                    b.Navigation("Brand")
                        .IsRequired();

                    b.Navigation("Contracts");

                    b.Navigation("Model")
                        .IsRequired();
                });

            modelBuilder.Entity("CarRent.API.Entities.Category", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRent.API.Entities.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("CarRent.API.Entities.Reservation", b =>
                {
                    b.Navigation("RentalContract")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}