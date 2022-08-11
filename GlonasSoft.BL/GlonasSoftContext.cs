using GlonasSoft.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace GlonasSoft.BL;

public class GlonasSoftContext : DbContext
{
    public DbSet<UserStatistic> UserStatistics { get; set; }

    public GlonasSoftContext(DbContextOptions<GlonasSoftContext> options) : base(options) { }
}
