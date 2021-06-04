using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Models;

namespace bankTask.Repositories
{
	public interface IUserRepository
	{
		User Create(User user);
		List<User> Read();
		User Read(string loginName);
		User Read(string loginName, string pswHash);
	}
}
