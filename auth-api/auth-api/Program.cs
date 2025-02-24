using auth_api.Datas;
using auth_api.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("postgreConnectionString");

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
