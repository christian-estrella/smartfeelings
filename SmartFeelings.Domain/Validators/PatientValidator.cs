using FluentValidation;
using SmartFeelings.Domain.Entities;

namespace SmartFeelings.Domain.Validators;

public class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5).MaximumLength(25)
            .WithMessage("Name must be between 5 and 25 characters");

        RuleFor(x => x.Lastname)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5).MaximumLength(25)
            .WithMessage("Lastname must be between 5 and 25 characters");

        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .MinimumLength(5).MaximumLength(100)
            .EmailAddress()
            .WithMessage("Email must be a valid email address, and must be between 5 and 100 characters.");
    }
}