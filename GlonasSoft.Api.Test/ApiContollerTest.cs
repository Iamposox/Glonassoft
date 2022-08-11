using GlonasSoft.Application.Service;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using NUnit.Framework;

namespace GlonasSoft.Api.Test;

public abstract class ApiControllerTest
{
    protected Mock<IUserStatisticService> UserStatisticServiceMock;

    public virtual void Setup()
    {
        UserStatisticServiceMock = new Mock<IUserStatisticService>();
    }

    protected void AssertOkObjectResult(IStatusCodeActionResult result)
    {
        Assert.NotNull(result);
        Assert.NotNull(result.StatusCode);
        Assert.AreEqual(200, result.StatusCode.Value);
    }
}
