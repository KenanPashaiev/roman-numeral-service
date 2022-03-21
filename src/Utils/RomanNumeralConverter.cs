using System.Text;
using RomanNumeralService.Utils.Abstractions;

namespace RomanNumeralService.Utils
{
    public class RomanNumeralConverter : IRomanNumeralConverter
    {
        public int[] Numbers = {100, 90, 50, 40, 10, 9, 5, 4, 1};
        public string[] RomanSymbols = {"C","XC","L","XL","X","IX","V","IV","I"};

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
