using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models; // Needs to be added.

namespace bankTask.Repositories
{
	public interface ICustomersRepository
	{
		Customer Create(Customer customer);
		List<Customer> Read();
		Customer Read(int id);
		Customer Update(Customer customer);
		void Delete(Customer customer);
		// Get bank's customers
		List<Customer> ReadBanksCustomers(int bankId); // Get the specific bank's all the customers
	}
}
