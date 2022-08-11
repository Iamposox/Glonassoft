using GlonasSoft.Application.Models;
using GlonasSoft.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlonasSoft.Api.Test;

public class UserStatisticControllerTest : ApiControllerTest
{
    private UserStatisticsController _userStatisticsController;
    private Guid _queryGuid;

    [SetUp]
    public override void Setup()
    {
        base.Setup();

        _userStatisticsController = new UserStatisticsController(UserStatisticServiceMock.Object);
    }

    [Test]
    public async Task Get_By_Guid_Should_Return_Result_With_TaskResponseModel()
    {
        var responseModel = new UserStatisticResponseModel { StatisticId = _queryGuid };

        UserStatisticServiceMock
            .Setup(s => s.GetUserStatisticByGuidAsync(_queryGuid))
            .ReturnsAsync(responseModel);

        var result = await _userStatisticsController.GetUserStatistic(_queryGuid) as OkObjectResult;

        AssertOkObjectResult(result);
    }

    [Test]
    public async Task PostModel_Should_Return_Result_With_Statistic_Id()
    {
        var editModel = new UserStatisticEditModel();

        UserStatisticServiceMock
            .Setup(m => m.CreateAsync(editModel))
            .ReturnsAsync(_queryGuid);

        var result = await _userStatisticsController.Post(editModel) as OkObjectResult;

        AssertOkObjectResult(result);
    }
}
