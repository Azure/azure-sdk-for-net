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
builder.Services.AddEventStreams();

// 2. Create the stream and ATTACH THE SUBSCRIBER FIRST. With the default live
//    backing there is no history, so a subscriber only sees events emitted after it
//    attached — start consuming before the producer emits (see "subscribe-before-start"
//    below), or use a replay backing if you cannot guarantee that ordering.
IEventStream stream = await registry.GetOrCreateAsync(streamId);
Task consume = Task.Run(async () =>
{
    await foreach (object evt in stream.Subscribe())
    {
        // forward evt to the client (SSE, WebSocket, ...)
    }
});

// 3. The producer (e.g. inside your task handler) emits into the same stream id:
await stream.EmitAsync(new { token = "Hello" });
await stream.EmitAsync(new { token = " world" });
await stream.CloseAsync();                       // mark the stream done

await consume;                                   // subscriber drains and finishes
```

`registry.GetOrCreateAsync(id)` is idempotent: the producer and subscriber both call
it with the same id and get the **same** `IEventStream` instance back.

---

## Public surface

The public surface is intentionally small: registration/configuration, a registry,
the stream contract, and a few stream-specific exceptions (covered in
*Exceptions → wire mapping*).

| Type | Role |
|---|---|
| `IServiceCollection.AddEventStreams(configure?)` | registration; selects the backing |
| `EventStreamOptions` | chooses and configures the single process backing |
| `IEventStreamRegistry` | maps stream ids to live `IEventStream` instances |
| `IEventStream` | a single producer/consumer event stream |

Obtain stream instances from `IEventStreamRegistry` and program against
`IEventStream`:

```csharp
public interface IEventStream
{
    ValueTask EmitAsync(object payload, bool close = false, CancellationToken cancellationToken = default);
    ValueTask CloseAsync(CancellationToken cancellationToken = default);
    IAsyncEnumerable<object> Subscribe(int? after = null, CancellationToken cancellationToken = default);
    ValueTask<int?> GetLastCursorAsync(CancellationToken cancellationToken = default);
}

public interface IEventStreamRegistry
{
    ValueTask<IEventStream> GetAsync(string id, CancellationToken cancellationToken = default);          // throws if absent
    ValueTask<IEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default);  // creates if absent
    ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default);                     // remove + free resources
}
```

---

## Choosing a backing

Choose the backing before you create streams (typically once at app startup through
`AddEventStreams`). The .NET registry selects exactly **one** backing per process; if
you select none, the default is in-memory live.

| Backing | Use when | Reconnect / replay? | Survives process restart? | Notes |
|---|---|---|---|---|
| `UseInMemoryLive()` (default) | A subscriber attaches before the producer; lowest memory; late subscribers do not need to catch up. | No — late subscribers miss earlier events. | No. | Constant memory: only live subscribers, no event buffer. |
| `UseInMemoryReplay(...)` | Multiple subscribers may attach at different times, or clients may reconnect within the retention window. | Yes (in RAM, while retained). | No. | Retains events in memory; `ttl` bounds retention and arms close-clock cleanup. |
| `UseFileBackedReplay(...)` | Long-running turns where a fresh worker may need to resume after a process crash. | Yes (from disk, while retained). | Yes. | Events are persisted under the streams storage root; one file per stream id. |

### Configurator signatures

```csharp
builder.Services.AddEventStreams(o => o.UseInMemoryLive());            // default

builder.Services.AddEventStreams(o => o.UseInMemoryReplay(
    cursor: payload => ((MyEvent)payload).Sequence,                   // payload → cursor
    ttl: TimeSpan.FromMinutes(10)));                                  // optional retention

// Typed overload: storage directory (~/.agentserver/streams), a 10-minute TTL,
// and JSON serialization all default, so only the cursor is required.
builder.Services.AddEventStreams(o => o.UseFileBackedReplay<MyEvent>(
    cursor: e => e.Sequence));

// The non-generic overload is for CUSTOM serialization (non-JSON, or a payload the default
// JSON can't round-trip). Supply serializer/deserializer whenever your cursor casts the
// payload to a CLR type: the default JSON path rehydrates objects as JsonNode, so a typed
// cursor like ((MyEvent)payload) would throw after a restart unless you round-trip the type
// yourself (or use the typed UseFileBackedReplay<MyEvent> overload above).
builder.Services.AddEventStreams(o => o.UseFileBackedReplay(
    storageDirectory: "/var/streams",                                 // one file per stream id
    cursor: payload => ((MyEvent)payload).Sequence,
    ttl: TimeSpan.FromHours(1),
    serializer: payload => JsonSerializer.SerializeToUtf8Bytes((MyEvent)payload),
    deserializer: bytes => JsonSerializer.Deserialize<MyEvent>(bytes)!));
```

- **`cursor`** — pass this when you want cursored re-subscription
  (`Subscribe(after: N)`) and a usable `GetLastCursorAsync()`. It receives each payload
  and returns the `int` cursor you choose for that event; a monotonically increasing
  sequence number is typical. The live backing does not retain history, so it does not
  take a cursor.
- **`ttl`** — retention for replay backings. It bounds buffered history and also drives
  close-clock auto-destroy for closed streams (see *Lifecycle*).
- **`storageDirectory`** (file-backed only) — when omitted, the file-backed backing
  writes under `~/.agentserver/streams` (one file per stream id). Override the root for
  all agent-server state — tasks and streams alike — with the `AGENTSERVER_STATE_ROOT`
  environment variable, or override just the streams location with `storageDirectory`.
- **`serializer` / `deserializer`** (file-backed only) — bring your own codec when the
  default JSON path cannot round-trip your payload type, or use the typed
  `UseFileBackedReplay<MyEvent>` overload for JSON payloads you want rehydrated as that
  CLR type.

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
> `EventStreamClosedException`. Always scope the stream id to **one logical
> request/turn/invocation** — for `azure-ai-agentserver-invocations`, that is the
> `InvocationId`; for a bare handler, any per-turn string you control end-to-end.

For file-backed replay, remember that the backing keeps one on-disk file per stream
id; choose ids that are stable and boring enough for your storage policy.

---

## The `IEventStream` protocol

Every stream — regardless of backing — exposes the same four operations.

### `EmitAsync(payload, close: false)`

Publishes one event to every currently-attached subscriber.

- `payload` is yours — pass values compatible with the backing's serializer. For the
  default file-backed JSON path, use JSON-serializable payloads or configure custom
  serialization.
- `close: true` is an **atomic emit-and-close**: the payload is delivered and the
  stream is closed in one call. For replay backings, the payload is still retained in
  history; for the live backing, late subscribers do not see it.
- Emitting after the stream is closed throws `EventStreamClosedException`. That signals
  a **producer bug** (you should not still be emitting), so an HTTP layer should surface
  it as a **5xx**, not a client error.

### `CloseAsync()`

Marks the stream **done**. Idempotent — calling it twice (or after the stream is gone)
is a no-op. After close:

- new `EmitAsync` calls raise `EventStreamClosedException`;
- subscribers already iterating the stream drain remaining events, then finish;
- new subscribers can still attach to a replay backing while retained history exists,
  but no new events will arrive.

### `Subscribe(after: null)`

Returns an async iterator over emitted payloads. Iterate it with `await foreach`. The
loop ends when the stream is closed and all buffered events are drained.

`after: N` is the **reconnection primitive** — with a replay backing configured with a
cursor, the iterator first yields retained events whose cursor is greater than `N`, then
continues live. With the live backing (or a replay backing that does not track cursors),
`after` is ignored and a subscriber only sees events emitted after it attached, which is
why the subscribe-before-start rule matters (below).

### `GetLastCursorAsync()`

Returns the highest cursor value seen so far, or `null` if nothing has been emitted
(or the backing does not track cursors). After the stream is closed, this is the last
cursor the backing saw during the close window.

`GetLastCursorAsync()` is the producer's recovery primitive: a recovering producer
reads it to learn where to resume emitting.

---

## Lifecycle: ACTIVE → CLOSED → (destroyed)

Each stream is **ACTIVE** or **CLOSED**. After CLOSED, the id may be destroyed; once
destroyed, the id's resources are gone and `GetAsync(id)` treats it as not found.

| State | What it means | How you reach it |
|---|---|---|
| **ACTIVE** | Accepts `EmitAsync`; subscribable. | Construction (first `GetOrCreateAsync(id)`). |
| **CLOSED** | No new emits (`EmitAsync` raises `EventStreamClosedException`). Existing subscribers drain. New subscribers can still attach to a replay backing and replay retained history, but no new events arrive. | `CloseAsync()` or `EmitAsync(close: true)` from ACTIVE. |

Three independent paths lead to destroyed:

- the id was **never registered** (no `GetOrCreateAsync` ever ran for it);
- it was **explicitly `registry.DeleteAsync(id)`**'d; or
- **close-clock TTL elapsed** — for a **replay backing configured with a `ttl`**, a
  CLOSED stream becomes eligible for auto-destroy once `close-time + ttl` passes,
  regardless of whether anyone is still subscribed or events remain buffered. Cleanup is
  **opportunistic**, not timer-driven: expiry is observed and applied on the next stream
  operation or registry lookup (emit, subscribe, or `GetAsync`), so `GetAsync(id)` after
  the window treats the stream as not found. Use `registry.DeleteAsync(id)` when you need
  deterministic, immediate cleanup.

A few practical implications:

- The **in-memory live** backing never auto-destroys — it has no TTL machinery. Call
  `registry.DeleteAsync(id)` explicitly if you need to release the id.
- Replay backings with a `ttl` clean up closed streams automatically — expiry is applied
  opportunistically on the next stream operation or registry lookup after the close-clock
  window, not by a background timer.
- `GetLastCursorAsync` remains safe to call during the close window, so a recovering
  producer can read the last cursor before cleanup.

> **TTL is a close-clock, not just per-event.** The `ttl` you pass to
> `UseInMemoryReplay`/`UseFileBackedReplay` both evicts individual events after their
> emit time *and* arms the auto-destroy that fires `ttl` after the stream is closed.
> The **in-memory live** backing has no TTL machinery and never auto-destroys — you
> must call `registry.DeleteAsync(id)` to release the id. `GetLastCursorAsync` remains
> safe to call during the close window, so a recovering producer can always read the
> last cursor it saw before close.

---

## The registry

`IEventStreamRegistry` is the process-level map from ids to live streams:

- `GetAsync(id)` — returns the registered stream when it **must** already exist; throws
  `EventStreamNotFoundException` if not.
- `GetOrCreateAsync(id)` — idempotent: the producer and subscriber using the same id
  get the same `IEventStream` instance; if the id was previously destroyed, this
  creates a fresh stream.
- `DeleteAsync(id)` — removes the stream and backing resources. Use it for immediate
  cleanup (end-of-request hook, test teardown) or for backings without TTL cleanup.

For replay backings configured with `ttl`, you typically do not need to call
`DeleteAsync(id)` on the happy path; close-clock auto-destroy handles eventual cleanup.

---

## Exceptions → wire mapping

```text
EventStreamException                 (base — catch-all)
├── EventStreamClosedException       producer bug — wire-map to HTTP 5xx
└── EventStreamNotFoundException     id is not currently a live stream — HTTP 404
```

| Exception | Meaning | Typical HTTP mapping |
|---|---|---|
| `EventStreamNotFoundException` | `GetAsync` for an id that does not exist | 404 |
| `EventStreamClosedException` | `EmitAsync` after the stream was closed | **5xx** (producer bug) |
| `EventStreamException` | base type for stream errors | 500 |

Every "this id is not currently a live stream" condition at the registry boundary is
`EventStreamNotFoundException` and maps naturally to 404. `EventStreamClosedException`
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
IEventStream stream = await registry.GetOrCreateAsync(id);
var consume = ConsumeAsync(stream);          // attaches the subscriber
await StartProducerAsync(id);                // producer emits into the same id
await consume;

// Pattern 2: use a replay backing so late subscribers still get earlier events
// via Subscribe(after: ...).
```

If you cannot guarantee subscribe-before-start (for example, the client connects late
or reconnects), use a **replay** backing and have subscribers resume with
`Subscribe(after: lastCursor)`.

---

## Recovery & resumption

### Cursored reconnect (client side)

If a subscriber drops (network blip, client refresh) and your backing tracks cursors,
the client reconnects with the last cursor it saw and the SDK only re-delivers later
events. Assign each event a cursor and surface it to the client (for SSE, as the event
id):

```csharp
// Client reconnects having last seen cursor 42.
await foreach (object evt in stream.Subscribe(after: 42))
{
    // only events with cursor > 42, then live
}
```

Events with cursor `<= 42` are skipped from retained history; delivery resumes after
42 and then continues live.

### Crash-recoverable producer (file-backed)

With `UseFileBackedReplay`, emitted events persist to disk and rehydrate on the next
`GetOrCreateAsync(id)` after a restart, so the producer can resume and subscribers can
replay from any cursor — across a process crash.

The typical recovery path is: the producer uses the same per-turn stream id, calls
`GetOrCreateAsync(id)`, reads `GetLastCursorAsync()`, and resumes emitting from the
next cursor.

### Don't double-track in task metadata

If you are bridging a task to a stream, let the stream's cursor be the single source
of truth for "where am I". Do not also record per-event progress in task `Metadata` —
that duplicates state and the two can drift. Task `Metadata` is for workflow
watermarks (which side-effecting work you have already completed), not for mirroring
stream state. Use `GetLastCursorAsync` to read the current position.

---

## HTTP / SSE bridging pattern

Typical endpoint helper for serving a stream over Server-Sent Events:

```csharp
// GET /runs/{id}/events  — stream a run's events as SSE, resumable via Last-Event-ID.
app.MapGet("/runs/{id}/events", async (string id, HttpContext http,
                                        IEventStreamRegistry registry) =>
{
    http.Response.Headers.ContentType = "text/event-stream";

    int? after = http.Request.Headers.TryGetValue("Last-Event-ID", out var v)
        && int.TryParse(v, out var n) ? n : null;

    // A GET is a pure RESUME/read endpoint: the stream must already exist (the
    // producer created it). Use GetAsync — not GetOrCreateAsync — so an unknown or
    // TTL-expired id surfaces EventStreamNotFoundException → 404 instead of silently
    // creating a new empty stream.
    IEventStream stream;
    try
    {
        stream = await registry.GetAsync(id, http.RequestAborted);
    }
    catch (EventStreamNotFoundException)
    {
        http.Response.StatusCode = 404;
        return;
    }

    await foreach (object evt in stream.Subscribe(after, http.RequestAborted))
    {
        // Derive the SSE event id from THIS event's own cursor — the same cursor
        // function you configured on the backing. Do NOT use GetLastCursorAsync()
        // here: it returns the stream's HIGHEST cursor, which races ahead of the
        // event you are currently writing (and would emit wrong Last-Event-ID values).
        int cursor = CursorOf(evt);
        await http.Response.WriteAsync($"id: {cursor}\n");
        await http.Response.WriteAsync($"data: {JsonSerializer.Serialize(evt)}\n\n");
        await http.Response.Body.FlushAsync(http.RequestAborted);
    }
});

// The SAME function you passed as `cursor:` to AddEventStreams(...).
static int CursorOf(object evt) => ((MyEvent)evt).Sequence;
```

Pair this with a replay backing so reconnecting clients (which send `Last-Event-ID`)
resume exactly where they left off. If the client sends `Last-Event-ID`, pass it
through to `Subscribe(after: lastEventId)` to skip already-delivered events.

---

## Bringing your own `IEventStream` implementation

You can write your own `IEventStream` implementation (for example a Redis-backed
stream). It is accepted anywhere the interface is — the registry and the SSE bridge
only depend on `IEventStream`, not on the bundled backings.

**But** don't register your custom implementation with the built-in `AddEventStreams`
registry — that registry's lifecycle (TTL eviction, file cleanup, tombstoning) is
wired to the bundled backings only. Ship your own peer registry instead, and let
consumers pick which one to call:

```csharp
// A peer namespace to the SDK's IEventStreamRegistry — same interface, its own
// lifecycle. Register it under your own DI type so callers choose explicitly.
public sealed class MyRedisStreams : IEventStreamRegistry
{
    public MyRedisStreams(string redisConnectionString) { /* ... */ }

    public ValueTask<IEventStream> GetOrCreateAsync(string id, CancellationToken ct = default) { /* ... */ }
    public ValueTask<IEventStream> GetAsync(string id, CancellationToken ct = default) { /* ... */ }
    public ValueTask DeleteAsync(string id, CancellationToken ct = default) { /* ... */ }
}
```

Consumers explicitly choose which registry they want — `myRedisStreams.GetOrCreateAsync(id)`
vs the injected built-in `IEventStreamRegistry`. The shared contract is the
`IEventStream` interface; lifecycle is each registry's own concern.

---

## See also

- [Resilient Tasks — Developer Guide](./tasks-guide.md) — for the producer side when
  the events come from a durable task.
