using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("clients");
            entity.HasKey(client => client.Id);
            entity.Property(client => client.Name).HasMaxLength(200).IsRequired();
            entity.Property(client => client.Document).HasMaxLength(20).IsRequired();
            entity.HasIndex(client => client.Document).IsUnique();
            entity.Property(client => client.BirthDate).IsRequired();
        });
    }
}
