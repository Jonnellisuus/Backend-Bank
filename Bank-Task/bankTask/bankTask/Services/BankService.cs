using bankTask.Models;
using bankTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankTask.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public Bank Create(Bank bank)
        {
            return _bankRepository.Create(bank);
        }

        public void Delete(int id)
        {
            Bank removedBank = _bankRepository.Read(id);
            _bankRepository.Delete(removedBank);
        }

        public List<Bank> Read()
        {
            return _bankRepository.Read();
        }

        public Bank Read(int id)
        {
            return _bankRepository.Read(id);
        }

        public Bank Update(Bank bank)
        {
            return _bankRepository.Update(bank);
        }
    }
}
