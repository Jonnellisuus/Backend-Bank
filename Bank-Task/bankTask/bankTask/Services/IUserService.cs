using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models;

namespace bankTask.Services
{
	public interface IUserService
	{
		User Create(User user);
		User Login(User userFrontEnd);
		List<User> Read();
		User Read(string loginName);
	}
}
