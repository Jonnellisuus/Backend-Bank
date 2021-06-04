using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models; // Needs to be added.

namespace bankTask.Repositories
{
	// Remember to make the interface public.
	public interface ITransactionRepository
	{
		Transaction Create(Transaction transaction);
		List<Transaction> Read();
		Transaction Read(int id);
		Transaction Update(Transaction transaction);
		void Delete(Transaction transaction);
		List<Transaction> ReadAccountsTransactions(string IBAN); // Get the specific account's all the transactions.
		List<Transaction> ReadTransactionDates(DateTime startDateTime, DateTime endDateTime);
	}
}
