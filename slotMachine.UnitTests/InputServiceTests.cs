using slotMachine.Interfaces;
using slotMachine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotMachine.UnitTests
{
    public class InputServiceTests
    {

        [Fact]
        public void ReadStake_ShouldReturnValidStakeAmount()
        {
            // Arrange
            var mockDisplayService = new Mock<IDisplayService>();
            var inputService = new InputService(mockDisplayService.Object);

            decimal testStake = 50;

            mockDisplayService.SetupSequence(d => d.EnterStakeMessage());

            mockDisplayService.Setup(d => d.InvalidAmountMessage());


            // Act
            Console.SetIn(new StringReader(testStake.ToString()));
            decimal result = inputService.ReadStake();

            // Assert
            Assert.Equal(testStake, result);
        }

        [Fact]
        public void ReadBalance_ShouldReturnValidBalanceAmount()
        {
            // Arrange
            var mockDisplayService = new Mock<IDisplayService>();
            var inputService = new InputService(mockDisplayService.Object);

            decimal testBalance = 500;

            mockDisplayService.SetupSequence(d => d.EnterBalanceMessage());

            // Act
            Console.SetIn(new StringReader(testBalance.ToString()));
            decimal result = inputService.ReadStake();

            // Assert
            Assert.Equal(testBalance, result);
        }
    }
}
