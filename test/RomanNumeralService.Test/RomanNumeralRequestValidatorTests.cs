using System.Linq;
using FluentAssertions;
using FluentValidation;
using RomanNumeralService.Models;
using RomanNumeralService.Validators;
using Xunit;

namespace RomanNumeralServiceTest.Test
{
    public class RomanNumeralRequestValidatorTests
    {
        private readonly IValidator<RomanNumeralRequest> romanNumeralRequestValidator;

        public RomanNumeralRequestValidatorTests()
        {
            this.romanNumeralRequestValidator = new RomanNumeralRequestValidator();
        }

        [Theory]
        [MemberData(nameof(TheoryData))]
        public void RomanNumeralRequestValidator_Validate_ReturnsNoErrors(int query)
        {
            var request = new RomanNumeralRequest()
            {
                Query = query
            };

            var validationResult = romanNumeralRequestValidator.Validate(request);

            validationResult.Errors.Count.Should().Be(0);
        }

        [Theory]
        [MemberData(nameof(ErrorTheoryData))]
        public void RomanNumeralRequestValidator_Validate_ReturnsError((int query, string errorCode) t)
        {
            var request = new RomanNumeralRequest()
            {
                Query = t.query
            };

            var validationResult = romanNumeralRequestValidator.Validate(request);

            var error = validationResult.Errors.Single();
            error.PropertyName = nameof(request.Query);
            error.ErrorCode.Should().Be(t.errorCode);
        }

        public static TheoryData<int> TheoryData =>
            new TheoryData<int>
            {
                1,
                2,
                4,
                5,
                9,
                10,
                40,
                50,
                90,
                100,
                213,
                255,
            };

        public static TheoryData<(int query, string errorCode)> ErrorTheoryData =>
            new TheoryData<(int query, string errorCode)>
            {
                (-1, "InclusiveBetweenValidator"),
                (0, "InclusiveBetweenValidator"),
                (256, "InclusiveBetweenValidator"),
                (257, "InclusiveBetweenValidator"),
            };
    }
}
