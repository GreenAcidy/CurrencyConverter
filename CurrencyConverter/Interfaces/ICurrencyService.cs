namespace CurrencyConverter.Interfaces
{
    /// <summary>
    /// Interface ICurrencyService sets behaviour of working with Currency.
    /// </summary>
    internal interface ICurrencyService
    {
        /// <summary>
        /// Method get data and sum currecy value.
        /// </summary>
        /// <param name="date">Date of exchange rates.</param>
        /// <param name="firstCurr">First name of currency.</param>
        /// <param name="firstNumber">First value of currency.</param>
        /// <param name="secondCurr">Second name of currency.</param>
        /// <param name="secondNumber">Second value of currency.</param>
        /// <param name="thirdCurr">result name of currency.</param>
        /// <returns>Return converted by exchange rates  sum of two values.</returns>
        public float Sum(DateTime date, string firstCurr, float firstNumber, string secondCurr, float secondNumber, string thirdCurr);

        /// <summary>
        /// Method return days of exchange rates.
        /// </summary>
        /// <returns>Days of exchange rates.</returns>
        public IEnumerable<DateTime> GetDays();

        /// <summary>
        /// Method return available exchange rates.
        /// </summary>
        /// <returns>Exchange rates.</returns>
        public IEnumerable<string> GetCurrencies();
    }
}
