// Travel Planner Agent — Demonstrates multi-turn conversation with the Invocations
// protocol. Each request carries a session_id query parameter so the handler can
// accumulate conversation history across turns.

using System.Collections.Concurrent;
using Azure.AI.AgentServer.Hosting;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;

var handler = new TravelPlannerHandler();
var builder = AgentHost.CreateBuilder(args);
builder.AddInvocations(handler);
builder.Build().Run();

public class TravelPlannerHandler : InvocationHandler
{
    private readonly ConcurrentDictionary<string, List<string>> _sessions = new();

    public override async Task HandleAsync(
        HttpRequest request, HttpResponse response,
        InvocationContext context, CancellationToken cancellationToken)
    {
        var sessionId = request.Query["session_id"].FirstOrDefault() ?? "default";
        var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);

        var history = _sessions.GetOrAdd(sessionId, _ => new List<string>());

        lock (history)
        {
            history.Add($"User: {input}");
        }

        string reply;
        lock (history)
        {
            reply = history.Count switch
            {
                1 => $"Welcome to Travel Planner! You said: \"{input}\". Where would you like to go?",
                2 => $"Great choice! How many days do you plan to stay? (History: {history.Count} turns)",
                3 => $"Here's a suggested itinerary based on our {history.Count}-turn conversation:\n" +
                     string.Join("\n", history.Select((h, i) => $"  Turn {i + 1}: {h}")),
                _ => $"Turn {history.Count}: Got it! Anything else you'd like to plan?\n" +
                     $"Full conversation so far:\n" +
                     string.Join("\n", history.Select((h, i) => $"  {i + 1}. {h}"))
            };
            history.Add($"Agent: {reply}");
        }

        await response.WriteAsync(reply, cancellationToken);
    }
}
