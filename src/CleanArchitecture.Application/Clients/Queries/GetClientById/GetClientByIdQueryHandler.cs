using CleanArchitecture.Application.Clients.Models;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Clients.Queries.GetClientById;

public class GetClientByIdQueryHandler(IClientRepository clientRepository)
    : IRequestHandler<GetClientByIdQuery, ClientDto?>
{
    public Task<ClientDto?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return clientRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
