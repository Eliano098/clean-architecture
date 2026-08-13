using CleanArchitecture.Application.Clients.Models;
using MediatR;

namespace CleanArchitecture.Application.Clients.Queries.GetClients;

public record GetClientsQuery : IRequest<IReadOnlyList<ClientDto>>;
