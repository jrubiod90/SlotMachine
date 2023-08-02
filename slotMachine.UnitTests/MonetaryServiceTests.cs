using slotMachine.Services;

namespace slotMachine.UnitTests
{
    public class MonetaryServiceTests
    {
        [Fact]
        public void GetActualBalance_ShouldReturnZeroWhenInitialize()
        {
            // Arrange
            var monetaryService = new MonetaryService();

            // Act
            var balance = monetaryService.GetActualBalance();

            // Assert
            Assert.Equal(0, balance);
        }

        [Fact]
        public void GetActualBalance_ShouldReturnBalanceProperly()
        {
            // Arrange
            var monetaryService = new MonetaryService();
            var randonAmount = 100;

            monetaryService.AddAmountToBalance(randonAmount);
            // Act
            var balance = monetaryService.GetActualBalance();

            // Assert
            Assert.Equal(randonAmount, balance);
        }

        [Fact]
        public void CalculatePrize_ShouldCalculateCorrectPrize()
        {
            // Arrange
            var monetaryService = new MonetaryService();
            var random = new Random();
            var testSteak = 10;
            var testCoeficient = 1.2;
            // Act
            var prize = monetaryService.CalculatePrize(new decimal(testCoeficient), testSteak);

            // Assert
            Assert.Equal(12, prize);
        }

        [Fact]
        public void AddAmountToBalance_ShouldAddAmountToBalanceCorrectly()
        {
            // Arrange
            var monetaryService = new MonetaryService();
            var testAmount = 123;

            monetaryService.AddAmountToBalance(testAmount);
            // Act
            var balance = monetaryService.GetActualBalance();

            // Assert
            Assert.Equal(testAmount, balance);
        }

        [Fact]
        public void AddAmountToBalance_ShouldThrowExceptionIfBalanceIsnegative()
        {
            // Arrange
            var monetaryService = new MonetaryService();

            // Act and Assert
            var exception = Assert.Throws<Exception>(() => monetaryService.AddAmountToBalance(-10));
            Assert.Equal("You can't have negative balance", exception.Message);
        }
    }
}
