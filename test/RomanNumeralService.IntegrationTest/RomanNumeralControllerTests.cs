using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RomanNumeralService.Models;
using Xunit;

namespace RomanNumeralService.IntegrationTest
{
    public class RomanNumeralControllerTests : IClassFixture<WebApplicationFactory<RomanNumeralService.Startup>>
    {
        private readonly WebApplicationFactory<RomanNumeralService.Startup> _factory;

        public RomanNumeralControllerTests(WebApplicationFactory<RomanNumeralService.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [MemberData(nameof(TheoryData))]
        public async Task RomanNumeralController_ConvertToRomanNumeral_ReturnsRomanNumeral((int query, string output) t)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"/romannumeral?query={t.query.ToString()}");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var romanNumeralResponse = JsonSerializer.Deserialize<RomanNumeralResponse>(responseString, options);
            romanNumeralResponse.Input.Should().Be(t.query.ToString());
            romanNumeralResponse.Output.Should().Be(t.output);
        }

        [Theory]
        [MemberData(nameof(BadRequestTheoryData))]
        public async Task RomanNumeralController_ConvertToRomanNumeral_ReturnsBadRequest((int query, string errorMessage) t)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"/romannumeral?query={t.query.ToString()}");

            var responseString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            responseString.Should().Contain(t.errorMessage);
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

        public static TheoryData<(int query, string errorMessage)> BadRequestTheoryData =>
            new TheoryData<(int query, string errorMessage)>
            {
                (-1, "'Query' must be between 1 and 255. You entered -1."),
                (0, "'Query' must be between 1 and 255. You entered 0."),
                (256, "'Query' must be between 1 and 255. You entered 256."),
            };
    }
}
