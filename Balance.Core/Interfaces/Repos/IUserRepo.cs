using Balance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Core.Interfaces.Repos
{
    public interface IUserRepo : IRepoBase<User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
