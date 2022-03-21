using Microsoft.AspNetCore.Mvc;
using RomanNumeralService.Models;
using RomanNumeralService.Utils.Abstractions;

namespace RomanNumeralService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RomanNumeralController : ControllerBase
    {
        private readonly IRomanNumeralConverter romanNumeralConverter;

        public RomanNumeralController(IRomanNumeralConverter romanNumeralConverter)
        {
            this.romanNumeralConverter = romanNumeralConverter;
        }

        [HttpGet]
        public IActionResult ConvertToRomanNumeral([FromQuery]RomanNumeralRequest request)
        {
            var output = romanNumeralConverter.ToRomanNumeral(request.Query);

            var response = new RomanNumeralResponse()
            {
                Input = request.Query.ToString(),
                Output = output
            };
            return this.Ok(response);
        }
    }
}
