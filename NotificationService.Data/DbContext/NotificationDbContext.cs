using Microsoft.EntityFrameworkCore;
using NotificationService.Core.Entites;

namespace NotificationService.Core.DbContext;

public class NotificationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<NotificationLog> NotificationLogs { get; set; }
}