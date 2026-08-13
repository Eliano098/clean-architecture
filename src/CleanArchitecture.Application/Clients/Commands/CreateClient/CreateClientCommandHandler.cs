using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Clients.Commands.CreateClient;

public class CreateClientCommandHandler(IClientRepository clientRepository)
    : IRequestHandler<CreateClientCommand, Guid>
{
    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client(request.Name, request.Document, request.BirthDate);

        await clientRepository.AddAsync(client, cancellationToken);

        return client.Id;
    }
}
