using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TirelireProject.Data;
using TirelireProject.Models;

public class MyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
      private readonly TirelireProjectContext _context;

    public MyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        TirelireProjectContext context)
        : base(options, logger, encoder, clock)
    {
        _context = context;
    }
    public async Task<AuthenticateResult> AuthenticateAsync()
    {

        // Obtenez les valeurs de l'e-mail et du mot de passe depuis la requête
        //var email = "example@example.com"; 
        //var password = "password"; 

        //if (IsValidUser(email, password))
        {
        
       //     var claims = new List<Claim>
        {
        //    new Claim(ClaimTypes.Name, email)
        };

       //     var identity = new ClaimsIdentity(claims, nameof(MyAuthenticationHandler)); 
        //    var principal = new ClaimsPrincipal(identity);
         //   var ticket = new AuthenticationTicket(principal, nameof(MyAuthenticationHandler));

        //    return AuthenticateResult.Success(ticket);
        }

        // return AuthenticateResult.Fail("Échec de l'authentification");
        {
            // Vous pouvez laisser cette méthode vide s'il n'y a pas de logique d'authentification personnalisée à gérer ici.
            // Si vous avez déjà implémenté la logique d'authentification dans la méthode AuthenticateAsync(),
            // vous n'avez peut-être pas besoin de mettre de code supplémentaire ici.
            // Cependant, la méthode doit être présente pour respecter l'interface.

            return AuthenticateResult.NoResult(); // Vous pouvez retourner NoResult si vous ne traitez rien ici.
        }
    }

    public Task ChallengeAsync(AuthenticationProperties? properties)
    {
        throw new NotImplementedException();
    }

    public Task ForbidAsync(AuthenticationProperties? properties)
    {
        throw new NotImplementedException();
    }

    public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
    {
        throw new NotImplementedException();
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        throw new NotImplementedException();
    }

    // Méthode de vérification des informations d'authentification (à personnaliser)
    private bool IsValidUser(string email, string password)
    {
        var user = _context.Customer.SingleOrDefault(u => u.EmailAddress == email);

        // Vérifie si l'utilisateur existe
        if (user == null)
        {
            return false;
        }
        else
        {
            // Vérifie si le mot de passe correspond 
            bool isPasswordValid = VerifyPasswordHash(password, user.Password);
            return isPasswordValid;
        }
    }

    // Méthode pour vérifier le hachage du mot de passe (à implémenter)
    private bool VerifyPasswordHash(string password, string hashedPassword)
    {
        // Ajoutez ici la logique pour vérifier le hachage du mot de passe
        // Par exemple, utilisez un algorithme de hachage tel que BCrypt ou SHA-256
        // Comparez le hachage du mot de passe avec le hachage stocké dans la base de données
        // Retournez true si les hachages correspondent, sinon false
        return password == hashedPassword;
    }
}
