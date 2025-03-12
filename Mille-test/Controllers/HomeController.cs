using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mille_test.Models;

namespace Mille_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return new JsonResult(new { test = "test" });
        }

    }
}
