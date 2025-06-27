using Dream_House.Data;
using Dream_House.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();