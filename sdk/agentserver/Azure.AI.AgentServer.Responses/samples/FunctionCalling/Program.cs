using Azure.AI.AgentServer.Responses;
using FunctionCalling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponsesServer();
builder.Services.AddSingleton<IResponseHandler, WeatherHandler>();

var app = builder.Build();

app.MapGet("/ready", () => Results.Ok("ready"));
app.MapResponsesServer();

app.Run();
