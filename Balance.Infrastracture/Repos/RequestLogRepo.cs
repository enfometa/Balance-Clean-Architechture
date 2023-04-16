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
    public class RequestLogRepo : RepoBase<RequestLog>, IRequestLogRepo
    {
        public RequestLogRepo(IDbConnection dbConnection): base(dbConnection)
        {

        }
    }
}
