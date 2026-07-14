// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing the resilient responses samples
    /// (Sample19_ResilientStreaming.md, Sample20_ResilientSteering.md,
    /// Sample22_ResilientMultiTurn.md). These are compiled to prevent the public
    /// API surface used by those samples from silently drifting. Every member
    /// referenced here is confirmed against
    /// <c>api/Azure.AI.AgentServer.Responses.net8.0.cs</c>.
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
        public void Register_ResilientBackground()
        {
            #region Snippet:Responses_Sample19_RegisterResilientBackground

            var services = new ServiceCollection();
            services.AddLogging();

            // Resilient background responses are composed on the Core durable-task /
            // event-stream primitives; enabling the option is all the handler needs.
            services.AddResponsesServer(o => o.ResilientBackground = true);
            services.AddScoped<ResponseHandler, ResilientStreamingHandler>();

            #endregion

            Assert.That(services, Is.Not.Empty);
        }

        [Test]
        public void Register_SteerableConversations()
        {
            #region Snippet:Responses_Sample20_RegisterSteerableConversations

            var services = new ServiceCollection();
            services.AddLogging();

            services.AddResponsesServer(o =>
            {
                o.ResilientBackground = true;
                o.SteerableConversations = true;
            });
            services.AddScoped<ResponseHandler, ResilientSteeringHandler>();

            #endregion

            Assert.That(services, Is.Not.Empty);
        }

        [Test]
        public void Register_SerialMultiTurn()
        {
            #region Snippet:Responses_Sample22_RegisterSerialMultiTurn

            var services = new ServiceCollection();
            services.AddLogging();

            // Serial multi-turn: resilient background without steering keeps turns
            // serialized by the conversation lock.
            services.AddResponsesServer(o =>
            {
                o.ResilientBackground = true;
                o.SteerableConversations = false;
            });
            services.AddScoped<ResponseHandler, ResilientMultiTurnHandler>();

            #endregion

            Assert.That(services, Is.Not.Empty);
        }

        #region Snippet:Responses_Sample19_ResilientStreamingHandler

        // Sample 19 — resilient streaming with handler-managed phase checkpoints.
        // Checkpoints are managed entirely via context.ConversationChainMetadata; the
        // handler seeds a ResponseEventStream and resumes at the first incomplete phase.
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
                // client-visible reset carrying the seeded prior output. (Mirrors Python.)
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

                    // Stamp the phase watermark and durably flush it, then checkpoint.
                    context.ConversationChainMetadata.Set("stream", "phase_complete", phase);
                    await context.ConversationChainMetadata.FlushAsync(cancellationToken);

                    // Persist a durable snapshot at the phase boundary
                    // (no-op unless resilient background).
                    yield return stream.Checkpoint();
                }

                yield return stream.EmitCompleted();
            }

            private static int NextPhaseIndex(ResponseContext context)
            {
                if (context.ConversationChainMetadata.TryGet("stream", "phase_complete", out var done)
                    && done is not null)
                {
                    int idx = Array.IndexOf(PhaseOrder, done);
                    if (idx >= 0)
                    {
                        return idx + 1;
                    }
                }

                return 0;
            }
        }

        #endregion

        #region Snippet:Responses_Sample20_ResilientSteeringHandler

        // Sample 20 — steering composed with cancellation × recovery. A superseded turn
        // observes IsSteeredTurn on the re-entry and drains the enqueued input.
        public class ResilientSteeringHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                string prompt = await context.GetInputTextAsync(cancellationToken: cancellationToken);

                // A steered re-entry drains any pending superseding input.
                bool steered = context.IsSteeredTurn;
                int pending = context.PendingInputCount;

                int turnCount = 1;
                if (context.ConversationChainMetadata.TryGet("state", "turn_count", out var raw)
                    && int.TryParse(raw, out var prior))
                {
                    turnCount = prior + 1;
                }

                context.ConversationChainMetadata.Set("state", "turn_count", turnCount.ToString());
                context.ConversationChainMetadata.Set("state", "steered", (steered && pending >= 0).ToString());
                await context.ConversationChainMetadata.FlushAsync(cancellationToken);

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
        // written through a MetadataNamespace on the stable ConversationChainId.
        public class ResilientMultiTurnHandler : ResponseHandler
        {
            public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                CancellationToken cancellationToken)
            {
                return new TextResponse(context, request, createText: async ct =>
                {
                    string inputText = await context.GetInputTextAsync(cancellationToken: ct);

                    // Durable per-conversation state is scoped to the stable chain id.
                    ConversationChainMetadataNamespace state = context.MetadataNamespace("state");
                    string chainId = context.ConversationChainId;

                    int turnCount = 1;
                    if (state.TryGet("turn_count", out var raw) && int.TryParse(raw, out var prior))
                    {
                        turnCount = prior + 1;
                    }

                    if (string.Equals(inputText.Trim(), "done", StringComparison.OrdinalIgnoreCase))
                    {
                        return $"Done! Session complete after {turnCount - 1} turns on {chainId}. Goodbye!";
                    }

                    // Framework-managed conversation history.
                    IReadOnlyList<OutputItem> history = await context.GetHistoryAsync(ct);

                    string reply =
                        $"Turn {turnCount}: You said '{inputText}'. " +
                        $"I have {history.Count} items of conversation context.";

                    state.Set("turn_count", turnCount.ToString());
                    await state.FlushAsync(ct);

                    return reply;
                });
            }
        }

        #endregion
    }
}
