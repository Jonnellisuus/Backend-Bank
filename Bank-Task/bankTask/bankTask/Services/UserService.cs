using bankTask.Authentication; // Needs to be added.
using bankTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankTask.Repositories;

namespace bankTask.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public User Create(User user)
		{
			user.Salt = PasswordHash.MakeSalt();
			user.PswHash = PasswordHash.HashPassword(user.PswHash, user.Salt);
			return _userRepository.Create(user);
		}

		public User Login(User userFrontEnd)
		{
			// 1. Löytyykö user tietokannasta.
			// 2. Suola talteen tietokannasta löytyneestä user:sta.
			// 3 Lasketaan Hash (selväkielinen salasana + suola).
			// 4. Kysely löytyykö user.LoginName + PswHash kannasta.
			// 5. return

			var userDatabase = _userRepository.Read(userFrontEnd.LoginName);

			var calculatedHash = PasswordHash.HashPassword(userFrontEnd.PswHash, userDatabase.Salt);

			var user = _userRepository.Read(userFrontEnd.LoginName, calculatedHash);

			return user;
		}

		public List<User> Read()
		{
			return _userRepository.Read();
		}

		public User Read(string loginName)
		{
			return _userRepository.Read(loginName);
		}
	}
}
