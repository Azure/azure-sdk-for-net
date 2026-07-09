# Streaming — Developer Guide

The streaming primitives let one part of your app **produce** a sequence of events
and one or more other parts **consume** them — decoupled in time and across the
process boundary. The canonical use is bridging a long-running task to an HTTP
Server-Sent Events (SSE) response so a client can watch progress live and reconnect
without losing events.

This guide is written for application developers and covers the public surface only.

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

---

## Public surface

The whole feature is four small pieces:

| Type | Role |
|---|---|
| `IServiceCollection.AddEventStreams(configure?)` | registration; selects the backing |
| `EventStreamOptions` | chooses and configures the single process backing |
| `IEventStreamRegistry` | maps stream ids to live `IEventStream` instances |
| `IEventStream` | a single producer/consumer event stream |

```csharp
public interface IEventStream
{
    ValueTask EmitAsync(object payload, bool close = false, CancellationToken ct = default);
    ValueTask CloseAsync(CancellationToken ct = default);
    IAsyncEnumerable<object> Subscribe(int? after = null, CancellationToken ct = default);
    ValueTask<int?> GetLastCursorAsync(CancellationToken ct = default);
}

public interface IEventStreamRegistry
{
    ValueTask<IEventStream> GetAsync(string id, CancellationToken ct = default);          // throws if absent
    ValueTask<IEventStream> GetOrCreateAsync(string id, CancellationToken ct = default);  // creates if absent
    ValueTask DeleteAsync(string id, CancellationToken ct = default);                     // remove + free resources
}
```

---

## Choosing a backing

Exactly **one** backing is selected per process at startup, via the configurator
passed to `AddEventStreams`. If you select none, the default is in-memory live.

| Backing | Memory | History | Survives crash | Use when |
|---|---|---|---|---|
| In-memory live | constant | none | no | fan-out to currently-attached subscribers; no replay needed |
| In-memory replay | retained | yes (in RAM) | no | clients reconnect and need missed events; single process |
| File-backed replay | retained | yes (on disk) | yes | the producer may crash and must resume from disk |

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

A **cursor** is an integer you assign to each event so subscribers can reconnect
"after event N" (see *Recovery & resumption*). The live backing does not retain
history, so it does not take a cursor.

When you don't pass `storageDirectory`, the file-backed backing writes under
`~/.agentserver/streams` (one file per stream id). Override the root for all
agent-server state — tasks and streams alike — with the `AGENTSERVER_STATE_ROOT`
environment variable, or override just the streams location with `storageDirectory`.

---

## The stream id

A stream is addressed by a string id you choose. The id is the contract between
producer and subscriber: both must use the same id to meet on the same stream.

A natural choice when bridging a task to a response is to derive the stream id from
the invocation that is producing the events, so the HTTP handler and the producer
agree without extra plumbing. Pick a stable, collision-free, **per-turn** id (e.g. the
invocation id) and reuse it on both sides.

> **Do NOT use a resilient `TaskId` as the stream id.** A resilient task can span
> multiple turns (steering, recovery), but a stream's lifecycle is a single
> ACTIVE→CLOSED arc. If you key the stream on the `TaskId`, the second turn finds the
> first turn's already-**closed** stream and `EmitAsync` throws
> `EventStreamClosedException`. Always scope the stream id to **one logical
> request/turn/invocation** — for `azure-ai-agentserver-invocations`, that is the
> `InvocationId`; for a bare handler, any per-turn string you control end-to-end.

---

## The `IEventStream` protocol

### `EmitAsync(payload, close: false)`

Publishes one event to every currently-attached subscriber. With a replay backing the
event is also retained for later/reconnecting subscribers. Pass `close: true` to emit
a final event and close the stream in one call. Emitting on a closed stream throws
`EventStreamClosedException` — that signals a **producer bug** (you should not still be
emitting), so an HTTP layer should surface it as a **5xx**, not a client error.

### `CloseAsync()`

Marks the stream **done**. Idempotent — calling it twice (or after the stream is
gone) is a no-op. Subscribers iterating the stream complete their loop once they have
observed all events up to the close.

### `Subscribe(after: null)`

Returns an async iterator over emitted payloads. Iterate it with `await foreach`. The
loop ends when the stream is closed and all buffered events are drained.

With a replay backing, pass `after: N` to **resume after cursor N** — the iterator
first yields the retained events with a cursor greater than `N`, then continues live.
With the live backing, a subscriber only sees events emitted after it attached, which
is why the subscribe-before-start rule matters (below).

### `GetLastCursorAsync()`

Returns the highest cursor value seen so far, or `null` if nothing has been emitted
(or the backing does not track cursors). Use it to tell a reconnecting client where
the stream currently is.

---

## Lifecycle: ACTIVE → CLOSED → (destroyed)

1. **ACTIVE** — created by `GetOrCreateAsync`; accepts `EmitAsync` and `Subscribe`.
2. **CLOSED** — after `CloseAsync` (or `EmitAsync(close: true)`); no more emits,
   subscribers drain remaining events and finish. New subscribers can still attach to
   a replay backing and replay retained history, but no new events will arrive.
3. **destroyed** — the id's resources (and, for replay backings, retained history; for
   the file-backed backing, its on-disk file) are released. There are three paths into
   destroyed:
   - the id was **never registered** (no `GetOrCreateAsync` ever ran for it);
   - it was **explicitly `registry.DeleteAsync(id)`**'d; or
   - **close-clock TTL elapsed** — for a **replay backing configured with a `ttl`**, a
     CLOSED stream auto-destroys once `close-time + ttl` passes, regardless of whether
     anyone is still subscribed or events remain buffered.

> **TTL is a close-clock, not just per-event.** The `ttl` you pass to
> `UseInMemoryReplay`/`UseFileBackedReplay` both evicts individual events after their
> emit time *and* arms the auto-destroy that fires `ttl` after the stream is closed.
> The **in-memory live** backing has no TTL machinery and never auto-destroys — you
> must call `registry.DeleteAsync(id)` to release the id. `GetLastCursorAsync` remains
> safe to call during the close window, so a recovering producer can always read the
> last cursor it saw before close.

---

## The registry

`IEventStreamRegistry` maps ids to live streams:

- `GetOrCreateAsync(id)` — the producer's entry point: returns the existing stream or
  creates a fresh one.
- `GetAsync(id)` — the subscriber's entry point when the stream **must** already
  exist; throws `EventStreamNotFoundException` if not.
- `DeleteAsync(id)` — tear down when the work is finished.

---

## Subscribing — the subscribe-before-start rule

With the **live** backing there is no history: a subscriber only receives events
emitted *after* it attaches. So if the producer starts emitting before the subscriber
attaches, those early events are lost to that subscriber.

The rule: **attach the subscriber before the producer starts emitting.** Two safe
patterns:

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

If you cannot guarantee subscribe-before-start (e.g. the client connects late, or
reconnects), use a **replay** backing and have subscribers resume with
`Subscribe(after: lastCursor)`.

---

## Recovery & resumption

### Cursored reconnect (client side)

Assign each event a cursor and surface it to the client (for SSE, as the event id).
When a client reconnects it sends the last cursor it saw; resume the stream after it:

```csharp
// Client reconnects having last seen cursor 42.
await foreach (object evt in stream.Subscribe(after: 42))
{
    // only events with cursor > 42, then live
}
```

### Crash-recoverable producer (file-backed)

With `UseFileBackedReplay`, emitted events persist to disk and rehydrate on the next
`GetOrCreateAsync(id)` after a restart, so the producer can resume and subscribers can
replay from any cursor — across a process crash.

### Don't double-track in task metadata

If you are bridging a task to a stream, let the stream's cursor be the single source
of truth for "where am I". Do not also record per-event progress in task `Metadata`
— that duplicates state and the two can drift. Use `GetLastCursorAsync` to read the
current position.

---

## Exceptions → wire mapping

| Exception | Meaning | Typical HTTP mapping |
|---|---|---|
| `EventStreamNotFoundException` | `GetAsync` for an id that does not exist | 404 |
| `EventStreamClosedException` | `EmitAsync` after the stream was closed | **5xx** (producer bug) |
| `EventStreamException` | base type for stream errors | 500 |

`EventStreamClosedException` means the **producer** tried to emit after the stream was
already closed — that is a server-side bug, not a bad client request, so map it to a
**5xx** (e.g. 500), never a 4xx. (`EventStreamNotFoundException` on `GetAsync` *is* a
client-addressable condition and maps to 404.)

---

## HTTP / SSE bridging pattern

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
resume exactly where they left off.

---

## Bringing your own `IEventStream` implementation

You can write your own `IEventStream` implementation (for example a Redis-backed
stream). It is accepted anywhere the interface is — the registry and the SSE bridge
only depend on `IEventStream`, not on the bundled backings.

**But don't register your custom implementation with the built-in `AddEventStreams`
registry** — that registry's lifecycle (TTL eviction, file cleanup, tombstoning) is
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

Consumers choose which registry they want — `myRedisStreams.GetOrCreateAsync(id)`
vs the injected built-in `IEventStreamRegistry` — and the shared contract is the
`IEventStream` interface; lifecycle is each registry's own concern.

---

## See also

- [Resilient Tasks — Developer Guide](./tasks-guide.md) — for the producer side when
  the events come from a durable task.
