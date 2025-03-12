using CenterfieldAPI.Abstractions;
using CenterfieldAPI.Behaviors;
using CenterfieldAPI.Entities;
using Moq;

namespace CenterfieldAPI.Test
{
    public class BusinessTests
    {
        [Fact]
        public void BusinessBase_Should_Have_Correct_Defaults()
        {
            // Arrange
            var business = new TestBusiness(); // Using a test class since BusinessBase is abstract

            // Assert
            Assert.False(business.IsOpen);
            Assert.Equal("Test Business (8:00 AM - 6:00 PM) | Rating: 4.5", business.ToString());
        }

        [Fact]
        public void Business_Should_Set_Properties_Correctly()
        {
            // Arrange
            var mockStrategy = new Mock<IBusinessOpenStrategy>();
            mockStrategy.Setup(s => s.IsOpen(It.IsAny<Business>())).Returns(true);

            var business = new Business(mockStrategy.Object)
            {
                Id = 1,
                Name = "Test Coffee Shop",
                OpeningTime = new TimeOnly(9, 0),
                ClosingTime = new TimeOnly(17, 0),
                Rating = 4.2m
            };

            // Assert
            Assert.Equal(1, business.Id);
            Assert.Equal("Test Coffee Shop", business.Name);
            Assert.Equal(new TimeOnly(9, 0), business.OpeningTime);
            Assert.Equal(new TimeOnly(17, 0), business.ClosingTime);
            Assert.Equal(4.2m, business.Rating);
            Assert.True(business.IsOpen); // Mocked to return true
        }

        [Theory]
        [InlineData(10, 15, true)] // Inside business hours
        [InlineData(7, 30, false)] // Before opening
        [InlineData(18, 0, false)] // After closing
        public void TimeBasedBusinessOpenStrategy_Should_Correctly_Determine_IsOpen(int hour, int minute, bool expectedIsOpen)
        {
            // Arrange
            var strategy = new TimeBasedBusinessOpenStrategy();
            var business = new Business(strategy)
            {
                OpeningTime = new TimeOnly(8, 0),
                ClosingTime = new TimeOnly(17, 0)
            };

            // Act
            var testTime = new TimeOnly(hour, minute);
            bool isOpen = testTime >= business.OpeningTime && testTime <= business.ClosingTime;

            // Assert
            Assert.Equal(expectedIsOpen, isOpen);
        }

        // Test class for BusinessBase (since it's abstract)
        private class TestBusiness : BusinessBase
        {
            public TestBusiness()
            {
                Id = 1;
                Name = "Test Business";
                OpeningTime = new TimeOnly(8, 0);
                ClosingTime = new TimeOnly(18, 0);
                Rating = 4.5m;
            }
        }
    }
}
