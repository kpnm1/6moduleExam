using ContactSystem.Bll.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Bll.Validators;

public class UserLogInDtoValidation : AbstractValidator<UserLogInDto>
{
    public UserLogInDtoValidation()
    {
        RuleFor(x => x.UserName)
           .NotEmpty().WithMessage("Username is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}
