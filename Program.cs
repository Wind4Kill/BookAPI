using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewBookApi.ApiEndpoints;
using NewBookApi.Domain;
using NewBookApi.Domain.Entities;
using NewBookApi.Services;
using NewBookApi.Services.DTOs;
using NewBookApi.Services.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

if (builder.Environment.IsDevelopment())
{
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();
}

string dbConnectionStr = builder.Configuration.GetConnectionString("DbConnectionString")!;

builder.Services.AddDbContext<ApplicationContext>(options =>
{
      options.UseSqlite(dbConnectionStr);
});

builder.Services.AddTransient<IBooksControlService, BooksControlService>();

builder.Services.AddTransient<IAuthorControlService, AuthorControlService>();


var app = builder.Build();

app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
      app.UseSwagger();
      app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
      app.UseExceptionHandler();

      await using (var _scope = app.Services.CreateAsyncScope())
      {
            ApplicationContext _context = _scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            if (_context.Database.GetPendingMigrations().Any())
            {
                 await _context.Database.MigrateAsync();
            }
      }
}

app.AddBookControlEndpoints();
app.AddAuthorControlEndpoints();
app.Run();
