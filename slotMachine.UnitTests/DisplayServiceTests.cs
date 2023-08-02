using slotMachine.Entities;
using slotMachine.Services;

namespace slotMachine.UnitTests
{
    public class DisplayServiceTests
    {
        static readonly Symbol[] AllSymbols = new Symbol[]
        {
            new Symbol("A", 0.45m, 0.4m),
            new Symbol("B", 0.35m, 0.6m),
            new Symbol("P", 0.15m, 0.8m),
            new Symbol("*", 0.05m, 0)
        };

        [Fact]
        public void WelcomeMessage_PrintsCorrectMessage()
        {
            // Arrange
            DisplayService displayService = new DisplayService();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var expectedMessage = "/******/WELCOME TO THE SLOT MACHINE GAME!/******/\n\n\r\n";

            // Act
            displayService.WelcomeMessage();
            var actualMessage = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void EnterBalanceMessage_PrintsCorrectMessage()
        {
            // Arrange
            DisplayService displayService = new DisplayService();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var expectedMessage = "Please deposit money you would like to play with:\r\n";

            // Act
            displayService.EnterBalanceMessage();
            var actualMessage = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void EnterStakeMessage_PrintsCorrectMessage()
        {
            // Arrange
            DisplayService displayService = new DisplayService();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var expectedMessage = "Enter stake amount:\r\n";

            // Act
            displayService.EnterStakeMessage();
            var actualMessage = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void WinMessage_PrintsCorrectMessage()
        {
            // Arrange
            DisplayService displayService = new DisplayService();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var profits = 10.25m;
            var expectedMessage = $"You have won: {profits}$\r\n";

            // Act
            displayService.WinMessage(profits);
            var actualMessage = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void BalanceMessage_PrintsCorrectMessage()
        {
            // Arrange
            DisplayService displayService = new DisplayService();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var balance = 120.90m;
            var expectedMessage = $"Current balance is: {balance}$\n\r\n";

            // Act
            displayService.ActualBalanceMessage(balance);
            var actualMessage = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void NoFundsMessage_PrintsCorrectMessage()
        {
            // Arrange
            DisplayService displayService = new DisplayService();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var expectedMessage = "Not enough funds. Put a lower bet and try again.\n\r\n";

            // Act
            displayService.NoFundsMessage();
            var actualMessage = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void DisplayReels_ShouldDisplaySymbolsInReelsCorrectly()
        {
            // Arrange
            var displayService = new DisplayService();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Set up the reels with test symbols
            Symbol[][] testReels = new Symbol[][]
            {
                new Symbol[] { AllSymbols[0], AllSymbols[1], AllSymbols[2] },
                new Symbol[] { AllSymbols[3], AllSymbols[2], AllSymbols[1] },
                new Symbol[] { AllSymbols[1], AllSymbols[3], AllSymbols[2] }
            };

            var expectedOutput = "[A] [B] [P] \r\n[*] [P] [B] \r\n[B] [*] [P] \r\n\r\n";

            // Act
            displayService.DisplayReels(testReels);
            var actualOutput = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GameOverMessage_PrintsCorrectMessage()
        {
            // Arrange
            DisplayService displayService = new DisplayService();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var expectedMessage = "You don't have more balance.\n\nGAME OVER\n\r\n";

            // Act
            displayService.GameOverMessage();
            var actualMessage = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void InvalidAmountMessage_PrintsCorrectMessage()
        {
            // Arrange
            DisplayService displayService = new DisplayService();
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            var expectedMessage = "Invalid input. Amount must be a positive number.\n\r\n";

            // Act
            displayService.InvalidAmountMessage();
            var actualMessage = consoleOutput.ToString();

            // Assert
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}
