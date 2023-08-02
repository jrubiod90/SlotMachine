using slotMachine.Interfaces;

namespace slotMachine.Services
{
    /// <summary>
    /// Represents a monetary service.
    /// </summary>
    public class MonetaryService : IMonetaryService
    {
        /// <summary>
        /// Actual money balace.
        /// </summary>
        private decimal balance { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MonetaryService()
        {
            balance = 0;
        }

        /// <summary>
        /// Add a specific amount to actual balance.
        /// </summary>
        /// <param name="amount">Amount to add to the balance.</param>
        public void AddAmountToBalance(decimal amount)
        {
            var newBalance = balance + amount;
            if (newBalance >= 0)
            {
                balance = newBalance;
            }
            else
            {
                throw new Exception("You can't have negative balance");
            }
        }

        /// <summary>
        /// Calculate corresponding prize with coefficient and stake introduced by user.
        /// </summary>
        /// <param name="coefficient">Coefficient to multiplicate the stake.</param>
        /// <param name="stake">Stake bet by the user.</param>
        /// <returns>Corresponding prize.</returns>
        public decimal CalculatePrize(decimal coefficient, decimal stake)
        {
            var prize = Math.Round(coefficient * stake * 100) / 100;

            if (prize >= 0)
            {
               return prize;
            }
            else
            {
                throw new Exception("You can't have negative prize");
            }
        }

        /// <summary>
        /// Return actual balance.
        /// </summary>
        /// <returns>Actual money balance.</returns>
        public decimal GetActualBalance()
        {
            return Math.Round(balance * 100) / 100;
        }
    }
}
