using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ✅ LISTEN ON 8080 (matches service targetPort)
builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

// ❌ REMOVE UsePathBase
// ❌ REMOVE path-rewrite middleware

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
