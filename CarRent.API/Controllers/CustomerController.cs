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
            return customers.Select(x => new CustomerResponse(x.Id, x.CustomerNr, x.Name, null));
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerResponse Get(Guid id)
        {
            var customer = _repository.Get(id);
            return new CustomerResponse(customer.Id, customer.CustomerNr, customer.Name, null);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public CustomerResponse Post([FromBody] CustomerRequest value)
        {
            var customer = new Customer(value.Id.ToString(), value.FullName);
            _repository.Add(customer);
            return new CustomerResponse(customer.Id, customer.CustomerNr, customer.Name, null);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public CustomerResponse Put(Guid id, [FromBody] CustomerRequest value)
        {
            var customer = new Customer(value.Id.ToString(), value.FullName);
            _repository.Update(customer);
            return new CustomerResponse(customer.Id, customer.CustomerNr, customer.Name, null);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
