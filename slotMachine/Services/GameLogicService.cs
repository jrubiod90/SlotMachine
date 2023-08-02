using slotMachine.Entities;
using slotMachine.Interfaces;

namespace slotMachine.Services
{
    /// <summary>
    /// Represents a game logic service.
    /// </summary>
    public class GameLogicService : IGameLogicService
    {
        /// <summary>
        /// Monetary service to calculate money prizes and balance.
        /// </summary>
        private readonly IMonetaryService monetaryService;
        /// <summary>
        /// Symbols service to have random symbols.
        /// </summary>
        private readonly ISymbolsService symbolsService;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GameLogicService(IMonetaryService monetaryService, ISymbolsService symbolsService)
        {
            this.monetaryService = monetaryService;
            this.symbolsService = symbolsService;
        }

        /// <summary>
        /// Checks for winning combinations and calculates the prize amount based on the stake.
        /// </summary>
        /// <param name="stake">The amount of money bet by the player.</param>
        /// <param name="reels">The reels symbols result in the bet.</param>
        /// <returns>The prize amount won by the player.</returns>
        public decimal CheckWinAndCalculatePrize(decimal stake, Symbol[][] reels)
        {
            decimal prize = 0;
            foreach (var reel in reels)
            {
                if (CheckReelWin(reel))
                {
                    prize += monetaryService.CalculatePrize(CalculateCoefficent(reel), stake);
                }
            }
            return prize;
        }

        /// <summary>
        /// Calculate the sum coefficent to multiplicate the bet of the symbols results in a reel.
        /// </summary>
        /// <param name="reel">Reel that we wanted to calculate the coefficient.</param>
        /// <returns>The sum coefficient.</returns>
        public decimal CalculateCoefficent(Symbol[] reel)
        {
            decimal coefficentSum = 0;
            foreach (Symbol symbol in reel)
            {
                coefficentSum += symbol.Coefficient;
            }
            return coefficentSum;
        }

        /// <summary>
        /// Check winning combination.
        /// </summary>
        /// <param name="reel">Reel that we wanted to know if have a win combination.</param>
        /// <returns>True if it's a win combination.</returns>
        private bool CheckReelWin(Symbol[] reel)
        {
            string wildcardSymbol = "*";
            string matchedSymbol = string.Empty;

            foreach (Symbol symbol in reel)
            {
                if (symbol.Name.Equals(wildcardSymbol))
                    continue;

                if (string.IsNullOrEmpty(matchedSymbol))
                    matchedSymbol = symbol.Name;
                else if (matchedSymbol.Equals(symbol.Name))
                    continue;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Spin the reels to have a random combination of symbols.
        /// </summary>
        /// <returns>Reels with random combination.</returns>
        public Symbol[][] SpinReels()
        {
            Symbol[][] reels = new Symbol[4][];
            for (int i = 0; i < reels.Length; i++)
            {
                reels[i] = Enumerable.Range(0, 3).Select(_ => symbolsService.GetRandomSymbol()).ToArray();
            }
            return reels;
        }

    }
}
