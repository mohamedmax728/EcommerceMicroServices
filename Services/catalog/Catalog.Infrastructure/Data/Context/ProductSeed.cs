using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Context
{
    public static class ProductSeed
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static IEnumerable<Product> GetSeedData(IMongoCollection<Product> products)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "products.json");
            using var stream = File.OpenRead(path);
            var data = JsonSerializer.Deserialize<List<Product>>(stream, Options)
                       ?? new List<Product>();
            products.InsertMany(data);
            return data;
        }
    }
}
