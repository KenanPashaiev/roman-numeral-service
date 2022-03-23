using FluentAssertions;
using RomanNumeralService.Converters;
using RomanNumeralService.Converters.Abstractions;
using Xunit;

namespace RomanNumeralServiceTest.Test
{
    public class RomanNumeralConverterTests
    {
        private readonly IRomanNumeralConverter romanNumeralConverter;

        public RomanNumeralConverterTests()
        {
            this.romanNumeralConverter = new RomanNumeralConverter();
        }

        [Theory]
        [MemberData(nameof(TheoryData))]
        public void RomanNumeralConverter_ToRomanNumeral_ReturnsRomanNumeral((int query, string output) t)
        {
            var result = romanNumeralConverter.ToRomanNumeral(t.query);
            result.Should().Be(t.output);
        }

        public static TheoryData<(int query, string output)> TheoryData =>
            new TheoryData<(int query, string output)>
            {
                (1, "I"),
                (2, "II"),
                (4, "IV"),
                (5, "V"),
                (9, "IX"),
                (10, "X"),
                (40, "XL"),
                (50, "L"),
                (90, "XC"),
                (100, "C"),
                (213, "CCXIII"),
                (255, "CCLV"),
            };
    }
}
