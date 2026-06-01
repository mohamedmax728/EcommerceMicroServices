using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductBrandRepository : RepositoryBase<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}
