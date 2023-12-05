

using System;
using TigerPadG4.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);





builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<UserContext>();

context.Database.EnsureCreated();
//context.Database.EnsureDeleted();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();



app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SignUp}/{action=UserLogin}/{id?}");

app.Run();
