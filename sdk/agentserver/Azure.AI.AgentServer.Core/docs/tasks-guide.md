# Resilient Tasks — Developer Guide

Resilient tasks let an agent run work that **survives process restarts**. You write
an ordinary asynchronous handler; if the host crashes, is rescheduled, or scales out
to a different instance mid-flight, the library re-invokes your handler from the top
with the same persisted input so the work can complete.

This is **not** exactly-once execution and it is **not** deterministic replay: on
recovery the handler runs again from the beginning, and its return value is not
persisted. Any external side effect (charging a card, sending an email) can therefore
happen more than once unless you guard it with a durable `Metadata` marker (§6.2).
The building blocks the library gives you — persisted input, durable metadata, and
cooperative cancellation — are what you compose into an at-most-once effect.

This guide is written for application developers. It covers the public surface only —
you never need to know how state is stored, leased, or transported to use it well.

---

## 1. Why

A normal `Task<T>` lives and dies with your process. If the host restarts while the
work is in flight, the result is lost and the caller hangs or errors.

Resilient tasks give you three guarantees that a plain `Task` cannot:

- **Durable input + resumability** — the input and durable metadata are persisted, so
  after a crash the run is picked up and the handler is **re-invoked from the top** with
  the same input. Progress you want to survive a crash must be written to `Metadata`
  (or your own store) before the crash; the handler's return value itself is **not**
  persisted — it only resolves the awaiting caller.
- **Convergence** — the same logical task identity converges to one run. Two callers
  that name the same task id observe the same single execution, not two.
- **At-most-once side effects** — by recording a marker in durable metadata *before*
  the side effect and flushing it, you can make external side effects (charging a card,
  sending an email) happen at most once across any number of crashes and recoveries
  (§6.2). The library does not do this for you — you compose it from the durable marker.

If your work is short, side-effect-free, and you do not care about surviving a
restart, a plain `Task` is simpler — use that. Reach for resilient tasks when the
work is long, has side effects, or must outlive the process.

---

## 2. Mental model

A resilient task is a **named handler** plus an **invoker** that starts runs of it.

```text
register:   builder.AddTask("summarize", handler)
                       │
invoke:     await invoker.RunAsync<TIn, TOut>("summarize", input)
                       │
run:        handler(TaskContext<TIn>, ct) ──► TOut   (durable, resumable)
```

- You **register** handlers once at startup against names.
- You **invoke** by name with a typed input and get a typed output back.
- Each invocation becomes a durable **run** identified by a `TaskId`.

There are two shapes:

### One-shot vs multi-turn — at a glance

| | One-shot | Multi-turn |
|---|---|---|
| Register with | `AddTask` | `AddMultiTurnTask` |
| Lifetime | one input → one output, then terminal | many inputs over time, same `TaskId` |
| Between inputs | n/a (completes) | parks, waiting for the next input |
| Ending | automatic on return | explicit (`IMultiTurnTask.DeleteAsync`) |
| Steering | n/a | optional (`steerable: true`) |

A **one-shot** task takes one input, produces one output, and is then terminal. A
**multi-turn** task keeps the same `TaskId` across many inputs (think: a
conversation) and stays alive between turns until you end it.

---

## 3. Hello world

### One-shot

```csharp
// Startup: register the handler.
builder.Services
    .AddResilientTasks()
    .AddTask<string, string>("echo", async (ctx, ct) =>
    {
        return $"you said: {ctx.Input}";
    });

// Anywhere with the invoker injected:
string result = await invoker.RunAsync<string, string>("echo", "hello");
// result == "you said: hello"
```

### Multi-turn chain

```csharp
builder.Services
    .AddResilientTasks()
    .AddMultiTurnTask<string, string>("chat", async (ctx, ct) =>
    {
        // ctx.Input is this turn's message; ctx.Metadata persists across turns.
        return $"reply to: {ctx.Input}";
    });

// Turn 1 — a multi-turn chain REQUIRES an explicit TaskId (the chain id) that you
// own. Choose a stable id from your domain (session id, conversation id, ...).
string chatId = $"chat-{sessionId}";
var turn1 = await invoker.StartAsync<string, string>(
    "chat", "hi",
    new RunOptions { TaskId = chatId });
string a1 = await turn1;

// Turn 2 — reuse the same TaskId to continue the same chain.
var turn2 = await invoker.StartAsync<string, string>(
    "chat", "and again",
    new RunOptions { TaskId = chatId });
string a2 = await turn2;

// End the chain when you are done with it.
await multiTurn.DeleteAsync(chatId);
```

---

## 4. Concepts

### 4.1 Identifiers

- **`TaskId`** — identifies a run (one-shot) or a chain (multi-turn). For a **one-shot**
  task you may supply one via `RunOptions.TaskId` for identity-based convergence, or let
  the library generate one. For a **multi-turn** task a `TaskId` is **required on every
  turn** (there is nothing to auto-generate a chain identity from) — omitting it throws
  `ArgumentException`. Two invocations with the same `TaskId` converge to the same run.
- **`InputId`** — identifies a single input (one turn). Supply one via
  `RunOptions.InputId`, or omit it to default to the `TaskId`. Used for idempotent retries
  and for the last-input-id precondition (§4.8, §6.6). `IfLastInputId` requires an
  explicit `InputId` to be set alongside it.

### 4.2 Entry mode

A handler can be entered for the first time, resumed after a restart, or recovered
after a crash. The only way to observe this is `TaskContext.EntryMode`:

```csharp
EntryMode.Fresh      // first execution of this input
EntryMode.Resumed    // a multi-turn chain continued with a new input
EntryMode.Recovered  // execution resumed after an interruption (e.g. host restart)
```

`TaskContext.RecoveryCount` complements `EntryMode`: it is `0` on a fresh run and
increments each time the task is picked up under a new process instance after a crash
or takeover (it mirrors the durable lease generation). Treat it as an **observability
signal**, not a correctness guarantee. If your handler must do something only once
across recoveries, do **not** branch on `RecoveryCount == 0` — record a marker in
`Metadata` and check it, which is the durable, race-free way (§6.2).

### 4.3 Inputs and outputs

Inputs and outputs are your own types, serialized to JSON.

- **Inputs are persisted before the handler runs** — that is the guarantee crash
  recovery rests on: a recovered handler is invoked with the same `Input` it would
  have seen in the lost lifetime.
- **Outputs are not persisted.** When the handler returns, the value resolves the
  awaiting caller's `GetResultAsync()` — that is the only place it appears. If you
  want a per-turn artifact to survive a crash, write it to `Metadata` (or your own
  store) *before* you return.
- **Per-input size limit ≈ 10 MiB** (after JSON serialization). A larger input is
  rejected with `InputTooLargeException` at the caller, before any network round-trip.
  Externalize bigger payloads (blob store + reference). Inputs above an internal
  inline threshold are transparently promoted to an out-of-band attachment by the
  framework — you do not manage that, but it is why the ceiling is a serialized-size
  ceiling, not an in-memory one.

### 4.4 The handler's context (`TaskContext<TInput>`)

Every turn receives a `TaskContext<TInput>`:

| Member | Meaning |
|---|---|
| `Input` | the typed input for this turn |
| `TaskId` / `InputId` | identifiers for the run / this input |
| `EntryMode` | fresh, resumed, or recovered |
| `Metadata` | durable, namespaced key/value store (§4.5) |
| `RetryAttempt` | zero-based retry attempt for the current turn |
| `RecoveryCount` | zero-based crash-recovery count (mirrors the durable lease generation); a signal, not a guarantee (§4.2) |
| `IsSteeredTurn` | whether this turn was triggered by a steering input |
| `PendingInputCount` | number of queued steering inputs waiting |
| `Cancellation` | a token signaled for any cancellation cause |
| `CancelRequested` | true when cancellation was explicitly requested |
| `TimeoutExceeded` | true when the per-turn timeout fired |
| `Shutdown` | a token signaled when the host is shutting down |
| `ExitForRecoveryAsync()` | bail out now, leave the work resumable later (§4.11) |

Always pass `ct` (or `ctx.Cancellation`) into the async calls you make, so the run
stops promptly when cancelled, times out, or the host shuts down.

### 4.5 Metadata

`TaskContext.Metadata` is a durable, namespaced key/value store that travels with the
task across turns and restarts. Values are `BinaryData`, so anything you store is, by
construction, serializable:

```csharp
ctx.Metadata["charged"] = BinaryData.FromObjectAsJson(true);

if (ctx.Metadata.TryGetValue("charged", out var raw) && raw.ToObjectFromJson<bool>())
{
    // already done — skip the side effect.
}
```

Keys beginning with `_` are reserved for the framework **by convention** (SOT §17) but
are not rejected by the primitive — metadata is namespaced under `payload["metadata"]`, so
it cannot collide with the framework's top-level `_`-prefixed payload keys. Use
`Metadata.Namespace("billing")` for an isolated sibling namespace with the same surface.

### 4.6 The result handle (`TaskRun<TOutput>`)

`StartAsync` returns a `TaskRun<TOutput>` — an awaitable handle to the run:

```csharp
TaskRun<string> run = await invoker.StartAsync<string, string>("echo", "hi");

run.TaskId;            // the run's id
run.InputId;          // the input id assigned to this run
run.IsQueued;         // true if this input was queued as steering, not a fresh run
await run;            // await the handle directly to get the result
string r = await run.GetResultAsync();   // equivalent
await run.CancelAsync();                  // request cancellation
```

`RunAsync` is the convenience that starts a run and awaits it to completion in one
call; `StartAsync` hands you the handle so you can await it later or cancel it.

### 4.7 Steering (multi-turn only)

A **steerable** multi-turn task can accept a new input *while a turn is still
running*. The new input is queued; the running turn observes
`ctx.PendingInputCount > 0` (and can react, e.g. by wrapping up early). Register with
`steerable: true`:

```csharp
builder.AddMultiTurnTask<string, string>("assistant", handler, steerable: true);

// Caller pivots mid-turn — both inputs use the SAME explicit chain id, so the
// second one steers the running task.
string chatId = $"assistant-{sessionId}";
var r1 = await invoker.StartAsync<string, string>(
    "assistant", "write a long essay",
    new RunOptions { TaskId = chatId });
var r2 = await invoker.StartAsync<string, string>(
    "assistant", "actually, just one sentence",
    new RunOptions { TaskId = chatId });
```

If the steering queue is full, the enqueue fails with `SteeringQueueFullException`.

**Reacting to a steering nudge.** When an input is queued for a running turn, the
library bumps `ctx.PendingInputCount` **and signals `ctx.Cancellation`** so a handler
blocked in an `await` wakes up immediately. Because the cancellation token fires, any
cancellation-aware call you `await` (a `Task.Delay`, an HTTP/model call you passed
`ct` into, etc.) throws `OperationCanceledException`. A steering nudge is **not** a
caller cancel: the cooperative contract is to *wrap up the current turn and return a
result* so the next turn runs. Distinguish a bare nudge from a real cancel cause by
inspecting the cause booleans (`CancelRequested`, `TimeoutExceeded`, `Shutdown`):

```csharp
for (int step = 0; step < workSteps; step++)
{
    if (ctx.PendingInputCount > 0)
    {
        return WrapUpEarly(ctx);     // a newer input is waiting — yield to it
    }

    try
    {
        await DoOneStepAsync(ct);    // ct == ctx.Cancellation
    }
    catch (OperationCanceledException)
        when (ctx.PendingInputCount > 0
              && !ctx.CancelRequested
              && !ctx.TimeoutExceeded
              && !ctx.Shutdown.IsCancellationRequested)
    {
        return WrapUpEarly(ctx);     // bare steering nudge → cooperative wind-down
    }
}
```

If you let the `OperationCanceledException` from a bare nudge escape the handler, the
turn ends without a result and the queued input still drains as the next turn — but
the interrupted turn's caller observes a `TaskCancelledException` instead of a result,
which is rarely what you want.

> **Note (Python parity):** the Python library signals steering through an
> `asyncio.Event`, so a handler's in-flight `await` completes naturally and the handler
> simply checks `ctx.pending_input_count`. The .NET library signals through the
> cancellation token, so ct-aware awaits throw — handle the nudge as shown above.

### 4.8 Retry

Retries are **off by default**: a task with no configured `RetryPolicy` runs the handler
exactly once and surfaces the first failure. Opt in by setting
`TaskRegistrationOptions.Retry`. When a handler throws, the library retries it according to
the task's `RetryPolicy`. Across retries:

- `ctx.RetryAttempt` increments (0 on the first try).
- Durable `Metadata` is preserved, so a marker written before the failure is still
  visible on the retry — this is how you avoid repeating a side effect.

`ctx.RetryAttempt` is **persisted, and crash recovery does NOT consume retry budget**.
If attempt 2 of 3 crashes mid-flight, the recovered handler is re-invoked with
`ctx.RetryAttempt == 2` and still has its third attempt available — the recovery is
not counted as an extra retry. Only an actual handler *throw* advances the counter.
The counter also resets at every new turn boundary (multi-turn), so each turn starts
with a fresh budget.

When retries are exhausted the invoker throws `TaskFailedException`, whose `Error`
(`TaskFailureDetail`) reports the `Kind` (`HandlerError` or `ExhaustedRetries`),
the `ErrorType`, `Message`, `Attempts`, and the last error.

```csharp
var policy = RetryPolicy.ExponentialBackoff(maxAttempts: 5);
builder.AddTask<Order, Receipt>("charge", handler, o => o.Retry = policy);
```

`RetryPolicy` ships with `ExponentialBackoff`, `FixedDelay`, `LinearBackoff`, and
`NoRetry` factories. You can scope which exceptions are retryable with `RetryOn`.

**Hard limits — invalid values throw.** Two values are hard-capped so a misconfiguration cannot
cause a task turn to retry unboundedly: `MaxAttempts` must be **1–10** (inclusive) and `MaxDelay`
must be **0–1 hour**. A value outside those ranges — like a negative `InitialDelay`/`MaxDelay`, a
`MaxAttempts` below 1 or above 10, a `MaxDelay` above 1 hour, or a `BackoffCoefficient` below 1.0 —
throws `ArgumentOutOfRangeException` when the `RetryPolicy` is constructed. These are configuration
bugs, so they fail fast rather than being silently clamped. Combined with the per-turn timeout
(§4.10), the bounded attempt count and delay keep the total time spent retrying a single turn
bounded.

### 4.9 Cancellation

`await run.CancelAsync()` requests cancellation. Inside the handler this surfaces as
`ctx.Cancellation` being signaled and `ctx.CancelRequested == true`. A cancelled run
completes by throwing `TaskCancelledException` to the awaiting caller. Honor
cancellation by passing the token into your async work.

### 4.10 Timeout

The timeout is a cap on **how long a single turn (one handler invocation) may run
uninterrupted** — nothing more. It **defaults to 1 day**, and 1 day is also a **hard ceiling**:
you can set `TaskRegistrationOptions.Timeout` to a *smaller* budget, but a larger value is
rejected at registration (`ArgumentOutOfRangeException`), as is a negative value. When the timeout
fires, `ctx.Cancellation` is signaled and `ctx.TimeoutExceeded == true`.

**It is per turn, not per task — and it does not limit how long a multi-turn task can live.**
For a multi-turn task the budget bounds each individual turn and resets for every fresh turn, so
a multi-turn task can stay alive **indefinitely**: you can keep sending it turns for weeks or
months. The timeout only guarantees that no *single* turn runs longer than its budget; it never
expires the task as a whole.

**The watchdog is wall-clock and survives crashes.** The budget is measured against a
**persisted turn-start timestamp** (UTC), not a fresh clock per lifetime. So a handler that
started its turn one minute before the process died and has a 90-second budget gets ~30 seconds
after recovery, not a fresh 90 — a long-running turn cannot game its budget by triggering
recovery to reset the clock. When the timeout fires it is **cooperative**: it signals
`ctx.Cancellation` and flips `ctx.TimeoutExceeded`; it does **not** force-stop the handler.

> **Task lifetime vs. turn timeout — don't conflate them.** The turn timeout (this setting) bounds
> a single handler run. A task's *overall* lifetime is governed separately by the platform's
> **30-day sliding TTL**: a task is retained as long as it stays active, and is only cleaned up
> after **30 days of inactivity** (no new turns in the last 30 days). Every turn resets that
> 30-day window. So to keep a multi-turn task alive forever, just make sure it sees at least one
> turn within any 30-day span — the per-turn timeout is irrelevant to that.

```csharp
// Lower the budget to 2 minutes (values above the 1-day cap are rejected at registration).
builder.AddTask<Doc, Summary>("summarize", handler, o => o.Timeout = TimeSpan.FromMinutes(2));
```

### 4.11 Shutdown

When the host begins a graceful shutdown, `ctx.Shutdown` is signaled. A long-running
handler should stop promptly and **leave its work resumable** by calling
`ctx.ExitForRecoveryAsync()`, which unwinds the handler without a terminal result so
the run is picked up and continued elsewhere (or after restart):

```csharp
if (ctx.Shutdown.IsCancellationRequested)
{
    await ctx.ExitForRecoveryAsync();   // throws to unwind; resumes later
}
```

Cooperative exit is preferred because it lets you checkpoint first. As a safety net, the
framework also **force-releases the lease** of any turn still running when the shutdown
grace window elapses, so the record (left `in_progress`) is reclaimed immediately when the
process restarts instead of waiting for the lease to expire on its own.

### 4.12 Multi-turn chain deletion

A multi-turn chain stays alive between turns; ending it is explicit. Inject
`IMultiTurnTask` and call `DeleteAsync(taskId)`. It cancels any in-flight turn,
resolves queued callers as cancelled, and removes the record. It is idempotent — a
no-op if the chain is already gone.

---

## 5. Reference

### 5.1 Registration

```csharp
IResilientTaskBuilder AddResilientTasks(this IServiceCollection services,
                                        TokenCredential? credential = null);

IResilientTaskBuilder AddTask<TInput, TOutput>(
    string name,
    Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
    Action<TaskRegistrationOptions>? configure = null);

IResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(
    string name,
    Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
    bool steerable = false,
    Action<TaskRegistrationOptions>? configure = null);
```

### 5.2 `ITaskInvoker`

```csharp
Task<TOutput>          RunAsync<TInput, TOutput>(string name, TInput input, RunOptions? options = null, CancellationToken ct = default);
Task<TaskRun<TOutput>> StartAsync<TInput, TOutput>(string name, TInput input, RunOptions? options = null, CancellationToken ct = default);
Task<TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(string name, string taskId, CancellationToken ct = default);
Task<TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(string name, string taskId, string inputId, CancellationToken ct = default);
```

Both `RunAsync` and `StartAsync` perform a storage round-trip and so are async.
`StartAsync` returns once the run has been durably created; awaiting the returned
handle waits for the result.

Use the `(name, taskId)` `GetActiveRunAsync` overload for one-shot tasks. Use the
`(name, taskId, inputId)` overload for multi-turn chains when you hold the specific
turn's `inputId` and want that turn's handle; it is required for multi-turn tasks
(the two-argument overload throws for a multi-turn registration).

### 5.3 `TaskRun<TOutput>`

`TaskId`, `InputId`, `Metadata`, `IsQueued`, `GetResultAsync(ct)`, `CancelAsync(ct)`,
and `GetAwaiter()` (so you can `await` the handle directly).

### 5.4 `TaskContext<TInput>`

See §4.4 for the full table.

### 5.5 `RunOptions`

```csharp
string? TaskId;          // identity-based convergence; generated when omitted
string? InputId;         // explicit per-turn input id; defaults to TaskId when omitted
string? IfLastInputId;   // precondition: require the task's last input id to equal this
```

### 5.6 Exceptions

| Exception | When |
|---|---|
| `TaskException` | base type for all task errors |
| `TaskFailedException` | handler failed / retries exhausted (carries `TaskFailureDetail`) |
| `TaskCancelledException` | the run was cancelled |
| `TaskConflictException` | the task is in a state that forbids the operation (carries `CurrentStatus`) |
| `TaskDeferredException` | thrown by `ExitForRecoveryAsync` to unwind for later recovery |
| `InputTooLargeException` | the input exceeded the allowed size |
| `LastInputIdPreconditionFailedException` | `IfLastInputId` did not match (carries `ActualLastInputId`) |
| `SteeringQueueFullException` | a steering input could not be queued |

### 5.7 `RetryPolicy`

Fields: `InitialDelay`, `BackoffCoefficient`, `MaxDelay`, `MaxAttempts`, `Jitter`,
`RetryOn`. Factories: `ExponentialBackoff`, `FixedDelay`, `LinearBackoff`, `NoRetry`.
`MaxAttempts` must be 1–10 and `MaxDelay` 0–1 hour; a value outside those hard caps — like
negative delays, `MaxAttempts` < 1 or > 10, `MaxDelay` > 1 hour, or `BackoffCoefficient` < 1.0 —
throws `ArgumentOutOfRangeException` at construction. Retries are off unless a policy
is set (§4.8).

### 5.8 `TaskMetadata`

Indexer `BinaryData? this[string key]`, `ContainsKey`, `TryGetValue`, `Name`, and
`Namespace(string)`. Keys beginning with `_` are reserved by convention (not rejected).

### 5.9 `EntryMode`

`Fresh`, `Resumed`, `Recovered`.

---

## 6. Patterns

### 6.1 Multi-turn agent (the common case)

```csharp
builder.AddMultiTurnTask<string, string>("agent", async (ctx, ct) =>
{
    var history = ctx.Metadata.TryGetValue("history", out var h)
        ? h.ToObjectFromJson<List<string>>() : new List<string>();
    history.Add(ctx.Input);
    var reply = await Model.RespondAsync(history, ct);
    history.Add(reply);
    ctx.Metadata["history"] = BinaryData.FromObjectAsJson(history);
    return reply;
});
```

### 6.2 At-most-once side effects across crashes

The durable marker must be **flushed before** the side effect, and the side effect
should carry the reserved token as an idempotency key. That ordering is what makes the
effect at-most-once: if the process dies after the charge but before the receipt is
written, the recovered handler re-charges with the *same* idempotency key, so the
gateway dedupes it.

```csharp
builder.AddTask<Order, Receipt>("charge", async (ctx, ct) =>
{
    if (ctx.Metadata.TryGetValue("receipt", out var prior))
        return prior!.ToObjectFromJson<Receipt>();      // already charged in a prior lifetime

    // 1. Reserve a dedup token and FLUSH it before the side effect.
    if (!ctx.Metadata.TryGetValue("charge_token", out var token))
    {
        token = BinaryData.FromString(Guid.NewGuid().ToString());
        ctx.Metadata["charge_token"] = token;
        await ctx.Metadata.FlushAsync(ct);
    }

    // 2. Do the side effect with the token as an idempotency key.
    Receipt receipt = await Billing.ChargeAsync(
        ctx.Input, idempotencyKey: token!.ToString(), ct);

    // 3. Record the result and flush it so a later recovery short-circuits at the top.
    //    Even if the process dies before this flush lands, the reserved token above
    //    keeps the charge at-most-once (the gateway dedupes on the idempotency key).
    ctx.Metadata["receipt"] = BinaryData.FromObjectAsJson(receipt);
    await ctx.Metadata.FlushAsync(ct);
    return receipt;
});
```

### 6.3 Steering — interruptible long turn

```csharp
builder.AddMultiTurnTask<string, string>("writer", async (ctx, ct) =>
{
    var sb = new StringBuilder();
    await foreach (var token in Model.StreamAsync(ctx.Input, ct))
    {
        if (ctx.PendingInputCount > 0) break;   // a newer input is waiting — wrap up
        sb.Append(token);
    }
    return sb.ToString();
}, steerable: true);
```

### 6.4 Graceful shutdown — `ExitForRecoveryAsync`

```csharp
builder.AddTask<Job, Result>("batch", async (ctx, ct) =>
{
    foreach (var item in ctx.Input.Items)
    {
        if (ctx.Shutdown.IsCancellationRequested)
            await ctx.ExitForRecoveryAsync();    // resume the remaining items later
        await ProcessAsync(item, ct);
    }
    return Result.Done;
});
```

### 6.5 Late-join an in-flight run

```csharp
// Another caller already started "echo" with this taskId; attach to it.
TaskRun<string>? existing = await invoker.GetActiveRunAsync<string>("echo", taskId);
if (existing is not null)
    string result = await existing;
```

### 6.6 Optimistic concurrency on the input queue

Use `IfLastInputId` to make a turn conditional on the chain not having advanced since
you last observed it. If another input landed first, the call fails with
`LastInputIdPreconditionFailedException`, whose `ActualLastInputId` tells you the
current head so you can retry against it.

Pair it with an explicit `InputId` for the turn you are appending: `IfLastInputId` is
the *precondition* (the head you expect) and `InputId` is the *new* input's id (the
head you are advancing to). Setting both makes the compare-and-swap unambiguous and
lets a safe retry reuse the same `InputId` idempotently.

```csharp
await invoker.StartAsync<string, string>("chat", "next",
    new RunOptions
    {
        TaskId = taskId,
        InputId = "msg-8",            // the id this turn will advance the head to
        IfLastInputId = lastSeenInputId,   // require the head to still be "msg-7"
    });
```

---

## 7. Operational notes

- Register all handlers at startup, before the host starts serving.
- One-shot tasks complete and become terminal automatically; multi-turn chains must
  be ended explicitly with `IMultiTurnTask.DeleteAsync`.
- Make handlers idempotent with respect to recovery: anything observable outside the
  process (a charge, an email) should be guarded by a `Metadata` marker.
- Always thread the cancellation token through your async work so cancellation,
  timeout, and shutdown take effect promptly.

## 8. What this is NOT

- It is **not** a general background-job scheduler or cron. There is no "run at
  3am" surface — you invoke a task when you have work for it.
- It is **not** a workflow/DAG engine. A handler is plain code; there are no
  step/activity primitives to compose.
- It does **not** expose storage, leasing, or transport. Those are framework
  internals deliberately kept off the public surface.

## Quick FAQ

**Do I need to know where state is stored?** No. Registration and invocation are the
whole surface; persistence is automatic and environment-selected.

**How do I make a side effect happen once?** Guard it with a `Metadata` marker and
check the marker on entry (§6.2). `EntryMode`/`RetryAttempt` are signals, not
guarantees — the marker is the guarantee.

**When should I use a plain `Task` instead?** When the work is short, has no external
side effects, and does not need to survive a restart.

**How do I do "fire and forget"?** Call `StartAsync(...)` instead of `RunAsync(...)`.
It returns a `TaskRun<TOutput>` handle as soon as the run is registered; you can drop
the handle and the task keeps running resiliently. A later caller can attach via
`GetActiveRunAsync(name, taskId)` if it cares about the outcome.

**Can two callers run the same `taskId` concurrently?** No — `taskId` is the identity.
The second caller either attaches to the first's in-flight run (one-shot convergence),
gets queued (multi-turn, when steering is enabled), or sees `TaskConflictException`.

**Does the framework retry by default?** No. Pass `RunOptions { Retry = RetryPolicy.… }`
(or set it on the registration) to opt in. Without a policy a handler runs once and
surfaces the exception.

**Can I store conversation history in `ctx.Metadata`?** Small histories fit, but
`Metadata` is intentionally small and JSON-only (values are `BinaryData`). Use a
dedicated checkpointer (your own database, a vector store, etc.) for large multi-turn
state, and keep `Metadata` to small watermarks and dedup tokens.

**What if my handler ignores `ctx.Cancellation`?** Cooperative cancellation is a
request; nothing forces a handler to stop. If your handler must be interruptible,
observe `ctx.Cancellation` in your loop (or pass it to the calls you `await`).
`IMultiTurnTask.DeleteAsync(taskId)` is the call that force-cancels: it signals
cancellation AND tears the run down so a non-cooperating handler still exits.

**How do I inspect a task's persisted state from outside the handler?** You don't —
the public surface is intentionally write-shaped (register + invoke), and the store,
providers, and wire schema are internal. Read paths stay in the handler via
`ctx.Metadata`, `ctx.RetryAttempt`, `ctx.RecoveryCount`, and `ctx.EntryMode`. If you
need external read access, record your own watermarks in `Metadata` and surface them
from your application.
