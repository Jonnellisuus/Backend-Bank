using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Needs to be added.
using System.Data; // Needs to be added.
using bankTask.Models;
using bankTask.Data;

namespace bankTask.Repositories
{
	public class TransactionRepository : ITransactionRepository
	{
		// Injected database
		private readonly DtbankdbContext _dtbankdbContext;

		// Define constructor
		public TransactionRepository(DtbankdbContext dtbankdbContext)
		{
			_dtbankdbContext = dtbankdbContext;
		}

		public Transaction Create(Transaction transaction)
		{
			_dtbankdbContext.Transaction.Add(transaction);
			_dtbankdbContext.SaveChanges();
			return transaction;
		}

		public void Delete(Transaction transaction)
		{
			_dtbankdbContext.Transaction.Remove(transaction);
			_dtbankdbContext.SaveChanges();
		}

		public List<Transaction> Read()
		{
			var transactions = _dtbankdbContext.Transaction.ToList();
			return transactions;
		}

		public Transaction Read(int id)
		{
			var transaction = _dtbankdbContext.Transaction.FirstOrDefault(i => i.Id == id);
			return transaction;
		}

		public List<Transaction> ReadTransactionDates(DateTime startDateTime, DateTime endDateTime)
		{
			var transactions = _dtbankdbContext.Transaction
				.Where(t => t.TimeStamp >= startDateTime && t.TimeStamp <= endDateTime)
				.ToList();
			return transactions;
		}

		public List<Transaction> ReadAccountsTransactions(string IBAN)
		{
			var accountsTransactions = _dtbankdbContext.Transaction
				.Where(t => t.IBAN == IBAN)
				.ToList();
			return accountsTransactions;
		}

		public Transaction Update(Transaction transaction)
		{
			_dtbankdbContext.Transaction.Update(transaction);
			_dtbankdbContext.SaveChanges();
			return transaction;
		}
	}
}
