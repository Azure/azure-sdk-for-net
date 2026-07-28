// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

/*
 * Resilient Research Agent — Invocations protocol (.NET)
 *
 * This is the .NET port of the Python azure-ai-agentserver-invocations
 * `resilient-agent-demo`. It hosts a long-running, crash-resilient, steerable
 * research task on the Invocations protocol and bridges the durable, session-scoped
 * task to a per-turn Server-Sent Events (SSE) stream.
 *
 * Three platform capabilities of the resilient-task primitive are demonstrated
 * (all validated end-to-end against a hosted Foundry deployment):
 *
 *   1. LONG-RUNNING TASKS run uninterrupted past the platform's sandbox-eviction
 *      window. The framework's task-lease renewal cycle signals activity through the
 *      task-storage API, which refreshes the platform's sandbox idle-reclaim timer.
 *
 *   2. CRASH RECOVERY. When the container dies, the platform's nanny worker brings it
 *      back within ~1 min on its own (no new client ingress). The resilient task
 *      auto-resumes from its last checkpoint: the cold-start recovery scan in
 *      AddResilientTasks re-enters the task body with `ctx.EntryMode == Recovered`, and
 *      the handler resumes at the next un-finished subcall.
 *
 *   3. STEERING. A new POST on a running steerable task queues the input and signals a
 *      cooperative cancel. The agent winds down the current turn at the next checkpoint
 *      and re-enters with the queued input as a fresh turn.
 *
 * What the agent does: N logical research phases on the caller's topic. Each phase runs
 * a small loop (research -> critique -> refine -> synthesize), each subcall a REAL
 * streaming model request whose token deltas are forwarded to the per-turn stream. The
 * handler checkpoints to ctx.Metadata (small integer watermarks) and a file-backed
 * CheckpointStore (the heavier in-flight text) after each subcall — so a crash mid-phase
 * recovers at the next un-finished subcall.
 *
 * Special behaviour: `POST /invocations` with message "crash" (when the container has
 * DEMO_MODE=1) forces Environment.Exit(137) shortly after returning 202, so the platform
 * nanny restarts us and the resilient task auto-recovers.
 *
 * Routes (all platform-managed; only /invocations* is reachable through the Foundry proxy):
 *   * POST /invocations                      — dispatch a run (or steer an in-flight one);
 *                                              "crash" forces a process exit (DEMO_MODE)
 *   * GET  /invocations/{id}?last_event_id=N — SSE stream of the active run (resume-safe)
 *   * POST /invocations/{id}/cancel          — operator cancel
 */

using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Invocations;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects;
using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Responses;

// ── Host bootstrap ─────────────────────────────────────────────────────────────
// AgentHost wires Kestrel on port 8088, OpenTelemetry, and health probes. AddInvocations
// registers the Invocations HTTP host + our handler. AddEventStreams gives per-turn SSE
// streams FILE-BACKED so a subscriber reconnecting after a crash resumes from its last
// cursor with no gap. AddResilientTasks registers the durable task engine AND the
// cold-start recovery scan (a hosted service) that re-enters in-progress tasks on restart
// — this is what makes the crash-recovery path work with zero extra wiring.
if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING")))
    Console.Error.WriteLine(
        "[WARNING] APPLICATIONINSIGHTS_CONNECTION_STRING not set — traces will not be sent " +
        "to Application Insights. (Auto-injected in hosted Foundry containers.)");

var builder = AgentHost.CreateBuilder(args);

builder.AddInvocations<ResilientResearchHandler>();

// Upstream research model — lazy + fake-capable so the container boots without credentials.
builder.Services.AddSingleton(_ => new UpstreamModel());

// Per-turn streams persist to disk so they survive a container crash + restart. The cursor
// accessor reads each event's sequence_number so ?last_event_id=N reconnects skip
// already-delivered events (whether served live, from on-disk replay, or after a crash
// rehydrate). In-memory replay would lose the pre-crash buffer, defeating crash-resilience.
builder.Services.AddEventStreams(o => o.UseFileBackedReplay<ResearchEvent>(
    cursor: e => e.SequenceNumber,
    ttl: TimeSpan.FromMinutes(10)));

// Heavy in-flight artifacts (partial phase text) live in a file-backed store co-located with
// the event streams (under AGENTSERVER_STATE_ROOT when set, else ~/.agentserver) so a single
// mount/volume carries everything the handler needs to survive a restart; ctx.Metadata holds
// only small integer watermarks. A DefaultAzureCredential is passed so the HOSTED task store
// (Foundry /tasks API) can authenticate; locally the SDK selects the file-backed store and the
// credential is never used.
string stateRoot = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT")
    ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".agentserver");
string checkpointRoot = Path.Combine(stateRoot, "checkpoints");
var checkpointStore = new CheckpointStore(checkpointRoot);

builder.Services.AddResilientTasks(new DefaultAzureCredential())
    .AddMultiTurnTask<ResearchRequest, ResearchResult>(
        "research",
        (provider, ctx, ct) => ResilientResearchHandler.RunResearchAsync(
            provider.GetRequiredService<IEventStreamRegistry>(),
            provider.GetRequiredService<UpstreamModel>(),
            ctx,
            checkpointStore,
            ct),
        steerable: true);

builder.Build().Run();

// ── Config (same knobs as the Python resilient-agent-demo) ─────────────────────
internal static class DemoConfig
{
    public static readonly string[] PhaseTitles =
    [
        "Decomposing topic into focused research questions",
        "Surveying foundational literature and key concepts",
        "Identifying leading researchers and institutions",
        "Mapping the historical trajectory of the field",
        "Analyzing recent breakthroughs and publications",
        "Examining competing theories and methodological debates",
        "Evaluating experimental evidence and data quality",
        "Mapping connections to adjacent fields",
        "Identifying open problems and knowledge gaps",
        "Assessing real-world applications and current adoption",
        "Analyzing funding landscape and research trends",
        "Surveying ethical considerations and societal implications",
        "Projecting near-term and long-term outlook",
        "Synthesizing findings into a coherent narrative",
        "Generating key insights and concrete recommendations",
    ];

    public static readonly (string Name, string Prompt)[] SubCallRoles =
    [
        ("research",
            "Conduct an in-depth investigation of the assigned aspect. Include specific " +
            "findings, examples, and references where you can. Aim for substantive, " +
            "multi-paragraph content."),
        ("critique",
            "Critically evaluate the research above. Identify weak claims, gaps, competing " +
            "interpretations, and quality concerns. Be specific."),
        ("refine",
            "Revise the original research, incorporating the critique. Strengthen weak " +
            "claims, address gaps, and clarify uncertainty. Produce a tightened, more " +
            "rigorous version."),
        ("synthesize",
            "Distill the refined material into 2-3 paragraphs of key takeaways suitable " +
            "for someone briefing a decision-maker on this phase."),
    ];

    public static readonly int NumPhases =
        Math.Max(1, EnvInt("NUM_PHASES", PhaseTitles.Length));
    public static readonly int CallsPerPhase =
        Math.Max(1, Math.Min(SubCallRoles.Length, EnvInt("CALLS_PER_PHASE", 4)));
    public static readonly int TargetOutputTokens = EnvInt("TARGET_OUTPUT_TOKENS", 1500);
    public static readonly double IntraPhaseCooldownSec = EnvDouble("INTRA_PHASE_COOLDOWN_SEC", 10);
    public static readonly double InterPhaseCooldownSec = EnvDouble("INTER_PHASE_COOLDOWN_SEC", 20);
    public static readonly bool DemoMode = Environment.GetEnvironmentVariable("DEMO_MODE") == "1";

    public static string PhaseTitle(int i) =>
        i < PhaseTitles.Length ? PhaseTitles[i] : $"Continued research (phase {i + 1})";

    private static int EnvInt(string name, int fallback) =>
        int.TryParse(Environment.GetEnvironmentVariable(name), out var v) ? v : fallback;

    private static double EnvDouble(string name, double fallback) =>
        double.TryParse(Environment.GetEnvironmentVariable(name), out var v) ? v : fallback;
}

/// <summary>
/// Upstream research model. Uses a real Foundry Responses client when
/// <c>FOUNDRY_PROJECT_ENDPOINT</c> is set (and <c>USE_FAKE_MODEL != 1</c>); otherwise
/// streams synthetic tokens so the crash / recover / steer flow can be exercised
/// end-to-end without credentials (local verification + CI). Lazy + thread-safe so the
/// container boots and survives recovery re-invocation without eager credential resolution.
/// </summary>
public sealed class UpstreamModel
{
    /// <summary>True when no real model is configured — the producer streams synthetic tokens.</summary>
    public bool IsFake { get; } =
        Environment.GetEnvironmentVariable("USE_FAKE_MODEL") == "1"
        || string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT"));

    private readonly Lazy<ProjectResponsesClient> _client = new(() =>
    {
        var endpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("FOUNDRY_PROJECT_ENDPOINT environment variable is not set.");
        var model = Environment.GetEnvironmentVariable("AZURE_AI_MODEL_DEPLOYMENT_NAME")
            ?? throw new InvalidOperationException("AZURE_AI_MODEL_DEPLOYMENT_NAME environment variable is not set.");
        var projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        return projectClient.ProjectOpenAIClient.GetProjectResponsesClientForModel(model);
    });

    /// <summary>
    /// Stream one subcall's token deltas. Stops early (yield break) when the token is
    /// cancelled so a steering / cancel nudge winds the subcall down gracefully rather
    /// than throwing — mirrors the Python demo's check-then-return early stop.
    /// </summary>
    public async IAsyncEnumerable<string> StreamDeltasAsync(
        string instructions,
        string userInput,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (IsFake)
        {
            await foreach (var t in StreamFakeAsync(userInput, cancellationToken).ConfigureAwait(false))
                yield return t;
            yield break;
        }

        var options = new CreateResponseOptions
        {
            Instructions = instructions,
            MaxOutputTokenCount = DemoConfig.TargetOutputTokens,
        };
        options.InputItems.Add(ResponseItem.CreateUserMessageItem(userInput));

        // Not tied to the handler token directly — mirror the check-then-break early stop so a
        // steering/cancel signal winds the subcall down gracefully instead of throwing.
        await foreach (var update in _client.Value.CreateResponseStreamingAsync(options, CancellationToken.None)
            .ConfigureAwait(false))
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            if (update is StreamingResponseOutputTextDeltaUpdate delta && !string.IsNullOrEmpty(delta.Delta))
                yield return delta.Delta;
        }
    }

    // Synthetic token generator: emits a handful of word tokens with a small delay so the
    // stream visibly "types" and the crash / cooldown / steering timing is realistic offline.
    private static async IAsyncEnumerable<string> StreamFakeAsync(
        string userInput,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        string seed = userInput.Length > 60 ? userInput[..60] : userInput;
        string[] words =
        [
            "Analyzing", "the", "topic", "in", "depth:", seed.Replace('\n', ' '), "—",
            "surveying", "sources,", "weighing", "evidence,", "and", "synthesizing",
            "a", "concise,", "well-supported", "assessment", "for", "this", "phase.",
        ];
        foreach (var w in words)
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            try
            { await Task.Delay(40, cancellationToken).ConfigureAwait(false); }
            catch (OperationCanceledException) { yield break; }
            yield return w + " ";
        }
    }
}

/// <summary>Error detail for a terminal <c>run_failed</c> event.</summary>
public sealed class ErrorInfo
{
    [JsonPropertyName("type")] public string Type { get; set; } = "";
    [JsonPropertyName("message")] public string Message { get; set; } = "";
}

/// <summary>
/// A single event on a research turn's stream. Serializes to a flat JSON object matching the
/// Python demo's event schema (only set fields are written), and carries its own
/// <c>sequence_number</c> which is used both as the SSE <c>id:</c> and the replay cursor.
/// </summary>
public sealed class ResearchEvent
{
    [JsonPropertyName("sequence_number")] public int SequenceNumber { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; } = "";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("topic")] public string? Topic { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("entry_mode")] public string? EntryMode { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prior_topic")] public string? PriorTopic { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_phases")] public int? TotalPhases { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("calls_per_phase")] public int? CallsPerPhase { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("completed_phases")] public int? CompletedPhases { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("phase")] public int? Phase { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total")] public int? Total { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("role")] public string? Role { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("index")] public int? Index { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("of")] public int? Of { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("stage")] public string? Stage { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subcall")] public int? Subcall { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("duration_sec")] public double? DurationSec { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cause")] public string? Cause { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pending_steering_inputs")] public int? PendingSteeringInputs { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("phases_completed")] public int? PhasesCompleted { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error")] public ErrorInfo? Error { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("server_time_utc")] public string? ServerTimeUtc { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("server_uptime_sec")] public double? ServerUptimeSec { get; set; }
}

/// <summary>Input for the research task. Carries the per-turn invocation id so the producer
/// keys its event stream to this turn (the durable TaskId spans the whole session).</summary>
public record ResearchRequest(string Topic, string InvocationId);

/// <summary>Final result of the research task.</summary>
public record ResearchResult(string Status, int PhasesCompleted);

/// <summary>
/// File-backed checkpoint store for heavy in-flight artifacts (partial phase text, potentially
/// several KB). ctx.Metadata is a small-watermark store, not a bulk store — heavy content lives
/// here keyed by invocation id, with atomic writes (temp file + rename). Rooted under the user
/// profile (NOT the OS temp dir, which may be cleared) so it survives a container restart.
/// </summary>
public sealed class CheckpointStore
{
    private readonly string _dir;
    public CheckpointStore(string directory)
    {
        _dir = directory;
        Directory.CreateDirectory(directory);
    }

    private string PathFor(string key) => Path.Combine(_dir, key + ".json");

    public string? Load(string key)
    {
        string p = PathFor(key);
        return File.Exists(p) ? File.ReadAllText(p) : null;
    }

    public void Save(string key, string content)
    {
        string p = PathFor(key);
        string tmp = p + ".tmp";
        File.WriteAllText(tmp, content);
        File.Move(tmp, p, overwrite: true);
    }

    public void Delete(string key)
    {
        string p = PathFor(key);
        if (File.Exists(p))
            File.Delete(p);
    }
}
