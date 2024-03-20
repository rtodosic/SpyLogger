using Microsoft.Extensions.Logging;

namespace Todosichuk;
public record LogInfo(LogLevel LogLevel, EventId EventId, Exception? Ex, string Message, object Scope)
{
}
