using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RomanNumeralService.Controllers;
using RomanNumeralService.Converters;
using RomanNumeralService.Models;
using RomanNumeralService.Validators;
using Xunit;

namespace RomanNumeralService.ComponentTest
{
    public class RomanNumeralControllerTests
    {
        private readonly RomanNumeralController romanNumeralController;

        public RomanNumeralControllerTests()
        {
            this.romanNumeralController = new RomanNumeralController(
                new RomanNumeralConverter(),
                new RomanNumeralRequestValidator());
        }

        [Theory]
        [MemberData(nameof(TheoryData))]
        public void RomanNumeralController_ConvertToRomanNumeral_ReturnsRomanNumeral((int query, string output) t)
        {
            var request = new RomanNumeralRequest()
            {
                Query = t.query
            };

            var result = (OkObjectResult)romanNumeralController.ConvertToRomanNumeral(request);
            var romanNumeralResponse = (RomanNumeralResponse)result.Value;
            romanNumeralResponse.Output.Should().Be(t.output);
        }

        [Theory]
        [MemberData(nameof(BadRequestTheoryData))]
        public void RomanNumeralController_ConvertToRomanNumeral_ReturnsBadRequest((int query, string errorMessage) t)
        {
            var request = new RomanNumeralRequest()
            {
                Query = t.query
            };

            var result = (BadRequestObjectResult)romanNumeralController.ConvertToRomanNumeral(request);
            var validationFailures = (List<ValidationFailure>)result.Value;
            validationFailures[0].ErrorMessage.Should().Be(t.errorMessage);
        }

        public static TheoryData<(int number, string output)> TheoryData =>
            new TheoryData<(int number, string output)>
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

        public static TheoryData<(int number, string output)> BadRequestTheoryData =>
            new TheoryData<(int number, string output)>
            {
                (-1, "'Query' must be between 1 and 255. You entered -1."),
                (0, "'Query' must be between 1 and 255. You entered 0."),
                (256, "'Query' must be between 1 and 255. You entered 256."),
            };
    }
}
