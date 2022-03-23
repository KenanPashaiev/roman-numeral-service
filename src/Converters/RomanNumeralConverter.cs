using System.Text;
using RomanNumeralService.Converters.Abstractions;

namespace RomanNumeralService.Converters
{
    ///<inheritdoc/>
    public class RomanNumeralConverter : IRomanNumeralConverter
    {
        private int[] Numbers = {100, 90, 50, 40, 10, 9, 5, 4, 1};
        private string[] RomanSymbols = {"C","XC","L","XL","X","IX","V","IV","I"};

        ///<inheritdoc/>
        public string ToRomanNumeral(int number)
        {
            var stringBuilder = new StringBuilder();
            for(int i = 0, num = number; i < Numbers.Length && num > 0; i++)
            {
                while(Numbers[i] <= num)
                {
                    num -= Numbers[i];
                    stringBuilder.Append(RomanSymbols[i]);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
