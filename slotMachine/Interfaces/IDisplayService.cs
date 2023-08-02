using slotMachine.Entities;

namespace slotMachine.Interfaces
{
    /// <summary>
    /// Represents a display messages service.
    /// </summary>
    public interface IDisplayService
    {
        /// <summary>
        /// Display a welcome message.
        /// </summary>
        void WelcomeMessage();
        /// <summary>
        /// Display an enter stake message.
        /// </summary>
        void EnterStakeMessage();
        /// <summary>
        /// Display an enter balance message.
        /// </summary>
        void EnterBalanceMessage();
        /// <summary>
        /// Display a win message with corresponding prize.
        /// </summary>
        /// <param name="profits">Profits of the victory.</param>
        void WinMessage(decimal profits);
        /// <summary>
        /// Display an actual balance message with corresponding balance amount.
        /// </summary>
        /// <param name="balance">Balance amount.</param>
        void ActualBalanceMessage(decimal balance);
        /// <summary>
        /// Display a no funds message.
        /// </summary>
        void NoFundsMessage();
        /// <summary>
        /// Display an invalid amount message.
        /// </summary>
        void InvalidAmountMessage();
        /// <summary>
        /// Display the symbols of corresponding reels.
        /// </summary>
        /// <param name="reels">Reels to display.</param>
        void DisplayReels(Symbol[][] reels);
        /// <summary>
        /// Display game over message.
        /// </summary>
        void GameOverMessage();
    }

}
