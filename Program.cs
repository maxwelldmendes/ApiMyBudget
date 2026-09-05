using ApiMyBudget.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configura o contexto do banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Mapeia a interface visual do Scalar
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Minha API")
               .WithTheme(ScalarTheme.Moon); // Opcional: define o tema visual
    });
}

//app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();
app.Run();
