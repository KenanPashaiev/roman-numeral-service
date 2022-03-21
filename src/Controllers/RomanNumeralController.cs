using Microsoft.AspNetCore.Mvc;
using RomanNumeralService.Models;
using RomanNumeralService.Converters.Abstractions;
using FluentValidation;

namespace RomanNumeralService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RomanNumeralController : ControllerBase
    {
        private readonly IRomanNumeralConverter romanNumeralConverter;
        private readonly IValidator<RomanNumeralRequest> validator;

        public RomanNumeralController(IRomanNumeralConverter romanNumeralConverter, IValidator<RomanNumeralRequest> validator)
        {
            this.romanNumeralConverter = romanNumeralConverter;
            this.validator = validator;
        }

        [HttpGet]
        public IActionResult ConvertToRomanNumeral([FromQuery]RomanNumeralRequest request)
        {
            var validationResult = validator.Validate(request);
            if(!validationResult.IsValid)
            {
                return this.BadRequest(validationResult.Errors);
            }

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
