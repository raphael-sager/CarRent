using CarRent.API.CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRent.API.CustomerManagement.Infrastructure
{
    public class CustomerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; }
    }
}
