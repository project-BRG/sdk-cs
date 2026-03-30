namespace BRG.SDK.Services;

public class NotificationServiceOptions
{
    public string? ApiKey { get; set; }
    public string BaseUrl { get; set; } = string.Empty;
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(10);
}