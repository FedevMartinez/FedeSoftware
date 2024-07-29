using BaseDeDatos.Contexto;
using BaseDeDatos.Entidades;
using BaseDeDatos.Repository;
using FedeSoftware.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FedeBaseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

builder.Services.AddScoped<IClienteProveedorRepository, ClienteProveedorRepository>();

builder.Services.AddScoped<IClienteProveedorService, ClienteProveedorService>();

builder.Services.AddScoped<IRepositoryGeneric<ClienteProveedor>, RepositoryGeneric<ClienteProveedor>>();


//builder.Services.InyectarDependencias(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
