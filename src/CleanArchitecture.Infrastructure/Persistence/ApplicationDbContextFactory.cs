using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        const string connectionString =
            "Server=localhost;Port=3306;Database=clean_architecture;User=root;Password=root;";

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0)));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
