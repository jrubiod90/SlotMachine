using slotMachine.Entities;
using slotMachine.Interfaces;
using slotMachine.Services;

namespace slotMachine.UnitTests
{
    public class SlotMachineGameTests
    {
        [Fact]
        public void StartGame_ShouldWorkAsExpected()
        {
            // Arrange
            var mockDisplayService = new Mock<IDisplayService>();
            var mockMonetaryService = new Mock<IMonetaryService>();
            var mockGameLogic = new Mock<IGameLogicService>();
            var mockSymbolsService = new Mock<ISymbolsService>();
            var mockInputService = new Mock<IInputService>();
            var slotMachineGame = new SlotMachineGame(mockDisplayService.Object, mockMonetaryService.Object, mockGameLogic.Object, mockSymbolsService.Object, mockInputService.Object);

            // Configure mock interactions
            decimal testBalance = 500;
            decimal testStake = 50;
            decimal testPrize = 100;

            mockInputService.Setup(input => input.ReadBalance()).Returns(testBalance);
            mockInputService.Setup(input => input.ReadStake()).Returns(testStake);

            mockDisplayService.Setup(d => d.EnterBalanceMessage());
            mockDisplayService.Setup(d => d.EnterStakeMessage());
            mockDisplayService.Setup(d => d.WelcomeMessage());
            mockDisplayService.Setup(d => d.InvalidAmountMessage());
            mockDisplayService.Setup(d => d.GameOverMessage());
            mockDisplayService.Setup(d => d.NoFundsMessage());
            mockDisplayService.Setup(d => d.DisplayReels(It.IsAny<Symbol[][]>()));
            mockDisplayService.Setup(d => d.WinMessage(testPrize));
            mockDisplayService.Setup(d => d.ActualBalanceMessage(testBalance - testStake - testPrize));

            mockGameLogic.Setup(gl => gl.CheckWinAndCalculatePrize(testStake, It.IsAny<Symbol[][]>())).Returns(testPrize);

            mockMonetaryService.SetupSequence(ms => ms.GetActualBalance())
                .Returns(testBalance)
                .Returns(testBalance - testStake)
                .Returns(testBalance - testStake - testPrize)
                .Returns(0);

            // Act
            slotMachineGame.StartGame();

            // Assert
            mockDisplayService.Verify(d => d.WelcomeMessage(), Times.Once);
           mockInputService.Verify(d => d.ReadBalance(), Times.Exactly(1));
            mockInputService.Verify(d => d.ReadStake(), Times.AtLeastOnce);
            mockDisplayService.Verify(d => d.DisplayReels(It.IsAny<Symbol[][]>()), Times.AtLeastOnce);
            mockDisplayService.Verify(d => d.WinMessage(testPrize), Times.Once);
            mockDisplayService.Verify(d => d.ActualBalanceMessage(testBalance - testStake - testPrize), Times.Once);
            mockMonetaryService.Verify(ms => ms.AddAmountToBalance(testPrize), Times.Once);
            mockDisplayService.Verify(d => d.GameOverMessage(), Times.Once);

        }

    }
}
