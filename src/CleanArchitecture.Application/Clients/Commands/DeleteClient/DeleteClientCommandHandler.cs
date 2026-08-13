using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Clients.Commands.DeleteClient;

public class DeleteClientCommandHandler(IClientRepository clientRepository)
    : IRequestHandler<DeleteClientCommand, bool>
{
    public async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await clientRepository.FindAsync(request.Id, cancellationToken);

        if (client is null)
        {
            return false;
        }

        clientRepository.Remove(client);
        await clientRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}
