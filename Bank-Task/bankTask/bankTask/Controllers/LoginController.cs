using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bankTask.Models;
using bankTask.Repositories;
using bankTask.Services;

namespace bankTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Login
        // Get the specific user by its login name.
        [HttpGet("users/{LoginName}")] //api/login/users/{LoginName}
        public IActionResult Get(string loginName)
        {
            var getUser = _userService.Read(loginName);
            return new JsonResult(getUser);
        }

        // GET: api/Login/5
        // Get all the users.
        [HttpGet("users")]
        public  IActionResult GetUsers()
        {
            var result = _userService.Read();
            return new JsonResult(result);
        }

        // POST: api/Login
        [HttpPost]
        [Route(template:"addUser")]
        // IActionResult does not know what to return. ActionResult does.
        public ActionResult<User> PostAddUser([FromBody] User userData)
        {
            User user = null;
            if (userData.LoginName != null)
            {
                user = _userService.Create(userData);
            }
            
            return user;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            return new JsonResult(_userService.Login(user));
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
