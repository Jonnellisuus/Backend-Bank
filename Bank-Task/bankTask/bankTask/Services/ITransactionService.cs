using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models; // Needs to be added.
using Microsoft.AspNetCore.Mvc;

namespace bankTask.Services
{
	// Remember to make the interface public.
	public interface ITransactionService
	{
		IActionResult Create(Transaction transaction);
		List<Transaction> Read();
		Transaction Read(int id);
		Transaction Update(Transaction transaction);
		void Delete(int id);
		List<Transaction> ReadAccountsTransactions(string IBAN); // Get the specific account's all the transactions.
		List<Transaction> ReadTransactionDates(DateTime startDateTime, DateTime endDateTime);
	}
}
