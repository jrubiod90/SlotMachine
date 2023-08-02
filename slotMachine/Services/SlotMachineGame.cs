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
            displayService.WelcomeMessage();
            decimal balance = inputService.ReadBalance();

            monetaryService.AddAmountToBalance(balance);
            while (monetaryService.GetActualBalance() > 0)
            {
                ;
                decimal stake = inputService.ReadStake();
                if (monetaryService.GetActualBalance() - stake >= 0)
                {
                    monetaryService.AddAmountToBalance(-stake);
                    reels = gameLogic.SpinReels();
                    displayService.DisplayReels(reels);
                    var prize = gameLogic.CheckWinAndCalculatePrice(stake, reels);
                    monetaryService.AddAmountToBalance(prize);
                    displayService.WinMessage(prize);
                    displayService.ActualBalanceMessage(monetaryService.GetActualBalance());
                }
                else
                {
                    displayService.NoFundsMessage();
                }
            }
            displayService.GameOverMessage();
        }
    }
}
