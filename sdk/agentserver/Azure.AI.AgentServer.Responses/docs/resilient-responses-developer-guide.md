# Resilient Responses Developer Guide (.NET)

This guide explains how to build crash-recoverable response handlers with the
resilient background responses feature in `Azure.AI.AgentServer.Responses`. It
is the .NET companion to the Python `azure-ai-agentserver-responses`
resilience guide and mirrors its behavior 1:1.

## Overview

When `ResilientBackground = true` (opt-in — the default is `false`), the
framework wraps your response handler in a **resilient task**. If the server
crashes mid-response:

- Background responses are automatically re-invoked on restart.
- Stream events are preserved for client reconnection.
- Conversation state is maintained across crashes.

**Opting in gets you the framework half for free**: re-invocation on restart,
event replay for reconnecting clients, and conversation continuity — with no
handler changes. A naive handler re-invoked this way still produces a correct
response (it just re-runs the whole turn). The *handler* half — making the
recovered attempt resume *where it left off* and not repeat non-idempotent side
effects — is optional work you take on when you want it (see
[Choosing a resume strategy](#choosing-a-resume-strategy)).

> **Default**: `ResilientBackground` defaults to `false`. Without the opt-in, a
> crash mid-handler leaves the response in the "crash-failed" state: the
> next-lifetime recovery scanner marks it `failed` (`server_error`,
> `shutdown_reason = crash_recovery`) instead of re-invoking the handler. Set
> `ResilientBackground = true` on `ResponsesServerOptions` to engage the
> re-invoke recovery path.

## Enabling resilience

```csharp
var options = new ResponsesServerOptions
{
    ResilientBackground = true,       // opt-in crash recovery
    SteerableConversations = false,   // opt-in mid-turn steering (independent)
};
```

`ResilientBackground` and `SteerableConversations` are **independent** options.
Enabling steering does not require resilience and vice versa.

### Provider requirements (fail-loud)

`ResilientBackground = true` requires a **persistent** response store. If it is
configured with a store that does not survive process crashes (for example an
explicit in-memory store), the host **refuses to start** with an actionable
error rather than silently downgrading:

> `resilient_background=true` was configured with an explicit in-memory store
> that does not persist across process crashes. Supply a persistent store, omit
> the store to use the default file-backed store, or set
> `ResilientBackground = false`.

The default file-backed store (created under `${AGENTSERVER_STATE_ROOT}/responses/`)
never trips this guard.

## The resilience matrix

Behavior is selected by three flags: `store`, `background`, and
`ResilientBackground`. The single decision site is
`ResponseResilienceDispatch.ClassifyRow` / `DecideDisposition`:

| Row | `store` | `background` | `ResilientBackground` | On interruption |
|-----|---------|--------------|-----------------------|-----------------|
| 1 | true | true | true | **Re-invoke** with `IsRecovery = true` |
| 2 | true | true | false | Mark **failed** (`server_error`) |
| 3 | true | false | n/a | Mark **failed** (`server_error`) |
| 4 | false | n/a | n/a | No persisted state, no recovery |

Only Row 1 (`store && background && ResilientBackground`) is re-invoked; every
other row is marked failed on interruption.

### Three termination paths

| Path | Trigger | Row 1 outcome | Row 2/3 outcome |
|------|---------|---------------|-----------------|
| A | Natural terminal | Completes normally | Completes normally |
| B | Graceful shutdown (grace exhausted or `ExitForRecoveryAsync`) | Leaves `in_progress`; re-invoked next lifetime | Mark failed (`shutdown_reason = grace_exhausted`) |
| C | Crash (SIGKILL) | Re-invoked next lifetime with `IsRecovery = true` | Mark failed (`shutdown_reason = crash_recovery`) |

When a response is marked **failed** on interruption (Rows 2/3), the framework
**overlays** the failed status onto the durable snapshot: it sets `status = failed`
and attaches the `error`, but preserves everything the handler had already
persisted — `agent_reference`, `model`, `metadata`, and any `output` items
checkpointed before the crash. A failed response's `output` **may be partial**;
it is kept, not cleared. (A `cancelled` response is the exception — cancellation
always wins and clears `output` to an empty list.)

## Handler-visible recovery surface

`ResponseContext` exposes the recovery/steering surface:

| Member | Type | Meaning |
|--------|------|---------|
| `IsRecovery` | `bool` | `true` when this invocation re-enters after a crash. |
| `PersistedResponse` | `ResponseObject?` | The last durable snapshot from the prior lifetime (only on recovery). |
| `ConversationChainId` | `string` | Stable id shared across every turn/attempt of a conversation chain. |
| `ConversationChainMetadata` | `ConversationChainMetadata` | Durable, explicitly-flushed per-chain metadata. |
| `IsSteeredTurn` | `bool` | `true` on a steering-drain re-entry. |
| `PendingInputCount` | `int` | Steering inputs queued behind the current turn. |
| `ClientCancelled` | `bool` | `true` when the client explicitly cancelled (distinct from shutdown). |
| `ExitForRecoveryAsync()` | `Task` | Defer the current turn for recovery instead of failing. |

`IsRecovery` is `true` only on a crash-recovery re-entry (`entry_mode == recovered`).
A new steerable turn (`resumed`) is **not** a recovery entry.

### What you get, and what you owe, on recovery

On a recovered re-invocation the handler observes the **same** inputs it saw on the
fresh entry — the same `request`, client headers, query parameters, and
`await context.GetInputTextAsync()` / `GetInputItemsAsync()` / `GetHistoryAsync()`.
Nothing is dropped or altered. The only differences are:

- `context.IsRecovery == true`.
- `context.PersistedResponse` carries the last durable snapshot (see below).
- The handler's `CancellationToken` may already be signalled if the recovery is
  itself racing another shutdown.

**What `PersistedResponse` contains depends on your resume model.** If you use
framework checkpoints (`stream.Checkpoint()`), it is the **last** checkpoint
snapshot (including the output items emitted up to that boundary). If your durable
state lives in an upstream framework or your own store, the library has no useful
in-flight snapshot to hand you and `PersistedResponse` may carry only the shell
(id + status). You are then responsible for rebuilding resume state yourself.

## The recovery handler pattern

**Always emit `response.created`, even on recovery — never branch on `IsRecovery`
to decide whether to emit it.** The framework keeps exactly **one** logical
`response.created` on the durable stream across all lifetimes: on a recovered entry
the pre-crash `response.created` is already durable, so the framework **drops** the
re-emitted duplicate and the handler's subsequent `response.in_progress` becomes the
client-visible reset point. This dedup happens inside the framework
(`EventStreamObserver`) — the handler does not (and must not) implement it.

The only thing that differs on recovery is **which snapshot you seed the stream
from**:

```csharp
public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    CreateResponse request,
    ResponseContext context,
    [EnumeratorCancellation] CancellationToken cancellationToken)
{
    // Seed from the last checkpoint on recovery; from the request on a fresh entry.
    ResponseEventStream stream =
        context.IsRecovery && context.PersistedResponse is not null
            ? new ResponseEventStream(context, context.PersistedResponse)
            : new ResponseEventStream(context, request);

    // Unconditional. On recovery the framework drops this duplicate created; the
    // following in_progress is the client-visible reset carrying the seeded output.
    yield return stream.EmitCreated();

    if (context.IsShutdownRequested)
    {
        await context.ExitForRecoveryAsync(cancellationToken);
    }

    yield return stream.EmitInProgress();

    // ... resume work past the seeded watermark (e.g. stream.Response.Output.Count) ...
}
```

> **Why not just skip `created` on recovery?** The orchestrator requires the first
> yielded event to be `response.created` (a fresh entry has no other valid first
> event), and the seeded-output baseline check keys off it. Skipping it on recovery
> yields a bad-handler error. Emitting it unconditionally and letting the framework
> deduplicate is the single pattern that works for both fresh and recovered entries
> — and it mirrors the Python handler contract exactly.

## Choosing a resume strategy

A recovered handler is re-invoked from the top. You choose how much of the prior
attempt to reuse. All three strategies still emit `created` unconditionally (above);
they differ only in how the stream is seeded and how far work is skipped.

1. **Naive restart (default, zero work)** — construct the stream from the
   `request` even on recovery and re-run the whole turn. Correct whenever the work
   is idempotent (or the client is expected to redraw from an empty `in_progress`
   reset). This is the pattern in `Sample22_ResilientMultiTurn` and
   `Sample20_ResilientSteering` (non-deterministic upstream).

   ```csharp
   var stream = new ResponseEventStream(context, request);
   yield return stream.EmitCreated();     // duplicate dropped on recovery
   yield return stream.EmitInProgress();  // empty reset — client redraws
   // re-run the whole turn from scratch
   ```

2. **Framework checkpoint resume** — emit `stream.Checkpoint()` at phase
   boundaries. On recovery, seed the stream from `context.PersistedResponse` (the
   last checkpoint) so the completed items are carried into the `in_progress`
   reset, and resume at the next phase. This is the pattern in
   `Sample19_ResilientStreaming`.

   ```csharp
   var stream = context.IsRecovery && context.PersistedResponse is not null
       ? new ResponseEventStream(context, context.PersistedResponse)
       : new ResponseEventStream(context, request);
   int donePhases = stream.Response.Output.Count; // completed phases are seeded
   yield return stream.EmitCreated();
   yield return stream.EmitInProgress();
   for (int i = donePhases; i < phases.Length; i++) { /* ...; yield return stream.Checkpoint(); */ }
   ```

3. **Upstream-owned resume** — your durable state lives in an upstream
   framework/store. Rebuild the resumption response from that store, seed the
   stream from it, and resume. Use `context.ConversationChainMetadata` watermarks to
   fence non-idempotent side effects across the crash.

### Checkpoints

`ResponseEventStream.Checkpoint()` persists a durable snapshot at a phase
boundary. It is a **no-op** unless the response is resilient background
(Row 1). Cutpoint guarantees:

| Cutpoint | Behavior |
|----------|----------|
| C1 (after checkpoint) | Recovery resumes at the next phase. |
| C3 (before checkpoint) | The un-checkpointed phase re-runs. |
| C4 (post-terminal checkpoint) | Silently dropped. |
| C5 (checkpoint store failure) | Swallowed; recovery sees the prior snapshot. |

Checkpoint writes are idempotent (byte-compared) and fail-closed (a store
failure is swallowed and tagged as a platform error, never surfaced as a torn
snapshot).

## Durable metadata

`context.ConversationChainMetadata` is a named-namespace store for values that
must survive crash/recovery:

```csharp
context.ConversationChainMetadata.Set("myAgent", "phase", "analyze");
await context.ConversationChainMetadata.FlushAsync();
```

- Values are buffered until `FlushAsync()` persists them into the snapshot.
- Namespace names and keys beginning with `_` are **reserved** and rejected.
- On the base (non-resilient) context, `FlushAsync()` is a no-op.

### Internal metadata (persist-but-strip)

Two framework-reserved keys are persisted (so they survive crashes) but **never**
reach the client wire:

- `internal_metadata` — an item-level bag, stripped from every object in the tree.
- `_internal_metadata` — a response-level entry inside `metadata`; if removing it
  empties `metadata`, `metadata` is normalized to `null`.

These are stripped at every egress path and are not accessible through the
`ConversationChainMetadata` facade.

### Which metadata facility should I use?

Three distinct facilities exist — pick by lifetime and audience:

| Facility | Scope / lifetime | Visible to client? | Use for |
|----------|------------------|--------------------|---------|
| `ResponseObject.Metadata` | Single response; client-owned | **Yes** | Values the caller set and expects back on their response. |
| `internal_metadata` (item- and response-level) | Single turn; framework-internal | **No** — stripped on egress | Per-turn bookkeeping you want to persist for recovery but never leak (e.g. an upstream run id you re-read from `PersistedResponse`). |
| `context.ConversationChainMetadata` | Whole conversation chain; survives crash **and** spans turns | **No** | Cross-turn / cross-crash resume state: phase watermarks, turn counts, side-effect fences. |

Rule of thumb: reach for `ConversationChainMetadata` for anything that must be
read on a **later turn or a recovery**; use `internal_metadata` for **this turn's**
private state that should ride along on the persisted response; use
`ResponseObject.Metadata` only for values the **client** owns.

## Streaming and reconnect

Resilient streaming persists each event **before** it is flushed to the wire, so
a reconnecting client can replay from a cursor:

```
GET /responses/{id}?stream=true&starting_after={cursor}
```

- `starting_after` uses strict `>` semantics: only events with
  `sequence_number > cursor` are returned.
- Absent (`starting_after = -1`) replays from the beginning.
- `response.created` appears exactly **once** across all lifetimes on the durable
  stream. The handler emits it on every entry (fresh and recovered); the framework
  drops the recovered duplicate (see *The recovery handler pattern* above).
- On a recovered entry the client-visible reset is the `response.in_progress` that
  follows the (dropped) recovered `created`. It carries the output seeded from
  `PersistedResponse`, and every recovered event has a `sequence_number` strictly
  greater than the pre-crash maximum, so the assembled cross-lifetime stream stays
  monotonic and contiguous.

### Client-side reconciliation

A client reconnecting mid-recovery must reconcile the replayed stream:

- **Treat `response.in_progress` as a reset.** Whenever an `in_progress` arrives
  carrying a `response` payload, **replace** your local view of `output` with the
  payload's `output` rather than appending. On recovery this reset re-seeds the
  completed items in one shot.
- **Output indexes are slot ids, not counters.** An `output_item.added` event's
  index identifies the slot it occupies; after a recovery reset, new items continue
  at the next slot past the seeded ones. Do not assume indexes are a contiguous
  running count of items *you* have observed this connection.
- **Deduplicate on `sequence_number`.** Because `starting_after` is strict-`>`, a
  correctly-cursored reconnect never re-delivers an event; but if you replay from
  the beginning you will see the single `created` and the full history — dedupe by
  `sequence_number` if you merge multiple reads.

## Steering (multi-turn)

With `SteerableConversations = true`, a new POST for an in-progress chain is
**queued** (status `queued`) rather than rejected. The running handler observes
`context.PendingInputCount > 0` and can drain via `context.IsSteeredTurn`.

Fork/overlap conflicts return HTTP 409:

- `conversation_fork_not_supported` — `previous_response_id` does not reference
  the most recent response.
- `conversation_locked` — an overlapping turn is already in progress.

## Fail-loud composition

Resilience never silently downgrades:

- **Startup**: a missing/invalid persistent provider fails host startup naming the
  missing provider.
- **Request time (non-stream)**: a resilient-start failure returns HTTP 500 with
  `x-platform-error-source: platform` and `x-platform-error-detail`.
- **Request time (stream)**: a standalone `error` / `response.failed` SSE event
  with `error.code = server_error`.

## TTL vs timeout

Retained stream events have a replay TTL that governs how long a reconnecting
client can replay history; it is distinct from any handler execution timeout. A
recovery re-invocation is not bounded by the original request's client timeout.

## See also

- `docs/resilience-contract.md` — normative per-row × per-path conformance contract.
- `docs/resilience-sample-parity.md` — .NET ↔ Python sample mapping.
- `samples/Sample19_ResilientStreaming.md`, `Sample20_ResilientSteering.md`,
  `Sample22_ResilientMultiTurn.md` — worked resilient samples.
- `tests/e2e/resilience_contract/PARITY_REPORT.md` — .NET ↔ Python parity status.
- `docs/dotnet-python-parity-report.md` — canonical .NET ↔ Python resilience
  parity report (CONVERGED; per-finding adjudication + Python-side action items).
