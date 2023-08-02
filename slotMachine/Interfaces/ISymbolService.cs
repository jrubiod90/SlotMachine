using System;
using slotMachine.Entities;

namespace slotMachine.Interfaces
{
    /// <summary>
    /// Represents Symbols service to get random symbols.
    /// </summary>
    public interface ISymbolsService
    {
        /// <summary>
        /// Returns a random symbol from Symbols taking into account probability.
        /// </summary>
        /// <returns>Random symbol from Symbols</returns>
        Symbol GetRandomSymbol();
    }

}
