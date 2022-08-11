using GlonasSoft.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlonasSoft.Application.Service;

public interface IUserStatisticService
{
    Task<Guid> CreateAsync(UserStatisticEditModel model);
    Task<UserStatisticResponseModel> GetUserStatisticByGuidAsync(Guid id);
}
