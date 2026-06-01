using Catalog.Core.Entities;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Context
{
    public static class ProductSeed
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static IEnumerable<Product> GetSeedData()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "products.json");
            using var stream = File.OpenRead(path);
            return JsonSerializer.Deserialize<List<Product>>(stream, Options)
                   ?? new List<Product>();
        }
    }
}
