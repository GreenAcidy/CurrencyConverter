using CurrencyConverter.Interfaces;

namespace CurrencyConverter.Services
{
    /// <summary>
    /// The class CurrencyService is used to call the summation method.
    /// </summary>
    internal class CurrencyService : ICurrencyService
    {
        private readonly IExchangeRatesQuery exchangeRatesQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyService"/> class.
        /// </summary>
        /// <param name="exchangeRatesQuery">Input class for woking with mockdata.</param>
        public CurrencyService(IExchangeRatesQuery exchangeRatesQuery)
        {
            this.exchangeRatesQuery = exchangeRatesQuery;
        }

        /// <summary>
        /// Method receives two currency values, the names of these currencies, converts and sums them in the third currency.
        /// </summary>
        /// <param name="date">Date of exchange rates.</param>
        /// <param name="firstCurr">First name of currency.</param>
        /// <param name="firstNumber">First value of currency.</param>
        /// <param name="secondCurr">Second name of currency.</param>
        /// <param name="secondNumber">Second value of currency.</param>
        /// <param name="thirdCurr">result name of currency.</param>
        /// <returns>Return converted by exchange rates  sum of two values.</returns>
        public float Sum(DateTime date, string firstCurr, float firstNumber, string secondCurr, float secondNumber, string thirdCurr)
        {
            var firstValue = this.exchangeRatesQuery.GetExchangeRatesForCurrency(date, firstCurr);

            var secondValue = this.exchangeRatesQuery.GetExchangeRatesForCurrency(date, secondCurr);

            var thirdValue = this.exchangeRatesQuery.GetExchangeRatesForCurrency(date, thirdCurr);

            var result = MathF.Round(((firstNumber * firstValue) + (secondNumber * secondValue)) / thirdValue, 4);

            return result;
        }

        /// <summary>
        /// Method return days of exchange rates.
        /// </summary>
        /// <returns>days of exchange rates.</returns>
        public IEnumerable<DateTime> GetDays()
        {
            var result = this.exchangeRatesQuery.GetDays();

            return result;
        }

        /// <summary>
        /// Method return available exchange rates.
        /// </summary>
        /// <returns>Exchange rates.</returns>
        public IEnumerable<string> GetCurrencies()
        {
            var result = this.exchangeRatesQuery.GetAvailableCurrencies();

            return result;
        }
    }
}
