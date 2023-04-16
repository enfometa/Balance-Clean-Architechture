using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Application.Services
{
    public interface ICryptoService
    {
        (string PasswordHash, string PasswordSalt) HashPassword(string password);
        bool VerifyHashedPassword(string password, string passwordHash, string passwordSalt);
    }
}
