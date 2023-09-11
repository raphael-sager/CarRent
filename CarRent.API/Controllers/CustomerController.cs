using CarRent.API.CustomerManagement.Api;
using CarRent.API.CustomerManagement.Domain;
using CarRent.API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
        
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerResponse> Get()
        {
            var customers = _repository.GetAll();
            return customers.Select(x => new CustomerResponse(x.Name));
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerResponse Get(int id)
        {
            var customer = _repository.Get(id);
            return new CustomerResponse(customer.Name);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public CustomerResponse Post([FromBody] CustomerRequest value)
        {
            var customer = new Customer(value.Id, value.FullName);
            _repository.Add(customer);
            return new CustomerResponse(customer.Name);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public CustomerResponse Put(int id, [FromBody] CustomerRequest value)
        {
            var customer = new Customer(id, value.FullName);
            _repository.Update(customer);
            return new CustomerResponse(customer.Name);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}
