using slotMachine.Interfaces;

namespace slotMachine.Services
{
    /// <summary>
    /// Represents a input data service.
    /// </summary>
    public class InputService: IInputService
    {
        /// <summary>
        /// Display messages service.
        /// </summary>
        IDisplayService displayService;

        /// <summary>
        /// Constructor.
        /// </summary>
        public InputService(IDisplayService displayService)
        {
            this.displayService = displayService;
        }

        /// <summary>
        /// Read the data to introduce in stake. If data is invalid shows a message and ask you to try again.
        /// </summary>
        public decimal ReadStake()
        {
            decimal stake;
            while (true)
            {
                displayService.EnterStakeMessage();
                if (decimal.TryParse(Console.ReadLine(), out stake) && stake > 0)
                {
                    return stake;
                }
                displayService.InvalidAmountMessage();
            }
        }

        /// <summary>
        /// Read the data to introduce in balance. If data is invalid shows a message and ask you to try again.
        /// </summary>
        public decimal ReadBalance()
        {
            decimal balance;
            while (true)
            {
                displayService.EnterBalanceMessage();
                if (decimal.TryParse(Console.ReadLine(), out balance) && balance > 0)
                {
                    return balance;
                }
                displayService.InvalidAmountMessage();
            }
        }
    }
}
