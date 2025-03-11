namespace CenterfieldAPI.Test
{
    public class CoffeShopTest
    {
        ////Unit Test (Happy Path)
        //[Fact]
        //public async Task GetCoffeeShopById_ReturnsCoffeeShop_WhenIdIsValid()
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();
        //    var coffeeShopId = 1;

        //    // Act
        //    var response = await client.GetAsync($"/api/coffeeshops/{coffeeShopId}");

        //    // Assert
        //    response.EnsureSuccessStatusCode();
        //    var content = await response.Content.ReadAsStringAsync();
        //    var coffeeShop = JsonConvert.DeserializeObject<CoffeeShop>(content);
        //    Assert.Equal("Centerfield Coffee", coffeeShop.Name);
        //    Assert.Equal("123 Main St", coffeeShop.Location);
        //}

        ////Integration Test (Database Interaction)
        //[Fact]
        //public async Task GetCoffeeShopById_ReturnsNotFound_WhenIdDoesNotExist()
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();
        //    var invalidId = 999;

        //    // Act
        //    var response = await client.GetAsync($"/api/coffeeshops/{invalidId}");

        //    // Assert
        //    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        //}

        ////Functional Test (Creating a New Coffee Shop)
        //[Fact]
        //public async Task CreateCoffeeShop_ReturnsCreated_WhenValidDataProvided()
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();
        //    var newCoffeeShop = new
        //    {
        //        Name = "New Coffee Spot",
        //        Location = "456 Elm St"
        //    };

        //    var content = new StringContent(JsonConvert.SerializeObject(newCoffeeShop), Encoding.UTF8, "application/json");

        //    // Act
        //    var response = await client.PostAsync("/api/coffeeshops", content);

        //    // Assert
        //    Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        //    var createdShop = JsonConvert.DeserializeObject<CoffeeShop>(await response.Content.ReadAsStringAsync());
        //    Assert.Equal("New Coffee Spot", createdShop.Name);
        //}

        ////Security Test (Unauthorized Access)
        //[Fact]
        //public async Task GetCoffeeShops_ReturnsUnauthorized_WhenNoTokenProvided()
        //{
        //    // Arrange
        //    var client = _factory.CreateClient(); // No authentication token set

        //    // Act
        //    var response = await client.GetAsync("/api/coffeeshops");

        //    // Assert
        //    Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        //}

        ////Performance Test (Response Time)
        //[Fact]
        //public async Task GetCoffeeShops_ResponseTimeUnder200ms()
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();
        //    var stopwatch = Stopwatch.StartNew();

        //    // Act
        //    var response = await client.GetAsync("/api/coffeeshops");

        //    stopwatch.Stop();

        //    // Assert
        //    Assert.True(stopwatch.ElapsedMilliseconds < 200, $"Response time too slow: {stopwatch.ElapsedMilliseconds}ms");
        //}

        ////Error Handling Test (Invalid Input)
        //[Fact]
        //public async Task CreateCoffeeShop_ReturnsBadRequest_WhenNameIsMissing()
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();
        //    var invalidCoffeeShop = new { Location = "789 Oak St" }; // Missing "Name"

        //    var content = new StringContent(JsonConvert.SerializeObject(invalidCoffeeShop), Encoding.UTF8, "application/json");

        //    // Act
        //    var response = await client.PostAsync("/api/coffeeshops", content);

        //    // Assert
        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        //}



    }
}
