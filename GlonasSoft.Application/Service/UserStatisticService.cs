using GlonasSoft.Application.Exceptions;
using GlonasSoft.Application.Mappers;
using GlonasSoft.Application.Models;
using GlonasSoft.Application.Service.Common;
using GlonasSoft.BL;
using GlonasSoft.BL.Models;
using Microsoft.Extensions.Configuration;

namespace GlonasSoft.Application.Service;

public class UserStatisticService : GlonasSoftContextService, IUserStatisticService
{
    public UserStatisticService(GlonasSoftContext context, IConfiguration configuration) : base(context) 
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public async Task<Guid> CreateAsync(UserStatisticEditModel model)
    {
        var userStatistic = model.ToUserStatistic();

        await Context.UserStatistics.AddAsync(userStatistic);

        await SaveChangesAsync();

        return userStatistic.Id;
    }

    public async Task<UserStatisticResponseModel> GetUserStatisticByGuidAsync(Guid id)
    {
        var userStatistic = await GetUserStatisticAsync(id);

        userStatistic.CountSignIn++;

        await SaveChangesAsync();

        return userStatistic.ToUserStatisticResponseModel(Configuration["Time"]);
    }

    private async Task<UserStatistic> GetUserStatisticAsync(Guid id)
    {
        var userStatistic = await Context.UserStatistics.FindAsync(id);

        if (userStatistic == null)
            throw new NotFoundException($"Статистика пользователя с идентификатором {id} не найдена");

        return userStatistic;
    }
}
