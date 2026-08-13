using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandHandler(IClientRepository clientRepository)
    : IRequestHandler<UpdateClientCommand, bool>
{
    public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await clientRepository.FindAsync(request.Id, cancellationToken);

        if (client is null)
        {
            return false;
        }

        client.Update(request.Name, request.Document, request.BirthDate);
        await clientRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
