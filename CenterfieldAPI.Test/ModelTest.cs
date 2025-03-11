using CenterfieldAPI.Abstractions;
using CenterfieldAPI.Entities;


namespace CenterfieldAPI.Test
{
    public class ModelTest
    {
        [Fact]
        public void CoffeeShop_ReturnsValidInstance()
        {
            // Arrange
            var openingTime = new TimeOnly(0, 0, 0);//12:00 AM
            var closingTime = new TimeOnly(0, 0, 0);
            var expectedName = "Unnamed CoffeeShop";

            // Act
            CoffeeShopBase coffeeShop = new CoffeeShop(expectedName, openingTime, closingTime);

            // Assert
            Assert.NotNull(coffeeShop);                      // Ensure instance is created
            Assert.False(coffeeShop.Id == Guid.Empty);       // Ensure ID is assigned
            Assert.Equal(expectedName, coffeeShop.Name);     // Ensure Name is set
            Assert.Equal(openingTime, coffeeShop.OpeningTime); // Ensure Opening Time is set
            Assert.Equal(closingTime, coffeeShop.ClosingTime); // Ensure Closing Time is set

            // Optional properties should be null initially
            Assert.Null(coffeeShop.Location);
            Assert.InRange(coffeeShop.Rating, 0.0m, 5.0m);

        }
    }
}
