using bankTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Needs to be added.
using System.Data; // Needs to be added.
using bankTask.Data;

namespace bankTask.Repositories
{
	public class CustomersRepository : ICustomersRepository
	{
		// Injected database
		private readonly DtbankdbContext _dtbankdbContext;

		// Define constructor
		public CustomersRepository(DtbankdbContext dtbankdbContext)
		{
			_dtbankdbContext = dtbankdbContext;
		}

		// Create a new customer.
		public Customer Create(Customer customer)
		{
			_dtbankdbContext.Customer.Add(customer);
			_dtbankdbContext.SaveChanges();
			return customer;
		}

		// Delete a specific customer by id.
		public void Delete(Customer customer)
		{
			_dtbankdbContext.Customer.Remove(customer);
			_dtbankdbContext.SaveChanges();
		}

		// Get all the customers in the list.
		public List<Customer> Read()
		{
			var customer = _dtbankdbContext.Customer.ToList();
			return customer;
		}

		// Get a specific customers by ID.
		public Customer Read(int id)
		{
			var customers = _dtbankdbContext.Customer.FirstOrDefault(c => c.Id == id);
			return customers;
		}

		// Get the specific bank's all the customers
		public List<Customer> ReadBanksCustomers(int bankId)
		{
			var banksCustomers = _dtbankdbContext.Customer
				.Where(c => c.BankId == bankId)
				.ToList();
			return banksCustomers;
		}

		// Update a specific customer by id.
		public Customer Update(Customer customer)
		{
			_dtbankdbContext.Customer.Update(customer);
			_dtbankdbContext.SaveChanges();
			return customer;
		}
	}
}
