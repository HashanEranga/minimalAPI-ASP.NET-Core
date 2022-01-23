using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// create builder service for Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Library API", Description = "Keeping track of the Books of a library"});
});

var app = builder.Build();

// create Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1");
});

app.MapGet("/", () => "Hello World!");

app.Run();
