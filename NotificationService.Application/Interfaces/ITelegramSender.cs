namespace NotificationService.Application.Interfaces;

public interface ITelegramSender
{
    Task SendAsync(string chatId,string message);
}