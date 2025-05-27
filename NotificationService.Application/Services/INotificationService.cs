namespace NotificationService.Application.Services;

public interface INotificationService
{
    Task SendEmailNotificationAsync(string recipient, string subject, string content);
    Task SendSmsNotificationAsync(string recipient, string message);
    Task SendTelegramNotificationAsync(string recipient, string message);
    Task SendWebNotificationAsync(string recipient, string message);
}