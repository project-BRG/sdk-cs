namespace BRG.SDK.Notifications;

public class EmailNotification : INotification
{
    public required string Recipient { get; init; }
    public required string Title { get; init; }
    public required string Message { get; init; }
}