using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RomanNumeralService.Controllers;
using RomanNumeralService.Converters.Abstractions;
using RomanNumeralService.Models;
using RomanNumeralService.Validators;
using Xunit;

namespace RomanNumeralServiceTest.Test
{
    public class RomanNumeralControllerTests
    {
        private readonly RomanNumeralController romanNumeralController;

        public RomanNumeralControllerTests()
        {
            var mockConverter = new Mock<IRomanNumeralConverter>();
            mockConverter.Setup(m => m.ToRomanNumeral(It.IsAny<int>())).Returns(string.Empty);

            this.romanNumeralController = new RomanNumeralController(
                mockConverter.Object,
                new RomanNumeralRequestValidator());
        }

        [Theory]
        [MemberData(nameof(TheoryData))]
        public void RomanNumeralController_ConvertToRomanNumeral_ReturnsOk(int query)
        {
            var request = new RomanNumeralRequest()
            {
                Query = query
            };

            var result = romanNumeralController.ConvertToRomanNumeral(request);

            result.Should().BeOfType<OkObjectResult>();
        }

        [Theory]
        [MemberData(nameof(BadRequestTheoryData))]
        public void RomanNumeralController_ConvertToRomanNumeral_ReturnsBadRequest(int query)
        {
            var request = new RomanNumeralRequest()
            {
                Query = query
            };

            var result = (BadRequestObjectResult)romanNumeralController.ConvertToRomanNumeral(request);

            result.Should().BeOfType<BadRequestObjectResult>();
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

        public static TheoryData<int> BadRequestTheoryData =>
            new TheoryData<int>
            {
                -1,
                0,
                256,
            };
    }
}
