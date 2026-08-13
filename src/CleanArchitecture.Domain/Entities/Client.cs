namespace CleanArchitecture.Domain.Entities;

public class Client
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public DateOnly BirthDate { get; private set; }

    public Client(string name, string document, DateOnly birthDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Document = document;
        BirthDate = birthDate;
    }
}
