using bankTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankTask.Services
{
     public interface IBankService
    {
        Bank Create(Bank bank);
        List<Bank> Read();
        Bank Read(int id);
        void Delete(int id);
        Bank Update(Bank bank);
    }
}
