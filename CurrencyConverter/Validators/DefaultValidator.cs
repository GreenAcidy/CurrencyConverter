using CurrencyConverter.Interfaces;

namespace CurrencyConverter.Validators
{
    /// <summary>
    /// Class DefaultValidator contains default methods of validation currency value.
    /// </summary>
    public class DefaultValidator : ICurrencyValidator
    {
        private readonly IExchangeRatesQuery exchangeRatesQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultValidator"/> class.
        /// </summary>
        /// <param name="exchangeRatesQuery">Input class for woking with mockdata.</param>
        public DefaultValidator(IExchangeRatesQuery exchangeRatesQuery)
        {
            this.exchangeRatesQuery = exchangeRatesQuery;
        }

        /// <summary>
        /// Metod validate input float value.
        /// </summary>
        /// <param name="value"> Input float value.</param>
        /// <exception cref="ArgumentException">if value is negative or more than float max value.</exception>
        public void ValidateValue(float value)
        {
            if (value < 0 || value > float.MaxValue)
            {
                throw new ArgumentException("Value must be not negative or less than 3.40282346638528859e+38");
            }
        }

        /// <summary>
        /// Metod validate input string name.
        /// </summary>
        /// <param name="name">Input name.</param>
        /// <exception cref="ArgumentNullException">if name is null.</exception>
        /// <exception cref="ArgumentException">if name contains not 3 symbols or does not correspond to the supported currencies.</exception>
        public void ValidateNameOfCurrency(string name)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name), "Must not be null!");
            }

            if (name.Length != 3)
            {
                throw new ArgumentException("Must contain 3 symbols");
            }

            if (this.exchangeRatesQuery.FindCurrency(name) == null)
            {
                throw new ArgumentException("Must be selected from the list of suggested currencies", nameof(name));
            }
        }

        /// <summary>
        /// Metod validate input date.
        /// </summary>
        /// <param name="date">Input date.</param>
        /// <exception cref="ArgumentException">Does not correspond to the available dates.</exception>
        public void ValidateCurrencyDate(DateTime date)
        {
            if (this.exchangeRatesQuery.FindDate(date) == default)
            {
                throw new ArgumentException("Must be selected from the list of suggested dates", nameof(date));
            }
        }
    }
}
