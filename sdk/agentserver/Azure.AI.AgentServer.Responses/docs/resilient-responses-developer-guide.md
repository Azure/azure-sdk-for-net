# Resilient Responses Developer Guide

This guide explains how to build crash-recoverable response handlers using the
resilient background responses feature in `Azure.AI.AgentServer.Responses`. It
covers what the framework provides automatically, what developers need to
implement, and the .NET mechanics that keep recovered streams and conversations
coherent.

## Overview

When `ResilientBackground = true` (opt-in — the default is `false`), the
framework automatically wraps your response handler in a **resilient task**. If
the server crashes mid-response:

- Background responses are automatically re-invoked on restart.
- Stream events are preserved for client reconnection.
- Conversation state is maintained across crashes.

**Opting in (`ResilientBackground = true`) gets you the framework half for
free**: re-invocation on restart, event replay for reconnecting clients, and
conversation continuity — with no handler changes. A naive handler re-invoked
this way still produces a correct response (it just re-runs the whole turn). The
*handler* half — making the recovered attempt resume *where it left off* and not
repeat non-idempotent side effects — is optional work you take on when you want
it; see [Choosing a resume strategy](#choosing-a-resume-strategy).

> **Default**: `ResilientBackground` defaults to `false`. Without the opt-in, a
> crash mid-handler leaves the response in the "crash-failed" state: the
> next-lifetime recovery scanner marks it `failed` (`server_error`,
> `shutdown_reason = crash_recovery`) instead of re-invoking the handler. Set
> `ResilientBackground = true` on `ResponsesServerOptions` to engage the
> re-invoke recovery path.

## What the Framework Provides (Zero Code)

| Feature | Behavior |
|---------|----------|
| Crash recovery | Handler re-invoked on server restart when `store`, `background`, and `ResilientBackground` are all enabled. |
| Stream replay | Events are persisted incrementally; reconnecting clients replay from a cursor. |
| Conversation continuity | `ConversationChainId` and `ConversationChainMetadata` stay stable across turns and recovery attempts. |
| Conversation lock | Conflicting concurrent writes are rejected instead of forked. |
| Non-background cleanup | Foreground or non-resilient responses are marked `failed` on interruption; there is no ghost re-invocation. |
| TTL-based cleanup | Retained stream events expire according to the replay TTL, which is separate from handler execution time. |

## Decision Tree

### What is `context.ConversationChainMetadata` for?

`context.ConversationChainMetadata` is a **small key-value store of references
and watermarks** — it is not the place to keep your application's bulk
checkpoint data.

Use it for things like:

- An upstream session id, thread id, or durable conversation pointer.
- A small pointer to the most recently processed input or output.
- A short workflow step or phase watermark so the recovered handler knows where
  to resume.
- A side-effect fence that prevents a recovered attempt from repeating a
  non-idempotent call.

The actual checkpoint data — graph state, conversation history, generated
content, intermediate work — belongs in an upstream framework or in your own
external storage. The metadata pointer is what lets the recovered handler find
that data.

```csharp
context.ConversationChainMetadata.Set("myAgent", "phase", "analyze");
await context.ConversationChainMetadata.FlushAsync();
```

Why this distinction matters: metadata is persisted alongside the resilient
response. Small writes are cheap and fast; bulk writes slow down recovery and
belong in the storage system best suited to them. Treat metadata as a checkpoint
*index*, not a checkpoint *store*.

### Do you need multi-turn conversations?

Use steerable conversations for agents that maintain context across turns or
need to queue a new turn while the current one is still in progress. Steering is
orthogonal to resilience: you can enable either option independently. The
options live side by side; set `SteerableConversations` according to whether you
want mid-turn steering for this server.

```csharp
var options = new ResponsesServerOptions
{
    ResilientBackground = true,       // opt-in crash recovery
    SteerableConversations = false,   // opt-in mid-turn steering (independent)
};
```

When steering is enabled:

- Each turn participates in the same conversation chain identity.
- A new POST for an in-progress chain is queued (`status = queued`) instead of
  rejected.
- `context.PendingInputCount` tells the running handler how many turns are
  waiting.
- `context.IsSteeredTurn` is true on the drain re-entry that processes a queued
  steering input.

## Configuration

| Option | Default | Description |
|--------|---------|-------------|
| `ResilientBackground` | `false` | Opt into crash-recoverable background responses. |
| `SteerableConversations` | `false` | Enable multi-turn steering with queued follow-up turns. |

`ResilientBackground` and `SteerableConversations` are **independent** options.
Enabling steering does not require resilience and vice versa.

## Configuration Matrix

Recovery semantics depend on `store`, `background`, and `ResilientBackground`.
The table below is a quick orientation. For the normative per-row and
per-termination-path contract, see [`resilience-contract.md`](resilience-contract.md).

| `store` | `background` | `ResilientBackground` | Summary |
|---|---|---|---|
| `true` | `true` | `true` | **Full recovery.** Handler is re-invoked with `context.IsRecovery == true`; persisted events replay to reconnecting clients. |
| `true` | `true` | `false` (default) | **Failed marker.** Response is marked `failed` on restart; handler is not re-invoked. Pre-crash persisted events remain replayable until TTL expires. |
| `true` | `false` (foreground) | any | **Failed marker.** Response is marked `failed` with `server_error`; handler is not re-invoked because the client connection is already gone. Persisted state remains queryable. |
| `false` | any | any | **No durable recovery.** Without persisted state, recovery does not apply. |

The single decision site is `ResponseResilienceDispatch.ClassifyRow` /
`DecideDisposition`:

| Row | `store` | `background` | `ResilientBackground` | On interruption |
|-----|---------|--------------|-----------------------|-----------------|
| 1 | true | true | true | **Re-invoke** with `IsRecovery = true` |
| 2 | true | true | false | Mark **failed** (`server_error`) |
| 3 | true | false | n/a | Mark **failed** (`server_error`) |
| 4 | false | n/a | n/a | No persisted state, no recovery |

Only Row 1 (`store && background && ResilientBackground`) is re-invoked; every
other row is marked failed on interruption.

### Termination paths

| Path | Trigger | Row 1 outcome | Row 2/3 outcome |
|------|---------|---------------|-----------------|
| A | Natural terminal | Completes normally | Completes normally |
| B | Graceful shutdown (grace exhausted or `ExitForRecoveryAsync`) | Leaves `in_progress`; re-invoked next lifetime | Mark failed (`shutdown_reason = grace_exhausted`) |
| C | Crash (SIGKILL) | Re-invoked next lifetime with `IsRecovery = true` | Mark failed (`shutdown_reason = crash_recovery`) |

When a response is marked **failed** on interruption (Rows 2/3), the framework
**overlays** the failed status onto the durable snapshot: it sets
`status = failed` and attaches the `error`, but preserves everything the handler
had already persisted — `agent_reference`, `model`, `metadata`, and any `output`
items checkpointed before the crash. A failed response's `output` **may be
partial**; it is kept, not cleared. A `cancelled` response is the exception:
cancellation always wins and clears `output` to an empty list.

`SteerableConversations = true` composes orthogonally: it enables multi-turn
steering on top of any row above. Recovery composes with steering; see [`handler-implementation-guide.md`](handler-implementation-guide.md)
for the base handler mechanics that this guide builds on.

### Steerable conversations: no forking

With `SteerableConversations = true`, a new POST for an in-progress chain is
**queued** (`status = queued`) rather than rejected. The running handler observes
`context.PendingInputCount > 0` and can drain via `context.IsSteeredTurn`.

Fork or overlap conflicts return HTTP 409:

- `conversation_fork_not_supported` — `previous_response_id` does not reference
  the most recent response.
- `conversation_locked` — an overlapping turn is already in progress.

There is no soft path through: a steerable conversation cannot be branched. Keep
`previous_response_id` pointing at the latest response id you have seen for the
conversation.

### Provider configuration for local-dev recovery testing

Real cross-process recovery requires persistent storage that survives subprocess
restarts. `ResilientBackground = true` requires a **persistent** response store.
If it is configured with a store that does not survive process crashes (for
example an explicit in-memory store), the host **refuses to start** with an
actionable error rather than silently downgrading:

> `resilient_background=true` was configured with an explicit in-memory store
> that does not persist across process crashes. Supply a persistent store, omit
> the store to use the default file-backed store, or set
> `ResilientBackground = false`.

The default file-backed store (created under `${AGENTSERVER_STATE_ROOT}/responses/`)
never trips this guard.

## Recovery + steering surface on `ResponseContext`

When `ResilientBackground = true`, the framework populates fields on
`ResponseContext` for every handler invocation. They mirror the underlying
resilient task classifiers and are safe to read regardless of `IsRecovery`:

| Member | Type | Meaning |
|--------|------|---------|
| `IsRecovery` | `bool` | `true` when this invocation re-enters after a crash. |
| `PersistedResponse` | `ResponseObject?` | The last durable snapshot from the prior lifetime (only on recovery). |
| `ConversationChainId` | `string` | Stable id shared across every turn/attempt of a conversation chain. |
| `ConversationChainMetadata` | `ConversationChainMetadata` | Durable, explicitly-flushed per-chain metadata. |
| `IsSteeredTurn` | `bool` | `true` on a steering-drain re-entry. |
| `PendingInputCount` | `int` | Steering inputs queued behind the current turn. |
| `IsShutdownRequested` | `bool` | `true` when graceful shutdown is asking the handler to defer. |
| `Shutdown` | `CancellationToken` | Dedicated shutdown signal (separate from the primary cancellation token) that handlers can `await` or link — mirrors `TaskContext.Shutdown` / Python `context.shutdown`. |
| `ClientCancelled` | `bool` | `true` when the client explicitly cancelled (distinct from shutdown). |
| `ExitForRecoveryAsync()` | `Task` | Defer the current turn for recovery instead of failing. |

> **Recovered inputs are identical to fresh entry.** On a recovered
> re-invocation the handler observes the **same** inputs it saw on the fresh
> entry — the same `request`, client headers, query parameters, and
> `await context.GetInputTextAsync()` / `GetInputItemsAsync()` /
> `GetHistoryAsync()`. Nothing is dropped or altered. The only differences are
> `context.IsRecovery == true`, `context.PersistedResponse` carrying the last
> durable snapshot, and the handler's `CancellationToken` may already be
> signalled if the recovery is itself racing another shutdown.

`IsRecovery` is `true` only on a crash-recovery re-entry (`entry_mode == recovered`).
A new steerable turn (`resumed`) is **not** a recovery entry.

### Conversation chain identity

`ResponseContext.ConversationChainId` is a **derived, stable chain identifier**:
the framework computes it so that every turn of the same conversation resolves
to the same value, and so it stays constant across all attempts of a turn
(fresh, recovered, multiply-recovered). Think of it as the stable name of this
conversation, not as any single request field.

Handlers that wrap a stateful upstream framework can use it as their upstream
session id — a convenient way to avoid allocating and persisting their own UUID,
though you are free to use your own identifier.

What snapshot does the library hand you on recovery? It depends on your resume
model (see [Choosing a resume strategy](#choosing-a-resume-strategy)):

- If you use **framework checkpoints** (`stream.Checkpoint()`),
  `PersistedResponse` is the **last** checkpoint snapshot, including the output
  items emitted up to that boundary.
- If your resilient state lives in an **upstream framework/store**, the library
  has no useful in-flight snapshot to hand you; `PersistedResponse` may carry
  only the shell (id + status), and you rebuild resume state yourself.

### Notes on `context.ConversationChainMetadata`

- Values are buffered until `FlushAsync()` persists them into the snapshot.
- Namespace names and keys beginning with `_` are **reserved** and rejected.
- On the base (non-resilient) context, `FlushAsync()` is a no-op.
- Metadata survives crashes; use it for small watermarks, session ids,
  checkpoint references, and side-effect fences.
- Do not store conversation history, LLM outputs, or bulk data in metadata; keep
  that in an upstream framework or your own storage.

## Choosing a resume strategy

When the framework re-invokes your handler after a crash (`context.IsRecovery == true`),
how the recovered attempt resumes coherently is **your choice**, driven by one
question: **where does your resilient progress state live?**

| Where state lives | Strategy | On recovery |
|---|---|---|
| Nowhere (cheap to re-run) | **Naive re-run** | Do nothing recovery-specific; the whole turn re-runs. Correct, just duplicative — only unsafe if it repeats non-idempotent side effects. |
| In the response snapshot | **Framework checkpoint** | Emit `stream.Checkpoint()` at phase boundaries. `context.PersistedResponse` is the last snapshot — seed the stream from it and resume past the items already there. |
| In an upstream framework/store | **Upstream-owned** | Rebuild a resumption `ResponseObject` from upstream state and seed the stream from it. Use metadata watermarks to fence non-idempotent side effects. |

All three strategies still emit `response.created` unconditionally (see
[The recovery handler pattern](#the-recovery-handler-pattern)); they differ only
in how the stream is seeded and how far work is skipped.

1. **Naive restart (default, zero work)** — construct the stream from the
   `request` even on recovery and re-run the whole turn. Correct whenever the
   work is idempotent (or the client is expected to redraw from an empty
   `in_progress` reset). This is the pattern in `Sample22_ResilientMultiTurn`
   and `Sample20_ResilientSteering` (non-deterministic upstream).

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
   stream from it, and resume. Use `context.ConversationChainMetadata` watermarks
   to fence non-idempotent side effects across the crash.

**Watermark overlay (composable — not a fourth strategy).** Independently of the
strategy you pick: if your handler makes a **non-idempotent side effect** that
the upstream cannot deduplicate for you, fence it with a metadata watermark so a
recovered attempt does not repeat it. Flush the watermark before the side effect,
and clear/flush it after the side effect has durably committed. A handler may
checkpoint its response output **and** watermark a non-response side effect in
the same turn.

## Crash recovery — what you get, what you owe

Re-entry is governed by the recovery contract in
[`resilience-contract.md`](resilience-contract.md), with handler mechanics covered
in [`handler-implementation-guide.md`](handler-implementation-guide.md). This
section is the configuration and decision context.

### What you get on recovered entry

- `context.IsRecovery == true`, plus `context.PersistedResponse` — the last
  resiliently persisted snapshot when framework checkpoints are in use.
- `context.ConversationChainMetadata` carrying whatever watermarks you flushed.
- The same request/input surface as the fresh entry.
- The cancellation contract still applies. `CancellationToken` may already be
  signalled, `context.ClientCancelled` distinguishes explicit client cancel, and
  `context.Shutdown` / `context.IsShutdownRequested` distinguishes graceful shutdown.
- The framework persists response state at `response.created`, at each
  successful `stream.Checkpoint()`, and at terminal events. `response.created` is
  kept logical across recovery attempts: the handler emits it every time, and the
  framework drops the recovered duplicate from the durable stream.

### What you owe on recovered entry (only if you chose a non-naive strategy)

- Seed or build your resumption response (framework-checkpoint: from
  `context.PersistedResponse`; upstream-owned: from upstream state).
- Emit `response.in_progress` early — it is the client-visible reset point.
- For non-idempotent side effects without upstream idempotency, honor your
  watermarks and do not re-issue a call whose watermark says it already crossed
  the crash boundary.

### Naive opt-out

A handler that does nothing recovery-specific still produces a correct response:
it re-runs from scratch, the recovered stream's first client-visible event is a
fresh `response.in_progress` (the duplicate `response.created` is suppressed),
and everything re-streams. The one real risk is **repeating non-idempotent side
effects**; if your handler has any, reach for the watermark overlay or a strategy
that resumes past them.

## The recovery handler pattern

**Always emit `response.created`, even on recovery — never branch on `IsRecovery`
to decide whether to emit it.** The framework keeps exactly **one** logical
`response.created` on the durable stream across all lifetimes: on a recovered
entry the pre-crash `response.created` is already durable, so the framework
**drops** the re-emitted duplicate and the handler's subsequent
`response.in_progress` becomes the client-visible reset point. This dedup happens
inside the framework (`EventStreamObserver`) — the handler does not (and must
not) implement it.

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
> event), and the seeded-output baseline check keys off it. Skipping it on
> recovery yields a bad-handler error. Emitting it unconditionally and letting the
> framework deduplicate is the single pattern that works for both fresh and
> recovered entries — and it mirrors the Python handler contract exactly.

## Checkpoint-driven recovery — one item per phase

When your work decomposes into phases, the simplest correct recovery shape is
one output item per phase plus `stream.Checkpoint()` at each phase boundary. The
persisted response is the watermark: on recovery you seed the stream from
`context.PersistedResponse` and resume from `stream.Response.Output.Count`. A
phase that finished and checkpointed is already in the seeded output; a phase
interrupted before its checkpoint never entered the snapshot, so it re-runs
cleanly.

`ResponseEventStream.Checkpoint()` persists a durable snapshot at a phase
boundary. It is a **no-op** unless the response is resilient background (Row 1).
Cutpoint guarantees:

| Cutpoint | Behavior |
|----------|----------|
| C1 (after checkpoint) | Recovery resumes at the next phase. |
| C3 (before checkpoint) | The un-checkpointed phase re-runs. |
| C4 (post-terminal checkpoint) | Silently dropped. |
| C5 (checkpoint store failure) | Swallowed; recovery sees the prior snapshot. |

Checkpoint writes are idempotent (byte-compared) and fail-closed (a store
failure is swallowed and tagged as a platform error, never surfaced as a torn
snapshot).

### Which metadata facility?

Three distinct facilities exist — pick by lifetime and audience:

| Facility | Scope / lifetime | Visible to client? | Use for |
|----------|------------------|--------------------|---------|
| `ResponseObject.Metadata` | Single response; client-owned | **Yes** | Values the caller set and expects back on their response. |
| `internal_metadata` (item- and response-level) | Single turn; framework-internal | **No** — stripped on egress | Per-turn bookkeeping you want to persist for recovery but never leak (for example an upstream run id you re-read from `PersistedResponse`). |
| `context.ConversationChainMetadata` | Whole conversation chain; survives crash **and** spans turns | **No** | Cross-turn / cross-crash resume state: phase watermarks, turn counts, side-effect fences. |

Rule of thumb: reach for `ConversationChainMetadata` for anything that must be
read on a **later turn or a recovery**; use `internal_metadata` for **this
turn's** private state that should ride along on the persisted response; use
`ResponseObject.Metadata` only for values the **client** owns.

### Internal metadata (persist-but-strip)

Two framework-reserved keys are persisted (so they survive crashes) but **never**
reach the client wire:

- `internal_metadata` — an item-level bag, stripped from every object in the tree.
- `_internal_metadata` — a response-level entry inside `metadata`; if removing it
  empties `metadata`, `metadata` is normalized to `null`.

These are stripped at every egress path and are not accessible through the
`ConversationChainMetadata` facade.

## Stream Recovery (client-side reconciliation)

The library persists every SSE event in order — including events emitted across
multiple recovery attempts. Reconnecting clients use the standard
`starting_after=` query parameter to resume:

```
GET /responses/{id}?stream=true&starting_after={cursor}
```

- `starting_after` uses strict `>` semantics: only events with
  `sequence_number > cursor` are returned.
- Absent (`starting_after = -1`) replays from the beginning.

A resilient stream has **exactly one** `response.created` — it is the first event
of the stream. On a recovered entry the framework does **not** append a second
`response.created`; it is suppressed because the resilient stream is already
non-empty. End-to-end, a reconnecting client sees:

```text
response.created
response.in_progress
<events emitted before the crash>
response.in_progress        ← recovery reset: carries the stable
                              (already-persisted) output items at the
                              resumption point
<events emitted after recovery>
response.completed
```

The post-recovery guarantee is normative for Row 1 Path C in
[`resilience-contract.md`](resilience-contract.md): a client reconnecting after
a crash receives the events the recovered handler emits, framed by the reset rule
below.

### The reset-on-`in_progress` rule

Clients that support resilient background recovery must observe this rule:

> **Any `response.in_progress` event received after the first one in a stream is
> a snapshot reset.** Replace the local `response.output` with the event's
> `response.output`. Discard any partial in-flight item content you had been
> accumulating. Treat subsequent events as additive on top of the new snapshot.

This rule applies whether the client is reading the live stream or replaying via
`starting_after=`. The reset event is in-band — no separate signal is needed.

### Output indexes are slot IDs, not monotonic counters

After a snapshot reset, output indexes identify slots, not the number of items
the current connection has observed:

- `output_item.added` at an index already present in the snapshot replaces the
  slot.
- `output_item.added` at a new index appends a slot.
- Subsequent `output_item.delta` / `output_item.done` apply to the slot
  identified by the output index.

Clients that assume indexes are strictly monotonic may still see a coherent
final response but can render intermediate states incorrectly.

## Non-Background Response Behavior

When `background = false` (foreground streaming):

- Response is tied to the HTTP connection lifetime.
- If the server crashes, the response is marked `failed` with `server_error`.
- The handler is not re-invoked because the client is already disconnected.
- Conversation locking still applies to prevent concurrent modifications.

## Layered Concerns

This guide and the handler guide together describe three layered concerns that
compose to give you resilient response handlers:

- **The resilient background runtime** provides the runtime primitives: recovery
  and steering fields on `ResponseContext`, provider fail-loud behavior,
  re-invocation, event replay, and steerable conversation orchestration.
- **The cancellation and shutdown contract** provides the `CancellationToken`,
  `context.ClientCancelled`, `context.Shutdown` / `context.IsShutdownRequested`, and
  `context.ExitForRecoveryAsync()` mechanics. Shutdown is cooperative: a handler
  should exit promptly and leave work resumable.
- **The recovery contract** provides the multi-attempt reconciliation pattern:
  resumption response, snapshot reset on `response.in_progress`, checkpointed
  output, and watermark-guarded side effects.

The three compose cleanly: the runtime surfaces recovery hooks, the cancellation
contract tells recovered handlers what to honor, and the recovery contract
prescribes how the recovered attempt produces coherent output.

## Best Practices

These are recommendations, not framework requirements — adapt them to your
handler. The hard rules are few: a `ResponseEventStream` handler emits
`response.created` then `response.in_progress` first and exactly one terminal
event; a recovered streaming entry emits `response.in_progress` as the reset
point; and clients supporting resilient streams treat any later
`response.in_progress` as a snapshot reset.

1. **Keep the recovery branch easy to find.** A recovery-aware handler usually
   diverges from a fresh handler near the top (`if (context.IsRecovery)`).
   Branching early keeps the two paths readable.

2. **Prefer your upstream framework's own resume facility** when you have one.
   Reconstructing upstream state from your own metadata is usually more work and
   more fragile.

3. **Watermark non-idempotent side effects — when the upstream cannot deduplicate
   them.** Stamp and `FlushAsync()` metadata before the call; clear and
   `FlushAsync()` after it resiliently commits. If the upstream is already
   idempotent, or the framework-checkpoint snapshot is your side-effect boundary,
   you may not need this.

4. **Keep metadata small.** Watermarks, session IDs, and checkpoint references —
   never bulk data.

5. **Honor the cancellation and shutdown contract on recovery.** Recovery does
   not change the `CancellationToken`, `ClientCancelled`, `Shutdown` /
   `IsShutdownRequested`, or `ExitForRecoveryAsync` rules.

6. **Do not store secrets in metadata.** The backing store persists it.

## Examples

See the `samples/` directory for canonical resilient handler shapes:

- `Sample19_ResilientStreaming.md` — handler-managed checkpointing with
  `stream.Checkpoint()`.
- `Sample20_ResilientSteering.md` — steerable resilient streaming and
  cancellation × recovery composition.
- `Sample22_ResilientMultiTurn.md` — multi-turn conversation with resilient
  background behavior.

## See also

- [`resilience-contract.md`](resilience-contract.md) — normative per-row ×
  per-path conformance contract.
- [`handler-implementation-guide.md`](handler-implementation-guide.md) — handler
  mechanics, cancellation, streaming, and implementation patterns.
- `samples/Sample19_ResilientStreaming.md`, `Sample20_ResilientSteering.md`,
  `Sample22_ResilientMultiTurn.md` — worked resilient samples.
