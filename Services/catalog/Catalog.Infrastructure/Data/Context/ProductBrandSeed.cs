using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Context
{
    public static class ProductBrandSeed
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static IEnumerable<ProductBrand> GetSeedData(IMongoCollection<ProductBrand> brands)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "brands.json");
            using var stream = File.OpenRead(path);
            var data = JsonSerializer.Deserialize<List<ProductBrand>>(stream, Options)
                       ?? new List<ProductBrand>();
            brands.InsertMany(data);
            return data;
        }
    }
}
