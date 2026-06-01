using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductTypeRepository : RepositoryBase<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}
