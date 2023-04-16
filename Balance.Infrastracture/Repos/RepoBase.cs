using Balance.Core.Entities;
using Balance.Core.Interfaces.Repos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Infrastracture.Repos
{
    public class RepoBase<T> : IRepoBase<T> where T : EntityBase
    {
        protected readonly IDbConnection _dbConnection;

        public RepoBase(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public virtual Task<int> DeleteAsync(int id)
        {
            string sql = $"delete from {GetTableName(typeof(T))} where id = @id";

            return _dbConnection.ExecuteAsync(sql, new { id = id });
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            string sql = $"select * from {GetTableName(typeof(T))}";
            return _dbConnection.QueryAsync<T>(sql);
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            string sql = $"select * from {GetTableName(typeof(T))} where id = @id";
            return _dbConnection.QueryFirstOrDefaultAsync<T>(sql, new { id = id });
        }

        public virtual Task<int> InsertAsync(T obj)
        {
            string sql = $"insert into {GetTableName(typeof(T))} ({GetCsvProps(typeof(T))}) values({GetCsvPropsParams(typeof(T))})";

            return _dbConnection.ExecuteAsync(sql, obj);
        }

        public virtual Task<int> UpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }


        #region Helpers
        private static string GetTableName(Type t)
        {
            return t.Name;
        }
        private static string GetCsvProps(Type t)
        {
            var props = t.GetProperties();
            return string.Join(",", props.Select(x => x.Name));
        }
        private static string GetCsvPropsParams(Type t)
        {
            var props = t.GetProperties();
            return string.Join(",", props.Select(x => "@" + x.Name));
        }
        #endregion
    }
}
