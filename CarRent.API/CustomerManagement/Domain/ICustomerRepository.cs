using CarRent.API.Entities;

namespace CarRent.API.CustomerManagement.Domain
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer Get(int id);

        void Add(Customer customer);

        void Remove(Customer customer);

        void Remove(int id);
        void Update(Customer customer);
    }
}
