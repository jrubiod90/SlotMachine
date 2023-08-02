namespace slotMachine.Interfaces
{
    /// <summary>
    /// Represents a monetary service.
    /// </summary>
    public interface IMonetaryService
    {
        /// <summary>
        /// Return actual balance.
        /// </summary>
        /// <returns>Actual money balance.</returns>
        decimal GetActualBalance();
        /// <summary>
        /// Calculate corresponding prize with coefficient and stake introduced by user.
        /// </summary>
        /// <param name="coefficient">Coefficient to multiplicate the stake.</param>
        /// <param name="stake">Stake bet by the user.</param>
        /// <returns>Corresponding prize.</returns>
        decimal CalculatePrize(decimal coefficient, decimal steak);
        /// <summary>
        /// Add a specific amount to actual balance.
        /// </summary>
        /// <param name="amount">Amount to add to the balance.</param>
        void AddAmountToBalance(decimal amount);
    }
}
