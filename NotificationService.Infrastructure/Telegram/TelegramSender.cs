using Microsoft.Extensions.Configuration;
using NotificationService.Application.Interfaces;

namespace NotificationService.Infrastructure.Telegram;

public class TelegramSender : ITelegramSender
{
    private readonly HttpClient _httpClient;
    private readonly string _botToken;

    public TelegramSender(IConfiguration configuration,HttpClient httpClient)
    {
        _httpClient = httpClient;
        _botToken = configuration["Telegram:BotToken"] ?? throw new ArgumentNullException("botToken null exception");
    }
    
    public async Task SendAsync(string chatId, string message)
    {
        var url = $"https://api.telegram.org/bot{_botToken}/sendMessage?chat_id={chatId}&text={Uri.EscapeDataString(message)}";
        var payload = new Dictionary<string, string>
        {
            {"chat_Id",chatId},
            {"text" , message}
        };
        
        var response = await _httpClient.PostAsync(url, new FormUrlEncodedContent(payload));
        response.EnsureSuccessStatusCode();
    }
}