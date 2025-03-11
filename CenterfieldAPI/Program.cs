
using CenterfieldAPI.Database;
using CenterfieldAPI.Features.CoffeeShops;
using CenterfieldAPI.Features.CoffeeShops.CreateCoffeeShop;
using Microsoft.Extensions.DependencyInjection;

namespace CenterfieldAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var connString = builder.Configuration.GetConnectionString("CoffeeShopConnStr");
            builder.Services.AddSqlite<CoffeeShopContext>(connString);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //Map all Coffeeshop Endpoints
            app.MapCoffeeShops();

            //Prepopulate Database
            app.InitializeDb();

            app.Run();
        }
    }
}
