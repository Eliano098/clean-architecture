using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IClientRepository
{
    Task AddAsync(Client client, CancellationToken cancellationToken);
}
