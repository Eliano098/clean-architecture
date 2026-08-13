using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;

namespace CleanArchitecture.Application.Clients.Commands.CreateClient;

public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidator(IClientRepository clientRepository)
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200);

        RuleFor(command => command.Document)
            .NotEmpty().WithMessage("Document is required.")
            .MaximumLength(20)
            .MustAsync(async (document, cancellationToken) =>
                !await clientRepository.DocumentExistsAsync(document, cancellationToken))
            .WithMessage("Document is already registered.");

        RuleFor(command => command.BirthDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Birth date cannot be in the future.");
    }
}
