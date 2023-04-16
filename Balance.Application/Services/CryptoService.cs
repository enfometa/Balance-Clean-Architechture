using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Application.Services
{
    public class CryptoService : ICryptoService
    {
        public (string PasswordHash, string PasswordSalt) HashPassword(string password)
        {
            (var passHash, var passSalt) = HashPasswordHelper(password, string.Empty);

            return (passHash, passSalt);
        }

        public bool VerifyHashedPassword(string password, string passwordHash, string passwordSalt)
        {
            string newHash = String.Empty;

            (var passHash, var passSalt) = HashPasswordHelper(password, passwordSalt);

            return passHash == passwordHash;
        }

        private (string PasswordHash, string PasswordSalt) HashPasswordHelper(string password, string passwordSalt)
        {
            string strPasswordSalt = string.Empty;
            string strPasswordHash = string.Empty;
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                if (!string.IsNullOrEmpty(passwordSalt))
                {
                    byte[] key = Convert.FromBase64String(passwordSalt);
                    hmac.Key = key;
                }

                strPasswordSalt = Convert.ToBase64String(hmac.Key);
                strPasswordHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }

            return (strPasswordHash, strPasswordSalt);
        }
    }
}
