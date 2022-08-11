using GlonasSoft.Application.Exceptions;
using GlonasSoft.Application.Models;
using GlonasSoft.Application.Service;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlonasSoft.Application.Test;

public class UserStatisticServiceTest : GlonasSoftContextServiceTest
{
    private IUserStatisticService _userStatisticService;
    private Mock<IConfiguration> _config;

    [SetUp]
    protected override void Setup()
    {
        base.Setup();
        _config = new Mock<IConfiguration>();
        _userStatisticService = new UserStatisticService(Context, _config.Object);
    }

    #region CreateAsync Tests
    [Test]
    public async Task CreateAsync_Should_Return_Created_UserStatistic_Id()
    {
        var createModel = new UserStatisticEditModel
        {
            UserId = Guid.NewGuid().ToString(),
            StartTime = DateTime.UtcNow.AddDays(-2).ToString(),
            EndTime = DateTime.UtcNow.AddDays(2).ToString(),
        };

        var id = await _userStatisticService.CreateAsync(createModel);

        var createdStatistic = Context.UserStatistics.Find(id);

        Assert.AreEqual(createModel.UserId, createdStatistic.UserId);
        Assert.AreEqual(createModel.StartTime, createdStatistic.StartDate);
        Assert.AreEqual(createModel.EndTime, createdStatistic.EndDate);
    }
    #endregion

    #region GetByIdAsync Tests

    [Test]
    public async Task GetByIdAsync_Should_Return_UserStatisticResponseModel_If_UserStatistic_Exist()
    {
        await SeedContextAsync();

        var existUserStatistic = Context.UserStatistics.First();

        var userStatistic = await _userStatisticService.GetUserStatisticByGuidAsync(existUserStatistic.Id);

        Assert.AreEqual(existUserStatistic.Id, userStatistic.StatisticId);
        Assert.AreEqual(existUserStatistic.UserId, userStatistic.Result.UserId);
        Assert.AreEqual(existUserStatistic.CountSignIn, userStatistic.Result.CountSignIn);
    }
    #endregion
}
