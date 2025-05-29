namespace NotificationService.Application.Interfaces;

public interface ISmsSender
{
    Task SendAsync(string recipient,string message);
}