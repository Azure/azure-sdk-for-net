# Sample 19 — Resilient streaming with handler-managed phase checkpoints

The .NET port of Python `sample_19_resilient_streaming.py`. A resilient response
handler with **no** upstream framework — checkpoints are managed entirely via
`context.ConversationChainMetadata`. This is the teaching shape of the recovery
contract; samples that wrap a real upstream framework layer additional
reconciliation on top of the same pattern.

The handler runs three phases (`analyze` → `generate` → `refine`) and emits one
output item per phase. After each phase finishes it stamps a `phase_complete`
watermark and calls `stream.Checkpoint()` to persist a durable snapshot. On a
recovered entry, the handler seeds a new `ResponseEventStream` from
`context.PersistedResponse` (the last checkpoint — it already contains the output
items for the completed phases), re-emits `response.created` (which the framework
deduplicates on the durable stream), emits `response.in_progress` as the
client-visible reset point carrying the seeded prior output, and resumes at the
first incomplete phase (read from the `phase_complete` watermark).

Demonstrates:

- The recovery-aware default pattern from the developer guide.
- Seeding a `ResponseEventStream` from `context.PersistedResponse` on recovery.
- Unconditional `response.created` with framework-side single-created dedup.
- A `phase_complete` watermark in `ConversationChainMetadata` to pick the resume
  point.
- Pre-entry / mid-stream / post-stream cancellation handling.

Options: `ResilientBackground = true`.

## Handler

The handler is a `ResponseHandler` whose `CreateAsync` is an async iterator: it
`yield return`s events produced by `ResponseEventStream`. Each `Emit*` /
`OutputItemMessage` / `Checkpoint` call **returns** the event(s) to yield.

```csharp
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

public class ResilientStreamingHandler : ResponseHandler
{
    private static readonly string[] PhaseOrder = { "analyze", "generate", "refine" };

    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string prompt = await context.GetInputTextAsync(cancellationToken: cancellationToken);

        // Recovery-aware stream seeding. On a recovered entry, seed the stream from the last
        // durable checkpoint (context.PersistedResponse) so the output items for the phases that
        // completed before the crash are carried forward and replayed on the reset. On a fresh
        // entry, start from the request.
        ResponseEventStream stream =
            context.IsRecovery && context.PersistedResponse is not null
                ? new ResponseEventStream(context, context.PersistedResponse)
                : new ResponseEventStream(context, request);

        // Always emit response.created — even on recovery. The framework keeps exactly one
        // response.created on the durable stream across all lifetimes: on a recovered entry the
        // pre-crash created is already durable, so this duplicate is dropped and the following
        // response.in_progress becomes the client-visible reset point carrying the seeded prior
        // output. (This mirrors the Python handler pattern — the handler never branches on
        // IsRecovery to decide whether to emit created.)
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        int startPhase = NextPhaseIndex(context);
        for (int i = startPhase; i < PhaseOrder.Length; i++)
        {
            string phase = PhaseOrder[i];

            if (cancellationToken.IsCancellationRequested)
            {
                // Mid-stream shutdown: leave in_progress for recovery.
                await context.ExitForRecoveryAsync(cancellationToken);
                yield break;
            }

            string text = phase switch
            {
                "analyze" => $"[analyze] Examining input: '{prompt}'.",
                "generate" => $"[generate] Drafting response for: '{prompt}'.",
                _ => $"[refine] Polished result for: '{prompt}'.",
            };

            // Emit one complete message output item for this phase.
            foreach (var evt in stream.OutputItemMessage(text))
            {
                yield return evt;
            }

            // Stamp the phase watermark and durably flush it, then checkpoint.
            context.ConversationChainMetadata.Set("stream", "phase_complete", phase);
            await context.ConversationChainMetadata.FlushAsync(cancellationToken);

            // Persist a durable snapshot at the phase boundary (no-op unless resilient background).
            yield return stream.Checkpoint();
        }

        yield return stream.EmitCompleted();
    }

    // Index of the next phase to run; 0 if nothing has been checkpointed yet.
    private static int NextPhaseIndex(ResponseContext context)
    {
        if (context.ConversationChainMetadata.TryGet("stream", "phase_complete", out var done)
            && done is not null)
        {
            int idx = Array.IndexOf(PhaseOrder, done);
            if (idx >= 0)
            {
                return idx + 1;
            }
        }

        return 0;
    }
}
```

## Start the server

Enable resilient background responses via `ResponsesServerOptions`:

```csharp
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAgentServerCore();
builder.Services.AddResponsesServer(o => o.ResilientBackground = true);
builder.Services.AddScoped<ResponseHandler, ResilientStreamingHandler>();

var app = builder.Build();
app.UseAgentServerCore();
app.MapResponsesServer();
app.Run();
```

## Try it

```bash
curl -N -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "streamer", "input": "Tell me a joke", "stream": true, "store": true, "background": true}'
```

## Recovery behavior

- Each phase stamps a durable `phase_complete` watermark (flushed) and calls
  `stream.Checkpoint()` — a no-op unless the response is resilient background.
  The checkpoint persists the current response snapshot (including the output
  items emitted so far), which becomes `context.PersistedResponse` on recovery.
- On a recovered entry the handler re-emits `response.created`. The framework
  keeps exactly **one** `response.created` on the durable stream across all
  lifetimes, so the recovered duplicate is dropped and the following
  `response.in_progress` — seeded from `PersistedResponse` — is the
  client-visible reset carrying the already-completed phases' output items. The
  handler does **not** branch on `IsRecovery` to decide whether to emit
  `created`; it always emits it and lets the framework deduplicate.
- On a crash after phase *k*'s checkpoint (cutpoint C1), recovery resumes at
  phase *k+1*; the completed phases are replayed via the seeded reset.
- On a crash **before** a phase's checkpoint (cutpoint C3), that phase re-runs
  from scratch on recovery.
- Recovered events carry sequence numbers strictly greater than the pre-crash
  maximum, so the assembled cross-lifetime stream stays monotonic and contiguous.

> **Verified.** The published flow of this sample — resilient background
> streaming, a single `response.created`, a monotonic contiguous event stream,
> one output item per phase, and a terminal `completed` — is exercised
> end-to-end against the real Core-composed engine by
> `ResilienceSampleParityEndToEndTests.Sample19_ResilientStreaming_ProducesMonotonicContiguousStream`.
