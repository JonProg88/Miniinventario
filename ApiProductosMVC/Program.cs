

using ApiProductosMVC.Bussiness.Interfaces;
using ApiProductosMVC.Bussiness.Services;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// Servicios
// ===============================

// Controllers (API)
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias
builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

// ===============================
// Pipeline HTTP
// ===============================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // opcional, no estorba

app.UseAuthorization();

app.MapControllers();

app.Run();
