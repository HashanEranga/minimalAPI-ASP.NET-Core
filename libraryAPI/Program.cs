using Microsoft.OpenApi.Models;
using libraryAPI.Db;

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
app.MapGet("/books/{bookId}", (int bookId) => BookDatabase.GetBook(bookId));
app.MapGet("/books", () => BookDatabase.GetBooks());
app.MapPost("/books", (Book book) => BookDatabase.CreateBook(book));
app.MapPut("/books", (Book book) => BookDatabase.UpdateBook(book));
app.MapDelete("/books/{bookId}", (int bookId) => BookDatabase.RemoveBook(bookId));
app.Run();
