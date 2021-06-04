using bankTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using bankTask.Data;

namespace bankTask.Repositories
{
    public class BankRepository : IBankRepository
    {
        //Injected database
        private readonly DtbankdbContext _dtbankdbContext;

        public BankRepository(DtbankdbContext dtbankdbContext)
        {
            _dtbankdbContext = dtbankdbContext;
        }

        //define constructor


        public Bank Create(Bank bank)
        {
            _dtbankdbContext.Bank.Add(bank);
            _dtbankdbContext.SaveChanges();
            return bank;
        }

        public void Delete(Bank bank)
        {
            _dtbankdbContext.Bank.Remove(bank);
            _dtbankdbContext.SaveChanges();
        }

        public List<Bank> Read()
        {
            var banks = _dtbankdbContext.Bank.ToList();
            return banks;
        }

        public Bank Read(int id)
        {
            var bank = _dtbankdbContext.Bank.FirstOrDefault(b => b.Id == id);
            return bank;
        }

        public Bank Update(Bank bank)
        {
            _dtbankdbContext.Bank.Update(bank);
            _dtbankdbContext.SaveChanges();
            return bank;
        }
    }

}
