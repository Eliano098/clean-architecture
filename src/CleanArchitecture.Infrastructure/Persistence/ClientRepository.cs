using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Clients.Models;
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

    public Task<bool> DocumentExistsAsync(
        string document,
        Guid? excludingId,
        CancellationToken cancellationToken)
    {
        return context.Clients.AnyAsync(
            client => client.Document == document && client.Id != excludingId,
            cancellationToken);
    }

    public Task<Client?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return context.Clients.SingleOrDefaultAsync(client => client.Id == id, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ClientDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Clients
            .AsNoTracking()
            .OrderBy(client => client.Name)
            .Select(client => new ClientDto(
                client.Id,
                client.Name,
                client.Document,
                client.BirthDate))
            .ToListAsync(cancellationToken);
    }

    public Task<ClientDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return context.Clients
            .AsNoTracking()
            .Where(client => client.Id == id)
            .Select(client => new ClientDto(
                client.Id,
                client.Name,
                client.Document,
                client.BirthDate))
            .SingleOrDefaultAsync(cancellationToken);
    }
}
