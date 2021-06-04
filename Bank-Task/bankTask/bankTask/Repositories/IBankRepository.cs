using bankTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bankTask.Repositories
{
    public interface IBankRepository
    {
        Bank Create(Bank person);
        List<Bank> Read();
        Bank Read(int id);
        Bank Update(Bank bank);
        void Delete(Bank bank);
    }
}
