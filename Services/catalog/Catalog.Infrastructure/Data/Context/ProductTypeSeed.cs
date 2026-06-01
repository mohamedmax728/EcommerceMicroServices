using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Context
{
    public static class ProductTypeSeed
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static IEnumerable<ProductType> GetSeedData(IMongoCollection<ProductType> types)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "types.json");
            using var stream = File.OpenRead(path);
            var data = JsonSerializer.Deserialize<List<ProductType>>(stream, Options)
                       ?? new List<ProductType>();
            types.InsertMany(data);
            return data;
        }
    }
}
