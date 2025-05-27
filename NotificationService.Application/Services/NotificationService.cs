using NotificationService.Application.Interfaces;
using NotificationService.Core.Repositories;

namespace NotificationService.Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationLogRepo _notificationLogRepo; 
    private readonly IEmailSender _emailSender;
    private readonly ISmsSender _smsSender;
    private readonly ITelegramSender _telegramSender;
    private readonly IWebSender _webSender;

    public NotificationService(INotificationLogRepo notificationLogRepo,
        IEmailSender emailSender, ISmsSender smsSender, ITelegramSender telegramSender,
        IWebSender webSender)
    {
        _notificationLogRepo = notificationLogRepo;
        _emailSender = emailSender;
        _smsSender = smsSender;
        _telegramSender = telegramSender;
        _webSender = webSender;
    }
    
    public Task SendEmailNotificationAsync(string recipient, string subject, string content)
    {
        throw new NotImplementedException();
    }

    public Task SendSmsNotificationAsync(string recipient, string message)
    {
        throw new NotImplementedException();
    }

    public Task SendTelegramNotificationAsync(string recipient, string message)
    {
        throw new NotImplementedException();
    }

    public Task SendWebNotificationAsync(string recipient, string message)
    {
        throw new NotImplementedException();
    }
}