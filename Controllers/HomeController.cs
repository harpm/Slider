using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Slider5.Repository;

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
