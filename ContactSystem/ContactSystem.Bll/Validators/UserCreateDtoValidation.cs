using ContactSystem.Bll.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Bll.Validators;

public class UserCreateDtoValidation : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidation()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(4).WithMessage("Username must be at least 4 characters.")
            .MaximumLength(30).WithMessage("Username must not exceed 30 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.");
    }
}
