// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Storage;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing the resilient responses samples
    /// (Sample19_ResilientStreaming.md, Sample20_ResilientSteering.md,
    /// Sample22_ResilientMultiTurn.md). Compiled to prevent the public API surface
    /// used by those samples from silently drifting; every member referenced here is
    /// confirmed against <c>api/Azure.AI.AgentServer.Responses.net8.0.cs</c>. The
    /// <c>Snippet:</c>-prefixed regions are injected into the sample markdown by
    /// <c>eng/scripts/Update-Snippets.ps1</c>, so the docs and these compile guards
    /// stay in lockstep.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class ResilienceSnippetsTests
    {
        [Test]
        public void Implement_ResilientStreamingHandler()
        {
            var handler = new ResilientStreamingHandler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_ResilientSteeringHandler()
        {
            var handler = new ResilientSteeringHandler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_ResilientMultiTurnHandler()
        {
            var handler = new ResilientMultiTurnHandler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        [Explicit("Starts a blocking host; compiled as a snippet guard only.")]
        public void StartServer_ResilientStreaming()
        {
            #region Snippet:Responses_Sample19_StartServer

            // Resilient background responses are composed on the Core durable-task /
            // event-stream primitives; enabling the option is all the handler needs.
            AgentHost.CreateBuilder()
                .AddResponses<ResilientStreamingHandler>(o => o.ResilientBackground = true)
                .Build()
                .Run();

            #endregion
        }

        [Test]
        [Explicit("Starts a blocking host; compiled as a snippet guard only.")]
        public void StartServer_SteerableConversations()
        {
            #region Snippet:Responses_Sample20_StartServer

            AgentHost.CreateBuilder()
                .AddResponses<ResilientSteeringHandler>(o =>
                {
                    o.ResilientBackground = true;
                    o.SteerableConversations = true;
                })
                .Build()
                .Run();

            #endregion
        }

        [Test]
        [Explicit("Starts a blocking host; compiled as a snippet guard only.")]
        public void StartServer_SerialMultiTurn()
        {
            #region Snippet:Responses_Sample22_StartServer

            // Serial multi-turn: resilient background without steering keeps turns
            // serialized by the conversation lock.
            AgentHost.CreateBuilder()
                .AddResponses<ResilientMultiTurnHandler>(o =>
                {
                    o.ResilientBackground = true;
                    o.SteerableConversations = false;
                })
                .Build()
                .Run();

            #endregion
        }

        #region Snippet:Responses_Sample19_ResilientStreamingHandler

        // Sample 19 — resilient streaming with handler-managed phase checkpoints.
        // The handler seeds a ResponseEventStream from the last durable response snapshot
        // and resumes after the output items already committed by prior phases.
        public class ResilientStreamingHandler : ResponseHandler
        {
            private static readonly string[] PhaseOrder = { "analyze", "generate", "refine" };

            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                string prompt = await context.GetInputTextAsync(cancellationToken: cancellationToken);

                // Recovery-aware stream seeding. On a recovered entry, seed the stream from the
                // last durable checkpoint (context.PersistedResponse) so the completed phases'
                // output items are carried forward and replayed on the reset. On a fresh entry,
                // start from the request.
                ResponseEventStream stream =
                    context.IsRecovery && context.PersistedResponse is not null
                        ? new ResponseEventStream(context, context.PersistedResponse)
                        : new ResponseEventStream(context, request);

                // Always emit response.created — even on recovery. The framework keeps exactly one
                // response.created on the durable stream across lifetimes: on a recovered entry the
                // duplicate is dropped and the following response.in_progress becomes the
                // client-visible reset carrying the seeded prior output.
                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                int startPhase = NextPhaseIndex(context);
                for (int i = startPhase; i < PhaseOrder.Length; i++)
                {
                    string phase = PhaseOrder[i];

                    if (cancellationToken.IsCancellationRequested)
                    {
                        // Mid-stream shutdown: leave in_progress for recovery.
                        await context.ExitForRecoveryAsync(cancellationToken);
                        yield break;
                    }

                    string text = phase switch
                    {
                        "analyze" => $"[analyze] Examining input: '{prompt}'.",
                        "generate" => $"[generate] Drafting response for: '{prompt}'.",
                        _ => $"[refine] Polished result for: '{prompt}'.",
                    };

                    // Emit one complete message output item for this phase.
                    foreach (var evt in stream.OutputItemMessage(text))
                    {
                        yield return evt;
                    }

                    // Persist a durable snapshot at the phase boundary
                    // (no-op unless resilient background).
                    yield return stream.Checkpoint();
                }

                yield return stream.EmitCompleted();
            }

            private static int NextPhaseIndex(ResponseContext context)
            {
                int completedPhases = context.IsRecovery
                    ? context.PersistedResponse?.Output?.Count ?? 0
                    : 0;
                return Math.Min(completedPhases, PhaseOrder.Length);
            }
        }

        #endregion

        #region Snippet:Responses_Sample20_ResilientSteeringHandler

        // Sample 20 — steering composed with cancellation × recovery. A superseded turn
        // observes IsSteeredTurn on the re-entry and drains the enqueued input.
        public class ResilientSteeringHandler : ResponseHandler
        {
            private static readonly DefaultAzureCredential s_credential = new();

            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                string prompt = await context.GetInputTextAsync(cancellationToken: cancellationToken);

                // A steered re-entry drains any pending superseding input.
                bool steered = context.IsSteeredTurn;
                int pending = context.PendingInputCount;

                FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
                    $"responses/resilient-steering/{context.ConversationChainId}",
                    s_credential,
                    description: "State for the resilient steering response sample",
                    cancellationToken: CancellationToken.None);
                StateStoreItem? item = await store.GetItemAsync(
                    "state",
                    cancellationToken: CancellationToken.None);
                IDictionary<string, BinaryData> state = item?.Value
                    ?? new Dictionary<string, BinaryData>(StringComparer.Ordinal);

                int turnCount;
                if (state.TryGetValue("last_response_id", out BinaryData? responseIdData)
                    && responseIdData.ToObjectFromJson<string>() == context.ResponseId)
                {
                    turnCount = state.TryGetValue("turn_count", out BinaryData? turnData)
                        ? turnData.ToObjectFromJson<int>()
                        : 1;
                }
                else
                {
                    turnCount = state.TryGetValue("turn_count", out BinaryData? turnData)
                        ? turnData.ToObjectFromJson<int>() + 1
                        : 1;
                    await store.SetItemAsync(
                        "state",
                        new Dictionary<string, BinaryData>
                        {
                            ["turn_count"] = BinaryData.FromObjectAsJson(turnCount),
                            ["last_response_id"] = BinaryData.FromObjectAsJson(context.ResponseId),
                            ["steered"] = BinaryData.FromObjectAsJson(steered && pending >= 0),
                        },
                        cancellationToken: CancellationToken.None);
                }

                var stream = new ResponseEventStream(context, request);

                // Re-runs from scratch on recovery (non-deterministic upstream; the single message
                // item is only emitted at completion, so a mid-stream crash leaves no durable output
                // to seed). Always emit response.created — even on recovery. The framework keeps
                // exactly one response.created across lifetimes, so the recovered duplicate is dropped
                // and the following (empty) response.in_progress is the client-visible reset. The
                // handler never branches on IsRecovery to decide whether to emit created.
                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                string[] words = $"Let me explain {prompt} in detail. Comprehensive answer here.".Split(' ');
                var partial = new StringBuilder();

                foreach (string word in words)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        if (context.ClientCancelled)
                        {
                            yield break; // client cancelled — no terminal
                        }

                        if (context.IsShutdownRequested)
                        {
                            await context.ExitForRecoveryAsync(cancellationToken);
                            yield break; // shutdown — re-run next lifetime
                        }

                        // Steering pressure: end this turn cleanly with partial content so it is
                        // valid context for the superseding turn.
                        foreach (var evt in stream.OutputItemMessage(partial.ToString()))
                        {
                            yield return evt;
                        }

                        yield return stream.EmitCompleted();
                        yield break;
                    }

                    partial.Append(word).Append(' ');
                }

                foreach (var evt in stream.OutputItemMessage(partial.ToString()))
                {
                    yield return evt;
                }

                yield return stream.EmitCompleted();
            }
        }

        #endregion

        #region Snippet:Responses_Sample22_ResilientMultiTurnHandler

        // Sample 22 — serial multi-turn (no steering). Durable per-conversation state is
        // written to an explicit State Store scoped by the stable ConversationChainId.
        public class ResilientMultiTurnHandler : ResponseHandler
        {
            private static readonly DefaultAzureCredential s_credential = new();

            public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                CancellationToken cancellationToken)
            {
                return new TextResponse(context, request, createText: async ct =>
                {
                    string inputText = await context.GetInputTextAsync(cancellationToken: ct);

                    string chainId = context.ConversationChainId;
                    FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
                        $"responses/resilient-multiturn/{chainId}",
                        s_credential,
                        description: "State for the resilient multi-turn response sample",
                        cancellationToken: CancellationToken.None);
                    StateStoreItem? item = await store.GetItemAsync(
                        "state",
                        cancellationToken: CancellationToken.None);
                    IDictionary<string, BinaryData> state = item?.Value
                        ?? new Dictionary<string, BinaryData>(StringComparer.Ordinal);

                    if (state.TryGetValue("terminated", out BinaryData? terminatedData)
                        && terminatedData.ToObjectFromJson<bool>()
                        && (!state.TryGetValue("last_response_id", out BinaryData? terminatedResponseData)
                            || terminatedResponseData.ToObjectFromJson<string>() != context.ResponseId))
                    {
                        state = new Dictionary<string, BinaryData>(StringComparer.Ordinal);
                    }

                    bool repeatedResponse =
                        state.TryGetValue("last_response_id", out BinaryData? responseIdData)
                        && responseIdData.ToObjectFromJson<string>() == context.ResponseId;
                    int turnCount = repeatedResponse
                        ? state.TryGetValue("turn_count", out BinaryData? existingTurnData)
                            ? existingTurnData.ToObjectFromJson<int>()
                            : 1
                        : state.TryGetValue("turn_count", out BinaryData? priorTurnData)
                            ? priorTurnData.ToObjectFromJson<int>() + 1
                            : 1;

                    if (string.Equals(inputText.Trim(), "done", StringComparison.OrdinalIgnoreCase))
                    {
                        int completedTurns;
                        if (repeatedResponse
                            && state.TryGetValue("terminated", out BinaryData? repeatedTerminatedData)
                            && repeatedTerminatedData.ToObjectFromJson<bool>())
                        {
                            completedTurns = state.TryGetValue("completed_turns", out BinaryData? completedData)
                                ? completedData.ToObjectFromJson<int>()
                                : 0;
                        }
                        else
                        {
                            completedTurns = Math.Max(turnCount - 1, 0);
                            await store.SetItemAsync(
                                "state",
                                new Dictionary<string, BinaryData>
                                {
                                    ["turn_count"] = BinaryData.FromObjectAsJson(completedTurns),
                                    ["last_response_id"] = BinaryData.FromObjectAsJson(context.ResponseId),
                                    ["terminated"] = BinaryData.FromObjectAsJson(true),
                                    ["completed_turns"] = BinaryData.FromObjectAsJson(completedTurns),
                                },
                                cancellationToken: CancellationToken.None);
                        }

                        return $"Done! Session complete after {completedTurns} turns on {chainId}. Goodbye!";
                    }

                    // Framework-managed conversation history.
                    IReadOnlyList<OutputItem> history = await context.GetHistoryAsync(ct);

                    string reply =
                        $"Turn {turnCount}: You said '{inputText}'. " +
                        $"I have {history.Count} items of conversation context.";

                    await store.SetItemAsync(
                        "state",
                        new Dictionary<string, BinaryData>
                        {
                            ["turn_count"] = BinaryData.FromObjectAsJson(turnCount),
                            ["last_response_id"] = BinaryData.FromObjectAsJson(context.ResponseId),
                        },
                        cancellationToken: CancellationToken.None);

                    return reply;
                });
            }
        }

        #endregion
    }
}
