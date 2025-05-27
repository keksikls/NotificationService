using Microsoft.AspNetCore.Mvc;

namespace Notification_Service.Controllers;

public class NotificationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}