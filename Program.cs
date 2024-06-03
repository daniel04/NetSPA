using Microsoft.EntityFrameworkCore;
using NetSPA.ServicesApp.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//Configuracion de Conexion a la Base de datos utilizando el Driver que corresponde, para este caso PostgreSql
builder.Services.AddDbContext<SpaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionTienda"))); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
