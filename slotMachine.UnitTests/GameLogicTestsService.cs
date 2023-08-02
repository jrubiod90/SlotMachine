using slotMachine.Entities;
using slotMachine.Interfaces;
using slotMachine.Services;

namespace slotMachine.UnitTests
{
    public class GameLogicTestsService
    {
        static readonly Symbol[] AllSymbols = new Symbol[]
        {
            new Symbol("A", 0.45m, 0.4m),
            new Symbol("B", 0.35m, 0.6m),
            new Symbol("P", 0.15m, 0.8m),
            new Symbol("*", 0.05m, 0)
        };

        [Fact]
        public void CheckWinAndCalculatePrice_ShouldCalculateCorrectPrize()
        {
            // Arrange
            var mockSymbolsService = new Mock<ISymbolsService>();
            var mockMonetaryService = new Mock<IMonetaryService>();
            var gameLogicService = new GameLogicService(mockMonetaryService.Object, mockSymbolsService.Object);

            var reel = new Symbol[] { AllSymbols[0], AllSymbols[0], AllSymbols[0] };

            Symbol[][] reels = new Symbol[][]
            {
                reel,
                reel,
                reel,
                reel
            };

            mockMonetaryService.Setup(input => input.CalculatePrize(1.2m, 5)).Returns(100);

            // Act
            decimal prize = gameLogicService.CheckWinAndCalculatePrize(5, reels);

            // Assert
            Assert.Equal(400, prize);
        }

        [Fact]
        public void CalculateCoefficent_ShouldReturnCorrectCoefficientSum()
        {
            // Arrange
            var reel = new Symbol[] { AllSymbols[0], AllSymbols[1], AllSymbols[2] };

            var mockSymbolsService = new Mock<ISymbolsService>();
            var mockMonetaryService = new Mock<IMonetaryService>();
            var gameLogicService = new GameLogicService(mockMonetaryService.Object, mockSymbolsService.Object);

            // Act
            decimal coefficientSum = gameLogicService.CalculateCoefficent(reel);

            // Assert
            Assert.Equal(1.8m, coefficientSum);
        }

        [Fact]
        public void SpinReels_ReturnsExpectedReels()
        {
            // Arrange
            var mockSymbolsService = new Mock<ISymbolsService>();
            var mockMonetaryService = new Mock<IMonetaryService>();
            var gameLogicService = new GameLogicService(mockMonetaryService.Object, mockSymbolsService.Object);

            // Set up the symbols for each reel
            var reel1 = new Symbol[] { AllSymbols[0], AllSymbols[1], AllSymbols[2] };
            var reel2 = new Symbol[] { AllSymbols[3], AllSymbols[0], AllSymbols[1] };
            var reel3 = new Symbol[] { AllSymbols[2], AllSymbols[3], AllSymbols[0] };
            var reel4 = new Symbol[] { AllSymbols[1], AllSymbols[2], AllSymbols[3] };

            // Set up the symbols service mock to return specific symbols for each reel
            mockSymbolsService.SetupSequence(service => service.GetRandomSymbol())
                              .Returns(reel1[0])
                              .Returns(reel1[1])
                              .Returns(reel1[2])
                              .Returns(reel2[0])
                              .Returns(reel2[1])
                              .Returns(reel2[2])
                              .Returns(reel3[0])
                              .Returns(reel3[1])
                              .Returns(reel3[2])
                              .Returns(reel4[0])
                              .Returns(reel4[1])
                              .Returns(reel4[2]);

            // Act
            var reels = gameLogicService.SpinReels();

            // Assert
            Assert.Equal(4, reels.Length);

            Assert.Equal(reel1, reels[0]);
            Assert.Equal(reel2, reels[1]);
            Assert.Equal(reel3, reels[2]);
            Assert.Equal(reel4, reels[3]);
        }
    }
}
