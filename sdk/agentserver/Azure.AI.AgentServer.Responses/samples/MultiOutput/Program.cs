using Azure.AI.AgentServer.Responses;
using MultiOutput;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponsesServer();
builder.Services.AddSingleton<IResponseHandler, MultiOutputHandler>();

var app = builder.Build();

app.MapGet("/ready", () => Results.Ok("ready"));
app.MapResponsesServer();

app.Run();
