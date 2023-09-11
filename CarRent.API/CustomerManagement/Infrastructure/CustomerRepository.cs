using CarRent.API.CustomerManagement.Domain;
using CarRent.API.Entities;

namespace CarRent.API.CustomerManagement.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
        }

        public Customer Get(Guid id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id) ?? throw new ArgumentNullException();
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

        public void Remove(Guid id)
        {
            var deleteCustomer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (deleteCustomer == null) return;
            _context.Customers.Remove(deleteCustomer);
            _context.SaveChanges();
        }
    }
}
