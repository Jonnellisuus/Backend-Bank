using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using bankTask.Models;
using bankTask.Data;

namespace bankTask.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DtbankdbContext _dtbankdbContext;
		public UserRepository(DtbankdbContext dtbankdbContext)
		{
			_dtbankdbContext = dtbankdbContext;
		}
		public User Create(User user)
		{
			_dtbankdbContext.Add(user);
			_dtbankdbContext.SaveChanges();
			return user;
		}

		public List<User> Read()
		{
			return _dtbankdbContext.User.AsNoTracking().ToList();
		}

		public User Read(string loginName)
		{
			return _dtbankdbContext.User.FirstOrDefault(u => u.LoginName == loginName);
		}

		public User Read(string loginName, string pswHash)
		{
			return _dtbankdbContext.User.FirstOrDefault(u => u.LoginName == loginName && u.PswHash == pswHash);
		}
	}
}
