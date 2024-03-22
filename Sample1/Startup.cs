using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sample1;

internal class Startup
{
    public IServiceProvider ServiceProvider { get; set; }

    public Startup()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddLogging(loggeringBuilder =>
        {
            loggeringBuilder.AddConsole();
        });
    }

    public T ActivateInstance<T>(Type instanceType)
    {
        return (T)ActivatorUtilities.CreateInstance(ServiceProvider, instanceType);
    }
}
