using bankTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Repositories; // Needs to be added.

namespace bankTask.Services
{
	public class CustomersService : ICustomersService
	{
		// Inject repository layer
		private readonly ICustomersRepository _customersRepository;

		// Define constructor
		public CustomersService(ICustomersRepository customerRepository)
		{
			_customersRepository = customerRepository;
		}

		// Create a new customer.
		public Customer Create(Customer customer)
		{
			return _customersRepository.Create(customer);
		}

		// Delete a specific customer by id.
		public void Delete(int id)
		{
			Customer deleteCustomer = _customersRepository.Read(id);
			_customersRepository.Delete(deleteCustomer);
		}

		// Get all the customers in the list.
		public List<Customer> Read()
		{
			return _customersRepository.Read();
		}

		// Get a specific customers by ID.
		public Customer Read(int id)
		{
			return _customersRepository.Read(id);
		}

		// Get the specific bank's all the customers
		public List<Customer> ReadBanksCustomers(int bankId)
		{
			return _customersRepository.ReadBanksCustomers(bankId);
		}

		// Update a specific customer by id.
		public Customer Update(Customer customer)
		{
			return _customersRepository.Update(customer);
		}
	}
}
