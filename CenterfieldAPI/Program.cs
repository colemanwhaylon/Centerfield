
using CenterfieldAPI.Database;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CenterfieldAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });


            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var connString = builder.Configuration.GetConnectionString("CoffeeShopConnStr");//BusinessConnStr
            var businessConnString = builder.Configuration.GetConnectionString("BusinessConnStr");//BusinessConnStr

            builder.Services.AddSqlite<CoffeeShopContext>(connString);
            builder.Services.AddSqlite<BusinessContext>(businessConnString);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //Prepopulate Database
            app.InitializeDb();

            app.Run();
        }


    }
}
