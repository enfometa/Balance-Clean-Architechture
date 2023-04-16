using Balance.Core.Entities;
using Balance.Core.Interfaces.Repos;
using Dapper;
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
        public async Task<User> GetByUsernameAsync(string username)
        {
            string sql = "select * from [user] where username = @username";
            return _dbConnection.QueryFirstOrDefault<User>(sql, new { username });
        }
    }
}
