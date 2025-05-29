using NotificationService.Application.Interfaces;
using NotificationService.Core.Entites;
using NotificationService.Core.Repositories;

namespace NotificationService.Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationLogRepo _notificationLogRepo; 
    private readonly IEmailSender _emailSender;
    private readonly ISmsSender _smsSender;
    private readonly ITelegramSender _telegramSender;

    public NotificationService(INotificationLogRepo notificationLogRepo,
        IEmailSender emailSender, ISmsSender smsSender, ITelegramSender telegramSender)
    {
        _notificationLogRepo = notificationLogRepo;
        _emailSender = emailSender;
        _smsSender = smsSender;
        _telegramSender = telegramSender;
    }
    
    public async Task SendEmailNotificationAsync(string recipient, string subject, string content)
    {
        await _emailSender.SendAsync(recipient,subject,content);
    }

    public async Task SendSmsNotificationAsync(string recipient, string message)
    {
        await _smsSender.SendAsync(recipient,message);
    }

    public async Task SendTelegramNotificationAsync(string recipient, string message)
    {
        await _telegramSender.SendAsync(recipient,message);
    }
}