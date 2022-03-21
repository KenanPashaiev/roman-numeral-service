using FluentValidation;
using RomanNumeralService.Models;

public class RomanNumeralRequestValidator : AbstractValidator<RomanNumeralRequest>
{
    public const int MinInput = 1; 
    public const int MaxInput = 255; 

    public RomanNumeralRequestValidator()
    {
        RuleFor(r => r.Query).InclusiveBetween(MinInput, MaxInput);
    }
}
