using GlonasSoft.Application.Models;
using GlonasSoft.BL.Models;

namespace GlonasSoft.Application.Mappers;

public static class UserStatisticMappers
{
    public static UserStatistic ToUserStatistic(this UserStatisticEditModel entity) 
    {
        return new UserStatistic
        {
            UserId = Guid.Parse(entity.UserId),
            StartDate = DateTime.Parse(entity.StartTime).ToUniversalTime(),
            EndDate = DateTime.Parse(entity.EndTime).ToUniversalTime(),
            CreatedDate = DateTime.UtcNow
        };
    }

    public static UserStatisticResponseModel ToUserStatisticResponseModel(this UserStatistic entity, string configTime)
    {
        if ((DateTime.UtcNow - entity.CreatedDate).TotalMilliseconds > int.Parse(configTime))
            return new UserStatisticResponseModel
            {
                Percent = 100,
                StatisticId = entity.Id,
                Result = new ResultResponseModel
                {
                    UserId = entity.UserId,
                    CountSignIn = entity.CountSignIn,
                }
            };
        else return new UserStatisticResponseModel
        {
            Percent = Convert.ToInt32((DateTime.UtcNow - entity.CreatedDate).TotalSeconds / TimeSpan.FromMilliseconds(double.Parse(configTime)).TotalSeconds * 100),
            StatisticId = entity.Id,
            Result = null
        };
    }
}
