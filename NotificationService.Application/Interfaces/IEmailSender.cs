namespace NotificationService.Application.Interfaces;

public interface IEmailSender
{
    Task SendAsync(string recipient,string subject ,string content);
}