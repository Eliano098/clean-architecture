using MediatR;

namespace CleanArchitecture.Application.Clients.Commands.CreateClient;

public record CreateClientCommand(
    string Name,
    string Document,
    DateOnly BirthDate) : IRequest<Guid>;
