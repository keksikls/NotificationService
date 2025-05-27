using NotificationService.Core.Entites;

namespace NotificationService.Core.Repositories;

public interface INotificationLogRepo
{
    Task<NotificationLog?> GetByIdAsync(Guid id,CancellationToken ct = default);
    Task<IEnumerable<NotificationLog>> GetAllAsync(CancellationToken ct = default);
    Task<IEnumerable<NotificationLog>> GetFailedAsync(CancellationToken ct = default);
    
    Task DeleteAsync(Guid id,CancellationToken ct = default);
    Task AddAsync(NotificationLog log,CancellationToken ct = default);
    Task UpdateAsync(NotificationLog log,CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}