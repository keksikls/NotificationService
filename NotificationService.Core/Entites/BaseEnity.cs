namespace NotificationService.Core.Entites;

public abstract class BaseEnity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    public DateTime ModifiedOn { get; private set; }
}