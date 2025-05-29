using System.Text.Json;
using Microsoft.Extensions.Configuration;
using NotificationService.Application.Interfaces;

namespace NotificationService.Infrastructure.Sms;

public class SmsSender : ISmsSender
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public SmsSender(IConfiguration configuration,HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiKey = configuration["SmsRu:ApiKey"] ?? throw new ArgumentNullException("apiKey null exception");
    }
    public async Task SendAsync(string recipient, string message)
    {
        var url = $"https://sms.ru/sms/send?api_id={_apiKey}&to={recipient}&msg={Uri.EscapeDataString(message)}&json=1";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var json = await response.Content.ReadAsStringAsync();
        var result =  JsonSerializer.Deserialize<JsonElement>(json);

        if (result.GetProperty("status").GetString() != "OK")
        {
            var error = result.GetProperty("error").GetString();
            throw new Exception($"sms not send{error}");
        }
    }
}