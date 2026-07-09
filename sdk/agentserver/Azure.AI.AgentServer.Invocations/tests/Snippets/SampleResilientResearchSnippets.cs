// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenAI.Responses;

#pragma warning disable OPENAI001 // The OpenAI Responses API is experimental.

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample — Resilient Research Agent.
    /// Demonstrates a multi-phase research pipeline with per-subcall checkpointing
    /// via metadata watermarks, a file-backed checkpoint store for heavy artifacts,
    /// streaming emit with cursor-based recovery resume, cooperative steering
    /// wind-down, inter/intra-phase cooldowns, crash-recovery re-entry, and a
    /// terminal failure frame on exception.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class SampleResilientResearchSnippets
    {
        [Test]
        public void RegisterServices()
        {
            #region Snippet:ResilientResearch_RegisterServices

            var services = new ServiceCollection();

            // Inject a REAL OpenAI Responses client as the upstream model. In production this
            // points at your Foundry/OpenAI endpoint; tests inject a mock transport so the
            // same producer code runs deterministically offline. See CreateModelClient below.
            services.AddSingleton(CreateModelClient());

            // Event streams with FILE-BACKED replay so a subscriber reconnecting AFTER A CRASH +
            // restart resumes from its last cursor with no gap — events persist as JSON to
            // ~/.agentserver/streams/<invocationId>.jsonl (the same state root tasks use) and
            // rehydrate on the next GetOrCreate. The typed overload defaults the storage directory,
            // a 10-minute TTL, and JSON serialization, so only the cursor is required. (In-memory
            // replay would lose the pre-crash buffer, defeating this sample's crash-resilience.)
            services.AddEventStreams(o => o.UseFileBackedReplay<ResearchEvent>(
                cursor: e => e.Cursor));

            // Heavy in-flight artifacts (partial phase output) live in a file-backed store;
            // metadata holds only small integer watermarks. Use a DURABLE state root under the
            // user profile — NOT Path.GetTempPath(), whose contents the OS may clear between
            // runs, which would defeat crash recovery. (Mirrors the Python sample's
            // ~/.agentserver/_checkpoints location.)
            string stateRoot = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".agentserver", "resilient-research-checkpoints");
            var checkpointStore = new CheckpointStore(stateRoot);

            // AddResilientTasks records registrations into a live registry that the engine reads
            // when a task is invoked. The provider-aware overload hands the handler the application
            // IServiceProvider at invocation time, so dependencies are resolved from DI without a
            // premature BuildServiceProvider() call or a forward-declared, captured provider.
            IResilientTaskBuilder tasks = services.AddResilientTasks();

            // The resilient "research" task is session-scoped and steerable: one durable
            // chain per session (TaskId = research-{sessionId}), and a POST while a turn is
            // in flight is enqueued as steering. Each turn streams a real model per sub-call
            // into the event stream keyed by that turn's invocation id (carried on the input).
            tasks.AddMultiTurnTask<ResearchRequest, ResearchResult>(
                "research",
                (provider, ctx, ct) => RunResearchAsync(
                    provider.GetRequiredService<IEventStreamRegistry>(),
                    provider.GetRequiredService<ResponsesClient>(),
                    ModelDeployment,
                    ctx,
                    checkpointStore,
                    ct: ct),
                steerable: true);

            #endregion
        }

        /// <summary>The model deployment name (e.g. an Azure AI Foundry deployment).</summary>
        public const string ModelDeployment = "gpt-5.4-nano";

        // Constructs the upstream OpenAI Responses client. In production, point it at your
        // Foundry/OpenAI endpoint and supply a credential; tests substitute a mock transport.
        private static ResponsesClient CreateModelClient() =>
            new ResponsesClient(
                new System.ClientModel.ApiKeyCredential(
                    Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "unused"),
                new OpenAI.OpenAIClientOptions());

        [Test]
        public void Implement_Handler()
        {
            var handler = new ResilientResearchHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:ResilientResearch_ProducerTask

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
        /// A file-backed checkpoint store for heavy in-flight artifacts (potentially
        /// several KB of LLM output). Metadata stores only small integer watermarks;
        /// the actual content lives here keyed by invocation id.
        /// </summary>
        public class CheckpointStore
        {
            private readonly string _directory;

            public CheckpointStore(string directory)
            {
                _directory = directory;
                Directory.CreateDirectory(directory);
            }

            public void Save(string key, string content)
            {
                string path = Path.Combine(_directory, key + ".json");
                string tmp = path + ".tmp";
                File.WriteAllText(tmp, content);
                File.Move(tmp, path, overwrite: true);
            }

            public string? Load(string key)
            {
                string path = Path.Combine(_directory, key + ".json");
                return File.Exists(path) ? File.ReadAllText(path) : null;
            }

            public void Delete(string key)
            {
                string path = Path.Combine(_directory, key + ".json");
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        /// <summary>
        /// The durable task that PRODUCES research events with crash-resilient,
        /// per-subcall checkpointing and cooperative steering.
        ///
        /// Metadata watermarks: <c>completed_phases</c>, <c>in_progress_phase</c>,
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
            IEventStreamRegistry registry,
            ResponsesClient model,
            string modelName,
            TaskContext<ResearchRequest> ctx,
            CheckpointStore checkpointStore,
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
            IEventStream stream = await registry.GetOrCreateAsync(invId, ct);

            // On crash recovery, last_cursor rehydrates the sequence counter.
            int? lastCursor = await stream.GetLastCursorAsync(ct);
            int seq = lastCursor ?? 0;

            async Task<ResearchEvent> Emit(string type, string content, string? phase = null)
            {
                seq++;
                var evt = new ResearchEvent(seq, type, content, phase);
                await stream.EmitAsync(evt, cancellationToken: ct);
                return evt;
            }

            await Emit("run_start", topic);

            // Read watermarks from metadata (persisted across crashes)
            int completedPhases = 0;
            int inProgressPhase = -1;
            int completedSubcalls = 0;
            if (ctx.Metadata.TryGetValue("completed_phases", out var cpRaw) && cpRaw is not null)
                completedPhases = cpRaw.ToObjectFromJson<int>();
            if (ctx.Metadata.TryGetValue("in_progress_phase", out var ipRaw) && ipRaw is not null)
                inProgressPhase = ipRaw.ToObjectFromJson<int>();
            if (ctx.Metadata.TryGetValue("completed_subcalls", out var csRaw) && csRaw is not null)
                completedSubcalls = csRaw.ToObjectFromJson<int>();

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
                        await FinishTurn(stream, ctx, invId, checkpointStore);
                        return new ResearchResult("steered", allFindings.ToArray());
                    }

                    string title = phaseIdx < PhaseTitle.Length
                        ? PhaseTitle[phaseIdx]
                        : $"Continued research (phase {phaseIdx + 1})";

                    await Emit("phase_start", title, $"{phaseIdx + 1}/{numPhases}");
                    ctx.Metadata["in_progress_phase"] = BinaryData.FromObjectAsJson(phaseIdx);
                    await ctx.Metadata.FlushAsync(ct);

                    // Determine resume point within this phase
                    int startSubcall = (phaseIdx == inProgressPhase) ? completedSubcalls : 0;
                    StringBuilder phaseText = new();

                    // Load checkpoint if resuming mid-phase
                    if (startSubcall > 0)
                    {
                        string? saved = checkpointStore.Load(invId);
                        if (saved != null)
                            phaseText.Append(saved);
                    }

                    int effectiveCalls = Math.Min(callsPerPhase, SubCallRoles.Length);
                    for (int sc = startSubcall; sc < effectiveCalls; sc++)
                    {
                        if (ctx.PendingInputCount > 0)
                        {
                            await Emit("wind_down", "Steering: winding down mid-phase");
                            await FinishTurn(stream, ctx, invId, checkpointStore);
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
                            await FinishTurn(stream, ctx, invId, checkpointStore);
                            return new ResearchResult("steered", allFindings.ToArray());
                        }
                        string result = sb.ToString();
                        phaseText.AppendLine(result);

                        await Emit("subcall_complete", role, phaseLabel);

                        // Per-subcall checkpoint
                        ctx.Metadata["completed_subcalls"] = BinaryData.FromObjectAsJson(sc + 1);
                        checkpointStore.Save(invId, phaseText.ToString());
                        await ctx.Metadata.FlushAsync(ct);

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
                                await FinishTurn(stream, ctx, invId, checkpointStore);
                                return new ResearchResult("steered", allFindings.ToArray());
                            }
                        }
                    }

                    allFindings.Add(phaseText.ToString());

                    // Phase complete checkpoint
                    ctx.Metadata["completed_phases"] = BinaryData.FromObjectAsJson(phaseIdx + 1);
                    ctx.Metadata["in_progress_phase"] = BinaryData.FromObjectAsJson(-1);
                    ctx.Metadata["completed_subcalls"] = BinaryData.FromObjectAsJson(0);
                    checkpointStore.Delete(invId);
                    await ctx.Metadata.FlushAsync(ct);

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
                            await FinishTurn(stream, ctx, invId, checkpointStore);
                            return new ResearchResult("steered", allFindings.ToArray());
                        }
                    }
                }

                await Emit("done", $"Completed {numPhases} phases");
                await FinishTurn(stream, ctx, invId, checkpointStore);
                return new ResearchResult("done", allFindings.ToArray());
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                // Terminal failure frame — emit before re-raising so the SSE subscriber
                // sees a clean failure event before the stream drops.
                seq++;
                var failEvt = new ResearchEvent(seq, "run_failed", ex.Message);
                await stream.EmitAsync(failEvt, close: true, cancellationToken: CancellationToken.None);
                throw;
            }
        }

        private static async Task FinishTurn(
            IEventStream stream, TaskContext<ResearchRequest> ctx,
            string invId, CheckpointStore store)
        {
            await stream.CloseAsync();
            ctx.Metadata.Remove("completed_phases");
            ctx.Metadata.Remove("in_progress_phase");
            ctx.Metadata.Remove("completed_subcalls");
            store.Delete(invId);
        }

        #endregion

        #region Snippet:ResilientResearch_Handler

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
                    .GetRequiredService<IEventStreamRegistry>();
                var invoker = request.HttpContext.RequestServices
                    .GetRequiredService<ITaskInvoker>();

                string taskId = TaskIdForSession(context.SessionId);
                string invId = context.InvocationId;
                s_taskIdByInvocation[invId] = taskId;

                // Reserve the per-turn stream BEFORE starting the task so a live subscriber
                // attaches without missing early events.
                IEventStream stream = await registry.GetOrCreateAsync(invId, cancellationToken);

                // Start a new turn or steer the running one. With the same TaskId, the engine
                // transparently enqueues this input as steering while a turn is in flight.
                _ = await invoker.StartAsync<ResearchRequest, ResearchResult>(
                    "research",
                    new ResearchRequest(body.Topic, invId),
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
                    .GetRequiredService<IEventStreamRegistry>();

                IEventStream stream;
                try
                {
                    stream = await registry.GetAsync(invocationId, cancellationToken);
                }
                catch (EventStreamNotFoundException)
                {
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return;
                }

                if (AcceptsEventStream(request))
                {
                    int? after = ResumeCursor(request);
                    await WriteSseAsync(response, stream, after, cancellationToken);
                    return;
                }

                // JSON snapshot of progress for polling clients.
                int? lastCursor = await stream.GetLastCursorAsync(cancellationToken);
                await response.WriteAsJsonAsync(new
                {
                    invocation_id = invocationId,
                    last_event_id = lastCursor,
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

                await run.CancelAsync(cancellationToken);
                response.StatusCode = StatusCodes.Status202Accepted;
                await response.WriteAsJsonAsync(new { invocation_id = invocationId, status = "cancelling" },
                    cancellationToken);
            }

            private static bool AcceptsEventStream(HttpRequest request) =>
                request.Headers.TryGetValue("Accept", out var accept)
                && accept.ToString().Contains("text/event-stream", StringComparison.OrdinalIgnoreCase);

            private static int? ResumeCursor(HttpRequest request)
            {
                if (request.Query.TryGetValue("last_event_id", out var q)
                    && int.TryParse(q, out var qn))
                    return qn;
                if (request.Headers.TryGetValue("Last-Event-ID", out var h)
                    && int.TryParse(h, out var hn))
                    return hn;
                return null;
            }

            private static async Task WriteSseAsync(
                HttpResponse response, IEventStream stream, int? after, CancellationToken ct)
            {
                response.ContentType = "text/event-stream";
                response.Headers.CacheControl = "no-cache";

                try
                {
                    await foreach (object evt in stream.Subscribe(after, ct))
                    {
                        var researchEvent = (ResearchEvent)evt;
                        await response.WriteAsync($"id: {researchEvent.Cursor}\n", ct);
                        await response.WriteAsync(
                            $"data: {JsonSerializer.Serialize(researchEvent)}\n\n", ct);
                        await response.Body.FlushAsync(ct);
                    }

                    // Clean close: emit a terminal `done` frame so the client can distinguish
                    // end-of-stream from a dropped connection (Python parity: resilient_research
                    // app emits an `event: done` terminator after the subscribe loop).
                    await response.WriteAsync("event: done\n", ct);
                    await response.WriteAsync("data: {\"type\":\"done\"}\n\n", ct);
                    await response.Body.FlushAsync(ct);
                }
                catch (EventStreamNotFoundException)
                {
                    // The stream was destroyed under us (superseded / TTL-evicted). Emit a
                    // `superseded` frame so the consumer can tell stream-end from "you got cut
                    // off" (Python parity: EventStreamNotFoundError -> `event: superseded`).
                    await response.WriteAsync("event: superseded\n", ct);
                    await response.WriteAsync("data: {\"type\":\"superseded\"}\n\n", ct);
                    await response.Body.FlushAsync(ct);
                }
            }
        }

        /// <summary>POST body for starting a research turn.</summary>
        public record ResearchStartRequest(string Topic);

        /// <summary>Input for the research task. Carries the per-turn invocation id so the
        /// producer can key its event stream to this turn.</summary>
        public record ResearchRequest(string Topic, string InvocationId);

        /// <summary>Final result of the research task.</summary>
        public record ResearchResult(string Status, string[] Findings);

        /// <summary>A single event emitted during research (carries its own cursor for replay).</summary>
        public record ResearchEvent(int Cursor, string Type, string Content, string? Phase = null);

        #endregion
    }
}
