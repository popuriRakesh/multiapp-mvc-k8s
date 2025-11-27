using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UsePathBase("/user");

app.UseStaticFiles();

app.UseRouting();

app.Use((context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/user", out var remaining))
    {
        context.Request.Path = remaining;
    }
    return next();
});

app.MapDefaultControllerRoute();

app.Run();
