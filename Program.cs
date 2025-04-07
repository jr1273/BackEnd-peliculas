using Microsoft.EntityFrameworkCore;
using Peliculas_Api;
using Peliculas_Api.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<ApplicationDbContext>(opciones => 
opciones.UseSqlServer("name=DefaultConnection"));

builder.Services.AddOutputCache(opciones  =>
{
    opciones.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(60);
});
var OrigenesPermitidos = builder.Configuration.GetValue<string>("origenesPermitidos")!.Split(",");

builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(opcionesCORS =>
    {
        opcionesCORS.WithOrigins(OrigenesPermitidos).AllowAnyMethod().AllowAnyHeader()
         .WithExposedHeaders("cantidad-total-registros");
        
    });
});
builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors();

app.UseAuthorization();


app.MapControllers();

app.UseOutputCache();

app.Run();
