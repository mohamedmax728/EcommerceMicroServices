using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}
