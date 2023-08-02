using slotMachine.Entities;
using slotMachine.Interfaces;

namespace slotMachine.Services
{
    /// <summary>
    /// Represents Symbols service to get random symbols.
    /// </summary>
    public class SymbolsService : ISymbolsService
    {
        /// <summary>
        /// Random generator.
        /// </summary>
        private Random random;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SymbolsService()
        {
            random = new Random();
        }

        /// <summary>
        /// Returns a random symbol from Symbols taking into account probability.
        /// </summary>
        /// <returns>Random symbol from Symbols</returns>
        public Symbol GetRandomSymbol()
        {
            decimal totalProbability = 0;
            decimal randomValue = new decimal(random.NextDouble());

            foreach (var symbol in Symbols.AllSymbols)
            {
                totalProbability += symbol.Probability;
                if (randomValue < totalProbability)
                    return symbol;
            }

            return Symbols.AllSymbols[0];
        }
    }
}
