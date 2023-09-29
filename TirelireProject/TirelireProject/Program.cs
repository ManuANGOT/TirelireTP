using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TirelireProject.Data;
using TirelireProject.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TirelireProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TirelireProjectContext") ?? throw new InvalidOperationException("Connection string 'TirelireProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
  
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Pour relier ASP.NET Core et projet React.
app.UseStaticFiles();

// Configuration des routes dans ASP.NET Core pour gérer à la fois les appels d'API et les appels à l'application React. CF HomeController
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "react",
        pattern: "{controller=Home}/{action=ReactApp}/{id?}");

    // Autres routes API (Autres controllers Customer, Admin, Mod, Assist) en cours
});

app.Run();


public partial class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
     Host.CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.ConfigureServices((context, services) =>
             {
                 services.AddAuthentication("MyScheme")
                     .AddScheme<AuthenticationSchemeOptions, MyAuthenticationHandler>("MyScheme", options => { });
                 services.AddAuthorization();

                 services.AddScoped<MyAuthenticationHandler>();
                 services.AddControllersWithViews();
             });

             webBuilder.Configure((context, app) =>
             {
                 app.UseAuthentication();
                 app.UseAuthorization();

                 app.UseEndpoints(endpoints =>
                 {
                     endpoints.MapControllerRoute(
                         name: "react",
                         pattern: "{controller=Home}/{action=ReactApp}/{id?}");

                     // Autres routes API (Autres controllers Customer, Admin, Mod, Assist)
                     endpoints.MapControllerRoute(
                         name: "default",
                         pattern: "{controller=Home}/{action=Index}/{id?}");
                 });
             });
         });
}