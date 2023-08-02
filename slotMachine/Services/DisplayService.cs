using slotMachine.Entities;
using slotMachine.Interfaces;

namespace slotMachine.Services
{
    /// <summary>
    /// Represents a display messages service.
    /// </summary>
    public class DisplayService : IDisplayService
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public DisplayService()
        {
        }

        /// <summary>
        /// Display a welcome message.
        /// </summary>
        public void WelcomeMessage()
        {
            Console.WriteLine("/******/WELCOME TO THE SLOT MACHINE GAME!/******/\n\n");
        }

        /// <summary>
        /// Display an enter balance message.
        /// </summary>
        public void EnterBalanceMessage()
        {
            Console.WriteLine("Please deposit money you would like to play with:");
        }

        /// <summary>
        /// Display an enter stake message.
        /// </summary>
        public void EnterStakeMessage()
        {
            Console.WriteLine("Enter stake amount:");
        }

        /// <summary>
        /// Display a win message with corresponding prize.
        /// </summary>
        /// <param name="profits">Profits of the victory.</param>
        public void WinMessage(decimal profits)
        {
            Console.WriteLine($"You have won: {profits}$");
        }

        /// <summary>
        /// Display an actual balance message with corresponding balance amount.
        /// </summary>
        /// <param name="balance">Balance amount.</param>
        public void ActualBalanceMessage(decimal balance)
        {
            Console.WriteLine($"Current balance is: {balance}$\n");
        }

        /// <summary>
        /// Display a no funds message.
        /// </summary>
        public void NoFundsMessage()
        {
            Console.WriteLine($"Not enough funds. Put a lower bet and try again.\n");
        }

        /// <summary>
        /// Display an invalid amount message.
        /// </summary>
        public void InvalidAmountMessage()
        {
            Console.WriteLine($"Invalid input. Amount must be a positive number.\n");
        }

        /// <summary>
        /// Display Game Over message.
        /// </summary>
        public void GameOverMessage()
        {
            Console.WriteLine($"You don't have more balance.\n\nGAME OVER\n");
        }

        /// <summary>
        /// Display the symbols of corresponding reels.
        /// </summary>
        /// <param name="reels">Reels to display.</param>
        public void DisplayReels(Symbol[][] reels)
        {
            foreach (var reel in reels)
            {
                foreach (var symbol in reel)
                {
                    Console.Write($"[{symbol.Name}] ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

