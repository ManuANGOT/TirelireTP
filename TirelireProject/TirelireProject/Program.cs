using Microsoft.AspNetCore.Authentication;
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
                    services.AddSingleton<MyAuthenticationHandler>();
                    services.AddAuthentication("MyScheme")
                        .AddScheme<AuthenticationSchemeOptions, MyAuthenticationHandler>("MyScheme", options => { });
                    services.AddAuthorization();
                });

                webBuilder.Configure((context, app) =>
                {
                    app.UseAuthentication();
                    app.UseAuthorization();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapGet("/", async context =>
                        {
                            await context.Response.WriteAsync("Hello World!");
                        });
                    });
                });
            });
}