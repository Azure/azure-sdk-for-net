# Streaming — Developer Guide

This is the developer guide for `Azure.AI.AgentServer.Core`'s streaming primitive —
the way to **emit events from one asynchronous producer and receive them from one or
more consumers**. Typically, your resilient task handler produces events and your HTTP
layer fans them out to a Server-Sent Events (SSE), WebSocket, or long-poll endpoint.

You pick a backing once at app startup. Everywhere else, producers and subscribers
look streams up by id and call `EmitAsync` / `Subscribe`.

This guide is written for application developers. It covers the public surface only —
you do not need to know how the bundled backings store buffers or files to use it
well.

---

## 5-minute getting started

```csharp
// 1. At app startup — pick a backing (in-memory live is the default).
builder.Services.AddAgentEventStreams();

// 2. Create the stream and ATTACH THE SUBSCRIBER FIRST. With the default live
//    backing there is no history, so a subscriber only sees events emitted after it
//    attached — start consuming before the producer emits (see "subscribe-before-start"
//    below), or use a replay backing if you cannot guarantee that ordering.
AgentEventStream stream = await registry.GetOrCreateAsync(streamId);
Task consume = Task.Run(async () =>
{
    await foreach (SseItem<string> evt in stream.Subscribe())
    {
        // forward evt.Data to the client (SSE, WebSocket, ...)
    }
});

// 3. The producer (e.g. inside your task handler) emits into the same stream id:
await stream.EmitAsync(new SseItem<string>(
    JsonSerializer.Serialize(new { token = "Hello" }),
    eventType: "message")
{
    EventId = "1"
});
await stream.EmitAsync(new SseItem<string>(
    JsonSerializer.Serialize(new { token = " world" }),
    eventType: "message")
{
    EventId = "2"
});
await stream.CloseAsync();                       // mark the stream done

await consume;                                   // subscriber drains and finishes
```

`registry.GetOrCreateAsync(id)` is idempotent: the producer and subscriber both call
it with the same id and get the **same** `AgentEventStream` instance back.
Each event is a `System.Net.ServerSentEvents.SseItem<string>`: `Data` is the event
text you serialized, `EventId` is the opaque resume token, and `EventType` is the
optional SSE event type.

---

## Public surface

The public surface is intentionally small: registration/configuration, a registry,
the stream contract, and a few stream-specific exceptions (covered in
*Exceptions → wire mapping*).

| Type | Role |
|---|---|
| `IServiceCollection.AddAgentEventStreams(configure?)` | code-based application registration; selects the backing |
| `IHostApplicationBuilder.AddAgentEventStreams(sectionName)` | binds application backing selection from configuration |
| `AgentEventStreamOptions` | chooses and configures the single process backing |
| `AgentEventStreamRegistry` | maps stream ids to live `AgentEventStream` instances |
| `AgentEventStream` | a single producer/consumer event stream |

Obtain stream instances from `AgentEventStreamRegistry` and program against
`AgentEventStream`:

```csharp
public abstract class AgentEventStream
{
    public abstract ValueTask EmitAsync(SseItem<string> item, bool close = false, CancellationToken cancellationToken = default);
    public abstract ValueTask CloseAsync(CancellationToken cancellationToken = default);
    public abstract IAsyncEnumerable<SseItem<string>> Subscribe(string? afterEventId = null, CancellationToken cancellationToken = default);
    public abstract ValueTask<string?> GetLastEventIdAsync(CancellationToken cancellationToken = default);
}

public abstract class AgentEventStreamRegistry
{
    public abstract ValueTask<AgentEventStream> GetAsync(string id, CancellationToken cancellationToken = default);          // throws if absent
    public abstract ValueTask<AgentEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default);  // creates if absent
    public abstract ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default);                     // remove + free resources
}
```

---

## Choosing a backing

Choose the backing before you create streams (typically once at app startup through
`AddAgentEventStreams`). The .NET registry selects exactly **one** backing per process; if
you select none, the default is in-memory live.

An explicit application selection overrides protocol-package defaults regardless of
registration order. Repeating the same canonical selection is idempotent. Conflicting
selections at the same precedence (two application selections, or two protocol defaults)
fail when the registry is first resolved, with both sources and selections in the error.

| Backing | Use when | Reconnect / replay? | Survives process restart? | Notes |
|---|---|---|---|---|
| `UseInMemoryLive()` (default) | A subscriber attaches before the producer; lowest memory; late subscribers do not need to catch up. | No — late subscribers miss earlier events. | No. | Constant memory: only live subscribers, no event buffer. |
| `UseInMemoryReplay(...)` | Multiple subscribers may attach at different times, or clients may reconnect within the retention window. | Yes (in RAM, while retained). | No. | Retains events in memory; `ttl` bounds retention and arms close-clock cleanup. |
| `UseFileBackedReplay(...)` | Long-running turns where a fresh worker may need to resume after a process crash. | Yes (from disk, while retained). | Yes. | Events are persisted under the streams storage root; one file per stream id. |

### Configurator signatures

```csharp
// Choose exactly one application backing.
builder.Services.AddAgentEventStreams(o => o.UseFileBackedReplay(
    storageDirectory: "/var/streams",                                 // one file per stream id
    ttl: TimeSpan.FromHours(1)));
```

Other choices are `o.UseInMemoryLive()` (the Core default),
`o.UseInMemoryReplay(ttl)`, and `o.UseFileBackedReplay()` with its default directory and
10-minute TTL.

### Configuration binding

```C# Snippet:StreamingGuide_ConfigBinding
public static IHostApplicationBuilder ConfigureStreams(
    IHostApplicationBuilder builder)
{
    return builder.AddAgentEventStreams("ResilientTasks:Streams");
}
```

```json
{
  "ResilientTasks": {
    "Streams": {
      "Backing": "FileBackedReplay",
      "StorageDirectory": "/var/streams",
      "Ttl": "01:00:00"
    }
  }
}
```

`Backing` accepts `InMemoryLive`, `InMemoryReplay`, or `FileBackedReplay`
case-insensitively. `StorageDirectory` is valid only for file-backed replay. `Ttl` is a
non-negative invariant-culture `TimeSpan` and applies to replay backings.
The section is read when the registry is first resolved, so configuration providers and
overrides added after this registration call but before host startup are honored.

- **`ttl`** — retention for replay backings. It bounds buffered history and also drives
  close-clock auto-destroy for closed streams (see *Lifecycle*).
- **`storageDirectory`** (file-backed only) — when omitted, the file-backed backing
  writes under `~/.agentserver/streams` (one file per stream id). Override the root for
  all agent-server state — tasks and streams alike — with the `AGENTSERVER_STATE_ROOT`
  environment variable, or override just the streams location with `storageDirectory`.

There is no cursor function or payload codec to configure. The caller now owns
serialization: serialize your event to a string, put that string in
`SseItem<string>.Data`, and set `SseItem<string>.EventId` to the opaque resume token
you want subscribers to use. Because replay stores strings, the previous
`serializer`/`deserializer` options and typed `UseFileBackedReplay<TPayload>` overload
are no longer needed.

## Task-bound streams

Every resilient task input has a lazy event stream keyed by its final `InputId`.
Handlers receive producer-only access through `TaskContext<TInput>.Stream`; callers
receive consumer-only access through `TaskRun<TOutput>.Stream`.
The same explicit `InputId` cannot be reused by an unrelated `TaskId` while the stream is
retained; this prevents cross-task replay leakage and closed-stream poisoning.

```C# Snippet:StreamingGuide_TaskBoundStreams
public static ValueTask EmitTaskProgress(
    TaskContext<string> context,
    CancellationToken cancellationToken)
{
    return context.Stream.EmitAsync(
        new SseItem<string>("working", "progress") { EventId = "1" },
        cancellationToken);
}

public static async Task ConsumeTaskProgress(
    TaskDefinition<string, string> task,
    CancellationToken cancellationToken)
{
    TaskRun<string> run = await task.StartAsync(
        "input",
        cancellationToken: cancellationToken);

    await foreach (SseItem<string> item in
        run.Stream.Subscribe(cancellationToken: cancellationToken))
    {
        _ = item.Data;
    }

    _ = await run.Completion;
}
```

The underlying backing is created only when a producer emits, a consumer subscribes, or
either side asks for the last event id. A task that never uses its stream creates no
file or replay buffer.

Core owns transport closure:

- success, final failure, cancellation, and timeout close after the existing terminal
  task-store transition or cleanup succeeds;
- retry does not close;
- shutdown, lease loss, and `ExitForRecoveryAsync` leave the stream open for the next
  process;
- each multi-turn input gets a distinct stream because its `InputId` is distinct.

Core does not emit protocol terminal events. A protocol handler must emit its semantic
terminal event before returning or throwing the terminal outcome. The advanced
`AgentEventStreamRegistry` remains available for later GET replay, id-addressed deletion,
custom backings, and standalone streams.
Custom registry implementations are responsible for preventing cross-task reuse of a
retained explicit `InputId`; the bundled registry enforces and persists this ownership.

Task-bound handles do not change the in-memory live backing's timing semantics: events
emitted before subscription are still not replayed. Use a replay backing when the caller
cannot subscribe before the producer emits.

---

## The stream id

A stream id is the identity of one producer/consumer conversation. Pick a stable,
collision-free, **per-turn** identifier and use it from both sides.

| Context | Use as id |
|---|---|
| Inside `azure-ai-agentserver-invocations` | the `InvocationId` |
| Bare handler / custom integration | any per-turn string you control end-to-end |

A natural choice when bridging a task to a response is to derive the stream id from
the invocation that is producing the events, so the HTTP handler and the producer
agree without extra plumbing.

> **Do NOT use a resilient `TaskId` as the stream id.** A resilient task can span
> multiple turns (steering, recovery), but a stream's lifecycle is a single
> ACTIVE→CLOSED arc. If you key the stream on the `TaskId`, the second turn finds the
> first turn's already-**closed** stream and `EmitAsync` throws
> `AgentEventStreamClosedException`. Always scope the stream id to **one logical
> request/turn/invocation** — for `azure-ai-agentserver-invocations`, that is the
> `InvocationId`; for a bare handler, any per-turn string you control end-to-end.

For file-backed replay, remember that the backing keeps one on-disk file per stream
id; choose ids that are stable and boring enough for your storage policy.

---

## The `AgentEventStream` protocol

Every stream — regardless of backing — exposes the same four operations.

### `EmitAsync(item, close: false)`

Publishes one event to every currently-attached subscriber.

- `item` is yours — pass a `SseItem<string>`. Put the event text you serialized in
  `item.Data`, set `item.EventId` to the opaque resume token, and optionally pass an
  event type to the constructor for `item.EventType`.
- `close: true` is an **atomic emit-and-close**: the item is delivered and the
  stream is closed in one call. For replay backings, the item is still retained in
  history; for the live backing, late subscribers do not see it.
- Emitting after the stream is closed throws `AgentEventStreamClosedException`. That signals
  a **producer bug** (you should not still be emitting), so an HTTP layer should surface
  it as a **5xx**, not a client error.

### `CloseAsync()`

Marks the stream **done**. Idempotent — calling it twice (or after the stream is gone)
is a no-op. After close:

- new `EmitAsync` calls raise `AgentEventStreamClosedException`;
- subscribers already iterating the stream drain remaining events, then finish;
- new subscribers can still attach to a replay backing while retained history exists,
  but no new events will arrive.

### `Subscribe(afterEventId: null)`

Returns an async iterator over emitted `SseItem<string>` values. Iterate it with
`await foreach`. The loop ends when the stream is closed and all buffered events are
drained.

`afterEventId` is the **reconnection primitive** — with a replay backing, the iterator
first yields retained events strictly after the retained item whose `EventId` matches
that string, then continues live. `null` replays all retained events. If the id is no
longer in the retained window, replay is best-effort and starts with all retained
events, matching standard SSE `Last-Event-ID` semantics. If your old cursor was a
monotonic sequence number, using that sequence as an `EventId` string is equivalent
within the retention window; only the TTL-eviction boundary differs. With the live
backing, `afterEventId` is ignored and a subscriber only sees events emitted after it
attached, which is why the subscribe-before-start rule matters (below).

### `GetLastEventIdAsync()`

Returns the last non-null `EventId` string seen so far, or `null` if no emitted item
has supplied one. After the stream is closed, this is the last event id the backing saw
during the close window.

`GetLastEventIdAsync()` is the producer's recovery primitive: a recovering producer
reads it to learn where to resume emitting.

---

## Lifecycle: ACTIVE → CLOSED → (destroyed)

Each stream is **ACTIVE** or **CLOSED**. After CLOSED, the id may be destroyed; once
destroyed, the id's resources are gone and `GetAsync(id)` treats it as not found.

| State | What it means | How you reach it |
|---|---|---|
| **ACTIVE** | Accepts `EmitAsync`; subscribable. | Construction (first `GetOrCreateAsync(id)`). |
| **CLOSED** | No new emits (`EmitAsync` raises `AgentEventStreamClosedException`). Existing subscribers drain. New subscribers can still attach to a replay backing and replay retained history, but no new events arrive. | `CloseAsync()` or `EmitAsync(close: true)` from ACTIVE. |

Three independent paths lead to destroyed:

- the id was **never registered** (no `GetOrCreateAsync` ever ran for it);
- it was **explicitly `registry.DeleteAsync(id)`**'d; or
- **close-clock TTL elapsed** — for a **replay backing**, a
  CLOSED stream becomes eligible for auto-destroy once `close-time + ttl` passes,
  regardless of whether anyone is still subscribed or events remain buffered. The bundled
  registry sweeps expired streams in the background (at least once per minute, or once per
  TTL interval when shorter) and also observes expiry during stream operations and lookups.
  Use `registry.DeleteAsync(id)` when you need deterministic, immediate cleanup.

A few practical implications:

- The **in-memory live** backing retains no replay history and is removed from the registry
  immediately when it closes.
- Replay backings default to a 10-minute TTL and clean up closed streams automatically in
  the background. An explicit TTL changes that retention window.
- `GetLastEventIdAsync` remains safe during the close window. After the TTL expires and the
  stream is destroyed, it throws `AgentEventStreamNotFoundException`.

> **TTL is a close-clock, not just per-event.** The `ttl` you pass to
> `UseInMemoryReplay`/`UseFileBackedReplay` both evicts individual events after their
> emit time *and* arms the auto-destroy that fires `ttl` after the stream is closed.
> Both replay backings default to a 10-minute TTL. The **in-memory live** backing has no
> replay window and is removed immediately on close. `GetLastEventIdAsync` remains safe
> only while the replay stream is retained; after destruction the stream is not found.

---

## The registry

`AgentEventStreamRegistry` is the process-level map from ids to live streams:

- `GetAsync(id)` — returns the registered stream when it **must** already exist; throws
  `AgentEventStreamNotFoundException` if not.
- `GetOrCreateAsync(id)` — idempotent: the producer and subscriber using the same id
  get the same `AgentEventStream` instance; if the id was previously destroyed, this
  creates a fresh stream.
- `DeleteAsync(id)` — removes the stream and backing resources. Use it for immediate
  cleanup (end-of-request hook, test teardown) or for backings without TTL cleanup.

For replay backings configured with `ttl`, you typically do not need to call
`DeleteAsync(id)` on the happy path; close-clock auto-destroy handles eventual cleanup.

---

## Exceptions → wire mapping

```text
AgentEventStreamException                 (base — catch-all)
├── AgentEventStreamClosedException       producer bug — wire-map to HTTP 5xx
└── AgentEventStreamNotFoundException     id is not currently a live stream — HTTP 404
```

| Exception | Meaning | Typical HTTP mapping |
|---|---|---|
| `AgentEventStreamNotFoundException` | `GetAsync` for an id that does not exist | 404 |
| `AgentEventStreamClosedException` | `EmitAsync` after the stream was closed | **5xx** (producer bug) |
| `AgentEventStreamException` | base type for stream errors | 500 |

Every "this id is not currently a live stream" condition at the registry boundary is
`AgentEventStreamNotFoundException` and maps naturally to 404. `AgentEventStreamClosedException`
means the **producer** tried to emit after the stream was already closed — that is a
server-side bug, not a bad client request, so map it to a **5xx** (e.g. 500), never a
4xx.

---

## Subscribing — the subscribe-before-start rule

For the **default live backing** (`UseInMemoryLive()`), subscribers only see events
emitted after they attach. With the live backing, merely agreeing on an id is not
enough; the subscriber must be consuming before the producer starts emitting or early
events are lost to that subscriber.

Safe options:

1. **Use a replay backing** (`UseInMemoryReplay` or `UseFileBackedReplay`). Late
   subscribers catch up through retained history, so the race does not matter. This is
   the recommended default for HTTP/SSE layers that need reconnects.
2. **Drive subscription before starting the producer.** Arrange for the consumer to be
   attached and iterating before the producer can emit. This is harder to get right
   than option 1; use it only when you intentionally want no buffer.

Once you have picked a strategy, the canonical pattern is:

1. The HTTP layer reads or creates the per-turn id.
2. The HTTP layer calls `GetOrCreateAsync(id)` and arranges for a subscriber to be
   attached according to the strategy above.
3. The HTTP layer starts the producer with the id propagated through input.
4. The producer calls `GetOrCreateAsync(id)` and gets the same instance.

```csharp
// Pattern 1 (recommended): create the stream and start subscribing in the HTTP
// layer, THEN kick off the producer.
AgentEventStream stream = await registry.GetOrCreateAsync(id);
var consume = ConsumeAsync(stream);          // attaches the subscriber
await StartProducerAsync(id);                // producer emits into the same id
await consume;

// Pattern 2: use a replay backing so late subscribers still get earlier events
// via Subscribe(afterEventId: ...).
```

If you cannot guarantee subscribe-before-start (for example, the client connects late
or reconnects), use a **replay** backing and have subscribers resume with
`Subscribe(afterEventId: lastEventId)`.

---

## Recovery & resumption

### EventId reconnect (client side)

If a subscriber drops (network blip, client refresh), the client reconnects with the
last event id it saw and the library only re-delivers later retained events. Assign
each event an opaque `EventId` (a monotonic counter encoded as a string is typical)
and surface it to the client (for SSE, as the event id):

```csharp
// Client reconnects having last seen event id "42".
await foreach (SseItem<string> evt in stream.Subscribe(afterEventId: "42"))
{
    // only retained events after EventId "42", then live
}
```

Within the retention window, delivery resumes strictly after the retained item whose
`EventId` is `"42"` and then continues live. If `"42"` has fallen out of the retained
window, replay starts with all currently retained events as a best-effort recovery.

### Crash-recoverable producer (file-backed)

With `UseFileBackedReplay`, emitted events persist to disk and rehydrate on the next
`GetOrCreateAsync(id)` after a restart, so the producer can resume and subscribers can
replay from an event id — across a process crash.

The typical recovery path is: the producer uses the same per-turn stream id, calls
`GetOrCreateAsync(id)`, reads `GetLastEventIdAsync()`, and resumes emitting after the
last event id it saw.

### Don't double-track stream progress

If you are bridging a task to a stream, let the stream's event id be the single source
of truth for "where am I". Do not also record per-event progress in a State Store item —
that duplicates state and the two can drift. Use `GetLastEventIdAsync` to read the
current position.

---

## HTTP / SSE bridging pattern

Typical endpoint helper for serving a stream over Server-Sent Events:

```csharp
// GET /runs/{id}/events  — stream a run's events as SSE, resumable via Last-Event-ID.
app.MapGet("/runs/{id}/events", async (string id, HttpContext http,
                                        AgentEventStreamRegistry registry) =>
{
    http.Response.Headers.ContentType = "text/event-stream";

    string? afterEventId = http.Request.Headers.TryGetValue("Last-Event-ID", out var header)
        ? header.ToString()
        : http.Request.Query.TryGetValue("last_event_id", out var query) ? query.ToString() : null;

    // A GET is a pure RESUME/read endpoint: the stream must already exist (the
    // producer created it). Use GetAsync — not GetOrCreateAsync — so an unknown or
    // TTL-expired id surfaces AgentEventStreamNotFoundException → 404 instead of silently
    // creating a new empty stream.
    AgentEventStream stream;
    try
    {
        stream = await registry.GetAsync(id, http.RequestAborted);
    }
    catch (AgentEventStreamNotFoundException)
    {
        http.Response.StatusCode = 404;
        return;
    }

    await SseFormatter.WriteAsync(
        stream.Subscribe(afterEventId, http.RequestAborted),
        http.Response.Body,
        http.RequestAborted);
});
```

Pair this with a replay backing so reconnecting clients (which send `Last-Event-ID`)
resume exactly where they left off. If the client sends `Last-Event-ID` (or a
`last_event_id` query parameter), pass that string through to
`Subscribe(afterEventId: lastEventId)` to skip already-delivered events.
`SseFormatter` writes the `event:`, `id:`, and `data:` lines directly from each
`SseItem<string>`'s `EventType`, `EventId`, and `Data`.

---

## Bringing your own `AgentEventStream` implementation

You can write your own `AgentEventStream` implementation (for example a Redis-backed
stream). It is accepted anywhere the abstract class is — the registry and the SSE bridge
only depend on `AgentEventStream`, not on the bundled backings.

**But** don't register your custom implementation with the built-in `AddAgentEventStreams`
registry — that registry's lifecycle (TTL eviction, file cleanup, tombstoning) is
wired to the bundled backings only. Ship your own peer registry instead, and let
consumers pick which one to call:

```csharp
// A peer namespace to the SDK's AgentEventStreamRegistry — same abstract class, its own
// lifecycle. Register it under your own DI type so callers choose explicitly.
public sealed class MyRedisStreams : AgentEventStreamRegistry
{
    public MyRedisStreams(string redisConnectionString) { /* ... */ }

    public override ValueTask<AgentEventStream> GetOrCreateAsync(string id, CancellationToken ct = default) { /* ... */ }
    public override ValueTask<AgentEventStream> GetAsync(string id, CancellationToken ct = default) { /* ... */ }
    public override ValueTask DeleteAsync(string id, CancellationToken ct = default) { /* ... */ }
}
```

Consumers explicitly choose which registry they want — `myRedisStreams.GetOrCreateAsync(id)`
vs the injected built-in `AgentEventStreamRegistry`. The shared contract is the
`AgentEventStream` abstract class; lifecycle is each registry's own concern.

---

## See also

- [Resilient Tasks — Developer Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/docs/tasks-guide.md) — for the producer side when
  the events come from a durable task.
