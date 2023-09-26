namespace TirelireProject.Models
{
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using TirelireProject.Data;
    using TirelireProject.Models;

   
    public class MyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly TirelireProjectContext _context; // Injectez le contexte de base de données

        public MyAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            TirelireProjectContext context) // Injectez le contexte de base de données ici
            : base(options, logger, encoder, clock)
        {
            _context = context; // Initialisez le champ avec le contexte de base de données
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Récupérez les valeurs de l'email et du mot de passe depuis la requête
            var EmailAddress = Request.Form["EmailAddress"];
            var Password = Request.Form["password"];


            if (IsValidUser(EmailAddress, Password))
            {
                // Créez un ClaimsPrincipal avec les informations de l'utilisateur
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, EmailAddress),

            };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Échec de l'authentification");
        }

        // Méthode de vérification des informations d'authentification (à personnaliser)
        private bool IsValidUser(string EmailAddress, string password)
        {

            var user = _context.Customer.SingleOrDefault(u => u.EmailAddress == EmailAddress);

            // Vérifie si l'utilisateur existe
            if (user == null)
            {
                return false;
            }
            else if (user.Password == password)
            {
                return true;
            }

            // Vérifiez si le mot de passe correspond

            bool isPasswordValid = VerifyPasswordHash(password, user.Password);

            return isPasswordValid;
        }


        private bool VerifyPasswordHash(string password, string hashedPassword)
        {

            return password == hashedPassword;
        }
    }
}