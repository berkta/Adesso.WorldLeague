using Adesso.WorldLeague.Application.Draws.Commands;
using FluentValidation;

namespace Adesso.WorldLeague.Application.Draws.Validators;

public class CreateDrawCommandValidator : AbstractValidator<CreateDrawCommand>
{
    public CreateDrawCommandValidator()
    {
        RuleFor(command => command.CreateDrawCommandInput.GroupCount)
            .NotEmpty()
            .WithMessage("Group count can not be empty.");

        RuleFor(command => command.CreateDrawCommandInput.GroupCount)
            .Must(c => c == 4 || c == 8)
            .WithMessage("Group count can not be a number different than 4 or 8.");

        RuleFor(command => command.CreateDrawCommandInput.OperatorFirstName)
            .NotEmpty()
            .WithMessage("Operator first name can not be empty.");
        
        RuleFor(command => command.CreateDrawCommandInput.OperatorLastName)
            .NotEmpty()
            .WithMessage("Operator last name can not be empty.");
    }
}