using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using NotificationService.Application.Interfaces;

namespace NotificationService.Infrastructure.Email;

public class EmailSender : IEmailSender
{
    private readonly string _fromAdress;
    private readonly SmtpClient _smtpClient;

    public EmailSender(IConfiguration configuration)
    {
        var smtpSettings = configuration.GetSection("SmtpSettings");

        _fromAdress = smtpSettings["From"];
        var host = smtpSettings["Host"];
        var port = int.Parse(smtpSettings["Port"]);
        var userName = smtpSettings["UserName"];
        var password = smtpSettings["Password"];
        var enableSsl = bool.Parse(smtpSettings["EnableSsl"]);

        _smtpClient = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(userName, password),
            EnableSsl = enableSsl
        };
    }

    public async Task SendAsync(string recipient, string subject, string content)
    {
        var mail = new MailMessage(_fromAdress, recipient, subject, content)
        {
            IsBodyHtml = true
        };
        
        await _smtpClient.SendMailAsync(mail);
    }
}