using System.Data;
using System.Data.SqlClient;
using ConsoDb_BLL.Interfaces;
using ConsoDb_BLL.Services;
using ConsoDb_DAL.Interfaces;
using ConsoDb_DAL.Repositories;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnection>(service =>
    {
        return new NpgsqlConnection(builder.Configuration.GetConnectionString("Npgsql"));
    }
);

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();