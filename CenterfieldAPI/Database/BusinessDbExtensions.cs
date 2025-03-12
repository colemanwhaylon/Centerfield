using CenterfieldAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace CenterfieldAPI.Database
{
    public static class BusinessDbExtensions
    {
        public static void InitializeDb(this WebApplication app)
        {
            app.MigrateDb();
            app.SeedDb();
        }

        private static void MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            BusinessContext dbContext = scope.ServiceProvider
                                               .GetRequiredService<BusinessContext>();
            dbContext.Database.Migrate();
        }

        private static void SeedDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            BusinessContext dbContext =
                scope.ServiceProvider
                     .GetRequiredService<BusinessContext>();

            if (!dbContext.BusinessTypes.Any())
            {
                var naicsCodes = GetBusinessTypesAsync().Result.Select(r => new BusinessType
                {
                    Id = r.Id,
                    Name = r.Name,
                    Emoji = r.Emoji
                });

                dbContext.BusinessTypes.AddRange(naicsCodes);
                dbContext.SaveChanges();
            }
        }

        private static async Task<IEnumerable<BusinessType>> GetBusinessTypesAsync()
        {
            await using FileStream stream = File.OpenRead("naics.json");
            var naicsCodes = await JsonSerializer.DeserializeAsync<BusinessType>(stream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
            })!;

            return null;
        }
    }
}