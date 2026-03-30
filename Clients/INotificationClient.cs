using BRG.SDK.Notifications;
using BRG.SDK.Results;

namespace BRG.SDK.Clients;

public interface INotificationClient
{
    Task<NotificationSendResult> SendAsync(INotification notification, CancellationToken ct = default);
}