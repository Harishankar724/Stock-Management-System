using Microsoft.AspNetCore.Mvc;

namespace Stock_Management_System.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }
    }

}
