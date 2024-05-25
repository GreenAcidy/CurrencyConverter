namespace CurrencyConverter.Interfaces
{
    /// <summary>
    /// Interface IExchangeRatesQuery sets behaviour of working with Data.
    /// </summary>
    public interface IExchangeRatesQuery
    {
        /// <summary>
        /// The method looks for the currency value on a specific day.
        /// </summary>
        /// <param name="date">Date of exchange rates.</param>
        /// <param name="currency">Name of currency.</param>
        /// <returns>Value of input currency on that day.</returns>
        float GetExchangeRatesForCurrency(DateTime date, string currency);

        /// <summary>
        /// the metod return list of available days of exchange rates.
        /// </summary>
        /// <returns>List of available days of exchange rates.</returns>
        IEnumerable<DateTime> GetDays();

        /// <summary>
        /// Metod return list of available exchange rates.
        /// </summary>
        /// <returns>list of exchange rates.</returns>
        public IEnumerable<string> GetAvailableCurrencies();

        /// <summary>
        /// The method checks whether the searched currency is in data.
        /// </summary>
        /// <param name="input">search name of currency.</param>
        /// <returns>Name or default value.</returns>
        public string FindCurrency(string input);

        /// <summary>
        /// The method checks whether the searched date is in data.
        /// </summary>
        /// <param name="date">search date of exchange rages.</param>
        /// <returns>Date or default.</returns>
        public DateTime FindDate(DateTime date);
    }
}
