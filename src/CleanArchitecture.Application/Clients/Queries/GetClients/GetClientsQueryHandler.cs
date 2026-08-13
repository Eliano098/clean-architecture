using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Clients.Models;
using MediatR;

namespace CleanArchitecture.Application.Clients.Queries.GetClients;

public class GetClientsQueryHandler(IClientRepository clientRepository)
    : IRequestHandler<GetClientsQuery, IReadOnlyList<ClientDto>>
{
    public Task<IReadOnlyList<ClientDto>> Handle(
        GetClientsQuery request,
        CancellationToken cancellationToken)
    {
        return clientRepository.GetAllAsync(cancellationToken);
    }
}
