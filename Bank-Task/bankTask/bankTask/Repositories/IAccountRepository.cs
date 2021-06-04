using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models;

namespace bankTask.Repositories
{
	public interface IAccountRepository
	{
		Account Create(Account account);
		List<Account> Read();
		Account Read(string IBAN);
		Account Update(Account account);
		void Delete(Account account);
		// get  all accounts of acustomer
		List<Account> Read(int customerId);
		// get all customer's accounts of a bank
		List<Account> Read(int customerId, int bankId);
	}
}
