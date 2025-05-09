using System.Data;
using APBD_Tutorial8.Application.Commands.ClientCommands;
using APBD_Tutorial8.Infrastructure.DTOs;
using FluentValidation;

namespace APBD_Tutorial8.Infrastructure.Validators;

public class ClientValidator : AbstractValidator<CreateClientCommand>
{
    public ClientValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cannot be empty");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number cannot be empty");
        RuleFor(x => x.Pesel).NotEmpty().WithMessage("Pesel cannot be empty");
    }
}