using MediatR;
using CleanStore.Application;
using CleanStore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CleanStore.Infrastructure.SharedContext.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/v1/accounts", async (
    ISender sender,
    CleanStore.Application.AccountContext.UseCases.Create.Command command) =>
{
    var result = await sender.Send(command);
    return TypedResults.Created($"v1/accounts/{result.Value.Id}", result);
});

app.Run();