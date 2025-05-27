using NotificationService.Core.Enum;

namespace NotificationService.Core.Entites;

public class NotificationLog : BaseEnity
{
    public Guid OrderId { get; private set; }
    public Guid UserId { get; private set; }
    public string Message { get; private set; }
    public string Title { get; private set; }
    public NotificationType Type { get; private set; }
    public string Status {get; private set; }
    
    public int RetryCount { get; private set; }

    public string? ErrorMessage { get; set; }
}