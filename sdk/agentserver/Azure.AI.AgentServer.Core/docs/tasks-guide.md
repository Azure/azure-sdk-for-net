# Resilient Tasks — Developer Guide

This is the developer guide for `Azure.AI.AgentServer.Core`'s resilient tasks — the
primitive that turns an ordinary asynchronous handler into a **crash-resilient unit of
agent work**.

If your agent needs to survive container crashes, OOM kills, or redeployments without
losing its place, you want this. If your unit of work could plausibly outlive the
request that started it (long model calls, multi-step tool chains, multi-message
conversations), you want this.

This guide is written for application developers. It covers the public surface only —
you never need to know how state is stored, leased, or transported to use it well.

---

## 1. Why

There is **one primitive in two flavours**:

- **`AddTask` — one-shot.** A single resilient run of a handler. Returns its output,
  then the record is gone. Use for "do this one thing resiliently".
- **`AddMultiTurnTask` — chain.** A series of turns sharing a conversation identity (a
  `TaskId`). Each `return` is one turn; the chain stays alive between turns and can
  accept more inputs. Use for chat sessions, agents that work across multiple user
  messages, and resilient orchestrations.

Both run the same way under the hood: lease-based crash recovery, a single typed input
per turn, a `TaskContext<TInput>` handle, optional retry, and optional steering (for a
multi-turn task).

What this primitive solves:

- **Crash survival.** If the process dies mid-call, the next process picks up the same
  task with the same input and **re-invokes the handler from the top** (or, for a chain
  parked between turns, the next caller resumes it). Progress you want to survive a
  crash must be written to `FoundryStateStore` (or your own store) before the crash; the
  handler's return value itself is **not** persisted — it only resolves the awaiting
  caller.
- **Identity.** A `TaskId` is the resilient name of the work. Two callers naming the
  same `TaskId` don't double-execute — they converge on the same single run.
- **Typed inputs and outputs.** Generic in `TInput` and `TOutput`; the framework
  persists the input and surfaces the output through a typed handle.
- **Cooperative cancellation.** The caller can ask the handler to stop; the handler
  decides how to wind down.
- **Lightweight, small surface.** A registration builder, a few types, and a handful of
  exceptions.

What this primitive deliberately does **not** do:

- **Deterministic replay.** The handler is re-invoked from the top on recovery; the
  framework does not record and replay every effect. Determinism across re-invocations
  is the handler's responsibility — use durable StateStore checkpoints for at-most-once patterns
  (§6.2).
- **Workflow orchestration** (fan-out / fan-in / child workflows). If you want
  Temporal-style orchestration, use a workflow engine; you can still wrap resilient
  tasks inside it.
- **A bulk data store.** Conversation history and big blobs belong in
  `FoundryStateStore` or your own storage.
- **A queue.** One `TaskId` is one logical job — not a competing-consumer pull queue.

If your work is short, side-effect-free, and does not need to survive a restart, a
plain `Task` is simpler — use that. Reach for resilient tasks when the work is long,
has side effects, or must outlive the process.

---

## 2. Mental model

A resilient task is a **named handler** registered at startup; registration returns a typed `TaskDefinition<TInput, TOutput>` handle that starts runs of it.

```text
┌─────────────────────────────────────────────────────────────────┐
│                            Your code                              │
│                                                                   │
│  AddTask("summarize", …)          AddMultiTurnTask("chat", …)     │
│  async (ctx, ct) =>               async (ctx, ct) =>              │
│      Work(ctx.Input)                  Reply(ctx.Input)            │
│                                                                   │
│  await summarize.RunAsync(input)    await chat.RunAsync(          │
│                                      input,                       │
│                                      new RunOptions {             │
│                                          TaskId = "c1" })         │
└─────────────────────────────────────────────────────────────────┘
                              ▲
                              │   (your async caller)
                              │
┌─────────────────────────────────────────────────────────────────┐
│                     Resilient task framework                      │
│                                                                   │
│   - persists input + task state + lease                           │
│   - invokes your handler with TaskContext<TInput>                 │
│   - watches for crashes, reclaims abandoned leases                │
│   - delivers output by resolving the awaited TaskRun<TOutput>     │
└─────────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│            Task store (hosted or local file-backed)               │
│                                                                   │
│   ETag-guarded store of task records:                             │
│     id, status, lease owner, payload, attachments, etag           │
└─────────────────────────────────────────────────────────────────┘
```

- You **register** handlers once at startup against names and capture their typed handles.
- You **invoke** through the returned `TaskDefinition<TInput, TOutput>` handle with a typed input and get a typed output back.
- Each invocation becomes a durable **run** identified by a `TaskId`.

There are two shapes:

### One-shot vs multi-turn — at a glance

| | `AddTask` (one-shot) | `AddMultiTurnTask` (chain) |
|---|---|---|
| Lifetime | one run | multiple turns; chain stays alive between turns |
| `TaskId` on start | optional (auto-generated opaque id) | mandatory |
| `InputId` | defaults to `TaskId` (1:1) | auto-generated uniquely per turn unless you supply `RunOptions.InputId` — pass the protocol's own per-turn identifier (an invocation id, or the Responses `response.id`) |
| Terminal status | `completed` / `failed` / `cancelled` → record deleted | parked between turns; deleted only via `DeleteAsync(taskId)` |
| `DeleteAsync(taskId)` | not available (auto-cleans on terminal) | available — chain-level delete |
| Handler `return` | finishes the run; the awaited `TaskRun<TOutput>` resolves | finishes the **turn**; chain parks; caller receives the value |
| Steering queue | n/a | `steerable: true` opt-in |
| Concurrent start on same `TaskId` while in-flight | converges on the in-flight run | if `steerable: true`: queued; else a `ResilientTaskException` (`Conflict`) |

A **one-shot** task takes one input, produces one output, and is then terminal. A
**multi-turn** task keeps the same `TaskId` across many inputs (think: a
conversation) and stays alive between turns until you end it.

---

## 3. Hello world

### One-shot

```csharp
var builder = AgentHost.CreateBuilder();

TaskDefinition<string, string> echo = builder.Services
    .AddResilientTask<string, string>("echo", async (ctx, ct) =>
    {
        return $"you said: {ctx.Input}";
    });

var app = builder.Build();
await app.StartAsync();

string result = await echo.RunAsync("hello");
// result == "you said: hello"
```

The registration-time handle is bound to the task engine when the application host starts.
When resolving a handle later through `GetResilientTask`, resolution initializes the engine
even when the caller is using a built service provider outside an `IHost`.

There are two ways to get a task's `TaskDefinition<TInput, TOutput>` handle:

1. **At registration time** — capture the value `AddResilientTask`/`AddResilientMultiTurnTask`
   returns, as above. Convenient at startup, when the handle is used immediately or stashed in a
   local.
2. **Later, at resolution time** — every registered task is also registered as a **keyed
   singleton** (keyed by its name), so resolve it from `IServiceProvider` wherever you have one
   (a request handler, a background service, ...) with `GetResilientTask<TInput, TOutput>(name)`:

```csharp
// Elsewhere — e.g. a request handler resolved from DI — get the same task by name.
TaskDefinition<string, string> echo = serviceProvider.GetResilientTask<string, string>("echo");
string result = await echo.RunAsync("hello again");
```

Both return the *same* handle instance; use whichever is convenient at the call site. See §5.2 for
the full `GetResilientTask` signature and the keyed-registration rationale.

### Multi-turn chain

```csharp
TaskDefinition<string, string> chat = builder.Services
    .AddResilientMultiTurnTask<string, string>("chat", async (ctx, ct) =>
    {
        // ctx.Input is this turn's message. Persist application state explicitly.
        return $"reply to: {ctx.Input}";
    });

// Turn 1 — a multi-turn chain REQUIRES an explicit TaskId (the chain id) that you
// own. Choose a stable id from your domain (session id, conversation id, ...).
string chatId = $"chat-{sessionId}";
var turn1 = await chat.StartAsync(
    "hi",
    new RunOptions { TaskId = chatId });
string a1 = await turn1.Completion;

// Turn 2 — reuse the same TaskId to continue the same chain.
var turn2 = await chat.StartAsync(
    "and again",
    new RunOptions { TaskId = chatId });
string a2 = await turn2.Completion;

// End the chain when you are done with it.
await chat.DeleteAsync(chatId);
```

---

## 4. Concepts

### 4.1 Identifiers

- **`TaskId`** — identifies a run (one-shot) or a chain (multi-turn). For a **one-shot**
  task you may supply one via `RunOptions.TaskId` for identity-based convergence, or let
  the library generate one. For a **multi-turn** task a `TaskId` is **required on every
  turn** (there is nothing to auto-generate a chain identity from) — omitting it throws
  `ArgumentException`. For a **one-shot** task, two invocations with the same `TaskId`
  converge to the same run; for a **multi-turn** task the `TaskId` identifies the chain,
  and a concurrent start on an in-flight chain either queues as the next turn (steerable)
  or throws a `ResilientTaskException` with `ErrorCode.Conflict` (non-steerable).
- **`InputId`** — the resilient name of one input within the task. Used for idempotent
  retries and for the last-input-id precondition (§4.8, §6.6).
  - One-shot: defaults to the `TaskId` (one run, one input — the 1:1 invariant).
  - Multi-turn: per turn; the framework generates a unique id **per turn** unless you
    supply `RunOptions.InputId` — pass the protocol's own per-turn identifier so the
    durable input id matches the wire identity (an invocation id, or the Responses
    `response.id`; this is exactly what the Responses layer supplies per turn). Read the
    id assigned to a turn back from `TaskRun.InputId` / `TaskContext.InputId`.

  `IfLastInputId` requires an explicit `InputId` to be set alongside it.

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
across recoveries, do **not** branch on `RecoveryCount == 0` — record and check a
durable StateStore checkpoint, which is the race-free way (§6.2).

### 4.3 Inputs and outputs

Inputs and outputs are your own types, serialized to JSON.

- **Inputs are persisted before the handler runs** — that is the guarantee crash
  recovery rests on: a recovered handler is invoked with the same `Input` it would
  have seen in the lost lifetime.
- **Outputs are not persisted.** When the handler returns, the value resolves the
  awaiting caller's `Completion` task — that is the only place it appears. If you
  want a per-turn artifact to survive a crash, write it to `FoundryStateStore` (or
  your own store) *before* you return.
- If the top-level serialized input contains `call_id`, the engine installs it as
  `FoundryAgentRequestContext.Current.CallId` for every handler attempt, including
  retries, steering, and recovery. User and session IDs are intentionally not restored.
- **Per-input size limit ≈ 10 MiB** (after JSON serialization). A larger input is
  rejected with `ArgumentException` at the caller, before any network round-trip.
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

### 4.5 Application state

Task records contain framework orchestration state only. Persist checkpoints,
conversation history, and idempotency markers explicitly with `FoundryStateStore`.
Scope the store name to your task, session, or conversation identity. See the
[State Store guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/docs/StateStoreGuide.md) for local fallback, optimistic concurrency,
tagging, and recovered-execution patterns.

### 4.6 The result handle (`TaskRun<TOutput>`)

`StartAsync` returns a `TaskRun<TOutput>` — an awaitable handle to the run:

```csharp
TaskRun<string> run = await echo.StartAsync("hi");

run.TaskId;            // the run's id
run.InputId;          // the input id assigned to this run
run.IsQueued;         // true if this input was queued as steering, not a fresh run
string r = await run.Completion;                        // await the result
string c = await run.Completion.WaitAsync(token);       // cancel only your wait
await run.RequestCancellationAsync();                   // request cancellation of the run
```

`RunAsync` is the handle method that starts a run and awaits it to completion in one
call; `StartAsync` hands you the `TaskRun<TOutput>` so you can await it later or cancel it.

### 4.7 Steering (multi-turn only)

A **steerable** multi-turn task can accept a new input *while a turn is still
running*. The new input is queued; the running turn observes
`ctx.PendingInputCount > 0` (and can react, e.g. by wrapping up early). Register with
`steerable: true`:

```csharp
TaskDefinition<string, string> assistant =
    services.AddResilientMultiTurnTask<string, string>("assistant", handler, steerable: true);

// Caller pivots mid-turn — both inputs use the SAME explicit chain id, so the
// second one steers the running task.
string chatId = $"assistant-{sessionId}";
var r1 = await assistant.StartAsync(
    "write a long essay",
    new RunOptions { TaskId = chatId });
var r2 = await assistant.StartAsync(
    "actually, just one sentence",
    new RunOptions { TaskId = chatId });
```

If the steering queue is full, the enqueue fails with a `ResilientTaskException` whose `ErrorCode` is `QueueFull`.

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
because a bare nudge carries no cancel cause (no explicit cancel and no timeout), the
escaping exception is treated as a **handler failure**, so the interrupted turn's caller
observes a `ResilientTaskException` (`ErrorCode.HandlerError`, subject to any retry policy)
rather than a clean result. Catch the nudge and return cooperatively instead.

> **Note (Python parity):** the Python library signals steering through an
> `asyncio.Event`, so a handler's in-flight `await` completes naturally and the handler
> simply checks `ctx.pending_input_count`. The .NET library signals through the
> cancellation token, so ct-aware awaits throw — handle the nudge as shown above.

### 4.8 Retry

Retries are **off by default**: a task with no configured `TaskRetryPolicy` runs the handler
exactly once and surfaces the first failure. Opt in by setting
`TaskRegistrationOptions.Retry`. When a handler throws, the library retries it according to
the task's `TaskRetryPolicy`. Across retries:

- `ctx.RetryAttempt` increments (0 on the first try).
- Durable StateStore checkpoints written before the failure remain visible on retry —
  this is how you avoid repeating a side effect.

`ctx.RetryAttempt` is **persisted, and crash recovery does NOT consume retry budget**.
If attempt 2 of 3 crashes mid-flight, the recovered handler is re-invoked with
`ctx.RetryAttempt == 2` and still has its third attempt available — the recovery is
not counted as an extra retry. Only an actual handler *throw* advances the counter.
The counter also resets at every new turn boundary (multi-turn), so each turn starts
with a fresh budget.

When retries are exhausted the task handle throws a `ResilientTaskException` (`ErrorCode.ExhaustedRetries`;
a single unretried throw uses `ErrorCode.HandlerError`), whose `Failure`
(`TaskFailureDetail`) reports the `Kind` (`HandlerError` or `ExhaustedRetries`),
the `ErrorType`, `Message`, `Attempts`, and the last error.

```csharp
var policy = new TaskRetryPolicy { MaxAttempts = 5 };
services.AddResilientTask<Order, Receipt>("charge", handler, o => o.Retry = policy);
```

`TaskRetryPolicy` expresses the delay between attempts as an `Azure.Core.DelayStrategy` (the `Delay`
property, defaulting to exponential); use `DelayStrategy.CreateExponentialDelayStrategy`,
`DelayStrategy.CreateFixedDelayStrategy`, or a custom derived strategy for linear/service-specific
backoff. You can scope which exceptions are retryable with `RetryOn`.

**Hard limit — invalid values throw.** `MaxAttempts` is hard-capped so a misconfiguration cannot
cause a task turn to retry unboundedly: it must be **1–10** (inclusive); a value below 1 or above 10
throws `ArgumentOutOfRangeException` when the `TaskRetryPolicy` is constructed. These are configuration
bugs, so they fail fast rather than being silently clamped. Combined with the per-turn timeout
(§4.10), the bounded attempt count and delay keep the total time spent retrying a single turn
bounded.

### 4.9 Cancellation

`await run.RequestCancellationAsync()` requests cancellation. Inside the handler this surfaces as
`ctx.Cancellation` being signaled and `ctx.CancelRequested == true`. A cancelled run
completes by throwing `OperationCanceledException` to the awaiting caller. Honor
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
> a single handler run. A task's *overall* lifetime is governed separately by the hosted platform's
> **30-day sliding TTL**: a task is retained as long as it stays active, and is only cleaned up
> after **30 days of inactivity** (no new turns in the last 30 days). Every turn resets that
> 30-day window. So to keep a multi-turn task alive forever, just make sure it sees at least one
> turn within any 30-day span — the per-turn timeout is irrelevant to that. (The in-process
> `LocalTaskStore` used for development has no inactivity TTL; it retains records until you call
> `DeleteAsync`. The 30-day sliding TTL is a hosted-platform behavior.)

```csharp
// Lower the budget to 2 minutes (values above the 1-day cap are rejected at registration).
services.AddResilientTask<Doc, Summary>("summarize", handler, o => o.Timeout = TimeSpan.FromMinutes(2));
```

### 4.11 Shutdown

When the host begins a graceful shutdown, `ctx.Shutdown` is signaled. A long-running
handler should stop promptly and **leave its work resumable** by calling
`ctx.ExitForRecoveryAsync()` and then returning. The call does not throw — it flushes
the task record, releases the lease, and sets a signal the engine reconciles once the handler
returns; the run is then picked up and continued elsewhere (or after restart). Deferral
is a lifecycle handoff, not a failure: it never surfaces as an exception on the run handle
(the handle's `Completion` simply stays pending; a caller can bail its own wait with
`Completion.WaitAsync(shutdownToken)`).

```csharp
if (ctx.Shutdown.IsCancellationRequested)
{
    await ctx.ExitForRecoveryAsync();   // no throw: signals deferral, then return
    return default!;                    // returned value is ignored for a deferred turn
}
```

Cooperative exit is preferred because it lets you checkpoint first. As a safety net, the
framework also **force-releases the lease** of any turn still running when the shutdown
grace window elapses, so the record (left `in_progress`) is reclaimed immediately when the
process restarts instead of waiting for the lease to expire on its own.

### 4.12 Multi-turn chain deletion

A multi-turn chain stays alive between turns; ending it is explicit. Call
`DeleteAsync(taskId)` on the multi-turn task's `TaskDefinition` handle. It cancels
any in-flight turn, resolves queued callers as cancelled, and removes the record.
It is idempotent — a no-op if the chain is already gone.

---

## 5. Reference

### 5.1 Registration

```csharp
IServiceCollection AddResilientTasks(this IServiceCollection services,
                                      TokenCredential? credential = null);

TaskDefinition<TInput, TOutput> AddResilientTask<TInput, TOutput>(
    this IServiceCollection services,
    string name,
    Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
    Action<TaskRegistrationOptions>? configure = null);

TaskDefinition<TInput, TOutput> AddResilientMultiTurnTask<TInput, TOutput>(
    this IServiceCollection services,
    string name,
    Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
    bool steerable = false,
    Action<TaskRegistrationOptions>? configure = null);
```

`AddResilientTask`/`AddResilientMultiTurnTask` self-initialize the resilient-tasks
services on first use, so `AddResilientTasks()` is optional — call it explicitly only
when you need to supply a `credential`, or register a `TokenCredential` directly in the
service collection. Either form may be configured before or after task registrations.
When both are used, they must resolve to the same credential instance. A credential is
required when the host is running in Foundry hosted mode and the framework selects
hosted task storage; local development uses the file-backed store and does not require
one.

### 5.2 `TaskDefinition<TInput, TOutput>`

```csharp
Task<TOutput>           RunAsync(TInput input, RunOptions? options = null, CancellationToken cancellationToken = default);
Task<TaskRun<TOutput>>  StartAsync(TInput input, RunOptions? options = null, CancellationToken cancellationToken = default);
Task<TaskRun<TOutput>?> GetActiveRunAsync(string taskId, CancellationToken cancellationToken = default);
Task<TaskRun<TOutput>?> GetActiveRunAsync(string taskId, string inputId, CancellationToken cancellationToken = default);
```

The handle is returned by `AddResilientTask`/`AddResilientMultiTurnTask`, which also
register it as a **keyed singleton** service — keyed by `name` — so resolution is never
ambiguous even when several tasks share the same `<TInput, TOutput>` pair. Resolve it in
a request handler with `IServiceProvider.GetResilientTask<TInput, TOutput>(name)`
(equivalent to `GetRequiredKeyedService<TaskDefinition<TInput, TOutput>>(name)`).

For unit tests, derive a substitute from `TaskDefinition<TInput, TOutput>` using its
protected constructor and override the virtual members needed by the component under
test.

Both `RunAsync` and `StartAsync` perform a storage round-trip and so are async.
`StartAsync` returns once the run has been durably created; awaiting the returned
handle waits for the result.

Use the `(taskId)` `GetActiveRunAsync` overload for one-shot tasks. Use the
`(taskId, inputId)` overload for multi-turn chains when you hold the specific
turn's `inputId` and want that turn's handle; it is required for multi-turn tasks
(the one-argument overload throws for a multi-turn registration).

### 5.3 `TaskRun<TOutput>`

`TaskId`, `InputId`, `IsQueued`, `Completion` (a `Task<TOutput>` — await it for the result,
or `Completion.WaitAsync(token)` to cancel only your wait), and `RequestCancellationAsync()`.

### 5.4 `TaskContext<TInput>`

See §4.4 for the full table.

### 5.5 `RunOptions`

```csharp
string? TaskId;          // identity-based convergence; generated when omitted
string? InputId;         // per-turn input id; one-shot defaults to TaskId; multi-turn auto-generates a unique id per turn when omitted (or supply the protocol's per-turn id, e.g. an invocation id / response.id)
string? IfLastInputId;   // precondition: require the task's last input id to equal this
```

### 5.6 Exceptions

| Exception | When |
|---|---|
| `ResilientTaskException` | the single task-framework exception; carries an `ErrorCode` and code-specific nullable data |
| &nbsp;&nbsp;`ErrorCode.HandlerError` | the handler threw and was not retried (carries `Failure` = `TaskFailureDetail`) |
| &nbsp;&nbsp;`ErrorCode.ExhaustedRetries` | the handler exhausted its retry budget (carries `Failure`) |
| &nbsp;&nbsp;`ErrorCode.Conflict` | the task is in a state that forbids the operation (carries `CurrentStatus`) |
| &nbsp;&nbsp;`ErrorCode.PreconditionFailed` | `IfLastInputId` did not match (carries `ActualLastInputId`) |
| &nbsp;&nbsp;`ErrorCode.QueueFull` | a steering input could not be queued |
| `ArgumentException` | invalid arguments, including an input that exceeds the allowed size |
| `OperationCanceledException` | the run was cancelled |

Recovery deferral (`ExitForRecoveryAsync`) is an internal lifecycle handoff and is **not**
represented by an exception.

### 5.7 `TaskRetryPolicy`

Members: `MaxAttempts`, `Delay` (an `Azure.Core.DelayStrategy`), and `RetryOn`.
`MaxAttempts` must be 1–10; a value outside that cap throws `ArgumentOutOfRangeException` at
construction. The delay bounds (max delay, jitter) are owned by the composed `DelayStrategy`.
Retries are off unless a policy
is set (§4.8).

### 5.8 `EntryMode`

`Fresh`, `Resumed`, `Recovered`.

---

## 6. Patterns

### 6.1 Multi-turn agent (the common case)

```csharp
services.AddResilientMultiTurnTask<string, string>("agent", async (ctx, ct) =>
{
    FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
        $"agent-history/{ctx.TaskId}", credential);
    StateStoreItem? item = await store.GetItemAsync("history", cancellationToken: ct);
    var history = item?.Value["messages"].ToObjectFromJson<List<string>>()
        ?? new List<string>();
    history.Add(ctx.Input);
    var reply = await Model.RespondAsync(history, ct);
    history.Add(reply);
    await store.SetItemAsync(
        "history",
        new Dictionary<string, BinaryData>
        {
            ["messages"] = BinaryData.FromObjectAsJson(history),
        },
        cancellationToken: ct);
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
services.AddResilientTask<Order, Receipt>("charge", async (ctx, ct) =>
{
    FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
        $"billing/{ctx.TaskId}", credential);
    StateStoreItem? item = await store.GetItemAsync("charge", cancellationToken: ct);
    IReadOnlyDictionary<string, BinaryData> state = item?.Value
        ?? new Dictionary<string, BinaryData>();
    if (state.TryGetValue("receipt", out BinaryData? prior))
        return prior.ToObjectFromJson<Receipt>();       // already charged in a prior lifetime

    // 1. Reserve a dedup token and persist it before the side effect.
    if (!state.TryGetValue("charge_token", out BinaryData? tokenData))
    {
        tokenData = BinaryData.FromObjectAsJson(Guid.NewGuid().ToString());
        await store.SetItemAsync(
            "charge",
            new Dictionary<string, BinaryData> { ["charge_token"] = tokenData },
            cancellationToken: ct);
    }
    string chargeToken = tokenData!.ToObjectFromJson<string>()!;

    // 2. Do the side effect with the token as an idempotency key.
    Receipt receipt = await Billing.ChargeAsync(
        ctx.Input, idempotencyKey: chargeToken, ct);

    // 3. Record the result so a later recovery short-circuits at the top.
    //    Even if the process dies before this write lands, the reserved token above
    //    keeps the charge at-most-once (the gateway dedupes on the idempotency key).
    await store.SetItemAsync(
        "charge",
        new Dictionary<string, BinaryData>
        {
            ["charge_token"] = tokenData,
            ["receipt"] = BinaryData.FromObjectAsJson(receipt),
        },
        cancellationToken: ct);
    return receipt;
});
```

### 6.3 Steering — interruptible long turn

```csharp
services.AddResilientMultiTurnTask<string, string>("writer", async (ctx, ct) =>
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
services.AddResilientTask<Job, Result>("batch", async (ctx, ct) =>
{
    foreach (var item in ctx.Input.Items)
    {
        if (ctx.Shutdown.IsCancellationRequested)
        {
            await ctx.ExitForRecoveryAsync();    // signal deferral, then return to resume later
            return Result.Done;                  // returned value is ignored for a deferred turn
        }
        await ProcessAsync(item, ct);
    }
    return Result.Done;
});
```

### 6.5 Late-join an in-flight run

```csharp
// Another caller already started "echo" with this taskId; attach to it.
TaskRun<string>? existing = await echo.GetActiveRunAsync(taskId);
if (existing is not null)
    string result = await existing.Completion;
```

### 6.6 Optimistic concurrency on the input queue

Use `IfLastInputId` to make a turn conditional on the chain not having advanced since
you last observed it. If another input landed first, the call fails with a
`ResilientTaskException` (`ErrorCode.PreconditionFailed`), whose `ActualLastInputId` tells you the
current head so you can retry against it.

Pair it with an explicit `InputId` for the turn you are appending: `IfLastInputId` is
the *precondition* (the head you expect) and `InputId` is the *new* input's id (the
head you are advancing to). Setting both makes the compare-and-swap unambiguous and
lets a safe retry reuse the same `InputId` idempotently.

```csharp
await chat.StartAsync("next",
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
  be ended explicitly with the multi-turn `TaskDefinition`'s `DeleteAsync`.
- Make handlers idempotent with respect to recovery: anything observable outside the
  process (a charge, an email) should be guarded by a durable checkpoint in
  `FoundryStateStore` or another external store.
- Always thread the cancellation token through your async work so cancellation,
  timeout, and shutdown take effect promptly.

## 8. What this is NOT

- **Not a deterministic-replay framework.** The handler is re-invoked from the top on
  recovery; the framework does not record and replay every effect. Determinism across
  re-invocations is the handler's responsibility — use durable StateStore checkpoints
  for at-most-once patterns (§6.2).
- **Not a workflow engine.** No fan-out / fan-in, no child-workflow orchestration, no
  first-class signals or timers. A handler is plain code; there are no step/activity
  primitives to compose. If you need those, use a workflow engine and wrap resilient
  tasks inside it.
- **Not a bulk data store.** Persist conversation history, model outputs, and large
  checkpoints through `FoundryStateStore` or your own storage.
- **Not a queue.** A `TaskId` identifies one logical unit of work. If you want competing
  consumers off a shared queue, use a different primitive.
- **Not a background-job scheduler or cron.** There is no "run at 3am" surface — you
  invoke a task when you have work for it.
- It does **not** expose storage, leasing, or transport. Those are framework internals
  deliberately kept off the public surface.

## Quick FAQ

**Do I need to know where state is stored?** No. Registration and invocation are the
whole surface; persistence is automatic and environment-selected.

**How do I make a side effect happen once?** Guard it with a durable StateStore
checkpoint and check the checkpoint on entry (§6.2). `EntryMode`/`RetryAttempt` are
signals, not guarantees — the checkpoint is the guarantee.

**When should I use a plain `Task` instead?** When the work is short, has no external
side effects, and does not need to survive a restart.

**How do I do "fire and forget"?** Call `StartAsync(...)` instead of `RunAsync(...)`.
It returns a `TaskRun<TOutput>` handle as soon as the run is registered; you can drop
the handle and the task keeps running resiliently. A later caller can attach via
`GetActiveRunAsync(taskId)` on the task's handle if it cares about the outcome.

**Can two callers run the same `taskId` concurrently?** No — `taskId` is the identity.
The second caller either attaches to the first's in-flight run (one-shot convergence),
gets queued (multi-turn, when steering is enabled), or sees a `ResilientTaskException` (`Conflict`).

**Does the framework retry by default?** No. Configure retry at registration via
`TaskRegistrationOptions.Retry` (e.g. `services.AddResilientTask<TIn, TOut>(name, handler,
o => o.Retry = new TaskRetryPolicy());`) to opt in. Without a policy a handler
runs once and surfaces the exception.

**Where should I store conversation history and recovery checkpoints?** Use
`FoundryStateStore` or another application-owned durable store. Keep the framework task
record limited to orchestration state.

**What if my handler ignores `ctx.Cancellation`?** Cooperative cancellation is a
request; nothing forces a handler to stop. If your handler must be interruptible,
observe `ctx.Cancellation` in your loop (or pass it to the calls you `await`).
`DeleteAsync(taskId)` on the multi-turn handle removes the durable chain record and signals
cancellation on the in-flight turn — but it does not preempt or abort running user code.
A non-cooperating handler keeps running until it returns or throws on its own.

**How do I inspect a task's persisted state from outside the handler?** You don't —
the public surface is intentionally write-shaped (register + invoke), and the task
provider and wire schema are internal. Read application state from your own
`FoundryStateStore` items. Handler lifecycle signals remain available through
`ctx.RetryAttempt`, `ctx.RecoveryCount`, and `ctx.EntryMode`.
