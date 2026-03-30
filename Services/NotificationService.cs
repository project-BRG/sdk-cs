using BRG.SDK.Clients;
using BRG.SDK.Notifications;
using BRG.SDK.Results;

namespace BRG.SDK.Services;

public class NotificationService(INotificationClient client) : INotificationService
{
    private readonly INotificationClient client = client ?? throw new ArgumentNullException(nameof(client));

    public async Task<NotificationSendResult> SendAsync(INotification notification, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(notification);
        return await client.SendAsync(notification, ct);
    }
}