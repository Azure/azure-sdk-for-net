# Sample 20 — Resilient steering with cancellation × recovery composition

The .NET port of Python `sample_20_resilient_steering.py`. A steerable resilient
handler with **no** upstream framework. It demonstrates how the cancellation
policy and the crash-recovery contract compose when steering, client cancel, and
shutdown interleave with crash recovery.

Options: `ResilientBackground = true`, `SteerableConversations = true`.

Differences from Sample 19:

- `SteerableConversations = true` — each new turn supersedes the prior one; the
  prior turn's handler observes its cancellation token set with **no** cause flag
  (steering pressure — neither `ClientCancelled` nor `IsShutdownRequested` is set).
- A single message item per turn (no phases). Recovery within a turn does not try
  to checkpoint partial token output — the resumption response is **empty** and
  the recovered attempt re-streams from scratch. This is the realistic case for
  handlers wrapping non-deterministic upstreams (LLMs): you cannot pick up exactly
  where you left off, so you start the turn over and let the client redraw on the
  reset.
- A `turn_count` watermark survives across turns.

## Distinguishing the three "stop" causes

When the cancellation token is signaled, inspect the context to find the cause:

| `ClientCancelled` | `IsShutdownRequested` | Meaning | Handler action |
|-------------------|-----------------------|---------|----------------|
| `true` | — | Client cancelled | Return without terminal (`cancelled`). |
| — | `true` | Graceful shutdown | `await context.ExitForRecoveryAsync()` — re-run next lifetime. |
| `false` | `false` | Steering pressure | Emit `completed` with partial content so it is valid context for the superseding turn. |

## Handler

```csharp
using System.Runtime.CompilerServices;
using System.Text;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

public class ResilientSteeringHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string prompt = await context.GetInputTextAsync(cancellationToken: cancellationToken);

        int turnCount = 1;
        if (context.ConversationChainMetadata.TryGet("state", "turn_count", out var raw)
            && int.TryParse(raw, out var prior))
        {
            turnCount = prior + 1;
        }

        context.ConversationChainMetadata.Set("state", "turn_count", turnCount.ToString());
        await context.ConversationChainMetadata.FlushAsync(cancellationToken);

        var stream = new ResponseEventStream(context, request);

        // This handler re-runs from scratch on recovery: the upstream generation is
        // non-deterministic, so there is no meaningful partial state to replay (the single
        // message output item is only emitted at completion, so a mid-stream crash leaves no
        // durable output items to seed). Always emit response.created — even on recovery. The
        // framework keeps exactly one response.created on the durable stream across lifetimes,
        // so on a recovered entry it drops this duplicate and the following (empty)
        // response.in_progress becomes the client-visible reset, telling the client to redraw
        // from here. The handler never branches on IsRecovery to decide whether to emit created.
        // (Mirrors the Python steering sample's empty-resumption pattern.)
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        string[] words = $"Let me explain {prompt} in detail. Comprehensive answer here.".Split(' ');
        var partial = new StringBuilder();

        foreach (string word in words)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                if (context.ClientCancelled)
                {
                    yield break; // client cancelled — no terminal
                }

                if (context.IsShutdownRequested)
                {
                    await context.ExitForRecoveryAsync(cancellationToken);
                    yield break; // shutdown — re-run next lifetime
                }

                // Steering pressure: end this turn cleanly with partial content so it is valid
                // context for the superseding turn.
                foreach (var evt in stream.OutputItemMessage(partial.ToString()))
                {
                    yield return evt;
                }

                yield return stream.EmitCompleted();
                yield break;
            }

            partial.Append(word).Append(' ');
        }

        foreach (var evt in stream.OutputItemMessage(partial.ToString()))
        {
            yield return evt;
        }

        yield return stream.EmitCompleted();
    }
}
```

## Start the server

```csharp
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAgentServerCore();
builder.Services.AddResponsesServer(o =>
{
    o.ResilientBackground = true;
    o.SteerableConversations = true;
});
builder.Services.AddScoped<ResponseHandler, ResilientSteeringHandler>();

var app = builder.Build();
app.UseAgentServerCore();
app.MapResponsesServer();
app.Run();
```

## Try it

```bash
# Turn 1
curl -N -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "agent", "input": "Explain quantum computing", "store": true, "background": true}'

# Steer (supersede turn 1)
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "agent", "input": "Actually explain relativity", "store": true, "background": true, "previous_response_id": "<id>"}'
```

## Recovery behavior

- On steering, the superseded turn's handler ends cleanly (`completed` with
  partial content) so it is valid context for the superseding turn, which sees
  `IsSteeredTurn = true`.
- On a mid-stream shutdown, the handler defers via `ExitForRecoveryAsync()` and
  the turn re-runs from scratch on the next lifetime, emitting an empty
  resumption reset that signals the client to redraw.
- The cross-turn `turn_count` watermark survives crashes via
  `ConversationChainMetadata.FlushAsync()`.

> **Verified.** The published flow of this sample — a concurrent turn on an
> active steerable chain enqueues (`queued`) then drains as a steered re-entry
> (`IsSteeredTurn`) — is exercised end-to-end against the real Core-composed
> engine by
> `ResilienceSampleParityEndToEndTests.Sample20_ResilientSteering_EnqueuesThenDrainsSteeredTurn`.
