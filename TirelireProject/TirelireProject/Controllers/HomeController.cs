using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TirelireProject.Models;

namespace TirelireProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to My piggy project";

            return View();
        }

        public IActionResult ClientPage()
        {
            return View("Client");
        }

        public IActionResult AdminPage()
        {
            return View("Admin");
        }

        public IActionResult ModPage()
        {
            return View("Mod");
        }

        public IActionResult AssistPage()
        {
            return View("Assist");
        }
    }
}