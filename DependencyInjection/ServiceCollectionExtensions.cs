using BRG.SDK.Clients;
using BRG.SDK.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BRG.SDK.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddNotificationService(this IServiceCollection services, IConfiguration configuration)
    {
        var options = new NotificationServiceOptions();
        configuration.GetSection("NotificationService").Bind(options);

        if (string.IsNullOrEmpty(options.ApiKey))
            options.ApiKey = Environment.GetEnvironmentVariable("BRG_API_KEY")
                             ?? throw new InvalidOperationException(
                                 "NotificationClient:ApiKey is required in configuration");

        services.AddServices(options);
    }

    public static void AddNotificationService(this IServiceCollection services, NotificationServiceOptions options)
    {
        if (string.IsNullOrEmpty(options.ApiKey))
            throw new ArgumentException("ApiKey is required", nameof(options.ApiKey));

        services.AddServices(options);
    }

    private static void AddServices(this IServiceCollection services, NotificationServiceOptions options)
    {
        services.AddSingleton(options);
        services.AddHttpClient<INotificationClient, NotificationClient>();
        services.AddScoped<INotificationService, NotificationService>();
    }
}