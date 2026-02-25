using System.IO.IsolatedStorage;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//Using the right port
builder.WebHost.UseUrls("http://0.0.0.0:1337");

// Add anti-forgery services
builder.Services.AddAntiforgery();

var app = builder.Build();

// Use anti-forgery middleware
app.UseAntiforgery();

app.MapPost("/contact", ([FromForm] ContactInfo info) =>
{
    Console.WriteLine("Got thing");
    return info.Serialize();
}).DisableAntiforgery();

app.Run();


