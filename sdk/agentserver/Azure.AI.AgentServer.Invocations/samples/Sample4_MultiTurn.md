# Sample 4: Multi-turn Conversation — Travel Planner Agent

This sample builds a travel planner agent that maintains conversational state across multiple invocations using the `agent_session_id` query parameter. Each invocation refines the trip plan based on user input.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Implement the handler

```C# Snippet:Invocations_Sample4_TravelPlannerHandler
public class TravelPlannerHandler : InvocationHandler
{
    private readonly List<string> _history = new();

    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var input = await request.ReadFromJsonAsync<TravelInput>(cancellationToken);
        var message = input?.Message ?? "";

        _history.Add($"User: {message}");

        // Build a reply based on conversation state.
        string reply;
        if (_history.Count == 1)
        {
            reply = $"Great, let's plan a trip! You said: \"{message}\". " +
                    "Where would you like to go, and for how many days?";
        }
        else
        {
            var turn = _history.Count / 2 + 1;
            reply = $"Got it — turn {turn}. " +
                    $"So far we've discussed {_history.Count / 2} topic(s). " +
                    $"You said: \"{message}\". What else would you like to add?";
        }

        _history.Add($"Agent: {reply}");

        await response.WriteAsJsonAsync(new
        {
            invocation_id = context.InvocationId,
            session_id = context.SessionId,
            turn = _history.Count / 2,
            reply
        }, cancellationToken);
    }
}

public record TravelInput(string Message);
```

## Start the server

```C# Snippet:Invocations_Sample4_StartServer
AgentHost.Run<TravelPlannerHandler>(args);
```

## Test the endpoint

### Turn 1 — Start the conversation

```bash
curl -X POST "http://localhost:8088/invocations?agent_session_id=trip-001" \
  -H "Content-Type: application/json" \
  -d '{"message":"I want to plan a vacation."}'
```

### Turn 2 — Refine the plan

```bash
curl -X POST "http://localhost:8088/invocations?agent_session_id=trip-001" \
  -H "Content-Type: application/json" \
  -d '{"message":"5 days in Japan, focusing on food and temples."}'
```

### Turn 3 — Add details

```bash
curl -X POST "http://localhost:8088/invocations?agent_session_id=trip-001" \
  -H "Content-Type: application/json" \
  -d '{"message":"Budget is around $3000. Include flights."}'
```

Each invocation uses the same `agent_session_id=trip-001`, so the agent accumulates context across turns.

## Implementation pattern

This is the **Multi-turn Conversation** pattern from the Invocations protocol. The `agent_session_id` query parameter groups related invocations — the SDK resolves it automatically and makes it available via `InvocationContext.SessionId`.

This pattern composes with any response style. A multi-turn agent can return synchronous responses (as shown here), stream via SSE, or use the LRO pattern on a per-turn basis.
