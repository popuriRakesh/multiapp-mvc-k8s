using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// ✅ MUST listen on container port
builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

// ✅ This matches Ingress path
app.UsePathBase("/user");

app.UseStaticFiles();
app.UseRouting();

// ✅ Strip /user before MVC routing
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/user", out var remaining))
    {
        context.Request.Path = remaining;
    }
    await next();
});

// ✅ THIS WAS MISSING OR WRONG
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
