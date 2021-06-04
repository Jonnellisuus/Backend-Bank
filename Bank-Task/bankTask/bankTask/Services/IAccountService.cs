using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models; // Needs to be added.

namespace bankTask.Services
{
	public interface IAccountService
	{
		Account Create(Account account);
		List<Account> Read();
		Account Read(string IBAN);
		Account Update(Account account);
		void Delete(string IBAN);
		//get all accounts of a customer
		List<Account> Read(int customerId);
		//get all customer's accounts of a single bank
		List<Account> Read(int customerId, int bankId);
	}
}
