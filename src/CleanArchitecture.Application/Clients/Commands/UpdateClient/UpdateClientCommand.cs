using MediatR;

namespace CleanArchitecture.Application.Clients.Commands.UpdateClient;

public record UpdateClientCommand(
    Guid Id,
    string Name,
    string Document,
    DateOnly BirthDate) : IRequest<bool>;
