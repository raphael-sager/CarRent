using CarRent.API.Entities;
using Microsoft.EntityFrameworkCore;

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
        // TODO: add-migration initial (i think must set everywhere the primary key)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Customer>()
                .HasMany<Reservation>(c => c.Reservations)
                .WithOne(r => r.Customer);

            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationNr);

            modelBuilder.Entity<Reservation>()
                .HasOne<Customer>(r => r.Customer)
                .WithMany(c => c.Reservations);

            modelBuilder.Entity<Reservation>()
                .HasOne<Category>(r => r.Category);

            modelBuilder.Entity<RentalContract>()
                .HasOne<Reservation>(c => c.Reservation);

            modelBuilder.Entity<RentalContract>()
                .HasKey(rc => rc.ContractNr);

            modelBuilder.Entity<RentalContract>()
                .HasOne<Car>(rc => rc.Car)
                .WithMany(c => c.Contracts);

            modelBuilder.Entity<Car>()
                .HasKey(c => c.CarNr);

            modelBuilder.Entity<Car>()
                .HasMany<RentalContract>(c => c.Contracts)
                .WithOne(rc => rc.Car);

            modelBuilder.Entity<Car>()
                .HasOne<Model>(c => c.Model)
                .WithOne(m => m.Car)
                .HasForeignKey<Car>(c => c.ModelId);

            modelBuilder.Entity<Car>()
                .HasOne<Brand>(c => c.Brand)
                .WithOne(b => b.Car)
                .HasForeignKey<Car>(c => c.BrandId);

            modelBuilder.Entity<Car>()
                .HasOne<Category>(c => c.Category)
                .WithMany(c => c.Cars);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .HasDiscriminator<string>("cat_type")
                .HasValue<Midrange>("Midrange")
                .HasValue<Luxury>("Luxury")
                .HasValue<Economy>("Economy");

            modelBuilder.Entity<Brand>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Brand>()
                .HasOne<Car>(b => b.Car)
                .WithOne(c => c.Brand)
                .HasForeignKey<Brand>(b => b.CarId);

            modelBuilder.Entity<Model>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Model>()
                .HasOne<Car>(m => m.Car)
                .WithOne(c => c.Model)
                .HasForeignKey<Model>(m => m.CarId);
        }
    }
}
