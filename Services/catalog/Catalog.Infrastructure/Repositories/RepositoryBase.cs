using System.Linq.Expressions;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        protected RepositoryBase(IMongoDatabase database)
        {
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null)
        {
            return await _collection.Find(filter ?? FilterDefinition<T>.Empty).ToListAsync();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            var result = await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
            return result.MatchedCount > 0;
        }

        public virtual async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
