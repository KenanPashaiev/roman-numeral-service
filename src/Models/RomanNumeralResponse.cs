namespace RomanNumeralService.Models
{
    /// <summary>
    /// <see cref="RomanNumeralResponse"/> Response of integer to roman numeral conversion
    /// </summary>
    public class RomanNumeralResponse
    {
        /// <summary>
        /// Integer to be converted to roman numeral
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Result of integer to roman numeral conversion
        /// </summary>
        public string Output { get; set; }
    }
}
