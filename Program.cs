
using Microsoft.Extensions.Configuration;
using SENSHOP2._1.Controllers;
using SENSHOP2._1.Repositorio;
using static SENSHOP2._1.Models.CarritoViewModel;
using static SENSHOP2._1.Repositorio.PDFRepositorio1;
using static SENSHOP2._1.Repositorio.RepositorioFactura;
using static SENSHOP2._1.Repositorio.RepositorioPDF2;
using static SENSHOP2._1.Repositorio.RepositorioProducto;
using static SENSHOP2._1.Repositorio.RepositorioUserpdf;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PSeleccionados>();
builder.Services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddTransient<IRepositoriohome, RepositorioHome>();
builder.Services.AddTransient<IRepositorioProducto, RepositorioProducto2>();
builder.Services.AddTransient<IRepositorioContacto, RepositorioContacto>();
builder.Services.AddTransient<IRepositorioCarro, RepositorioCarro>();
builder.Services.AddTransient<IRepositorioProveedores, RepositorioProveedores>();
builder.Services.AddTransient<IRepositorioPDF1, RepositorioPDF1>();
builder.Services.AddTransient<IRepositorioPDF_2, RepositorioPDF_2>();
builder.Services.AddTransient<IRepositorioUserpdf, RepositorioUserpdf3>();
builder.Services.AddTransient<IRepositorioFactura, RepositorioFactura1>();
builder.Services.AddControllersWithViews();
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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Inventario}/{action=Tienda}/{id?}");

app.Run();
