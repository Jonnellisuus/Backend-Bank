using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bankTask.Models; // Needs to be added.
using bankTask.Repositories; // Needs to be added.
using bankTask.Services; // Needs to be added.

namespace bankTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // Inject repository layer
        private readonly ICustomersRepository _customersRepository;

        // Inject service layer
        private readonly ICustomersService _customersService;

        // Define constructor
        public CustomersController(ICustomersRepository customersRepository, ICustomersService customersService)
        {
            _customersRepository = customersRepository;
            _customersService = customersService;
        }

        // GET: api/Customers
        // Get all the customers in the list.
        [HttpGet]
        public IActionResult Get()
        {
            var getCustomers = _customersRepository.Read();
            return new JsonResult(getCustomers);
        }

        // Get the specific bank's all the customers
        [HttpGet("bank/{id}")] // api/customers/bank/{id}
        public IActionResult GetBanksCustomers(int id)
        {
            var getBanksCustomers = _customersRepository.ReadBanksCustomers(id);
            return new JsonResult(getBanksCustomers);
        }

        // GET: api/Customers/5
        // Get a specific customer by id.
        [HttpGet("{id}")] //  Name = "Get" needs to be removed.
        public IActionResult Get(int id)
        {
            var getCustomer = _customersService.Read(id);
            return new JsonResult(getCustomer);
        }

        // POST: api/Customers
        // Create a new customer.
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var createCustomer = _customersService.Create(customer);
            return new JsonResult(createCustomer);
        }

        // PUT: api/Customers/5
        // Update a specific customer by id.
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Customer customer)
        {
            var updateCustomer = _customersService.Update(customer);
            return new JsonResult(updateCustomer);
        }

        // DELETE: api/ApiWithActions/5
        // Delete a specific customer by id.
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customersService.Delete(id);
        }
    }
}
