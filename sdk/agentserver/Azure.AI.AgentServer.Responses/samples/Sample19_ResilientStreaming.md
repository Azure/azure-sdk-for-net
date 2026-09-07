# Sample 19 — Resilient streaming with handler-managed phase checkpoints

A resilient response handler with **no** upstream framework. Each
`ResponseEventStream.Checkpoint()` persists the completed phase output, and the
recovered handler uses `context.PersistedResponse.Output.Count` as its resume
watermark.

The handler runs three phases (`analyze` → `generate` → `refine`) and emits one
output item per phase. After each phase finishes it calls `stream.Checkpoint()`
to persist a durable snapshot. On a
recovered entry, the handler seeds a new `ResponseEventStream` from
`context.PersistedResponse` (the last checkpoint — it already contains the output
items for the completed phases), re-emits `response.created` (which the framework
deduplicates on the durable stream), emits `response.in_progress` as the
client-visible reset point carrying the seeded prior output, and resumes after
the number of output items already present in the snapshot.

Demonstrates:

- The recovery-aware default pattern from the developer guide.
- Seeding a `ResponseEventStream` from `context.PersistedResponse` on recovery.
- Unconditional `response.created` with framework-side single-created dedup.
- The durable response snapshot's completed output count as the resume point.
- Pre-entry / mid-stream / post-stream cancellation handling.

Options: `ResilientBackground = true`.

## Handler

The handler is a `ResponseHandler` whose `CreateAsync` is an async iterator: it
`yield return`s events produced by `ResponseEventStream`. Each `Emit*` /
`OutputItemMessage` / `Checkpoint` call **returns** the event(s) to yield.

```C# Snippet:Responses_Sample19_ResilientStreamingHandler
// Sample 19 — resilient streaming with handler-managed phase checkpoints.
// The handler seeds a ResponseEventStream from the last durable response snapshot
// and resumes after the output items already committed by prior phases.
public class ResilientStreamingHandler : ResponseHandler
{
    private static readonly string[] PhaseOrder = { "analyze", "generate", "refine" };

    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string prompt = await context.GetInputTextAsync(cancellationToken: cancellationToken);

        // Recovery-aware stream seeding. On a recovered entry, seed the stream from the
        // last durable checkpoint (context.PersistedResponse) so the completed phases'
        // output items are carried forward and replayed on the reset. On a fresh entry,
        // start from the request.
        ResponseEventStream stream =
            context.IsRecovery && context.PersistedResponse is not null
                ? new ResponseEventStream(context, context.PersistedResponse)
                : new ResponseEventStream(context, request);

        // Always emit response.created — even on recovery. The framework keeps exactly one
        // response.created on the durable stream across lifetimes: on a recovered entry the
        // duplicate is dropped and the following response.in_progress becomes the
        // client-visible reset carrying the seeded prior output.
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

            // Persist a durable snapshot at the phase boundary
            // (no-op unless resilient background).
            yield return stream.Checkpoint();
        }

        yield return stream.EmitCompleted();
    }

    private static int NextPhaseIndex(ResponseContext context)
    {
        int completedPhases = context.IsRecovery
            ? context.PersistedResponse?.OutputItems?.Count ?? 0
            : 0;
        return Math.Min(completedPhases, PhaseOrder.Length);
    }
}
```

## Start the server

Enable resilient background responses via `ResponsesServerOptions`:

```C# Snippet:Responses_Sample19_StartServer
// Resilient background responses are composed on the Core durable-task /
// event-stream primitives; enabling the option is all the handler needs.
AgentHost.CreateBuilder()
    .AddResponses<ResilientStreamingHandler>(o => o.ResilientBackground = true)
    .Build()
    .Run();
```

## Try it

```bash
curl -N -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "streamer", "input": "Tell me a joke", "stream": true, "store": true, "background": true}'
```

## Recovery behavior

- Each phase calls `stream.Checkpoint()` — a no-op unless the response is
  resilient background.
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
