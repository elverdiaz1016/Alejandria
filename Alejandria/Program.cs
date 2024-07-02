using Alejandria.DataAccess;
using Alejandria.DataAccess.Repositories;
using Alejandria.Interfaces.IRepositories;
using Alejandria.Interfaces.IServices;
using Alejandria.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AlejandriaDbContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:AlejandriaConnection"]);
});

builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<IAutorService, AutorService>();

builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<ILibroService, LibroService>();

var app = builder.Build();  

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
