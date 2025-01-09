using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApi.Citas.Administrador.DAL;
using WebApi.Citas.Administrador.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Configurar inyección de dependencias para AsesoresDAL
builder.Services.AddScoped<AsesoresDAL>();

// Configurar cadena de conexión y contexto de base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BDConexion>(options =>
    options.UseSqlServer(connectionString));

// Agregar servicios de controladores
builder.Services.AddControllers();

// Configurar CORS para permitir acceso desde el frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:7223") // Cambiar URL si es necesario
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Configurar Swagger para documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Web API Citas Administrador",
        Version = "v1",
        Description = "API para la gestión de citas y asesores",
    });
});

var app = builder.Build();

// Configuración de entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API Citas Administrador v1");
    });
}

// Middleware para redirección HTTPS
app.UseHttpsRedirection();

// Usar la política de CORS configurada
app.UseCors("AllowFrontend");

// Middleware para autorización
app.UseAuthorization();

// Configurar los controladores
app.MapControllers();

// Ejecutar la aplicación
app.Run();
