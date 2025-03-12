using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CenterfieldAPI.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace CenterfieldAPI.Test
{
    public class CoffeeShopTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CoffeeShopTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5119")
            });
        }

        // Unit Test - Ensure CoffeeShop object initializes correctly
        [Fact]
        public void CoffeeShop_DefaultConstructor_SetsDefaults()
        {
            // Act
            var coffeeShop = new CoffeeShop();

            // Assert
            Assert.Equal("No Name Set", coffeeShop.Name);
            Assert.Equal("No Location Set", coffeeShop.Location);
            Assert.Equal(0.0m, coffeeShop.Rating);
        }

        // Unit Test - Ensure required properties are set via constructor
        [Fact]
        public void CoffeeShop_ParameterizedConstructor_SetsProperties()
        {
            // Arrange
            var openingTime = new TimeOnly(8, 0);
            var closingTime = new TimeOnly(18, 0);

            // Act
            var coffeeShop = new CoffeeShop("Java Beans", openingTime, closingTime);

            // Assert
            Assert.Equal("Java Beans", coffeeShop.Name);
            Assert.Equal(openingTime, coffeeShop.OpeningTime);
            Assert.Equal(closingTime, coffeeShop.ClosingTime);
            Assert.Equal("No Location Set", coffeeShop.Location);
            Assert.Equal(0.0m, coffeeShop.Rating);
        }

        // Integration Test - Fetch coffee shop by ID
        [Fact]
        public async Task GetCoffeeShopById_ReturnsCoffeeShop_WhenIdIsValid()
        {
            // Arrange
            var coffeeShopId = Guid.Parse("e45341f3-6068-08dd-b6a2-58202c03655f");

            // Act
            var response = await _client.GetAsync($"coffeeshops/{coffeeShopId}");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var coffeeShop = JsonConvert.DeserializeObject<CoffeeShop>(content);
            Assert.NotNull(coffeeShop);
            Assert.Equal("Hilpert, Lind and Kunze", coffeeShop.Name);
        }

        // Integration Test - Return Not Found for invalid ID
        [Fact]
        public async Task GetCoffeeShopById_ReturnsNotFound_WhenIdDoesNotExist()
        {
            // Arrange
            var invalidId = 999;

            // Act
            var response = await _client.GetAsync($"/api/coffeeshops/{invalidId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // Functional Test - Create new Coffee Shop
        [Fact]
        public async Task CreateCoffeeShop_ReturnsCreated_WhenValidDataProvided()
        {
            // Arrange
            var newCoffeeShop = new
            {
                Name = "The Beanery",
                OpeningTime = "07:00",
                ClosingTime = "19:00",
                Location = "123 Java St"
            };

            var content = new StringContent(JsonConvert.SerializeObject(newCoffeeShop), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/coffeeshops", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var createdShop = JsonConvert.DeserializeObject<CoffeeShop>(await response.Content.ReadAsStringAsync());
            Assert.Equal("The Beanery", createdShop.Name);
        }

        // Security Test - Unauthorized access
        [Fact]
        public async Task GetCoffeeShops_ReturnsUnauthorized_WhenNoTokenProvided()
        {
            // Arrange
            var unauthorizedClient = new HttpClient(); // No authentication

            // Act
            var response = await unauthorizedClient.GetAsync("/api/coffeeshops");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        // Performance Test - Response time under 200ms
        [Fact]
        public async Task GetCoffeeShops_ResponseTimeUnder200ms()
        {
            // Arrange
            var stopwatch = Stopwatch.StartNew();

            // Act
            var response = await _client.GetAsync("/api/coffeeshops");
            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds < 200, $"Response took too long: {stopwatch.ElapsedMilliseconds}ms");
        }

        // Error Handling - Missing Name in request
        [Fact]
        public async Task CreateCoffeeShop_ReturnsBadRequest_WhenNameIsMissing()
        {
            // Arrange
            var invalidCoffeeShop = new
            {
                OpeningTime = "08:00",
                ClosingTime = "18:00",
                Location = "789 Oak St"
            };

            var content = new StringContent(JsonConvert.SerializeObject(invalidCoffeeShop), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/coffeeshops", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
