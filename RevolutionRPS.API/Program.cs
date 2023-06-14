using Microsoft.EntityFrameworkCore;
using RevolutionRPS.API.Domain;
using RevolutionRPS.API.Infra;
using RevolutionRPS.API.Interfaces;
using RevolutionRPS.API.Repositoy;
using RevolutionRPS.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextRps>(options => options.UseInMemoryDatabase(databaseName: "db"));
builder.Services.AddScoped<IJogadorService, JogadorService>();

//builder.Services.AddTransient<IJogadorRepository, JogadorRepository<BaseContext>>();
builder.Services.AddTransient<IJogadorRepository, JogadorRepository<ContextRps>>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




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