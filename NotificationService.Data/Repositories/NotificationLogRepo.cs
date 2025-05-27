using Microsoft.EntityFrameworkCore;
using NotificationService.Core.DbContext;
using NotificationService.Core.Entites;

namespace NotificationService.Core.Repositories;

public class NotificationLogRepo : INotificationLogRepo
{
    private readonly NotificationDbContext _dbContext;

    public NotificationLogRepo(NotificationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<NotificationLog?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _dbContext.NotificationLogs.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<IEnumerable<NotificationLog>> GetAllAsync(CancellationToken ct = default)
    {
        return await _dbContext.NotificationLogs.ToListAsync(ct);
    }

    public async Task<IEnumerable<NotificationLog>> GetFailedAsync(CancellationToken ct = default)
    {
        return await _dbContext.NotificationLogs
            .Where(x=>x.Status == "Cancelled")
            .ToListAsync(ct);
    }   

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
         var log = await GetByIdAsync(id, ct);
         
         if (log == null)
         {
             throw new Exception("Log not found");
         }
         
         _dbContext.NotificationLogs.Remove(log);
         await _dbContext.SaveChangesAsync(ct);
    }

    public async Task AddAsync(NotificationLog log, CancellationToken ct = default)
    {
         await _dbContext.NotificationLogs.AddAsync(log, ct);
    }

    public async Task UpdateAsync(NotificationLog log, CancellationToken ct = default)
    {
        _dbContext.NotificationLogs.Update(log);
        await _dbContext.SaveChangesAsync(ct);
    }

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _dbContext.SaveChangesAsync(ct);
    }
}