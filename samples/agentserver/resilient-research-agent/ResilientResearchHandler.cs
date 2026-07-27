// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Resilient research agent — bridges a durable, session-scoped task to a per-turn SSE
/// event stream, implementing the full invocations protocol (matching the Python
/// azure-ai-agentserver-invocations resilient-agent-demo):
///
/// <list type="bullet">
/// <item><b>POST /invocations</b> (<see cref="HandleAsync"/>) — fire-and-forget dispatch of a
/// research turn (or a steering input on an in-flight run). Reserves the per-turn stream keyed
/// by the request's invocation id, starts the durable task with <c>TaskId = sessionId</c> and
/// <c>InputId = invocationId</c>, and returns <c>202 Accepted</c>. Special: message "crash"
/// (when <c>DEMO_MODE=1</c>) forces a process exit so the platform nanny restarts us.</item>
/// <item><b>GET /invocations/{id}?last_event_id=N</b> (<see cref="GetAsync"/>) — SSE stream of
/// the active run. Re-attaches to the EXISTING stream after the cursor; never starts a run.</item>
/// <item><b>POST /invocations/{id}/cancel</b> (<see cref="CancelAsync"/>) — operator cancel of the
/// active run for this session.</item>
/// </list>
/// </summary>
public class ResilientResearchHandler : InvocationHandler
{
    // POST /invocations — fire-and-forget dispatch, steering, or (DEMO_MODE) crash trigger.
    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var body = await request.ReadFromJsonAsync<InvokeBody>(cancellationToken)
            ?? new InvokeBody();
        string topic = (body.Message ?? string.Empty).Trim();

        if (string.IsNullOrEmpty(topic))
        {
            response.StatusCode = StatusCodes.Status400BadRequest;
            await response.WriteAsJsonAsync(new { error = "Provide a 'message' field" }, cancellationToken);
            return;
        }

        // Demo-only crash trigger. Return 202 and force a process exit shortly after — the
        // platform nanny worker brings the container back on its own (no new ingress required)
        // and the resilient task auto-resumes from its last checkpoint. We do NOT start a task
        // here so an already-running task is the one that recovers on restart.
        if (DemoConfig.DemoMode &&
            (topic.Equals("crash", StringComparison.OrdinalIgnoreCase)
             || topic.Equals("kill", StringComparison.OrdinalIgnoreCase)
             || topic == "\U0001F4A5"))
        {
            Console.Error.WriteLine($"[CRITICAL] CRASH triggered via /invocations message='{topic}' — exiting in 300ms");
            _ = Task.Run(async () =>
            {
                await Task.Delay(300).ConfigureAwait(false);
                Environment.Exit(137);
            });
            response.StatusCode = StatusCodes.Status202Accepted;
            await response.WriteAsJsonAsync(new
            {
                status = "crashing",
                message = "Process will exit. The platform's nanny worker brings the container "
                    + "back within ~1 min on its own (no new ingress required) and the resilient "
                    + "task auto-resumes from its last checkpoint.",
            }, cancellationToken);
            return;
        }

        var registry = request.HttpContext.RequestServices.GetRequiredService<IEventStreamRegistry>();
        var invoker = request.HttpContext.RequestServices.GetRequiredService<ITaskInvoker>();

        // ONE resilient task per session so steering finds the active run. invocationId labels
        // THIS turn (== InputId); sessionId labels the long-lived task (== TaskId).
        string taskId = context.SessionId;
        string invId = context.InvocationId;

        // Reserve the per-turn stream BEFORE starting the task so a GET that races the POST sees
        // the stream (rather than a 404). File-backed replay means we needn't await a subscriber.
        await registry.GetOrCreateAsync(invId, cancellationToken);

        // Start a new turn or steer the running one. With the same TaskId, the engine transparently
        // enqueues this input as steering while a turn is in flight; the running turn observes the
        // cooperative cancel, winds down at its next checkpoint, and the framework re-enters with
        // the queued input. invocationId is recorded as the chain's last-accepted InputId.
        _ = await invoker.StartAsync<ResearchRequest, ResearchResult>(
            "research",
            new ResearchRequest(topic, invId),
            new RunOptions { TaskId = taskId, InputId = invId },
            cancellationToken);

        response.StatusCode = StatusCodes.Status202Accepted;
        await response.WriteAsJsonAsync(new
        {
            status = "started",
            invocation_id = invId,
            session_id = context.SessionId,
        }, cancellationToken);
    }

    // GET /invocations/{id} — SSE stream of the active run (resume-safe, read-only).
    public override async Task GetAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var registry = request.HttpContext.RequestServices.GetRequiredService<IEventStreamRegistry>();

        IEventStream stream;
        try
        {
            stream = await registry.GetAsync(invocationId, cancellationToken);
        }
        catch (EventStreamNotFoundException)
        {
            response.StatusCode = StatusCodes.Status404NotFound;
            await response.WriteAsJsonAsync(new
            {
                status = "not_found",
                message = "No stream for this invocation id.",
            }, cancellationToken);
            return;
        }

        int? after = ResumeCursor(request);
        response.ContentType = "text/event-stream";
        response.Headers.CacheControl = "no-cache";

        try
        {
            await foreach (object evt in stream.Subscribe(after, cancellationToken))
            {
                var researchEvent = (ResearchEvent)evt;
                await response.WriteAsync($"id: {researchEvent.SequenceNumber}\n", cancellationToken);
                await response.WriteAsync(
                    $"data: {JsonSerializer.Serialize(researchEvent)}\n\n", cancellationToken);
                await response.Body.FlushAsync(cancellationToken);
            }
        }
        catch (EventStreamNotFoundException)
        {
            // Stream destroyed while attached (TTL eviction or explicit delete). Tell the client.
            await response.WriteAsync("event: gone\n", cancellationToken);
            await response.WriteAsync(
                $"data: {{\"type\":\"gone\",\"invocation_id\":\"{invocationId}\"}}\n\n", cancellationToken);
            await response.Body.FlushAsync(cancellationToken);
        }
    }

    // POST /invocations/{id}/cancel — cancel the active run for this session.
    public override async Task CancelAsync(
        string invocationId,
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var invoker = request.HttpContext.RequestServices.GetRequiredService<ITaskInvoker>();

        // task_id == session_id, input_id == invocationId (matches POST). The multi-turn
        // GetActiveRunAsync requires the input id so the framework verifies the caller is
        // targeting the in-flight turn and not a stale one.
        string taskId = context.SessionId;
        TaskRun<ResearchResult>? run = await invoker
            .GetActiveRunAsync<ResearchResult>("research", taskId, invocationId, cancellationToken);

        if (run is null)
        {
            response.StatusCode = StatusCodes.Status404NotFound;
            await response.WriteAsJsonAsync(new
            {
                status = "not_found",
                message = "No active task to cancel.",
            }, cancellationToken);
            return;
        }

        await run.CancelAsync(cancellationToken);
        response.StatusCode = StatusCodes.Status202Accepted;
        await response.WriteAsJsonAsync(new
        {
            status = "cancelled",
            message = "Task cancellation requested.",
        }, cancellationToken);
    }

    private static int? ResumeCursor(HttpRequest request)
    {
        if (request.Query.TryGetValue("last_event_id", out var q) && int.TryParse(q, out var qn))
            return qn;
        if (request.Headers.TryGetValue("Last-Event-ID", out var h) && int.TryParse(h, out var hn))
            return hn;
        return null;
    }

    // ── Server wall-clock helpers ───────────────────────────────────────────
    private static readonly long s_appStartedTicks = Environment.TickCount64;

    private static string NowIso() =>
        DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

    private static double ServerUptimeSec() =>
        Math.Round((Environment.TickCount64 - s_appStartedTicks) / 1000.0, 1);

    /// <summary>
    /// The durable task that PRODUCES research events with crash-resilient, per-subcall
    /// checkpointing and cooperative steering. Emits the same flat event schema as the Python
    /// deep_research task (run_start / recovered / phase_start / subcall_start / token /
    /// subcall_end / phase_end / cooldown / winding_down / run_complete / run_failed).
    ///
    /// Metadata watermarks: completed_phases, in_progress_phase, completed_subcalls. On recovery,
    /// resumes at the next un-finished subcall. On steering (a newer input queued behind this
    /// turn — observed via ctx.PendingInputCount &gt; 0 or a bare cancel on ct), winds down and
    /// returns a steered result so the framework re-enters with the new topic. Heavy in-flight
    /// phase text lives in the file-backed <paramref name="checkpointStore"/>.
    /// </summary>
    public static async Task<ResearchResult> RunResearchAsync(
        IEventStreamRegistry registry,
        UpstreamModel model,
        TaskContext<ResearchRequest> ctx,
        CheckpointStore checkpointStore,
        CancellationToken ct)
    {
        string topic = ctx.Input.Topic;
        string invId = ctx.Input.InvocationId; // one stream per turn; TaskId spans the session.
        IEventStream stream = await registry.GetOrCreateAsync(invId, ct);

        // On crash recovery, last_cursor rehydrates the sequence counter (no gap, no dupes).
        int? lastCursor = await stream.GetLastCursorAsync(ct);
        int seq = lastCursor ?? 0;

        async Task Emit(ResearchEvent evt, bool close = false)
        {
            seq++;
            evt.SequenceNumber = seq;
            await stream.EmitAsync(evt, close: close, cancellationToken: close ? CancellationToken.None : ct);
        }

        string entryMode = ctx.EntryMode switch
        {
            EntryMode.Recovered => "recovered",
            EntryMode.Resumed => "resumed",
            _ => "fresh",
        };

        await Emit(new ResearchEvent
        {
            Type = "run_start",
            Topic = topic,
            EntryMode = entryMode,
            TotalPhases = DemoConfig.NumPhases,
            CallsPerPhase = DemoConfig.CallsPerPhase,
            ServerTimeUtc = NowIso(),
            ServerUptimeSec = ServerUptimeSec(),
        });

        // Read watermarks (persisted across crashes).
        int completedPhases = MetaInt(ctx, "completed_phases", 0);
        int inProgressPhase = MetaInt(ctx, "in_progress_phase", -1);
        int completedSubcalls = MetaInt(ctx, "completed_subcalls", 0);

        if (ctx.EntryMode == EntryMode.Recovered && completedPhases > 0)
        {
            await Emit(new ResearchEvent
            {
                Type = "recovered",
                CompletedPhases = completedPhases,
                TotalPhases = DemoConfig.NumPhases,
                ServerTimeUtc = NowIso(),
                ServerUptimeSec = ServerUptimeSec(),
            });
        }

        try
        {
            for (int phaseIdx = completedPhases; phaseIdx < DemoConfig.NumPhases; phaseIdx++)
            {
                if (IsSteerOrCancel(ctx, ct))
                    return await WindDownAsync(Emit, stream, ctx, invId, checkpointStore, phaseIdx);

                long phaseStartTicks = Environment.TickCount64;
                string title = DemoConfig.PhaseTitle(phaseIdx);

                await Emit(new ResearchEvent
                {
                    Type = "phase_start",
                    Phase = phaseIdx + 1,
                    Total = DemoConfig.NumPhases,
                    Title = title,
                    ServerTimeUtc = NowIso(),
                    ServerUptimeSec = ServerUptimeSec(),
                });

                await RunPhaseAsync(
                    Emit, model, ctx, invId, checkpointStore,
                    phaseIdx, inProgressPhase, completedSubcalls, topic, title, ct);

                // --- PHASE-COMPLETE CHECKPOINT ---
                ctx.Metadata["completed_phases"] = BinaryData.FromObjectAsJson(phaseIdx + 1);
                ctx.Metadata["in_progress_phase"] = BinaryData.FromObjectAsJson(-1);
                ctx.Metadata["completed_subcalls"] = BinaryData.FromObjectAsJson(0);
                checkpointStore.Delete(invId);
                await ctx.Metadata.FlushAsync(ct);

                double phaseDuration = Math.Round((Environment.TickCount64 - phaseStartTicks) / 1000.0, 1);
                await Emit(new ResearchEvent
                {
                    Type = "phase_end",
                    Phase = phaseIdx + 1,
                    Total = DemoConfig.NumPhases,
                    Title = title,
                    DurationSec = phaseDuration,
                    ServerTimeUtc = NowIso(),
                    ServerUptimeSec = ServerUptimeSec(),
                });

                if (IsSteerOrCancel(ctx, ct))
                    return await WindDownAsync(Emit, stream, ctx, invId, checkpointStore, phaseIdx + 1);

                if (phaseIdx + 1 < DemoConfig.NumPhases && DemoConfig.InterPhaseCooldownSec > 0)
                {
                    await CooldownAsync(
                        Emit, ctx, DemoConfig.InterPhaseCooldownSec,
                        stage: "inter_phase", phase: phaseIdx + 2, total: DemoConfig.NumPhases, ct: ct);
                    if (IsSteerOrCancel(ctx, ct))
                        return await WindDownAsync(Emit, stream, ctx, invId, checkpointStore, phaseIdx + 1);
                }
            }

            await Emit(new ResearchEvent
            {
                Type = "run_complete",
                PhasesCompleted = DemoConfig.NumPhases,
                ServerTimeUtc = NowIso(),
                ServerUptimeSec = ServerUptimeSec(),
            });
            await FinishTurnAsync(stream, ctx, invId, checkpointStore);
            return new ResearchResult("done", DemoConfig.NumPhases);
        }
        catch (OperationCanceledException) when (IsSteerOrCancel(ctx, ct))
        {
            // A steering / operator cancel / timeout nudge cancelled ct mid-await. Wind down
            // cooperatively (do NOT treat as a logical failure). Read the CURRENT watermark from
            // metadata (not the stale entry-time local) so winding_down reports the phases actually
            // completed this lifetime — matching Python, which winds down at checkpoints with the
            // accurate phase index.
            int currentCompleted = MetaInt(ctx, "completed_phases", 0);
            return await WindDownAsync(Emit, stream, ctx, invId, checkpointStore, currentCompleted);
        }
        catch (Exception ex)
        {
            // Logical-failure path: emit a terminal frame so subscribers fast-fail instead of
            // hanging on the open stream, then re-raise so the framework records the task failed.
            try
            {
                await Emit(new ResearchEvent
                {
                    Type = "run_failed",
                    Error = new ErrorInfo
                    {
                        Type = ex.GetType().Name,
                        Message = ex.Message.Length > 2000 ? ex.Message[..2000] : ex.Message,
                    },
                    ServerTimeUtc = NowIso(),
                    ServerUptimeSec = ServerUptimeSec(),
                }, close: true);
                await FinishTurnAsync(stream, ctx, invId, checkpointStore);
            }
            catch
            {
                // If terminal-frame emission itself fails, still surface the original failure.
            }
            throw;
        }
    }

    private static async Task RunPhaseAsync(
        Func<ResearchEvent, bool, Task> emit,
        UpstreamModel model,
        TaskContext<ResearchRequest> ctx,
        string invId,
        CheckpointStore checkpointStore,
        int phaseIdx,
        int inProgressPhase,
        int completedSubcalls,
        string topic,
        string phaseTitle,
        CancellationToken ct)
    {
        int startSub;
        string currentText;
        if (inProgressPhase == phaseIdx)
        {
            startSub = completedSubcalls;
            currentText = checkpointStore.Load(invId) ?? string.Empty;
        }
        else
        {
            startSub = 0;
            currentText = string.Empty;
            ctx.Metadata["in_progress_phase"] = BinaryData.FromObjectAsJson(phaseIdx);
            ctx.Metadata["completed_subcalls"] = BinaryData.FromObjectAsJson(0);
            checkpointStore.Delete(invId);
            await ctx.Metadata.FlushAsync(ct);
        }

        for (int subIdx = startSub; subIdx < DemoConfig.CallsPerPhase; subIdx++)
        {
            var (roleName, rolePrompt) = DemoConfig.SubCallRoles[subIdx];
            string instructions =
                $"You are a research analyst working on the topic: '{topic}'.\n"
                + $"Current phase: '{phaseTitle}'.\n"
                + $"Your role in this sub-step: {roleName}.\n\n" + rolePrompt;
            string userInput = string.IsNullOrEmpty(currentText)
                ? $"Topic: {topic}\nPhase: {phaseTitle}"
                : $"Topic: {topic}\nPhase: {phaseTitle}\n\nPrevious sub-step output:\n{currentText}";

            await emit(new ResearchEvent
            {
                Type = "subcall_start",
                Role = roleName,
                Index = subIdx + 1,
                Of = DemoConfig.CallsPerPhase,
                ServerTimeUtc = NowIso(),
            }, false);

            var sb = new StringBuilder();
            await foreach (var delta in model.StreamDeltasAsync(instructions, userInput, ct).ConfigureAwait(false))
            {
                sb.Append(delta);
                await emit(new ResearchEvent { Type = "token", Content = delta }, false);
            }

            await emit(new ResearchEvent
            {
                Type = "subcall_end",
                Role = roleName,
                Index = subIdx + 1,
                Of = DemoConfig.CallsPerPhase,
                ServerTimeUtc = NowIso(),
            }, false);

            currentText = sb.ToString();

            // Heavy content -> file-backed store; light watermark -> ctx.Metadata.
            checkpointStore.Save(invId, currentText);
            ctx.Metadata["completed_subcalls"] = BinaryData.FromObjectAsJson(subIdx + 1);
            await ctx.Metadata.FlushAsync(ct);

            if (subIdx + 1 < DemoConfig.CallsPerPhase && DemoConfig.IntraPhaseCooldownSec > 0)
            {
                await CooldownAsync(
                    emit, ctx, DemoConfig.IntraPhaseCooldownSec,
                    stage: "intra_phase", phase: phaseIdx + 1, total: DemoConfig.NumPhases,
                    subcall: subIdx + 2, of: DemoConfig.CallsPerPhase, ct: ct);
                if (IsSteerOrCancel(ctx, ct))
                    break;
            }
        }
    }

    private static async Task CooldownAsync(
        Func<ResearchEvent, bool, Task> emit,
        TaskContext<ResearchRequest> ctx,
        double durationSec,
        string stage,
        int phase,
        int total,
        CancellationToken ct,
        int? subcall = null,
        int? of = null)
    {
        await emit(new ResearchEvent
        {
            Type = "cooldown",
            DurationSec = durationSec,
            Stage = stage,
            Phase = phase,
            Total = total,
            Subcall = subcall,
            Of = of,
            ServerTimeUtc = NowIso(),
            ServerUptimeSec = ServerUptimeSec(),
        }, false);

        // Interruptible wait: a steering / cancel nudge cancels ct and ends the cooldown early.
        try
        {
            await Task.Delay(TimeSpan.FromSeconds(durationSec), ct).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            // Wound down by steering/cancel — the caller's IsSteerOrCancel check handles it.
        }
    }

    private static async Task<ResearchResult> WindDownAsync(
        Func<ResearchEvent, bool, Task> emit,
        IEventStream stream,
        TaskContext<ResearchRequest> ctx,
        string invId,
        CheckpointStore checkpointStore,
        int completedPhases)
    {
        string cause = ctx.TimeoutExceeded ? "timeout"
            : ctx.CancelRequested ? "operator_cancel"
            : "steering";

        // Emit the terminal wind-down frame with close:true. This is the LAST event on this
        // invocation's stream (a steered re-entry runs as a NEW invocation with its own stream),
        // so emit+close is one atomic durable unit. Critically, close:true routes through
        // CancellationToken.None inside `emit` — on the steering / cancel path `ct` is already
        // cancelled, and IEventStream.EmitAsync throws OperationCanceledException on a cancelled
        // token, which would otherwise skip the watermark wipe below and leave a steered re-entry
        // resuming mid-plan. We still guard the emit so the wipe runs even if it fails.
        try
        {
            await emit(new ResearchEvent
            {
                Type = "winding_down",
                Cause = cause,
                CompletedPhases = completedPhases,
                TotalPhases = DemoConfig.NumPhases,
                PendingSteeringInputs = ctx.PendingInputCount,
                ServerTimeUtc = NowIso(),
                ServerUptimeSec = ServerUptimeSec(),
            }, true);
        }
        catch
        {
            // Best-effort terminal frame — the watermark wipe MUST still happen.
        }
        await FinishTurnAsync(stream, ctx, invId, checkpointStore);
        return new ResearchResult("steered", completedPhases);
    }

    // Tears down per-turn resources at every non-crash exit (steered re-entry, operator cancel,
    // timeout, normal completion). NOT called on crash paths — the wire stream must stay open for
    // the recovery re-entry and the watermarks must remain so it can resume mid-turn.
    private static async Task FinishTurnAsync(
        IEventStream stream, TaskContext<ResearchRequest> ctx, string invId, CheckpointStore store)
    {
        await stream.CloseAsync();
        ctx.Metadata.Remove("completed_phases");
        ctx.Metadata.Remove("in_progress_phase");
        ctx.Metadata.Remove("completed_subcalls");
        // Persist the wipe so a steered re-entry (new topic, same task) starts fresh at phase 0
        // rather than reading a stale watermark and skipping phases. FlushAsync uses a fresh
        // token because ct may already be cancelled on the steering / cancel wind-down path.
        await ctx.Metadata.FlushAsync(CancellationToken.None);
        store.Delete(invId);
    }

    private static bool IsSteerOrCancel(TaskContext<ResearchRequest> ctx, CancellationToken ct) =>
        ctx.PendingInputCount > 0
        || ctx.CancelRequested
        || ctx.TimeoutExceeded
        || ct.IsCancellationRequested
        || ctx.Shutdown.IsCancellationRequested;

    private static int MetaInt(TaskContext<ResearchRequest> ctx, string key, int fallback)
    {
        if (ctx.Metadata.TryGetValue(key, out var raw) && raw is not null)
            return raw.ToObjectFromJson<int>();
        return fallback;
    }
}

/// <summary>POST /invocations body: <c>{ "message": "&lt;topic&gt;" }</c>.</summary>
public sealed class InvokeBody
{
    [System.Text.Json.Serialization.JsonPropertyName("message")]
    public string? Message { get; set; }
}
