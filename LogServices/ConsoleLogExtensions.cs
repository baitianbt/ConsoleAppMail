using LogServices;

// 这里的namespace修改成Microsoft.Extensions.DependencyInjection
namespace Microsoft.Extensions.DependencyInjection;

public static class ConsoleLogExtensions
{
    public static void AddConsoleLog(this IServiceCollection services)
    {
        services.AddScoped<ILogProvider,ConsoleLogProvider>();
    }

}