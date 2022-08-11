using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace GlonasSoft.BL;

public static class AutomatedMigration
{
    public static async Task DatabaseMigrateAsync(this IServiceProvider services)
    {
        var context = services.GetRequiredService<GlonasSoftContext>();

        if (context.Database.IsNpgsql())
            await context.Database.MigrateAsync();
    }
}