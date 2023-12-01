using Microsoft.EntityFrameworkCore;
using NajotNur.Application.Data;
using NajotNur.Application.Interfaces.Users;
using NajotNur.Application.Repositories.Users;
using NajotNur.Application.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var connectionString = builder.Configuration.GetConnectionString("DockerConnection");
var defaultconnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NurDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
