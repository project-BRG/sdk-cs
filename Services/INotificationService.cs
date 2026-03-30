using BRG.SDK.Notifications;
using BRG.SDK.Results;

namespace BRG.SDK.Services;

public interface INotificationService
{
    Task<NotificationSendResult> SendAsync(INotification notification, CancellationToken ct = default);
}