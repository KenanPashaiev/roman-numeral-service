namespace RomanNumeralService.Converters.Abstractions
{
    /// <summary>
    /// <see cref="IRomanNumeralConverter"/> Provides the ability to convert integer to roman numeral
    /// </summary>
    public interface IRomanNumeralConverter
    {
        /// <summary>
        /// Converts integer to roman numeral
        /// </summary>
        /// <returns>Converted roman numeral as string</returns>
        /// <param name="number">The number to convert</param>
        string ToRomanNumeral(int number);
    }
}
