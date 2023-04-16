using Balance.Core.Entities;
using Balance.Core.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Infrastracture.Repos
{
    public class UserRepo : RepoBase<User>, IUserRepo
    {
        public UserRepo(IDbConnection dbConnection): base(dbConnection)
        {

        }
        public Task<User> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
