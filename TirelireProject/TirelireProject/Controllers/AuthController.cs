using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TirelireProject.Data;




namespace TirelireProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly TirelireProjectContext _context;
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Ici, vous pouvez collecter les informations d'authentification de l'utilisateur,
            // puis utiliser le gestionnaire d'authentification personnalisé pour valider l'utilisateur.

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email), // Vous pouvez ajouter d'autres revendications (claims) ici si nécessaire
            };

            var identity = new ClaimsIdentity(claims, "custom");
            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Si vous voulez créer un cookie persistant
            };

            await HttpContext.SignInAsync("custom", principal, authProperties);

            // Redirigez l'utilisateur vers la page souhaitée après l'authentification réussie
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("custom"); // Déconnectez l'utilisateur

            // Redirigez l'utilisateur vers la page d'accueil ou une autre page après la déconnexion
            return RedirectToAction("Index", "Home");
        }
    }
}