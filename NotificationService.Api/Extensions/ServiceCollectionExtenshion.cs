using NotificationService.Infrastructure.Email;
using NotificationService.Application.Interfaces;
using NotificationService.Infrastructure.Sms;
using NotificationService.Infrastructure.Telegram;

namespace Notification_Service.Extensions;

public static class ServiceCollectionExtenshion
{
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEmailSender, EmailSender>();
        builder.Services.AddHttpClient<ISmsSender, SmsSender>();
        builder.Services.AddHttpClient<ITelegramSender, TelegramSender>();
        
        return builder;
    }
}