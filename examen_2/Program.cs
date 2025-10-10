using examen_2.Models;
using examen_2.Services.Abstractions;
using examen_2.Services.Implements;
using examen_2.UnitOfWork.Abstractions;
using examen_2.UnitOfWork.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ContextDbTienda>(options => options.UseNpgsql(connectionString));
                                                 

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title=  "compensatuviaje.com",
        Version =  "v1.0",
        Description = "backend de compensatuviaje en .Net8"
    });
});
// registrando IUnitOfwork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger se habilita solo en desarrollo (SIN CAMBIOS)
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Business Management API v1");
    });
}
else
{
    // Configuración para producción (SIN CAMBIOS)
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();



//app.UseHttpsRedirection();


app.Run();
