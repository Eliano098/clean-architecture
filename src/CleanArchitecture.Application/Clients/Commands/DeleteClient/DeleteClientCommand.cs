using MediatR;

namespace CleanArchitecture.Application.Clients.Commands.DeleteClient;

public record DeleteClientCommand(Guid Id) : IRequest<bool>;
