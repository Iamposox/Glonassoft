using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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