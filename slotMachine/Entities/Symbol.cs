namespace slotMachine.Entities
{
    /// <summary>
    /// Represents a symbol in the slot machine game.
    /// </summary>
    public class Symbol
    {
        /// <summary>
        /// Gets or sets the name of the symbol.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the spawn probability associated with the symbol.
        /// </summary>
        public decimal Probability { get; set; }
        /// <summary>
        /// Gets or sets the coefficient to multiplicate with stake associated with the symbol.
        /// </summary>
        public decimal Coefficient { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="coefficient">Coefficient to multiplicate with stake associated with the symbol.</param>
        /// <param name="name">Name of the symbol.</param>
        /// <param name="probability">spawn probability associated with the symbol.</param>
        public Symbol(string name, decimal probability, decimal coefficient)
        {
            Name = name;
            Probability = probability;
            Coefficient = coefficient;
        }
    }
}
