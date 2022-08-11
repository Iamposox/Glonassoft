using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GlonasSoft.BL.Context;

public class SampleContextFactory : IDesignTimeDbContextFactory<GlonasSoftContext>
{
    public GlonasSoftContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GlonasSoftContext>();

        ConfigurationBuilder builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot config = builder.Build();

        string connectionString = config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        return new GlonasSoftContext(optionsBuilder.Options);
    }
}