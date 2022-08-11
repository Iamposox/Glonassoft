using GlonasSoft.BL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlonasSoft.BL;

public class GlonasSoftContext : DbContext
{
    public DbSet<UserStatistic> UserStatistics { get; set; }

    public GlonasSoftContext(DbContextOptions<GlonasSoftContext> options) : base(options) { }
}
