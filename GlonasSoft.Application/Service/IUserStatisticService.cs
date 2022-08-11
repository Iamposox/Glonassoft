using GlonasSoft.Application.Models;

namespace GlonasSoft.Application.Service;

public interface IUserStatisticService
{
    Task<Guid> CreateAsync(UserStatisticEditModel model);
    Task<UserStatisticResponseModel> GetUserStatisticByGuidAsync(Guid id);
}
