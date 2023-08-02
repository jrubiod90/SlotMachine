using slotMachine.Entities;

namespace slotMachine.Interfaces
{
    /// <summary>
    /// Represents a game logic service.
    /// </summary>
    public interface IGameLogicService
    {
        /// <summary>
        /// Checks for winning combinations and calculates the prize amount based on the stake.
        /// </summary>
        /// <param name="stake">The amount of money bet by the player.</param>
        /// <param name="reels">The reels symbols result in the bet.</param>
        /// <returns>The prize amount won by the player.</returns>
        public decimal CheckWinAndCalculatePrize(decimal stake, Symbol[][] reels);
        /// <summary>
        /// Calculate the sum coefficent to multiplicate the bet of the symbols results in a reel.
        /// </summary>
        /// <param name="reel">Reel that we wanted to calculate the coefficient.</param>
        /// <returns>The sum coefficient.</returns>
        public decimal CalculateCoefficent(Symbol[] reel);
        /// <summary>
        /// Spin the reels to have a random combination of symbols.
        /// </summary>
        /// <returns>Reels with random combination.</returns>
        public Symbol[][] SpinReels();
    }
}
