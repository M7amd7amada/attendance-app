using FluentValidation;

namespace Attendance.Shared.Models.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        CascadeMode = CascadeMode.Stop;
#pragma warning restore CS0618 // Type or member is obsolete

        RuleFor(user => user.FirstName)
            .NotEmpty()
            .WithMessage("First name is a required field.")
            .Length(3, 50)
            .WithMessage("First name must be between 3 and 50 characters.");

        RuleFor(user => user.LastName)
            .NotEmpty()
            .WithMessage("Last name is a required field.")
            .Length(3, 50)
            .WithMessage("Last name must be between 3 and 50 characters.");

        RuleFor(user => user.UserName)
            .NotEmpty()
            .WithMessage("User name is a required field.")
            .Length(3, 50)
            .WithMessage("User name must be between 3 and 50 characters.");

        RuleFor(user => user.FirstName)
            .NotEmpty()
            .WithMessage("Password is a required field.")
            .Length(6, 50)
            .WithMessage("Password must be between 6 and 50 characters.");
    }
}