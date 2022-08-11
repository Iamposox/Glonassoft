using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlonasSoft.BL;
using GlonasSoft.BL.Models;
using GlonasSoft.Web.Controllers.Common;

namespace GlonasSoft.Web.Controllers
{
    public class UserStatisticsController : ApiController
    {
        //private readonly IUserStatisticService _userStatisticService;

        //public UserStatisticsController(IUserStatisticService userStatisticService)
        //{
        //    _userStatisticService = userStatisticService;
        //}

        //// GET: api/UserStatistics/5
        //[HttpGet("{guid}")]
        //public async Task<ActionResult<UserStatistic>> GetUserStatistic(Guid guid)
        //{

        //}

        //// POST: api/UserStatistics
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UserStatistic>> PostUserStatistic(UserStatistic userStatistic)
        //{

        //}

        //private bool UserStatisticExists(int id)
        //{
        //    return (_context.UserStatistics?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
