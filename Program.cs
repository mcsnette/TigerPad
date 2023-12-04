

using Microsoft.EntityFrameworkCore;
using System;
using TigerPadG4.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<UserClass>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 1;

}).AddEntityFrameworkStores<UserContext>();

var app = builder.Build();
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<UserContext>();
//context.Database.EnsureDeleted();
context.Database.EnsureCreated();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SignUp}/{action=UserLogin}/{id?}");

app.Run();
