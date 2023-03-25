using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using S_ART__Version0_0_1.Data;
using S_ART__Version0_0_1.Helpers;
using S_ART__Version0_0_1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme =
   CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme =
  CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme =
  CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie();




string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryUsuarios>();
builder.Services.AddTransient<RepositoryFormularios>();
builder.Services.AddSingleton<HelperPathProvider>();
builder.Services.AddTransient<HelperUploadFiles>();
builder.Services.AddDbContext<UsuariosContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews(
    options => options.EnableEndpointRouting = false);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(
    name: "default",
    template: "{controller=Home}/{action=Index}/{id?}"
    );
});
   

app.Run();
