using CarRent.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CarRent.API.Context
{
    public class CarRentContext : DbContext
    {
        public DbSet<Customer> Customers { get; }
        public DbSet<Reservation> Reservations { get; }
        public DbSet<RentalContract> RentalContracts { get; }
        public DbSet<Car> Cars { get; }
        public DbSet<Model> Models { get; }
        public DbSet<Brand> Brands { get; }
        public DbSet<Category> Categories { get; }

        public CarRentContext(DbContextOptions<CarRentContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerNr);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Reservations)
                .WithOne(r => r.Customers);
            
            modelBuilder.Entity<Reservation>()
                .HasKey(c => c.ReservationNr);

            modelBuilder.Entity<RentalContract>()
                .HasKey(r => r.ContractNr);
            modelBuilder.Entity<RentalContract>()
                .HasOne(r => r.Car)
                .WithMany(c => c.RentalContracts)
                .HasForeignKey(r => r.CarId);
            modelBuilder.Entity<RentalContract>()
                .HasOne(r => r.Reservation)
                .WithMany(r => r.RentalContracts)
                .HasForeignKey(r => r.ReservationId);

            modelBuilder.Entity<Car>()
                .HasKey(c => c.CarNr);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithOne(m => m.Car)
                .HasForeignKey<Car>(c => c.ModelId);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithOne(b => b.Car)
                .HasForeignKey<Car>(c => c.BrandId);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Economy>();
            modelBuilder.Entity<Midrange>();
            modelBuilder.Entity<Luxury>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
