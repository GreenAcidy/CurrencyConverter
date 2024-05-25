namespace CurrencyConverter.Interfaces
{
    /// <summary>
    /// Interface ICurrencyValidator sets behaviour of validation currency value.
    /// </summary>
    internal interface ICurrencyValidator
    {
        /// <summary>
        /// Metod validate input float value.
        /// </summary>
        /// <param name="value"> Input float value.</param>
        public void ValidateValue(float value);

        /// <summary>
        /// Metod validate input string name.
        /// </summary>
        /// <param name="name">Input name.</param>
        public void ValidateNameOfCurrency(string name);

        /// <summary>
        /// Metod validate input date.
        /// </summary>
        /// <param name="date">Input date.</param>
        public void ValidateCurrencyDate(DateTime date);
    }
}
