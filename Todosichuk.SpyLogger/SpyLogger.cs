using Microsoft.Extensions.Logging;

namespace Todosichuk;

public class SpyLogger<T> : ILogger<T>
{
    public List<LogInfo> Logs { get; set; } = [];
    public object Scope { get; set; } = new object();

    public bool LoggerWasCalled { get; private set; }


    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        Logs.Add(new LogInfo(logLevel, eventId, exception, state?.ToString() ?? "", Scope));
        LoggerWasCalled = true;
    }

    public void ClearLogs()
    {
        LoggerWasCalled = false;
        Logs.Clear();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    IDisposable? ILogger.BeginScope<TState>(TState state)
    {
        Scope = state ?? new object();
        return null;
    }

}
