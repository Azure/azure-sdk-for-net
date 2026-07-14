// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

/*
 * Resilient Responses Research Agent — Demo (.NET)
 *
 * A resilient + steerable Responses-API agent that demonstrates four platform
 * capabilities of the Azure AI Hosted Agent + the Responses package. It is a
 * faithful port of the Python `resilient-responses-agent-demo` (same 15-phase ×
 * 4-subcall research plan, same cooldown cadence, same ~33-min runtime) onto the
 * .NET Responses package's resilience primitives — so the behaviour matches while
 * the mechanism is the one-OutputItem-per-subcall `stream.Checkpoint()` pattern.
 *
 * 1. Long-running responses run uninterrupted past the platform's sandbox-eviction
 *    window. 15 research phases × 4 LLM subcalls each, with intra-phase and
 *    inter-phase cooldowns (~132s/phase ≈ 33 min total) — ~2x the 15-min eviction
 *    window, so every run exercises the resilient-task lease keep-alive path.
 *
 * 2. Recovery from container crashes. When the container dies, the platform's nanny
 *    worker brings it back within ~1 min and the framework re-invokes this handler
 *    with `context.IsRecovery == true`. Recovery uses the one-OutputItem-per-subcall
 *    pattern: the persisted response IS the watermark. The handler seeds its stream
 *    from `context.PersistedResponse` and resumes at `stream.Response.Output.Count` —
 *    completed (checkpointed) subcalls survive and are replayed to reconnecting
 *    clients via the `response.in_progress` reset; the interrupted subcall re-runs.
 *
 * 3. Steering. POSTing a follow-up turn (with `previous_response_id` pointing at the
 *    still-running one) queues the input as a steering input. The agent observes
 *    `cancellationToken.IsCancellationRequested && context.PendingInputCount > 0`,
 *    winds down at the next phase boundary, and re-enters with
 *    `context.IsSteeredTurn == true` carrying the new input.
 *
 * 4. Operator cancel. `POST /responses/{id}/cancel` cancels the handler token +
 *    stamps `context.ClientCancelled`; the framework forces the response to
 *    status="cancelled" regardless of what the handler emits.
 *
 * Special behaviour: `POST /responses` with input "crash" (when the container has
 * DEMO_MODE=1) forces `Environment.Exit(137)` shortly after returning, so the
 * platform's nanny worker can demonstrate the recovery path.
 */

using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenAI.Responses;

// Disambiguate: the demo uses the AgentServer error code (not OpenAI.Responses.ResponseErrorCode).
using ResponseErrorCode = Azure.AI.AgentServer.Responses.Models.ResponseErrorCode;

// ── One-liner startup ────────────────────────────────────────────────────────
// Wires up Kestrel on port 8088, OpenTelemetry, health probes, and the Responses
// API endpoints. `ResilientBackground` + `SteerableConversations` turn on the
// resilient-task lease keep-alive, crash-recovery re-invoke, and steering paths.
//
// NOTE: we build the host explicitly (rather than the ResponsesServer.Run<T>
// one-liner) because we need to pass ResponsesServerOptions to AddResponses<T>.
// AddResponses<T>(configure) registers the resilient task exactly once; calling
// ResponsesServer.Run<T> AND AddResponsesServer would double-register it.
if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING")))
    Console.Error.WriteLine(
        "[WARNING] APPLICATIONINSIGHTS_CONNECTION_STRING not set — traces will not be sent " +
        "to Application Insights. (Auto-injected in hosted Foundry containers.)");

var builder = AgentHost.CreateBuilder(args);

builder.AddResponses<ResilientResearchHandler>(o =>
{
    o.ResilientBackground = true;
    o.SteerableConversations = true;
});

// Upstream Foundry model client — lazily resolved so the process still boots for
// the credential-free DEMO_MODE routes (crash / __ECHO_INPUT__ / __ECHO_CRASH__ /
// __FAIL__) that never call the model.
builder.Services.AddSingleton(_ => new UpstreamModel());

builder.Build().Run();

// ── Config (same knobs as the Python resilient-responses-agent-demo) ───────────
internal static class DemoConfig
{
    // 15 research phases × 4 subcalls each, with cooldowns, spans the sandbox-eviction
    // window (~33 min hosted). Hosted cooldowns are set low in agent.yaml; the defaults
    // here (10/20s, ~15 min) apply for fast local iteration.
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
/// Upstream Foundry Responses-API model client. Lazy + thread-safe so the container
/// boots without credentials for the credential-free DEMO_MODE routes, and survives
/// recovery re-invocation cleanly (a single client is reused across invocations).
/// </summary>
public sealed class UpstreamModel
{
    private readonly Lazy<ProjectResponsesClient> _client = new(() =>
    {
        var endpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
            ?? throw new InvalidOperationException("FOUNDRY_PROJECT_ENDPOINT environment variable is not set.");
        var model = Environment.GetEnvironmentVariable("AZURE_AI_MODEL_DEPLOYMENT_NAME")
            ?? throw new InvalidOperationException("AZURE_AI_MODEL_DEPLOYMENT_NAME environment variable is not set.");
        var projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        return projectClient.ProjectOpenAIClient.GetProjectResponsesClientForModel(model);
    });

    public ProjectResponsesClient Client => _client.Value;
}

/// <summary>
/// 15-phase × 4-subcall resilient + steerable research handler.
///
/// One OutputItem per subcall (research → critique → refine → synthesize), and a
/// <c>Checkpoint()</c> after each — so a crash loses at most the one subcall that was
/// actively streaming. The persisted response IS the watermark:
/// <c>stream.Response.Output.Count</c> is the number of checkpointed subcalls, so on
/// recovery the handler seeds its stream from <c>context.PersistedResponse</c> and
/// resumes at the first un-checkpointed subcall. Subcalls chain (each takes the
/// previous one's text as input); on recovery the previous subcall's text is read back
/// from the seeded snapshot.
/// </summary>
public sealed class ResilientResearchHandler(
    UpstreamModel upstream,
    ILogger<ResilientResearchHandler> logger) : ResponseHandler
{
    private static readonly HashSet<string> CrashInputs = new(StringComparer.Ordinal) { "crash", "kill", "💥" };

    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var topic = await context.GetInputTextAsync(cancellationToken: cancellationToken) ?? "";

        // ── Demo-only crash trigger ──────────────────────────────────────────
        // Guarded by !IsRecovery so the crash fires exactly once: on the recovered
        // re-invocation the same (re-delivered) "crash" input is ignored and the
        // handler resumes to completion.
        if (DemoConfig.DemoMode && !context.IsRecovery && CrashInputs.Contains(topic.Trim().ToLowerInvariant()))
        {
            logger.LogCritical("CRASH triggered via input={Topic} — exiting in 300ms", topic);
            _ = Task.Run(async () =>
            {
                await Task.Delay(300);
                Environment.Exit(137);
            });
            var s = new ResponseEventStream(context, request);
            yield return s.EmitCreated();
            yield return s.EmitFailed(ResponseErrorCode.ServerError,
                "Demo-mode crash trigger fired; process exiting in 300ms.");
            yield break;
        }

        // ── Demo-only input-integrity echo (DEMO_MODE) ───────────────────────
        // Echoes byte-length + sha256 of the observed input so the battery can prove
        // the resilient-input attachment-spill path round-trips losslessly.
        if (DemoConfig.DemoMode && topic.StartsWith("__ECHO_INPUT__", StringComparison.Ordinal))
        {
            var s = new ResponseEventStream(context, request);
            yield return s.EmitCreated();
            yield return s.EmitInProgress();
            var msg = s.AddOutputItemMessage();
            yield return msg.EmitAdded();
            var t = msg.AddTextContent();
            yield return t.EmitAdded();
            yield return t.EmitDelta($"INPUT_LEN={topic.Length} INPUT_SHA256={Sha256(topic)}");
            yield return t.EmitTextDone();
            yield return t.EmitDone();
            yield return msg.EmitDone();
            yield return s.EmitCompleted();
            yield break;
        }

        // ── Oversized-input + crash-recovery parity route (DEMO_MODE) ────────
        // Fresh entry: echo input integrity as one item, checkpoint it, then crash (no
        // terminal). Recovery: re-read the (spilled) input and echo it AGAIN as a second
        // item, then complete. The battery asserts the pre-crash and post-recovery echoes
        // are identical — proving the recovered handler re-observed the byte-identical
        // oversized input from the attachment.
        if (DemoConfig.DemoMode && topic.StartsWith("__ECHO_CRASH__", StringComparison.Ordinal))
        {
            if (context.IsRecovery && context.PersistedResponse is not null)
            {
                var s = new ResponseEventStream(context, context.PersistedResponse);
                yield return s.EmitCreated();
                yield return s.EmitInProgress();
                var msg = s.AddOutputItemMessage();
                yield return msg.EmitAdded();
                var t = msg.AddTextContent();
                yield return t.EmitAdded();
                yield return t.EmitDelta($"RECOVERED_LEN={topic.Length} RECOVERED_SHA256={Sha256(topic)}");
                yield return t.EmitTextDone();
                yield return t.EmitDone();
                yield return msg.EmitDone();
                yield return s.EmitCompleted();
                yield break;
            }

            var stream0 = new ResponseEventStream(context, request);
            yield return stream0.EmitCreated();
            yield return stream0.EmitInProgress();
            var m0 = stream0.AddOutputItemMessage();
            yield return m0.EmitAdded();
            var t0 = m0.AddTextContent();
            yield return t0.EmitAdded();
            yield return t0.EmitDelta($"PRECRASH_LEN={topic.Length} PRECRASH_SHA256={Sha256(topic)}");
            yield return t0.EmitTextDone();
            yield return t0.EmitDone();
            yield return m0.EmitDone();
            yield return stream0.Checkpoint(); // persist the pre-crash echo item
            await Task.Delay(1000);            // let the checkpoint flush, then crash mid-run
            Environment.Exit(137);
        }

        // ── Clean mark-failed route (DEMO_MODE) ──────────────────────────────
        // Emits a terminal response.failed with code=server_error WITHOUT crashing, so
        // the battery can observe the failed terminal + error.code (the one terminal
        // state the research path never produces on its own).
        if (DemoConfig.DemoMode && topic.StartsWith("__FAIL__", StringComparison.Ordinal))
        {
            var s = new ResponseEventStream(context, request);
            yield return s.EmitCreated();
            yield return s.EmitFailed(ResponseErrorCode.ServerError, "Demo-mode clean failure route.");
            yield break;
        }

        // ── In-container oversized-task-create HTTP trace (DEMO_MODE) ────────
        // Captures a full, untruncated request+response trace of the oversized task-create
        // path using the hosted-agent credential (external callers get 403, so the real
        // 500 is only observable here). Emits the trace as the response output.
        if (DemoConfig.DemoMode && topic.StartsWith("__TASKTRACE__", StringComparison.Ordinal))
        {
            var trace = await TaskTrace.CaptureOversizedTaskTraceAsync(
                Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
                    ?? throw new InvalidOperationException("FOUNDRY_PROJECT_ENDPOINT is not set."),
                Environment.GetEnvironmentVariable("AGENT_NAME") ?? "resilient-responses-agent-demo-dotnet",
                cancellationToken);
            var s = new ResponseEventStream(context, request);
            yield return s.EmitCreated();
            yield return s.EmitInProgress();
            var msg = s.AddOutputItemMessage();
            yield return msg.EmitAdded();
            var t = msg.AddTextContent();
            yield return t.EmitAdded();
            yield return t.EmitDelta(trace);
            yield return t.EmitTextDone();
            yield return t.EmitDone();
            yield return msg.EmitDone();
            yield return s.EmitCompleted();
            yield break;
        }

        // ── Recovery branch: seed from the persisted snapshot ────────────────
        // Each completed subcall is one persisted output item, so the item count is the
        // subcall watermark.
        ResponseEventStream stream;
        int doneSubcalls;
        if (context.IsRecovery && context.PersistedResponse is not null)
        {
            stream = new ResponseEventStream(context, context.PersistedResponse);
            doneSubcalls = stream.Response.Output.Count;
        }
        else
        {
            stream = new ResponseEventStream(context, request);
            doneSubcalls = 0;
        }

        yield return stream.EmitCreated(); // framework dedups the duplicate on recovery

        // ── Pre-entry: shutdown and cancellation are DISTINCT surfaces ───────
        if (context.IsShutdownRequested)
            await context.ExitForRecoveryAsync(cancellationToken);
        if (cancellationToken.IsCancellationRequested)
        {
            if (context.PendingInputCount > 0)
                yield return stream.EmitCompleted(); // steering pre-entry — finish cleanly
            yield break;                              // client cancel — framework forces "cancelled"
        }

        yield return stream.EmitInProgress(); // client-visible reset point on recovery

        // ── Drive the subcalls — one OutputItem + checkpoint per subcall ─────
        int totalSubcalls = DemoConfig.NumPhases * DemoConfig.CallsPerPhase;
        for (int step = doneSubcalls; step < totalSubcalls; step++)
        {
            int phaseIdx = step / DemoConfig.CallsPerPhase;
            int subIdx = step % DemoConfig.CallsPerPhase;
            string title = DemoConfig.PhaseTitle(phaseIdx);
            var (roleName, rolePrompt) = DemoConfig.SubCallRoles[subIdx];

            // Chain onto the previous subcall in this phase (reset at subIdx 0). On recovery
            // the previous subcall is read back from the seeded item.
            string prevText = subIdx == 0 ? "" : ItemText(stream.Response.Output[step - 1]);

            string instructions =
                $"You are a research analyst working on the topic: '{topic}'.\n" +
                $"Current phase: '{title}'.\nYour role in this sub-step: {roleName}.\n\n{rolePrompt}";
            string userInput = string.IsNullOrEmpty(prevText)
                ? $"Topic: {topic}\nPhase: {title}"
                : $"Topic: {topic}\nPhase: {title}\n\nPrevious sub-step output:\n{prevText}";

            var message = stream.AddOutputItemMessage();
            // Observability only; stripped on egress. .NET exposes internal metadata at the
            // stream level (there is no per-item builder surface), so we stamp the current
            // phase/subcall here.
            stream.InternalMetadata["phase"] = phaseIdx.ToString();
            stream.InternalMetadata["subcall"] = roleName;
            yield return message.EmitAdded();
            var text = message.AddTextContent();
            yield return text.EmitAdded();
            yield return text.EmitDelta(
                $"=== Phase {phaseIdx + 1}/{DemoConfig.NumPhases} — {title} · {roleName} ===\n\n");

            await foreach (var delta in StreamSubcallAsync(instructions, userInput, context, cancellationToken))
                yield return text.EmitDelta(delta);

            // Mid-subcall shutdown: defer BEFORE closing the item, so the item never enters
            // the snapshot and this subcall re-runs on recovery.
            if (context.IsShutdownRequested)
                await context.ExitForRecoveryAsync(cancellationToken);

            yield return text.EmitTextDone();
            yield return text.EmitDone();
            yield return message.EmitDone(); // item now in stream.Response.Output

            // Steering / client cancel mid-subcall: wind down without advancing the
            // watermark (don't checkpoint this subcall).
            if (cancellationToken.IsCancellationRequested)
                break;

            yield return stream.Checkpoint(); // subcall resilient; on to the next

            // Cooldown: intra-phase between subcalls, inter-phase after the last subcall of a
            // phase. Skipped after the final subcall.
            if (step + 1 < totalSubcalls)
            {
                bool lastSubOfPhase = subIdx + 1 == DemoConfig.CallsPerPhase;
                double cooldown = lastSubOfPhase ? DemoConfig.InterPhaseCooldownSec : DemoConfig.IntraPhaseCooldownSec;
                if (cooldown > 0)
                {
                    await CooldownAsync(context, cancellationToken, cooldown);
                    if (cancellationToken.IsCancellationRequested)
                        break;
                }
            }
        }

        yield return stream.EmitCompleted();
    }

    /// <summary>Stream one LLM subcall's token deltas. Stops early if cancel/shutdown fires.</summary>
    private async IAsyncEnumerable<string> StreamSubcallAsync(
        string instructions,
        string userInput,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var options = new CreateResponseOptions
        {
            Instructions = instructions,
            MaxOutputTokenCount = DemoConfig.TargetOutputTokens,
        };
        options.InputItems.Add(ResponseItem.CreateUserMessageItem(userInput));

        // Not tied to the handler token — mirror Python's check-then-return early stop so a
        // steering/cancel signal winds the subcall down gracefully instead of throwing.
        await foreach (var update in upstream.Client.CreateResponseStreamingAsync(options, CancellationToken.None))
        {
            if (cancellationToken.IsCancellationRequested || context.IsShutdownRequested)
                yield break;
            if (update is StreamingResponseOutputTextDeltaUpdate delta && !string.IsNullOrEmpty(delta.Delta))
                yield return delta.Delta;
        }
    }

    /// <summary>Cooldown wait. Wakes on cancel; defers to recovery on shutdown.</summary>
    private static async Task CooldownAsync(ResponseContext context, CancellationToken cancellationToken, double durationSec)
    {
        double slept = 0;
        while (slept < durationSec)
        {
            if (context.IsShutdownRequested)
                await context.ExitForRecoveryAsync(cancellationToken);
            if (cancellationToken.IsCancellationRequested)
                return;
            await Task.Delay(500, CancellationToken.None);
            slept += 0.5;
        }
    }

    /// <summary>Extract the output_text of a (seeded or just-emitted) output item.</summary>
    private static string ItemText(OutputItem item)
    {
        if (item is OutputItemMessage message)
        {
            foreach (var part in message.Content)
            {
                if (part is MessageContentOutputTextContent text)
                    return text.Text ?? "";
            }
        }
        return "";
    }

    private static string Sha256(string value) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value))).ToLowerInvariant();
}
