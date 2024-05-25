namespace CurrencyConverter.Mock.Models
{
    /// <summary>
    /// Class ExchangeRates contain exchange rate statistics by date.
    /// </summary>
    public class ExchangeRatesToRub
    {
        /// <summary>
        /// Gets or sets date of exchange rates.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets list of currencies.
        /// </summary>
        public IEnumerable<Сurrency> Currencies { get; set; }
    }
}
