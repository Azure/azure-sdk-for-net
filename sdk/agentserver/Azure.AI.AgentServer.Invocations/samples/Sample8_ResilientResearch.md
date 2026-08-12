# Sample: Resilient Research Agent — Durable Task ⇄ SSE Bridge

This sample demonstrates a **resilient research agent** that bridges a durable, session-scoped task to a per-turn Server-Sent Events (SSE) stream. Each sub-call makes a **real streaming model request** through the OpenAI `ResponsesClient` and forwards token deltas to the client. The task survives process restarts; clients reconnect and **resume** by issuing a `GET` against the same invocation id.

## Key concepts

- **Real upstream model**: the producer injects a real `ResponsesClient` and calls `CreateResponseStreamingAsync` per sub-call, forwarding each `output_text` delta as a `token` event. Tests redirect the client's transport to an in-process mock so the same code runs deterministically offline.
- **Task per session, stream per turn**: the durable `TaskId` is `research-{sessionId}` (it spans the whole session), while each turn owns its own replayable event stream keyed by the per-turn invocation id.
- **The invocations protocol**:
  - **`POST /invocations`** starts a new turn (or *steers* an in-flight one). With `Accept: text/event-stream` it streams live; otherwise it returns `202 Accepted` with the invocation id to resume later.
  - **`GET /invocations/{invocationId}`** is **resume** — it re-attaches to the *existing* stream after the opaque `last_event_id` / `Last-Event-ID` resume token or returns a JSON status snapshot. It is a read of durable state and **never starts a new run**.
  - **`POST /invocations/{invocationId}/cancel`** cancels the active run for the session.
- **Reserve-before-start**: the handler reserves the stream *before* starting the task, so no early events are lost.
- **Crash recovery & checkpointing**: per-sub-call metadata watermarks and a file-backed checkpoint store let the task resume mid-phase after a restart; the replay backing retains `SseItem<string>` events so a reconnecting subscriber sees everything after its last event id.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
dotnet add package OpenAI
```

## Register services

The model is a real `ResponsesClient`. In production point it at your Foundry/OpenAI endpoint with a credential; tests inject a mock transport so the producer runs unchanged.

```C# Snippet:ResilientResearch_RegisterServices
var services = new ServiceCollection();

// Inject a REAL OpenAI Responses client as the upstream model. In production this
// points at your Foundry/OpenAI endpoint; tests inject a mock transport so the
// same producer code runs deterministically offline. See CreateModelClient below.
services.AddSingleton(CreateModelClient());

// Event streams with FILE-BACKED replay so a subscriber reconnecting AFTER A CRASH +
// restart resumes from its last event id with no gap — events persist to
// ~/.agentserver/streams/<invocationId>.jsonl (the same state root tasks use) and
// rehydrate on the next GetOrCreate. The storage directory and a 10-minute TTL default,
// and the event text is carried in SseItem<string>.Data, so no payload codec is needed.
// (In-memory replay would lose the pre-crash buffer, defeating this sample's resilience.)
services.AddAgentEventStreams(o => o.UseFileBackedReplay());

// AddResilientTasks records registrations into a live registry that the engine reads
// when a task is invoked. The provider-aware overloads were removed (the service-locator
// shape is being retired ahead of GA), so resolve the handler's singleton dependencies
// from the built container once and capture them in the plain delegate — a DI-resolved
// handler wrapped in the delegate. The registry is read lazily at invocation time, so
// registering after the provider is built is fine.
ResilientTaskBuilder tasks = services.AddResilientTasks();

ServiceProvider provider = services.BuildServiceProvider();
AgentEventStreamRegistry streams = provider.GetRequiredService<AgentEventStreamRegistry>();
ResponsesClient model = provider.GetRequiredService<ResponsesClient>();

// The resilient "research" task is session-scoped and steerable: one durable
// chain per session (TaskId = research-{sessionId}), and a POST while a turn is
// in flight is enqueued as steering. Each turn streams a real model per sub-call
// into the event stream keyed by that turn's invocation id (carried on the input).
tasks.AddMultiTurnTask<ResearchRequest, ResearchResult>(
    "research",
    (ctx, ct) => RunResearchAsync(
        streams,
        model,
        ModelDeployment,
        ctx,
        ct: ct),
    steerable: true);
```

## The durable producer task

The producer streams a real model per sub-call into the stream keyed by the per-turn
invocation id, checkpoints progress for crash recovery, cooperatively winds down on steering,
and emits a terminal `done` (or `run_failed`) event. It is the documented, compiled snippet
used by both the CI and live tests:

```C# Snippet:ResilientResearch_ProducerTask
/// <summary>
/// Research phase titles — a multi-phase research plan. Each phase
/// contains up to 4 subcalls (research → critique → refine → synthesize).
/// </summary>
public static readonly string[] PhaseTitle = new[]
{
    "Decomposing topic into focused research questions",
    "Surveying foundational literature and key concepts",
    "Identifying leading researchers and institutions",
    "Analyzing recent breakthroughs and publications",
    "Synthesizing findings into a coherent narrative",
};

/// <summary>
/// Sub-call roles within each research phase.
/// </summary>
public static readonly (string Role, string Instructions)[] SubCallRoles = new[]
{
    ("research", "Conduct an in-depth investigation of the assigned aspect."),
    ("critique", "Critically evaluate the research. Identify weak claims and gaps."),
    ("refine", "Revise incorporating the critique. Strengthen weak claims."),
    ("synthesize", "Distill the refined material into key takeaways."),
};

/// <summary>
/// The durable task that PRODUCES research events with crash-resilient,
/// per-subcall checkpointing and cooperative steering.
///
/// State Store watermarks: <c>completed_phases</c>, <c>in_progress_phase</c>,
/// <c>completed_subcalls</c>. On recovery, resumes at the next un-finished
/// subcall. On steering (a newer input queued behind this turn, observed via
/// <c>ctx.PendingInputCount &gt; 0</c>), winds down and returns a steered-status so the
/// framework re-enters with the new topic.
///
/// Each sub-call makes a REAL streaming model request via <paramref name="model"/>
/// (OpenAI Responses) and forwards token deltas as <c>token</c> events. The stream
/// is keyed by the per-turn invocation id carried on the task input, so each turn
/// owns its own replayable stream while the durable task spans the whole session.
/// </summary>
public static async Task<ResearchResult> RunResearchAsync(
    AgentEventStreamRegistry registry,
    ResponsesClient model,
    string modelName,
    TaskContext<ResearchRequest> ctx,
    int numPhases = 5,
    int callsPerPhase = 4,
    TimeSpan? interPhaseCooldown = null,
    TimeSpan? intraPhaseCooldown = null,
    CancellationToken ct = default)
{
    string topic = ctx.Input.Topic;
    // The stream id is the per-turn invocation id (one stream per turn), while the
    // durable TaskId spans the whole session.
    string invId = ctx.Input.InvocationId;
    string sessionId = ctx.Input.SessionId;
    AgentEventStream stream = await registry.GetOrCreateAsync(invId, ct);
    FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
        $"resilient-research/{sessionId}",
        s_credential,
        description: "Deep-research recovery checkpoints",
        cancellationToken: CancellationToken.None);
    StateStoreItem? checkpointItem = await store.GetItemAsync(
        invId,
        cancellationToken: CancellationToken.None);
    var checkpoint = checkpointItem?.Value is { } value
        ? new Dictionary<string, BinaryData>(value, StringComparer.Ordinal)
        : new Dictionary<string, BinaryData>(StringComparer.Ordinal);

    if (checkpoint.TryGetValue("terminal_status", out BinaryData? terminalData))
    {
        string? terminalStatus = terminalData.ToObjectFromJson<string>();
        await stream.CloseAsync();
        if (terminalStatus == "failed")
        {
            string error = checkpoint.TryGetValue("error", out BinaryData? errorData)
                ? errorData.ToObjectFromJson<string>() ?? "Previous task attempt failed."
                : "Previous task attempt failed.";
            throw new InvalidOperationException(error);
        }

        return new ResearchResult(terminalStatus ?? "completed", Array.Empty<string>());
    }

    // On crash recovery, the last event id rehydrates the sequence counter.
    string? lastEventId = await stream.GetLastEventIdAsync(ct);
    int seq = lastEventId is not null && int.TryParse(lastEventId, NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsed)
        ? parsed
        : 0;

    async Task<ResearchEvent> Emit(string type, string content, string? phase = null)
    {
        seq++;
        var evt = new ResearchEvent(seq, type, content, phase);
        // The caller now owns serialization: the event JSON is the SseItem's Data, the
        // event type is the SSE event name, and the sequence is the opaque resume id.
        await stream.EmitAsync(
            new SseItem<string>(JsonSerializer.Serialize(evt), type)
            {
                EventId = seq.ToString(CultureInfo.InvariantCulture),
            },
            cancellationToken: ct);
        return evt;
    }

    await Emit("run_start", topic);

    int completedPhases = checkpoint.TryGetValue("completed_phases", out BinaryData? cpRaw)
        ? cpRaw.ToObjectFromJson<int>()
        : 0;
    int inProgressPhase = checkpoint.TryGetValue("in_progress_phase", out BinaryData? ipRaw)
        ? ipRaw.ToObjectFromJson<int>()
        : -1;
    int completedSubcalls = checkpoint.TryGetValue("completed_subcalls", out BinaryData? csRaw)
        ? csRaw.ToObjectFromJson<int>()
        : 0;

    // On recovered entry, emit a recovery event
    if (ctx.EntryMode == EntryMode.Recovered && completedPhases > 0)
    {
        await Emit("recovered", $"Resuming from phase {completedPhases + 1}/{numPhases}");
    }

    var allFindings = new List<string>();
    try
    {
        for (int phaseIdx = completedPhases; phaseIdx < numPhases; phaseIdx++)
        {
            // --- Steering checkpoint ---
            // A queued steering input is signalled by PendingInputCount, NOT by
            // CancelRequested (which is only true for an explicit caller cancel).
            if (ctx.PendingInputCount > 0)
            {
                await Emit("wind_down", "Steering: winding down for new topic");
                await FinishTurn(store, stream, invId, "suspended");
                return new ResearchResult("steered", allFindings.ToArray());
            }

            string title = phaseIdx < PhaseTitle.Length
                ? PhaseTitle[phaseIdx]
                : $"Continued research (phase {phaseIdx + 1})";

            await Emit("phase_start", title, $"{phaseIdx + 1}/{numPhases}");
            bool resumingPhase = phaseIdx == inProgressPhase;
            int startSubcall = resumingPhase ? completedSubcalls : 0;
            StringBuilder phaseText = new();

            if (resumingPhase
                && checkpoint.TryGetValue("current_text", out BinaryData? currentText))
            {
                string? saved = currentText.ToObjectFromJson<string>();
                if (saved != null)
                    phaseText.Append(saved);
            }
            else
            {
                checkpoint["in_progress_phase"] = BinaryData.FromObjectAsJson(phaseIdx);
                checkpoint["completed_subcalls"] = BinaryData.FromObjectAsJson(0);
                checkpoint["current_text"] = BinaryData.FromObjectAsJson(string.Empty);
                await SaveCheckpointAsync(store, invId, checkpoint);
            }

            int effectiveCalls = Math.Min(callsPerPhase, SubCallRoles.Length);
            for (int sc = startSubcall; sc < effectiveCalls; sc++)
            {
                if (ctx.PendingInputCount > 0)
                {
                    await Emit("wind_down", "Steering: winding down mid-phase");
                    await FinishTurn(store, stream, invId, "suspended");
                    return new ResearchResult("steered", allFindings.ToArray());
                }

                var (role, instructions) = SubCallRoles[sc];
                string prompt = $"[Phase: {title}] [{role}] Topic: {topic}. {instructions}";
                string phaseLabel = $"{phaseIdx + 1}/{numPhases}";

                // REAL streaming model call. Each token delta is forwarded as a
                // `token` event so a subscribing client sees output as it is produced.
                // A steering nudge cancels `ct`, so the enumeration can throw
                // OperationCanceledException mid-stream — catch the bare nudge here
                // (not a real cancel/timeout/shutdown) and wind down cooperatively.
                var sb = new StringBuilder();
                var options = new CreateResponseOptions(
                    modelName,
                    new[] { ResponseItem.CreateUserMessageItem(prompt) })
                {
                    Instructions = instructions,
                    StreamingEnabled = true,
                };
                try
                {
                    await foreach (StreamingResponseUpdate update in
                        model.CreateResponseStreamingAsync(options, ct))
                    {
                        if (update is StreamingResponseOutputTextDeltaUpdate delta
                            && !string.IsNullOrEmpty(delta.Delta))
                        {
                            sb.Append(delta.Delta);
                            await Emit("token", delta.Delta, phaseLabel);
                        }
                    }
                }
                catch (OperationCanceledException)
                    when (ctx.PendingInputCount > 0 && !ctx.CancelRequested
                          && !ctx.TimeoutExceeded && !ctx.Shutdown.IsCancellationRequested)
                {
                    await Emit("wind_down", "Steering: winding down mid-stream");
                    await FinishTurn(store, stream, invId, "suspended");
                    return new ResearchResult("steered", allFindings.ToArray());
                }
                string result = sb.ToString();
                phaseText.AppendLine(result);

                await Emit("subcall_complete", role, phaseLabel);

                // Per-subcall checkpoint
                checkpoint["completed_subcalls"] = BinaryData.FromObjectAsJson(sc + 1);
                checkpoint["current_text"] = BinaryData.FromObjectAsJson(phaseText.ToString());
                await SaveCheckpointAsync(store, invId, checkpoint);

                // Intra-phase cooldown
                if (sc + 1 < effectiveCalls && intraPhaseCooldown.HasValue
                    && intraPhaseCooldown.Value > TimeSpan.Zero)
                {
                    try
                    { await Task.Delay(intraPhaseCooldown.Value, ct); }
                    catch (OperationCanceledException)
                        when (ctx.PendingInputCount > 0 && !ctx.CancelRequested
                              && !ctx.TimeoutExceeded && !ctx.Shutdown.IsCancellationRequested)
                    {
                        await Emit("wind_down", "Steering during cooldown");
                        await FinishTurn(store, stream, invId, "suspended");
                        return new ResearchResult("steered", allFindings.ToArray());
                    }
                }
            }

            allFindings.Add(phaseText.ToString());

            // Phase complete checkpoint
            checkpoint["completed_phases"] = BinaryData.FromObjectAsJson(phaseIdx + 1);
            checkpoint["in_progress_phase"] = BinaryData.FromObjectAsJson(-1);
            checkpoint["completed_subcalls"] = BinaryData.FromObjectAsJson(0);
            checkpoint["current_text"] = BinaryData.FromObjectAsJson(string.Empty);
            await SaveCheckpointAsync(store, invId, checkpoint);

            await Emit("phase_end", title, $"{phaseIdx + 1}/{numPhases}");

            // Inter-phase cooldown
            if (phaseIdx + 1 < numPhases && interPhaseCooldown.HasValue
                && interPhaseCooldown.Value > TimeSpan.Zero)
            {
                try
                { await Task.Delay(interPhaseCooldown.Value, ct); }
                catch (OperationCanceledException)
                    when (ctx.PendingInputCount > 0 && !ctx.CancelRequested
                          && !ctx.TimeoutExceeded && !ctx.Shutdown.IsCancellationRequested)
                {
                    await Emit("wind_down", "Steering between phases");
                    await FinishTurn(store, stream, invId, "suspended");
                    return new ResearchResult("steered", allFindings.ToArray());
                }
            }
        }

        await Emit("done", $"Completed {numPhases} phases");
        await FinishTurn(store, stream, invId, "completed");
        return new ResearchResult("done", allFindings.ToArray());
    }
    catch (Exception ex) when (ex is not OperationCanceledException)
    {
        // Terminal failure frame — emit before re-raising so the SSE subscriber
        // sees a clean failure event before the stream drops.
        seq++;
        var failEvt = new ResearchEvent(seq, "run_failed", ex.Message);
        await stream.EmitAsync(
            new SseItem<string>(JsonSerializer.Serialize(failEvt), "run_failed")
            {
                EventId = seq.ToString(CultureInfo.InvariantCulture),
            },
            close: true, cancellationToken: CancellationToken.None);
        await FinishTurn(store, stream, invId, "failed", ex.Message);
        throw;
    }
}

private static async Task FinishTurn(
    FoundryStateStore store,
    AgentEventStream stream,
    string invId,
    string terminalStatus,
    string? error = null)
{
    var terminal = new Dictionary<string, BinaryData>
    {
        ["terminal_status"] = BinaryData.FromObjectAsJson(terminalStatus),
    };
    if (error is not null)
    {
        terminal["error"] = BinaryData.FromObjectAsJson(error);
    }

    await store.SetItemAsync(
        invId,
        terminal,
        tags: new Dictionary<string, string> { ["invocation_id"] = invId },
        cancellationToken: CancellationToken.None);
    await stream.CloseAsync();
}

private static Task SaveCheckpointAsync(
    FoundryStateStore store,
    string invocationId,
    IDictionary<string, BinaryData> checkpoint)
    => store.SetItemAsync(
        invocationId,
        checkpoint,
        tags: new Dictionary<string, string> { ["invocation_id"] = invocationId },
        cancellationToken: CancellationToken.None);
```

## Implement the handler

```C# Snippet:ResilientResearch_Handler
/// <summary>
/// A resilient research agent that bridges a durable, session-scoped task to a
/// per-turn SSE event stream, implementing the full invocations protocol:
///
/// <list type="bullet">
/// <item><b>POST /invocations</b> (<see cref="HandleAsync"/>) — start a new turn (or
/// steer an in-flight one). Reserves a stream keyed by the request's invocation id,
/// starts the durable task with <c>TaskId = research-{sessionId}</c>, then either
/// streams events live (when <c>Accept: text/event-stream</c>) or returns
/// <c>202 Accepted</c> with the invocation id for later resume.</item>
/// <item><b>GET /invocations/{id}</b> (<see cref="GetAsync"/>) — RESUME. Re-attaches to
/// the EXISTING stream after <c>Last-Event-ID</c> (SSE) or returns a JSON status
/// snapshot. This is a read of durable state — it never starts a new run.</item>
/// <item><b>POST /invocations/{id}/cancel</b> (<see cref="CancelAsync"/>) — cancel the
/// active run for the session.</item>
/// </list>
/// </summary>
public class ResilientResearchHandler : InvocationHandler
{
    // Map an invocation id back to the durable session-scoped TaskId. In production
    // this lives in the same store the protocol uses to resolve sessions; here it is
    // an in-memory map populated on POST so GET/cancel can find the run.
    private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, string> s_taskIdByInvocation =
        new System.Collections.Concurrent.ConcurrentDictionary<string, string>();

    private static string TaskIdForSession(string sessionId) => $"research-{sessionId}";

    // POST /invocations — start a new turn or steer an in-flight one.
    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var body = await request.ReadFromJsonAsync<ResearchStartRequest>(cancellationToken)
            ?? new ResearchStartRequest("general knowledge");

        var registry = request.HttpContext.RequestServices
            .GetRequiredService<AgentEventStreamRegistry>();
        var invoker = request.HttpContext.RequestServices
            .GetRequiredService<ITaskInvoker>();

        string taskId = TaskIdForSession(context.SessionId);
        string invId = context.InvocationId;
        s_taskIdByInvocation[invId] = taskId;

        // Reserve the per-turn stream BEFORE starting the task so a live subscriber
        // attaches without missing early events.
        AgentEventStream stream = await registry.GetOrCreateAsync(invId, cancellationToken);

        // Start a new turn or steer the running one. With the same TaskId, the engine
        // transparently enqueues this input as steering while a turn is in flight.
        _ = await invoker.StartAsync<ResearchRequest, ResearchResult>(
            "research",
            new ResearchRequest(
                body.Topic,
                invId,
                context.SessionId,
                context.PlatformContext.CallId),
            new RunOptions { TaskId = taskId },
            cancellationToken);

        // Non-streaming clients get 202 + the invocation id to resume later via GET.
        if (!AcceptsEventStream(request))
        {
            response.StatusCode = StatusCodes.Status202Accepted;
            await response.WriteAsJsonAsync(new
            {
                invocation_id = invId,
                session_id = context.SessionId,
                status = "running",
            }, cancellationToken);
            return;
        }

        await WriteSseAsync(response, stream, after: null, cancellationToken);
    }

    // GET /invocations/{id} — RESUME an existing turn (read-only). Never starts a run.
    public override async Task GetAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var registry = request.HttpContext.RequestServices
            .GetRequiredService<AgentEventStreamRegistry>();

        AgentEventStream stream;
        try
        {
            stream = await registry.GetAsync(invocationId, cancellationToken);
        }
        catch (AgentEventStreamNotFoundException)
        {
            response.StatusCode = StatusCodes.Status404NotFound;
            return;
        }

        if (AcceptsEventStream(request))
        {
            string? after = ResumeEventId(request);
            await WriteSseAsync(response, stream, after, cancellationToken);
            return;
        }

        // JSON snapshot of progress for polling clients.
        string? lastEventId = await stream.GetLastEventIdAsync(cancellationToken);
        await response.WriteAsJsonAsync(new
        {
            invocation_id = invocationId,
            last_event_id = lastEventId,
        }, cancellationToken);
    }

    // POST /invocations/{id}/cancel — cancel the active run for this session.
    public override async Task CancelAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var invoker = request.HttpContext.RequestServices
            .GetRequiredService<ITaskInvoker>();

        string taskId = s_taskIdByInvocation.TryGetValue(invocationId, out var mapped)
            ? mapped
            : TaskIdForSession(context.SessionId);

        TaskRun<ResearchResult>? run = await invoker
            .GetActiveRunAsync<ResearchResult>("research", taskId, cancellationToken);

        if (run is null)
        {
            response.StatusCode = StatusCodes.Status404NotFound;
            return;
        }

        await run.RequestCancellationAsync();
        response.StatusCode = StatusCodes.Status202Accepted;
        await response.WriteAsJsonAsync(new { invocation_id = invocationId, status = "cancelling" },
            cancellationToken);
    }

    private static bool AcceptsEventStream(HttpRequest request) =>
        request.Headers.TryGetValue("Accept", out var accept)
        && accept.ToString().Contains("text/event-stream", StringComparison.OrdinalIgnoreCase);

    private static string? ResumeEventId(HttpRequest request)
    {
        if (request.Query.TryGetValue("last_event_id", out var q) && !string.IsNullOrEmpty(q))
            return q.ToString();
        if (request.Headers.TryGetValue("Last-Event-ID", out var h) && !string.IsNullOrEmpty(h))
            return h.ToString();
        return null;
    }

    private static async Task WriteSseAsync(
        HttpResponse response, AgentEventStream stream, string? after, CancellationToken ct)
    {
        response.ContentType = "text/event-stream";
        response.Headers.CacheControl = "no-cache";

        try
        {
            // Delegate SSE framing (id:/event:/data: lines) to the BCL SseFormatter — the
            // stream already yields SseItem<string> with the event text in Data, the event
            // name in EventType, and the opaque resume id in EventId.
            await SseFormatter.WriteAsync(stream.Subscribe(after, ct), response.Body, ct);

            // Clean close: emit a terminal `done` frame so the client can distinguish
            // end-of-stream from a dropped connection.
            await SseFormatter.WriteAsync(
                SingleItem(new SseItem<string>("{\"type\":\"done\"}", "done")), response.Body, ct);
        }
        catch (AgentEventStreamNotFoundException)
        {
            // The stream was destroyed under us (superseded / TTL-evicted). Emit a
            // `superseded` frame so the consumer can tell stream-end from "you got cut
            // off" (AgentEventStreamNotFoundException -> `event: superseded`).
            await SseFormatter.WriteAsync(
                SingleItem(new SseItem<string>("{\"type\":\"superseded\"}", "superseded")), response.Body, ct);
        }
    }

    private static async IAsyncEnumerable<SseItem<string>> SingleItem(SseItem<string> item)
    {
        yield return item;
        await Task.CompletedTask;
    }
}

/// <summary>POST body for starting a research turn.</summary>
public record ResearchStartRequest(string Topic);

/// <summary>Input for the research task. Carries the per-turn invocation id so the
/// producer can key its event stream to this turn.</summary>
public record ResearchRequest(
    string Topic,
    string InvocationId,
    string SessionId,
    [property: JsonPropertyName("call_id")] string? CallId);

/// <summary>Final result of the research task.</summary>
public record ResearchResult(string Status, string[] Findings);

/// <summary>A single event emitted during research (carries its own cursor for replay).</summary>
public record ResearchEvent(int Cursor, string Type, string Content, string? Phase = null);
```

## Test the endpoint

### Start a research task (SSE stream)

`POST /invocations` with `Accept: text/event-stream` starts a turn and streams live. Pin an
invocation id you control (via `x-agent-invocation-id`) so you can **resume** the *same*
stream after a disconnect; if you omit it, the server generates one and echoes it back.

```bash
curl -N http://localhost:8088/invocations \
  -H "Content-Type: application/json" \
  -H "Accept: text/event-stream" \
  -H "x-agent-invocation-id: research-001" \
  -d '{"Topic":"quantum computing"}'
```

To start without streaming (e.g. a background turn), omit the `Accept` header — the handler
returns `202 Accepted` with `{ "invocation_id": "...", "status": "running" }`.

### Resume after disconnect (GET)

Resume is a **`GET`** against the same invocation id with `last_event_id` set to the opaque
event id you last saw. This re-attaches to the existing durable stream and replays
everything after that event id — it never starts a new run.

```bash
curl -N "http://localhost:8088/invocations/research-001?last_event_id=3" \
  -H "Accept: text/event-stream"
```

The client receives only events after event id `"3"`, then continues live. Omit the
`Accept` header to instead get a JSON snapshot (`{ "invocation_id": "...", "last_event_id": "3" }`).

### Cancel a turn

```bash
curl -X POST http://localhost:8088/invocations/research-001/cancel
```

## Implementation pattern

This is the **Task ⇄ Stream bridge** pattern. The durable producer is the
`ResilientResearch_ProducerTask` snippet (`RunResearchAsync`); the HTTP handler is the
`ResilientResearch_Handler` snippet:

1. **`POST` (`HandleAsync`)** reserves a stream keyed by the per-turn invocation id, then
   starts the durable task with `TaskId = research-{sessionId}`. With the same `TaskId`, a
   `POST` while a turn is running is transparently enqueued as *steering*. The replay backing
   covers late subscribers, so attaching after the producer starts loses nothing.
2. The producer makes **real streaming model calls** per sub-call, serializes each
   `ResearchEvent` into `SseItem<string>.Data`, and emits it with the SSE event name and
   opaque `EventId` resume token.
3. **`GET` (`GetAsync`)** is resume: it passes `last_event_id` / `Last-Event-ID` as
   `afterEventId` to `Subscribe`, and the replay backing fills in missed events — or returns
   a JSON snapshot with `GetLastEventIdAsync` when SSE isn't requested. HTTP framing is
   delegated to `SseFormatter`. A late reconnect (run already finished) replays the retained stream.
4. **`POST .../cancel` (`CancelAsync`)** resolves the active run via `GetActiveRunAsync` and
   calls `CancelAsync`, which the producer observes as a cooperative wind-down.

> **Cleanup:** the file-backed replay backing uses its retention settings to reclaim
> retained streams; long-lived hosts can also call `AgentEventStreamRegistry.DeleteAsync` once a
> client has fully drained a stream.

This composes with the [Resilient Tasks guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/docs/tasks-guide.md) and the [Streaming guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/docs/streaming-guide.md).
