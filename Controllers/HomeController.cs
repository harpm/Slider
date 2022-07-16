using Microsoft.AspNetCore.Mvc;

namespace Slider5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
