namespace DSRNetSchool.Logger;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static void AddLogger(this IServiceCollection services)
    {
        services.AddSingleton<ILogger, Logger>();
    }
}
