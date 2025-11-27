using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// ✔ No runtime compilation needed in .NET 9
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✔ Must be before routing
app.UsePathBase("/admin");

// ✔ Static files inside path base
app.UseStaticFiles();

app.UseRouting();

// ✔ Fix for /admin prefix so controllers work correctly
app.Use((context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/admin", out var remaining))
    {
        context.Request.Path = remaining;
    }
    return next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
