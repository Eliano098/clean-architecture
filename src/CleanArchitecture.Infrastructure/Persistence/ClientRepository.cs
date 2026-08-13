using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ClientRepository(ApplicationDbContext context) : IClientRepository
{
    public async Task AddAsync(Client client, CancellationToken cancellationToken)
    {
        await context.Clients.AddAsync(client, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> DocumentExistsAsync(string document, CancellationToken cancellationToken)
    {
        return context.Clients.AnyAsync(client => client.Document == document, cancellationToken);
    }
}
