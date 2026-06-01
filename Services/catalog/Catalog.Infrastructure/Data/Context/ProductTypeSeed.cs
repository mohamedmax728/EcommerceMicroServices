using Catalog.Core.Entities;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Context
{
    public static class ProductTypeSeed
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static IEnumerable<ProductType> GetSeedData()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "types.json");
            using var stream = File.OpenRead(path);
            return JsonSerializer.Deserialize<List<ProductType>>(stream, Options)
                   ?? new List<ProductType>();
        }
    }
}
