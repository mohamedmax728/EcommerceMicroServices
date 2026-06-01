using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Context;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<ProductBrand> Brands { get; }

        public IMongoCollection<ProductType> Types { get; }
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["CatalogDbSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["CatalogDbSettings:DatabaseName"]);

            // Initialize collections here if needed
            Products = database.GetCollection<Product>(configuration["CatalogDbSettings:ProductsCollection"]);
            Brands = database.GetCollection<ProductBrand>(configuration["CatalogDbSettings:BrandsCollection"]);
            Types = database.GetCollection<ProductType>(configuration["CatalogDbSettings:TypesCollection"]);

            _ = ProductBrandSeed.GetSeedData(Brands);
            _ = ProductSeed.GetSeedData(Products);
            _ = ProductTypeSeed.GetSeedData(Types);
        }
    }
}
