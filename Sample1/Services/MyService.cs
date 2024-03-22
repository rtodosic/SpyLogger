using Microsoft.Extensions.Logging;

namespace Sample1.Services;

public class MyService : IMyService
{
    private readonly ILogger<MyService> _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
    }

    public void RunInfo()
    {
        _logger.LogInformation("RunInfo was called");
    }

    public void RunWarning()
    {
        _logger.LogWarning("RunWarning was called");
    }

    public void RunException()
    {
        _logger.LogError(new Exception("Bad"), "RunException was called");
    }

    public void Run()
    {
        using (_logger.BeginScope("Test"))
        {
            RunInfo();
            RunWarning();
            RunException();
        }
    }
}
