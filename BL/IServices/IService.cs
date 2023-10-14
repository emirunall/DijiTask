using OL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.IServices
{
    public interface IService<T> where T : BaseEntity
    {
        Task<bool> CreateAsync(T TEntity);
        Task<bool> UpdateAsync(T Tentity);
        Task<T> GetByIdAsync(int id);
        Task<T> RemoveAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);
    }
}
