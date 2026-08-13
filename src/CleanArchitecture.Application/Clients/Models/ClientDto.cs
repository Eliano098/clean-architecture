namespace CleanArchitecture.Application.Clients.Models;

public record ClientDto(
    Guid Id,
    string Name,
    string Document,
    DateOnly BirthDate);
