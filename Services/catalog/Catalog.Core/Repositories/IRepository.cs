using System.Linq.Expressions;
using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
    }
}
