using System.Collections.Concurrent;
using System.IO.IsolatedStorage;
using System.Text;
using Microsoft.AspNetCore.Mvc;

var linesToAdd = new ConcurrentQueue<string>();

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
    string newLine = info.Serialize();

    Console.WriteLine("Adding to que");
    linesToAdd.Enqueue(newLine);
    return newLine;
}).DisableAntiforgery();



_ = appendNewThings();
app.Run();


async Task appendNewThings(){
    Console.WriteLine("Starting writer");
    

    while(true){
        string toAppend = "";

        if(linesToAdd.TryDequeue(out toAppend)){
            Console.WriteLine("New line to append");
            File.AppendAllText("/app/contact.csv", toAppend);
        }else{
            await Task.Delay(100);
        }
    }

    
}
