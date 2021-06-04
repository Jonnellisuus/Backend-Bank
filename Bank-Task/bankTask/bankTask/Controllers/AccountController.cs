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
    public class AccountController : ControllerBase
    {
        // Inject repository layer
        private readonly IAccountRepository _accountRepository;

        // Inject service layer
        private readonly IAccountService _accountService;

        // Define constructor
        public AccountController(IAccountRepository accountRepository, IAccountService accountService)
        {
            _accountRepository = accountRepository;
            _accountService = accountService;
        }

        // GET: api/Account
        [HttpGet]
        public IActionResult Get()
        {
            var getAccounts = _accountRepository.Read();
            return new JsonResult(getAccounts);
        }

        // GET: api/Account/5
        [HttpGet("{iban}")] //  Name = "Get" needs to be removed and it also needs to be removed from every controller.
        public IActionResult Get(string IBAN)
        {
            var getAccount = _accountService.Read(IBAN);
            return new JsonResult(getAccount);
        }

        // GET: api/Account/cutomer/5
        [HttpGet("customer/{id}")] //  Name = "Get" needs to be removed and it also needs to be removed from every controller.
        public IActionResult Get(int id)
        {
            var getAccounts = _accountService.Read(id);
            return new JsonResult(getAccounts);
        }

        // GET: api/Account/customer/bank/5/5
        [HttpGet("customer/bank/{customerId}/{bankId}")] //  Name = "Get" needs to be removed and it also needs to be removed from every controller.
        public IActionResult Get(int customerId, int bankId)
        {
            var getAccounts = _accountService.Read(customerId, bankId);
            return new JsonResult(getAccounts);
        }

        // POST: api/Account
        [HttpPost]
        public IActionResult Post([FromBody] Account account)
        {
            var createAccount = _accountService.Create(account);
            return new JsonResult(createAccount);
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Account account)
        {
            var updateAccount = _accountService.Update(account);
            return new JsonResult(updateAccount);
        }

        // DELETE: api/Account/5
        [HttpDelete("{iban}")] // Here {id} needs to be {iban}.
        public void Delete(string IBAN)
        {
            _accountService.Delete(IBAN);
        }
    }
}
