using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Showcase.CleanArchitecture.Application.Behaviors;
using Showcase.CleanArchitecture.Domain.Abstractions;
using Showcase.CleanArchitecture.Infrastructure;
using Showcase.CleanArchitecture.Infrastructure.Repositories;
using Showcase.CleanArchitecture.Presentation.Endpoints;
using Showcase.CleanArchitecture.Presentation.Middlewares;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var targetAssembly = Assembly.GetExecutingAssembly();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddValidatorsFromAssembly(targetAssembly);

builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.WithProperty("Showcase.CleanArchitecture", "Showcase.CleanArchitecture")
                .CreateLogger();

builder.Services.AddSingleton(Log.Logger);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(dbContext => dbContext.UseNpgsql(builder.Configuration.GetConnectionString("PostgresDataBase")));

builder.Services.AddScoped<IUnitOfWork>(factory => factory.GetRequiredService<ApplicationDbContext>());

builder.Services.AddScoped<IDbConnection>(factory => factory.GetRequiredService<ApplicationDbContext>().Database.GetDbConnection());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseRouting();

app.MapCustomerEndpoints();

await ApplyMigrationsAsync(app.Services);

app.Run();

static async Task ApplyMigrationsAsync(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();

    await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    await dbContext.Database.MigrateAsync();
}