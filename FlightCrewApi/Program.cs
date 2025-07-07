using FlightCrew.Application.Abstractions;
using FlightCrew.Application.UseCases.PilotUseCases.Queries;
using FlightCrew.Infrastructure.Persistence;
using FlightCrew.Infrastructure.Repositories;
using FlightCrew.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<FlightCrewDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<IPilotRepository, PilotRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(typeof(GetAllFlightsQueryRequest).Assembly));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FlightCrewDbContext>();
    db.Database.Migrate(); 
    var seeder = scope.ServiceProvider.GetRequiredService<SeedService>();
    seeder.Seed(); 
}

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
