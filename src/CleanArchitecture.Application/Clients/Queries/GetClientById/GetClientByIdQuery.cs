using CleanArchitecture.Application.Clients.Models;
using MediatR;

namespace CleanArchitecture.Application.Clients.Queries.GetClientById;

public record GetClientByIdQuery(Guid Id) : IRequest<ClientDto?>;
