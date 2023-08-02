using slotMachine.Entities;
using slotMachine.Interfaces;

namespace slotMachine.Services
{
    /// <summary>
    /// Represents slot machine game.
    /// </summary>
    public class SlotMachineGame: ISlotMachineGame
    {
        private readonly IDisplayService displayService;
        private readonly IMonetaryService monetaryService;
        private readonly IGameLogicService gameLogic;
        private readonly ISymbolsService symbolsService;
        private readonly IInputService inputService;

        private Symbol[][] reels;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SlotMachineGame(IDisplayService displayService, IMonetaryService monetaryService, IGameLogicService gameLogic, ISymbolsService symbolsService, IInputService inputService)
        {
            this.reels = new Symbol[4][];
            this.displayService = displayService;
            this.monetaryService = monetaryService;
            this.gameLogic = gameLogic;
            this.symbolsService = symbolsService;
            this.inputService = inputService;
        }

        /// <summary>
        /// Start slot machine game.
        /// </summary>
        public void StartGame()
        {
            WelcomeGame();
            while (monetaryService.GetActualBalance() > 0)
            {
                Game();
            }
            EndGame();
        }

        /// <summary>
        /// Display welcome message and get balance.
        /// </summary>
        private void WelcomeGame()
        {
            displayService.WelcomeMessage();
            decimal balance = inputService.ReadBalance();

            monetaryService.AddAmountToBalance(balance);
        }

        /// <summary>
        /// Principal game logic.
        /// </summary>
        private void Game()
        {
            decimal stake = inputService.ReadStake();
            if (monetaryService.GetActualBalance() - stake >= 0)
            {
                monetaryService.AddAmountToBalance(-stake);
                SpinReels();
                CalculatePrize(stake);
            }
            else
            {
                displayService.NoFundsMessage();
            }
        }

        /// <summary>
        /// Spin reels of slot machine.
        /// </summary>
        private void SpinReels()
        {
            reels = gameLogic.SpinReels();
            displayService.DisplayReels(reels);
        }

        /// <summary>
        /// Calculate prize logic
        /// </summary>
        /// <param name="stake">Stake introduced by user.</param>
        private void CalculatePrize(decimal stake)
        {
            var prize = gameLogic.CheckWinAndCalculatePrize(stake, reels);
            monetaryService.AddAmountToBalance(prize);
            displayService.WinMessage(prize);
            displayService.ActualBalanceMessage(monetaryService.GetActualBalance());
        }

        /// <summary>
        /// Prints game over message.
        /// </summary>
        private void EndGame()
        {
            displayService.GameOverMessage();
        }
    }
}
