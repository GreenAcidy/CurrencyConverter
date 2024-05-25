using CurrencyConverter.Interfaces;
using CurrencyConverter.Mock;
using CurrencyConverter.Mock.Models;

namespace CurrencyConverter.Query
{
    /// <summary>
    /// The class is intended for queries in mockdata.
    /// </summary>
    public class ExchangeRatesQuery : IExchangeRatesQuery
    {
        private readonly MockData mockData;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangeRatesQuery"/> class.
        /// </summary>
        /// <param name="mockData">input mockdata.</param>
        public ExchangeRatesQuery(MockData mockData)
        {
            this.mockData = mockData;
        }

        /// <summary>
        /// The method looks for the currency value on a specific day.
        /// </summary>
        /// <param name="date">Date of exchange rates.</param>
        /// <param name="currency">Name of currency.</param>
        /// <returns>Value of input currency on that day.</returns>
        public float GetExchangeRatesForCurrency(DateTime date, string currency)
        {
            var exchange = this.mockData.ExchangeRates
                .Where(x => x.Date == date.Date)
                .FirstOrDefault().Currencies
                .Where(x => x.CurrencyName == currency.ToUpper())
                .Select(x => x.CurrencyValue)
                .First();

            return exchange;
        }

        /// <summary>
        /// Method сhecks whether the entered currency is in the data. If there is, then returns its value.
        /// </summary>
        /// <param name="input">Input currency.</param>
        /// <returns>Currency or default.</returns>
        public string FindCurrency(string input)
        {
            var exchange = this.mockData.ExchangeRates
                 .FirstOrDefault().Currencies
                 .Where(x => x.CurrencyName == input.ToUpper())
                 .Select(x => x.CurrencyName)
                 .First();

            return exchange;
        }

        /// <summary>
        /// Method checks if the entered date is in the data. If there is, then returns its value.
        /// </summary>
        /// <param name="date">Input date.</param>
        /// <returns> date or default.</returns>
        public DateTime FindDate(DateTime date)
        {
            var exchange = this.mockData.ExchangeRates
                .Where(x => x.Date == date.Date)
                 .Select(x => date.Date)
                 .First();

            return exchange;
        }

        /// <summary>
        /// Metod return list of available days of exchange rates.
        /// </summary>
        /// <returns>List of available days of exchange rates.</returns>
        public IEnumerable<DateTime> GetDays()
        {
            var result = this.mockData.ExchangeRates.Select(x => x.Date);

            return result;
        }

        /// <summary>
        /// Metod return list of available exchange rates.
        /// </summary>
        /// <returns>list of exchange rates.</returns>
        public IEnumerable<string> GetAvailableCurrencies()
        {
            var result = this.mockData.ExchangeRates.FirstOrDefault().Currencies.Select(x => x.CurrencyName);
            return result;
        }
    }
}
