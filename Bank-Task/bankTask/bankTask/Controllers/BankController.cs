using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models;
using bankTask.Repositories;
using bankTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bankTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        //inject repository layer
        private readonly IBankRepository _bankRepository;
        //inject service layer
        private readonly IBankService _bankService;

        //define constructor
        public BankController(IBankRepository bankRepository, IBankService bankService)
        {
            _bankRepository = bankRepository;
            _bankService = bankService;
        }

        // GET: api/Bank
        [HttpGet]
        public IActionResult Get()
        {
            var result = _bankRepository.Read();
            return new JsonResult(result);
        }

        // GET: api/Bank/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _bankRepository.Read(id);
            return new JsonResult(result);
        }

        // POST: api/Bank
        [HttpPost]
        public IActionResult Post([FromBody] Bank bank)
        {
            var result = _bankRepository.Create(bank);
            return new JsonResult(result);
        }

        // PUT: api/Bank/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Bank bank)
        {
            var updateBank = _bankService.Update(bank);
            return new JsonResult(updateBank);  
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Bank bank)
        {
            _bankRepository.Delete(bank);
        }
    }
}
