namespace BRG.SDK.Notifications;

public interface INotification
{
    string Recipient { get; init; }
    string Title { get; init; }
    string Message { get; init; }
}