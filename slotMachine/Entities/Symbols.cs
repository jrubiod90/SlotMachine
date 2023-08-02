namespace slotMachine.Entities
{
    /// <summary>
    /// Represents all possible symbols in a reel.
    /// </summary>
    public static class Symbols
    {
        private static readonly List<Symbol> allSymbols = new List<Symbol>();

        /// <summary>
        /// Sets the list of all possible symbols in a reel.
        /// </summary>
        /// <param name="symbols">The list of symbols to set.</param>
        public static void SetAllSymbols(IEnumerable<Symbol> symbols)
        {
            allSymbols.Clear();
            allSymbols.AddRange(symbols);
        }

        /// <summary>
        /// All possible symbols in a reel.
        /// </summary>
        public static Symbol[] AllSymbols => allSymbols.ToArray();
    }
}
