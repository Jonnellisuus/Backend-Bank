using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography; // Needs to be added.
using System.Text; // Needs to be added.
using Microsoft.AspNetCore.Cryptography.KeyDerivation; // Needs to be added.

namespace bankTask.Authentication
{
	public class PasswordHash
	{
        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public static string MakeSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string returnValue = Convert.ToBase64String(salt);

            return returnValue;
        }
    }
}
