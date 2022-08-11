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
using GlonasSoft.Application.Models;
using GlonasSoft.Application.Service;

namespace GlonasSoft.Web.Controllers
{
    public class UserStatisticsController : ApiController
    {
        private readonly IUserStatisticService _userStatisticService;
        

        public UserStatisticsController(IUserStatisticService userStatisticService)
        {
            _userStatisticService = userStatisticService;
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetUserStatistic(Guid guid)
        {
            return Ok(await _userStatisticService.GetUserStatisticByGuidAsync(guid));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserStatisticEditModel model)
        {
            return Ok(await _userStatisticService.CreateAsync(model));
        }
    }
}
