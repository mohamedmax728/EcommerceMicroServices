using Catalog.Core.Entities;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Context
{
    public static class ProductBrandSeed
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static IEnumerable<ProductBrand> GetSeedData()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "brands.json");
            using var stream = File.OpenRead(path);
            return JsonSerializer.Deserialize<List<ProductBrand>>(stream, Options)
                   ?? new List<ProductBrand>();
        }
    }
}
