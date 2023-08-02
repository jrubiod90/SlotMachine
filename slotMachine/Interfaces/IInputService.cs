namespace slotMachine.Interfaces
{
    /// <summary>
    /// Represents a input data service.
    /// </summary>
    public interface IInputService
    {
        /// <summary>
        /// Read the data to introduce in stake. If data is invalid shows a message and ask you to try again.
        /// </summary>
        public decimal ReadStake();
        /// <summary>
        /// Read the data to introduce in balance. If data is invalid shows a message and ask you to try again.
        /// </summary>
        public decimal ReadBalance();
    }
}
