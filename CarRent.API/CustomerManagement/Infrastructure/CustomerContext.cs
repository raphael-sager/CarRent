using CarRent.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRent.API.CustomerManagement.Infrastructure
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(k => k.Id);
        }

    }
}
