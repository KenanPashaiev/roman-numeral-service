namespace RomanNumeralService.Models
{
    /// <summary>
    /// <see cref="RomanNumeralRequest"/> Request created for integer to roman numeral conversion
    /// </summary>
    public class RomanNumeralRequest
    {
        /// <summary>
        /// Integer to be converted to roman numeral
        /// </summary>
        public int Query { get; set; }
    }
}
