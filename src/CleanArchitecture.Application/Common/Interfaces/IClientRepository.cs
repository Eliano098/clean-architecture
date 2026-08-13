using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Clients.Models;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IClientRepository
{
    Task AddAsync(Client client, CancellationToken cancellationToken);
    Task<bool> DocumentExistsAsync(string document, CancellationToken cancellationToken);
    Task<IReadOnlyList<ClientDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<ClientDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
