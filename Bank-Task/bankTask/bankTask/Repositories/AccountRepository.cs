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
    public class AccountRepository : IAccountRepository
    {
        // Injected database
        private readonly DtbankdbContext _dtbankdbContext;

        // Define constructor
        public AccountRepository(DtbankdbContext dtbankdbContext)
        {
            _dtbankdbContext = dtbankdbContext;
        }

        public Account Create(Account account)
        {
            _dtbankdbContext.Account.Add(account);
            _dtbankdbContext.SaveChanges();
            return account;
        }

        public void Delete(Account account)
        {
            _dtbankdbContext.Account.Remove(account);
            _dtbankdbContext.SaveChanges();
        }

        public List<Account> Read()
        {
            var accounts = _dtbankdbContext.Account.ToList();
            return accounts;
        }

        public Account Read(string IBAN)
        {
            var account = _dtbankdbContext.Account.FirstOrDefault(a => a.IBAN == IBAN);
            return account;
        }

        public List<Account> Read(int customerId)
        {
            var customersAccounts = _dtbankdbContext.Account
                .Where(a => a.CustomerId == customerId)
                .ToList();
            return customersAccounts;
        }

        public List<Account> Read(int customerId, int bankId)
        {
            var customersAccountsByBank = _dtbankdbContext.Account
           .Where(a => a.CustomerId == customerId && a.BankId == bankId)
           .ToList();
            return customersAccountsByBank;
        }

        public Account Update(Account account)
        {
            _dtbankdbContext.Account.Update(account);
            _dtbankdbContext.SaveChanges();
            return account;
        }
    }
}
