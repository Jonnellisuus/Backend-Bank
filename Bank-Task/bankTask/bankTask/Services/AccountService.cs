using bankTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Repositories; // Needs to be added.

namespace bankTask.Services
{
	public class AccountService : IAccountService
	{
		// Inject repository layer
		private readonly IAccountRepository _accountRepository;

		// Define constructor
		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}
		public Account Create(Account account)
		{
			return _accountRepository.Create(account);
		}

		public void Delete(string IBAN)
		{
			Account deleteAccount = _accountRepository.Read(IBAN);
			_accountRepository.Delete(deleteAccount);
		}

		public List<Account> Read()
		{
			return _accountRepository.Read();
		}

		public Account Read(string IBAN)
		{
			return _accountRepository.Read(IBAN);
		}

		public List<Account> Read(int customerId)
		{
			return _accountRepository.Read(customerId);
		}

		public List<Account> Read(int customerId, int bankId)
		{
			return _accountRepository.Read(customerId, bankId);
		}

		public Account Update(Account account)
		{
			return _accountRepository.Update(account);
		}
	}
}
