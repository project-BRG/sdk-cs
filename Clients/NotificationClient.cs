using System.Net.Http.Json;
using BRG.SDK.Notifications;
using BRG.SDK.Results;
using BRG.SDK.Services;

namespace BRG.SDK.Clients;

public class NotificationClient : INotificationClient
{
    private readonly HttpClient httpClient;
    private readonly NotificationServiceOptions options;

    public NotificationClient(HttpClient httpClient, NotificationServiceOptions options)
    {
        this.httpClient = httpClient;
        this.options = options;

        httpClient.Timeout = options.Timeout;
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.ApiKey}");
    }

    public async Task<NotificationSendResult> SendAsync(INotification notification, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(notification);

        try
        {
            var endpoint = notification switch
            {
                EmailNotification => "/email/send",
                SmsNotification => "/sms/send",
                _ => throw new NotSupportedException($"Notification type {notification.GetType().Name} not supported")
            };

            var response = await httpClient.PostAsJsonAsync(
                $"{options.BaseUrl}{endpoint}",
                notification,
                ct);

            return response.IsSuccessStatusCode
                ? NotificationSendResult.Success()
                : NotificationSendResult.Failure(
                    new(
                        await response.Content.ReadAsStringAsync(ct),
                        response.StatusCode.ToString()));
        }
        catch (Exception exception)
        {
            return NotificationSendResult.Failure(
                new(exception.Message, exception.InnerException));
        }
    }
}