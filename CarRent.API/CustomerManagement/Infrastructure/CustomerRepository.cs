using CarRent.API.Context;
using CarRent.API.CustomerManagement.Domain;
using CarRent.API.Entities;

namespace CarRent.API.CustomerManagement.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CarRentContext _context;

        public CustomerRepository(CarRentContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
        }

        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerNr == id) ?? throw new ArgumentNullException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Remove(Customer customer)
        {
            var deleteCustomer = _context.Customers.FirstOrDefault(c => c == customer);

            if (deleteCustomer == null) return;
            _context.Customers.Remove(deleteCustomer);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var deleteCustomer = _context.Customers.FirstOrDefault(c => c.CustomerNr == id);

            if (deleteCustomer == null) return;
            _context.Customers.Remove(deleteCustomer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var updateCustomer = _context.Customers.FirstOrDefault(c => c.CustomerNr == customer.CustomerNr && c.Name == customer.Name);
            if (updateCustomer == null) return;
            _context.Customers.Update(updateCustomer);
        }
    }
}
