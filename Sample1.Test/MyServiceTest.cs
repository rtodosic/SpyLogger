using Microsoft.Extensions.Logging;
using Sample1.Services;
using Todosichuk;

namespace Sample1.Test;

public class MyServiceTest
{

    private readonly SpyLogger<MyService> _logger = new SpyLogger<MyService>();
    private readonly MyService _myService;

    public MyServiceTest()
    {
        _myService = new MyService(_logger);
    }

    [Fact]
    public void RunInfoTest()
    {
        // Arrange

        // Act
        _myService.RunInfo();

        //Assert
        Assert.True(_logger.LoggerWasCalled);
        Assert.Single(_logger.Logs);
        Assert.Equal(LogLevel.Information, _logger.Logs[0].LogLevel);
        Assert.Equal("RunInfo was called", _logger.Logs[0].Message);
    }

    [Fact]
    public void RunWarnTest()
    {
        // Arrange

        // Act
        _myService.RunWarning();

        //Assert
        Assert.True(_logger.LoggerWasCalled);
        Assert.Single(_logger.Logs);
        Assert.Equal(LogLevel.Warning, _logger.Logs[0].LogLevel);
        Assert.Equal("RunWarning was called", _logger.Logs[0].Message);
    }

    [Fact]
    public void RunExceptionTest()
    {
        // Arrange

        // Act
        _myService.RunException();

        //Assert
        Assert.True(_logger.LoggerWasCalled);
        Assert.Single(_logger.Logs);
        Assert.Equal(LogLevel.Error, _logger.Logs[0].LogLevel);
        Assert.Equal("RunException was called", _logger.Logs[0].Message);
        Assert.NotNull(_logger.Logs[0].Ex);
        Assert.Equal("Bad", _logger.Logs[0].Ex?.Message);
    }



    [Fact]
    public void RunTest()
    {
        // Arrange

        // Act
        _myService.Run();

        //Assert
        Assert.True(_logger.LoggerWasCalled);
        Assert.Equal(3, _logger.Logs.Count);

        Assert.Equal(LogLevel.Information, _logger.Logs[0].LogLevel);
        Assert.Equal("RunInfo was called", _logger.Logs[0].Message);
        Assert.Null(_logger.Logs[0].Ex);

        Assert.Equal(LogLevel.Warning, _logger.Logs[1].LogLevel);
        Assert.Equal("RunWarning was called", _logger.Logs[1].Message);
        Assert.Null(_logger.Logs[1].Ex);

        Assert.Equal(LogLevel.Error, _logger.Logs[2].LogLevel);
        Assert.Equal("RunException was called", _logger.Logs[2].Message);
        Assert.NotNull(_logger.Logs[2].Ex);
        Assert.Equal("Bad", _logger.Logs[2].Ex?.Message);

        Assert.NotNull(_logger.Scope);
        Assert.Equal("Test", _logger.Scope);
    }
}