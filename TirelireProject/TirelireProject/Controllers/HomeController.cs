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

        // Méthode pour créer une route depuis appli ASP.NET Core, afin de servir de point d'entrée de l'application React
        public IActionResult ReactApp()
        {
            return File("~/index.html", "text/html"); // Assurez-vous que le chemin correspond à l'emplacement de votre fichier HTML principal.
        }

        IActionResult File(string v1, string v2)
        {
            throw new NotImplementedException();
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