using BRG.SDK.Exceptions;

namespace BRG.SDK.Results;

public class NotificationSendResult(bool isSuccess, NotificationException? exception = null)
{
    public bool IsSuccess { get; set; } = isSuccess;
    public NotificationException? Exception { get; set; } = exception;

    public static NotificationSendResult Success()
        => new(true);
    public static NotificationSendResult Failure(NotificationException? exception = null)
        => new(false, exception);

    public static implicit operator NotificationSendResult(NotificationException exception)
        => Failure(exception);
}