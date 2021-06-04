using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models; // Needs to be added.

namespace bankTask.Services
{
	public interface ICustomersService
	{
		Customer Create(Customer customer);
		List<Customer> Read();
		Customer Read(int id);
		Customer Update(Customer customer);
		void Delete(int id);
		List<Customer> ReadBanksCustomers(int bankId); // Get the specific bank's all the customers
	}
}
