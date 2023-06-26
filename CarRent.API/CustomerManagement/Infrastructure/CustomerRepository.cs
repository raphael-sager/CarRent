using CarRent.API.CustomerManagement.Domain;

namespace CarRent.API.CustomerManagement.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>()
            {
                new("C00001", "Hans"),
                new("C00002", "Fritz")
            };
        }

        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public void Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
