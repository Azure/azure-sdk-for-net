using Azure.AI.AgentServer.Responses;
using GettingStarted;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponsesServer();
builder.Services.AddSingleton<IResponseHandler, EchoHandler>();

var app = builder.Build();

app.MapGet("/ready", () => Results.Ok("ready"));
app.MapResponsesServer();

app.Run();
