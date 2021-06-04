using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models;
using bankTask.Repositories; // Needs to be added.
using Microsoft.AspNetCore.Mvc;

namespace bankTask.Services
{
	public class TransactionService : ITransactionService
	{
		// Inject repository layer
		private readonly ITransactionRepository _transactionRepository;
		private readonly IAccountRepository _accountRepository;

		// Define constructor
		public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
		{
			_transactionRepository = transactionRepository;
			_accountRepository = accountRepository;
		}

		public IActionResult Create(Transaction transaction)
		{
			var account = _accountRepository.Read(transaction.IBAN);
			account.Balance += transaction.Amount;
			if(account.Balance < 0)
			{
				return new JsonResult("Not enough money.");
			}
			_transactionRepository.Create(transaction);
			var result = _accountRepository.Update(account);
			return new JsonResult(result);
		}

		public void Delete(int id)
		{
			Transaction deleteTransaction = _transactionRepository.Read(id);
			_transactionRepository.Delete(deleteTransaction);
		}

		public List<Transaction> Read()
		{
			return _transactionRepository.Read();
		}

		public Transaction Read(int id)
		{
			return _transactionRepository.Read(id);
		}

		public List<Transaction> ReadTransactionDates(DateTime startDateTime, DateTime endDateTime)
		{
			return _transactionRepository.ReadTransactionDates(startDateTime, endDateTime);
		}

		public List<Transaction> ReadAccountsTransactions(string IBAN)
		{
			return _transactionRepository.ReadAccountsTransactions(IBAN);
		}

		public Transaction Update(Transaction transaction)
		{
			return _transactionRepository.Update(transaction);
		}
	}
}
