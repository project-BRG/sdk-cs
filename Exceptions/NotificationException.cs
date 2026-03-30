namespace BRG.SDK.Exceptions;

public class NotificationException : Exception
{
    public string? ErrorCode { get; set; }

    public NotificationException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    public NotificationException(string message, string? errorCode = null)
        : base(message)
        => ErrorCode = errorCode;
}