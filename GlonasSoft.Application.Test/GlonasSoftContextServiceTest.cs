using GlonasSoft.BL;
using GlonasSoft.BL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlonasSoft.Application.Test;

public abstract class GlonasSoftContextServiceTest
{
    protected GlonasSoftContext Context;

    protected virtual void Setup()
    {
        var databaseName = Guid.NewGuid().ToString("N");

        Debug.WriteLine(databaseName);

        var builder = new DbContextOptionsBuilder<GlonasSoftContext>()
            .UseNpgsql(databaseName);

        Context = new GlonasSoftContext(builder.Options);
    }

    protected async Task SeedContextAsync()
    {
        var users = await SeedUsersAsync();

        await Context.SaveChangesAsync();
    }

    private async Task<UserStatistic[]> SeedUsersAsync()
    {
        const int userStatisticsCount = 5;

        var userStatistics = Enumerable.Range(1, userStatisticsCount)
            .Select(i => new UserStatistic
            {
                UserId = Guid.NewGuid(),
                StartDate = DateTime.UtcNow.AddDays(-1),
                EndDate = DateTime.UtcNow.AddDays(1),
            })
            .ToArray();

        await Context.UserStatistics.AddRangeAsync(userStatistics);

        return userStatistics;
    }
}
