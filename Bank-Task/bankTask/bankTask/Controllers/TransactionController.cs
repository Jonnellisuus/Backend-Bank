using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bankTask.Models; // Needs to be added.
using bankTask.Repositories; // Needs to be added.
using bankTask.Services; // Needs to be added.

namespace bankTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        // Inject repository layer
        private readonly ITransactionRepository _transactionRepository;

        // Inject service layer
        private readonly ITransactionService _transactionService;

        // Define constructor
        public TransactionController(ITransactionRepository transactionRepository, ITransactionService transactionService)
        {
            _transactionRepository = transactionRepository;
            _transactionService = transactionService;
        }

        // GET: api/Transaction
        [HttpGet]
        public IActionResult Get()
        {
            var getTransactions = _transactionRepository.Read();
            return new JsonResult(getTransactions);
        }

        // Get the specific account's all the transactions.
        [HttpGet("account/{IBAN}")] // api/transaction/account/{IBAN} -- (id in {id} need to be changed to IBAN)
        public IActionResult GetAccountsTransactions(string IBAN)
        {
            var getAccountsTransactions = _transactionRepository.ReadAccountsTransactions(IBAN);
            return new JsonResult(getAccountsTransactions);
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")] //  Name = "Get" needs to be removed and it also needs to be removed from every controller.
        public IActionResult Get(int id)
        {
            var getTransaction = _transactionService.Read(id);
            return new JsonResult(getTransaction);
        }

        [HttpGet("{startDateTime}/{endDateTime}")]
        public IActionResult GetTransactionDate(DateTime startDateTime, DateTime endDateTime)
        {
            var transactionDate = _transactionService.ReadTransactionDates(startDateTime, endDateTime);
            return new JsonResult(transactionDate);
        }

        // POST: api/Transaction
        [HttpPost]
        public IActionResult Post([FromBody] Transaction transaction)
        {
            return _transactionService.Create(transaction);
           // return new JsonResult(createTransaction);
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Transaction transaction)
        {
            var updateTransaction = _transactionService.Update(transaction);
            return new JsonResult(updateTransaction);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _transactionService.Delete(id);
        }
    }
}
