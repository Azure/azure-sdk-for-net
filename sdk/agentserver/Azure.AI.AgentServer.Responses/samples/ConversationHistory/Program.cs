using Azure.AI.AgentServer.Responses;
using ConversationHistory;

var builder = WebApplication.CreateBuilder(args);

// Configure the responses server with a history limit.
// DefaultFetchHistoryCount controls how many prior items are resolved
// when the handler calls context.GetHistoryAsync(). Default is 100.
builder.Services.AddResponsesServer(options =>
{
    options.DefaultFetchHistoryCount = 20;
});

builder.Services.AddSingleton<IResponseHandler, ConversationHandler>();

var app = builder.Build();
app.MapGet("/ready", () => Results.Ok("ready"));
app.MapResponsesServer();
app.Run();
