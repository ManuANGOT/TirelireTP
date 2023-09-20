using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TirelireProject.Data;
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
