using FluentValidation;
using RomanNumeralService.Models;

namespace RomanNumeralService.Validators
{
    /// <summary>
    /// <see cref="RomanNumeralRequestValidator"/> Validates objects of <see cref="RomanNumeralRequest"/> class
    /// </summary>
    public class RomanNumeralRequestValidator : AbstractValidator<RomanNumeralRequest>
    {
        private const int MinInput = 1;
        private const int MaxInput = 255;

        /// <summary>
        /// Constructor for object of <see cref="RomanNumeralRequestValidator"/> class.
        /// </summary>
        /// <remarks>
        /// Defines validation rules for <see cref="RomanNumeralRequest"/>
        /// </remarks>
        public RomanNumeralRequestValidator()
        {
            RuleFor(r => r.Query).InclusiveBetween(MinInput, MaxInput);
        }
    }
}
