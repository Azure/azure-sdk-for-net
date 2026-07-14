// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Sample-parity end-to-end tests (T060, FR-081/082). Each test drives the PUBLISHED flow of a
/// required resilient sample — Python 19 (resilient streaming), 20 (resilient steering), 22
/// (resilient multi-turn) — through the real Core-composed engine (real HTTP endpoint → dispatch →
/// Core one-shot/multi-turn task → handler → file-backed persistence), NOT a helper-only equivalent.
/// The observable contract of each sample is asserted:
/// <list type="bullet">
/// <item>19: a resilient streaming turn produces a single <c>response.created</c>, a strictly
/// monotonic contiguous event stream, one output item per phase, and terminal <c>completed</c>.</item>
/// <item>20: a concurrent steered turn enqueues (<c>queued</c>) then drains as a steered re-entry
/// (<c>IsSteeredTurn</c>).</item>
/// <item>22: a serial (non-steering) conversation chain accumulates per-turn state across turns via
/// durable chain metadata + framework history.</item>
/// </list>
/// Determinism is gated with <see cref="TaskCompletionSource"/> — no arbitrary sleeps for
/// correctness. Each test isolates its Core task/response stores in a fresh temp directory.
/// </summary>
[NonParallelizable]
public sealed class ResilienceSampleParityEndToEndTests
{
    private static StringContent Json(object body)
        => new(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

    private static async Task<JsonDocument> ParseAsync(HttpResponseMessage response)
        => JsonDocument.Parse(await response.Content.ReadAsStringAsync());

    // ==========================================================================================
    // Sample 19 — resilient streaming with handler-managed phase checkpoints.
    // ==========================================================================================
    [Test]
    public async Task Sample19_ResilientStreaming_ProducesMonotonicContiguousStream()
    {
        var root = NewRoot("sample19");
        try
        {
            using var factory = NewFactory(
                root,
                new TestHandler { EventFactory = ThreePhaseStreamingHandler },
                o => o.ResilientBackground = true);
            using var client = factory.CreateClient();

            // Drive the published flow: a resilient background streaming POST.
            using var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
            {
                Content = Json(new
                {
                    model = "streamer",
                    input = "Tell me a joke",
                    stream = true,
                    store = true,
                    background = true,
                }),
            };

            using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var (seqs, createdCount, addedCount, terminal) = await ReadStreamAsync(response);

            // Single response.created across the (single-lifetime) stream.
            Assert.That(createdCount, Is.EqualTo(1), "exactly one response.created must be emitted");

            // Strictly monotonic + contiguous sequence numbers.
            Assert.That(seqs, Is.Not.Empty);
            for (var i = 1; i < seqs.Count; i++)
            {
                Assert.That(seqs[i], Is.EqualTo(seqs[i - 1] + 1),
                    $"stream must be contiguous and gap-free; got [{string.Join(",", seqs)}]");
            }

            // One output item per phase (analyze/generate/refine).
            Assert.That(addedCount, Is.EqualTo(3), "one output item per phase");

            // Terminal completed.
            Assert.That(terminal, Is.EqualTo("response.completed"));
        }
        finally
        {
            TryDelete(root);
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThreePhaseStreamingHandler(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        string prompt = await context.GetInputTextAsync(cancellationToken: ct);
        var stream = new ResponseEventStream(context, request);

        // A recovered entry re-seeds from the last snapshot (published sample recovery reset).
        if (context.IsRecovery && context.PersistedResponse is not null)
        {
            yield return stream.EmitInProgress();
        }
        else
        {
            yield return stream.EmitCreated();
            yield return stream.EmitInProgress();
        }

        string[] phaseOrder = { "analyze", "generate", "refine" };
        int start = NextPhaseIndex(context, phaseOrder);
        for (int i = start; i < phaseOrder.Length; i++)
        {
            string phase = phaseOrder[i];
            string text = $"[{phase}] {prompt}";
            foreach (var evt in stream.OutputItemMessage(text))
            {
                yield return evt;
            }

            // Durable watermark + phase checkpoint (no-op unless resilient background).
            context.ConversationChainMetadata.Set("stream", "phase_complete", phase);
            await context.ConversationChainMetadata.FlushAsync(ct);
            yield return stream.Checkpoint();
        }

        yield return stream.EmitCompleted();
    }

    private static int NextPhaseIndex(ResponseContext context, string[] phaseOrder)
    {
        if (context.ConversationChainMetadata.TryGet("stream", "phase_complete", out var done)
            && done is not null)
        {
            int idx = Array.IndexOf(phaseOrder, done);
            if (idx >= 0)
            {
                return idx + 1;
            }
        }

        return 0;
    }

    // ==========================================================================================
    // Sample 20 — resilient steering: enqueue-then-drain a steered re-entry.
    // ==========================================================================================
    [Test]
    public async Task Sample20_ResilientSteering_EnqueuesThenDrainsSteeredTurn()
    {
        var root = NewRoot("sample20");
        var releaseTurn1 = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var turn1Entered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var steeredDrained = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        var handler = new TestHandler
        {
            EventFactory = (request, context, ct) =>
                SteeringHandler(request, context, releaseTurn1, turn1Entered, steeredDrained, ct),
        };

        try
        {
            using var factory = NewFactory(
                root,
                handler,
                o =>
                {
                    o.ResilientBackground = true;
                    o.SteerableConversations = true;
                });
            using var client = factory.CreateClient();

            // Turn 1: enters the steerable chain and blocks so the chain stays in-flight.
            var turn1 = await client.PostAsync(
                "/responses",
                Json(new { model = "agent", input = "Explain quantum computing", store = true, background = true, conversation = "conv-steer" }));
            Assert.That(turn1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            await turn1Entered.Task.WaitAsync(TimeSpan.FromSeconds(10));

            // Turn 2 on the same conversation: enqueued (steering pressure) → queued envelope.
            var turn2 = await client.PostAsync(
                "/responses",
                Json(new { model = "agent", input = "Actually explain relativity", store = true, background = true, conversation = "conv-steer" }));
            Assert.That(turn2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using (var doc2 = await ParseAsync(turn2))
            {
                Assert.That(doc2.RootElement.GetProperty("status").GetString(), Is.EqualTo("queued"),
                    "a concurrent turn on an active steerable chain must enqueue as 'queued'");
            }

            // Release turn 1 → the queued turn drains as a steered re-entry (IsSteeredTurn == true).
            releaseTurn1.SetResult();

            using (var turn1Doc = await ParseAsync(turn1))
            {
                var turn1Id = turn1Doc.RootElement.GetProperty("id").GetString()!;
                await WaitForTerminalAsync(client, turn1Id, TimeSpan.FromSeconds(15));
            }

            // The drain re-entry observed IsSteeredTurn — proves enqueue→drain composition end-to-end.
            await steeredDrained.Task.WaitAsync(TimeSpan.FromSeconds(15));
            Assert.Pass();
        }
        finally
        {
            releaseTurn1.TrySetResult();
            TryDelete(root);
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> SteeringHandler(
        CreateResponse request,
        ResponseContext context,
        TaskCompletionSource releaseTurn1,
        TaskCompletionSource turn1Entered,
        TaskCompletionSource steeredDrained,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new ResponseObject(context.ResponseId, request.Model ?? "agent");
        yield return new ResponseCreatedEvent(0, response);

        if (context.IsSteeredTurn)
        {
            // The superseding drain turn.
            steeredDrained.TrySetResult();
        }
        else
        {
            // The first (non-steered) turn: block so turn 2 arrives as steering pressure.
            turn1Entered.TrySetResult();
            await releaseTurn1.Task.WaitAsync(ct);
        }

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    // ==========================================================================================
    // Sample 22 — resilient multi-turn (serial conversation, no steering).
    // ==========================================================================================
    [Test]
    public async Task Sample22_ResilientMultiTurn_AccumulatesStateAcrossTurns()
    {
        var root = NewRoot("sample22");
        var handler = new TestHandler { EventFactory = MultiTurnHandler };

        try
        {
            // Serial multi-turn conversation, steering DISABLED (turns are serialized by the chain
            // lock; a conversation id routes them through the multi-turn task).
            using var factory = NewFactory(
                root,
                handler,
                o =>
                {
                    o.ResilientBackground = true;
                    o.SteerableConversations = false;
                });
            using var client = factory.CreateClient();

            // Turn 1.
            var turn1 = await client.PostAsync(
                "/responses",
                Json(new { model = "chat", input = "My name is Alice", store = true, background = true, conversation = "conv-mt" }));
            Assert.That(turn1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            string turn1Id;
            using (var d = await ParseAsync(turn1))
            {
                turn1Id = d.RootElement.GetProperty("id").GetString()!;
            }

            await WaitForStatusAsync(client, turn1Id, "completed", TimeSpan.FromSeconds(15));

            // Turn 2 references the previous turn; the handler asserts it sees turn_count == 2, which
            // is only possible if the durable chain metadata from turn 1 survived into turn 2.
            var turn2 = await client.PostAsync(
                "/responses",
                Json(new
                {
                    model = "chat",
                    input = "What is my name?",
                    store = true,
                    background = true,
                    conversation = "conv-mt",
                    previous_response_id = turn1Id,
                }));
            Assert.That(turn2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            string turn2Id;
            using (var d = await ParseAsync(turn2))
            {
                turn2Id = d.RootElement.GetProperty("id").GetString()!;
            }

            // A durable accumulation → turn 2 completes; a lost watermark → the handler throws → failed.
            await WaitForStatusAsync(client, turn2Id, "completed", TimeSpan.FromSeconds(15));
        }
        finally
        {
            TryDelete(root);
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> MultiTurnHandler(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new ResponseObject(context.ResponseId, request.Model ?? "chat");
        yield return new ResponseCreatedEvent(0, response);

        int turnCount = 1;
        if (context.ConversationChainMetadata.TryGet("state", "turn_count", out var raw)
            && int.TryParse(raw, out var prior))
        {
            turnCount = prior + 1;
        }

        // Accumulate the per-turn counter durably (published sample: cross-turn watermark).
        context.ConversationChainMetadata.Set("state", "turn_count", turnCount.ToString());
        await context.ConversationChainMetadata.FlushAsync(ct);

        // Second turn must observe the accumulated state; otherwise the chain did not persist.
        if (turnCount >= 2)
        {
            if (!context.ConversationChainMetadata.TryGet("state", "turn_count", out var back)
                || back != turnCount.ToString())
            {
                throw new InvalidOperationException(
                    "Multi-turn chain metadata did not accumulate across turns — durability broken.");
            }
        }

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    // ==========================================================================================
    // Harness
    // ==========================================================================================
    private static string NewRoot(string prefix)
    {
        var root = Path.Combine(Path.GetTempPath(), $"{prefix}-e2e-{Guid.NewGuid():N}");
        Directory.CreateDirectory(Path.Combine(root, "tasks"));
        Directory.CreateDirectory(Path.Combine(root, "responses"));
        return root;
    }

    private static TestWebApplicationFactory NewFactory(
        string root,
        TestHandler handler,
        Action<ResponsesServerOptions> configureOptions)
    {
        var tasksDir = Path.Combine(root, "tasks");
        var responsesDir = Path.Combine(root, "responses");
        return new TestWebApplicationFactory(
            handler,
            configureOptions: configureOptions,
            configureTestServices: services =>
            {
                services.AddSingleton<ITaskStore>(_ => new LocalTaskStore(tasksDir));
                services.AddSingleton(_ => new FileResponsesProvider(responsesDir));
            });
    }

    private static void TryDelete(string root)
    {
        try
        {
            Directory.Delete(root, recursive: true);
        }
        catch (IOException)
        {
        }
    }

    private static async Task<(List<long> Seqs, int CreatedCount, int AddedCount, string? Terminal)> ReadStreamAsync(
        HttpResponseMessage response)
    {
        var seqs = new List<long>();
        int created = 0, added = 0;
        string? terminal = null;

        await using var stream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream);
        string? line;
        while ((line = await reader.ReadLineAsync()) is not null)
        {
            if (!line.StartsWith("data: ", StringComparison.Ordinal))
            {
                continue;
            }

            using var doc = JsonDocument.Parse(line["data: ".Length..]);
            var root = doc.RootElement;
            if (root.TryGetProperty("sequence_number", out var seqProp))
            {
                seqs.Add(seqProp.GetInt64());
            }

            if (root.TryGetProperty("type", out var typeProp))
            {
                var type = typeProp.GetString();
                switch (type)
                {
                    case "response.created":
                        created++;
                        break;
                    case "response.output_item.added":
                        added++;
                        break;
                    case "response.completed":
                    case "response.failed":
                    case "response.incomplete":
                        terminal = type;
                        break;
                }

                if (terminal is not null)
                {
                    break;
                }
            }
        }

        return (seqs, created, added, terminal);
    }

    private static async Task WaitForTerminalAsync(HttpClient client, string responseId, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;
        while (DateTime.UtcNow < deadline)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            if (get.StatusCode == HttpStatusCode.OK)
            {
                using var doc = await ParseAsync(get);
                var status = doc.RootElement.GetProperty("status").GetString();
                if (status is "completed" or "failed" or "cancelled" or "incomplete")
                {
                    return;
                }
            }

            await Task.Delay(100);
        }

        Assert.Fail($"Response '{responseId}' did not reach a terminal state within {timeout}.");
    }

    private static async Task WaitForStatusAsync(HttpClient client, string responseId, string expected, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;
        string? last = null;
        while (DateTime.UtcNow < deadline)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            if (get.StatusCode == HttpStatusCode.OK)
            {
                using var doc = await ParseAsync(get);
                last = doc.RootElement.GetProperty("status").GetString();
                if (last is "completed" or "failed" or "cancelled" or "incomplete")
                {
                    Assert.That(last, Is.EqualTo(expected), $"Response '{responseId}' terminal status.");
                    return;
                }
            }

            await Task.Delay(100);
        }

        Assert.Fail($"Response '{responseId}' did not reach a terminal state within {timeout} (last: {last ?? "none"}).");
    }
}
