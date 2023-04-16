using Balance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance.Core.Interfaces.Repos
{
    public interface IRepoBase<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> InsertAsync(T obj);
        Task<int> UpdateAsync(T obj);
        Task<int> DeleteAsync(int id);
    }
}
