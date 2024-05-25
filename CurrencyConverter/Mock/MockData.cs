using CurrencyConverter.Mock.Models;

namespace CurrencyConverter.Mock
{
    /// <summary>
    /// Class MockData contains exchange rates by day.
    /// </summary>
    public class MockData
    {
        /// <summary>
        /// List of exchange rates by day.
        /// </summary>
        public ExchangeRatesToRub[] ExchangeRates =
        {
            new ExchangeRatesToRub()
            {
                Date = DateTime.Parse("2024-05-23"),
                Currencies = new List<Сurrency>
                {
                    new Сurrency() { CurrencyName = "RUB", CurrencyValue = 1F },
                    new Сurrency() { CurrencyName = "USD", CurrencyValue = 90.4082F },
                    new Сurrency() { CurrencyName = "EUR", CurrencyValue = 98.2971F },
                    new Сurrency() { CurrencyName = "BYN", CurrencyValue = 28.1768F },
                    new Сurrency() { CurrencyName = "PLN", CurrencyValue = 23.0780F },
                },
            },
            new ExchangeRatesToRub()
            {
                Date = DateTime.Parse("2024-04-21"),
                Currencies = new List<Сurrency>
                {
                    new Сurrency() { CurrencyName = "RUB", CurrencyValue = 1F },
                    new Сurrency() { CurrencyName = "USD", CurrencyValue = 93.4409F },
                    new Сurrency() { CurrencyName = "EUR", CurrencyValue = 99.5797F },
                    new Сurrency() { CurrencyName = "BYN", CurrencyValue = 28.6488F },
                    new Сurrency() { CurrencyName = "PLN", CurrencyValue = 22.9652F },
                },
            },
            new ExchangeRatesToRub()
            {
                Date = DateTime.Parse("2024-03-20"),
                Currencies = new List<Сurrency>
                {
                    new Сurrency() { CurrencyName = "RUB", CurrencyValue = 1F },
                    new Сurrency() { CurrencyName = "USD", CurrencyValue = 92.2243F },
                    new Сurrency() { CurrencyName = "EUR", CurrencyValue = 100.1047F },
                    new Сurrency() { CurrencyName = "BYN", CurrencyValue = 28.5021F },
                    new Сurrency() { CurrencyName = "PLN", CurrencyValue = 23.1336F },
                },
            },
            new ExchangeRatesToRub()
            {
                Date = DateTime.Parse("2024-02-19"),
                Currencies = new List<Сurrency>
                {
                    new Сurrency() { CurrencyName = "RUB", CurrencyValue = 1F },
                    new Сurrency() { CurrencyName = "USD", CurrencyValue = 92.5492F },
                    new Сurrency() { CurrencyName = "EUR", CurrencyValue = 99.3523F },
                    new Сurrency() { CurrencyName = "BYN", CurrencyValue = 28.478F },
                    new Сurrency() { CurrencyName = "PLN", CurrencyValue = 22.9508F },
                },
            },
        };
    }
}
