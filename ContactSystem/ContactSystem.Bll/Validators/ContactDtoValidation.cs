using ContactSystem.Bll.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSystem.Bll.Validators;

public class ContactDtoValidation : AbstractValidator<ContactDto>
{
    public ContactDtoValidation()
    {

        RuleFor(x => x.ContactId)
            .GreaterThan(0);

        RuleFor(x => x.FirstName)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .NotEmpty();

        RuleFor(x => x.Address)
            .MaximumLength(200);
    }
}
