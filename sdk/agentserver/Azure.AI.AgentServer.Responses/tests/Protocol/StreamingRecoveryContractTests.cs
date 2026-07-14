// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Streaming recovery contract (US3, T031). After a crash mid-stream, the recovered lifetime
/// re-emits <c>response.created</c> and a <c>response.in_progress</c> reset. The durable stream that
/// a client replays must contain <b>exactly one</b> <c>response.created</c> across both lifetimes
/// (the store-level idempotent-create gate has a stream-level analogue: the recovered created is not
/// re-appended), the recovered events must carry <b>monotonically increasing</b> sequence numbers
/// that continue past the pre-crash watermark, and the <c>response.in_progress</c> reset must carry
/// the resumption payload (prior output items).
/// </summary>
[NonParallelizable]
public sealed class StreamingRecoveryContractTests : CrashRecoveryE2ETestBase
{
    [Test]
    public async Task RecoveredStream_HasSingleCreated_ResetInProgress_AndMonotonicSeqs()
    {
        var responseId = IdGenerator.NewResponseId();

        // Prior (crashed) lifetime: durable envelope with one checkpointed output item ...
        await SeedDurableEnvelopeWithOutputAsync(responseId, outputItems: 1);
        // ... and a durable SSE stream holding created(0) + item added(1) + item done(2), no
        // completion sentinel (the process died mid-stream).
        await SeedInterruptedStreamAsync(responseId);
        await RegisterStreamingReinvokeAsync(responseId);

        var completed = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (req, ctx, ct) =>
            {
                Assert.That(ctx.IsRecovery, Is.True);
                return RecoveredStreamingLifecycle(ctx, req, completed, ct);
            },
        };

        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await completed.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await WaitForStatusAsync(client, responseId, "completed");

        // Replay the full durable stream (no cursor).
        var body = await ReadFullStreamAsync(client, responseId);

        var createdCount = Regex.Matches(body, @"^event: response\.created$", RegexOptions.Multiline).Count;
        Assert.That(createdCount, Is.EqualTo(1),
            "the durable stream must contain exactly one response.created across both lifetimes");

        Assert.That(body, Does.Contain("event: response.in_progress"),
            "recovery must emit a response.in_progress reset onto the durable stream");
        Assert.That(body, Does.Contain("event: response.completed"));

        // Reset ordering: the single response.created must appear BEFORE the response.in_progress
        // reset (a client that reconnects sees created → in_progress → resumed items → completed),
        // never a reset that precedes the lifecycle-opening created.
        var createdIdx = body.IndexOf("event: response.created", StringComparison.Ordinal);
        var inProgressIdx = body.IndexOf("event: response.in_progress", StringComparison.Ordinal);
        var completedIdx = body.IndexOf("event: response.completed", StringComparison.Ordinal);
        Assert.That(createdIdx, Is.GreaterThanOrEqualTo(0));
        Assert.That(inProgressIdx, Is.GreaterThan(createdIdx),
            "response.in_progress reset must follow response.created");
        Assert.That(completedIdx, Is.GreaterThan(inProgressIdx),
            "response.completed must be the terminal event, after the in_progress reset");

        // Sequence numbers across the whole replayed stream must be strictly increasing and contiguous.
        var seqs = ParseSequenceNumbers(body);
        Assert.That(seqs.Count, Is.GreaterThan(3));
        for (var i = 1; i < seqs.Count; i++)
        {
            Assert.That(seqs[i], Is.EqualTo(seqs[i - 1] + 1),
                $"replayed sequence numbers must be contiguous; got [{string.Join(",", seqs)}]");
        }

        // The reset in_progress must carry the resumption payload (the prior output item).
        var resetPayload = ExtractDataForEvent(body, "response.in_progress");
        Assert.That(resetPayload, Is.Not.Null);
        using var resetDoc = System.Text.Json.JsonDocument.Parse(resetPayload!);
        Assert.That(resetDoc.RootElement.GetProperty("response").GetProperty("output").GetArrayLength(),
            Is.GreaterThanOrEqualTo(1), "the reset in_progress must carry the seeded prior output items");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> RecoveredStreamingLifecycle(
        ResponseContext ctx,
        CreateResponse request,
        TaskCompletionSource completed,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, ctx.PersistedResponse!);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Resume phase 2 past the seeded watermark.
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();
        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("phase-1");
        yield return text.EmitTextDone("phase-1");
        yield return text.EmitDone();
        yield return message.EmitDone();

        await Task.Yield();
        yield return stream.EmitCompleted();
        completed.TrySetResult();
    }

    private static async Task<string> ReadFullStreamAsync(HttpClient client, string responseId)
    {
        using var response = await client.GetAsync($"/responses/{responseId}?stream=true");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        return await response.Content.ReadAsStringAsync();
    }

    private static List<long> ParseSequenceNumbers(string sseBody)
        => sseBody.Split('\n')
            .Where(l => l.StartsWith("data: ", StringComparison.Ordinal))
            .Select(l => System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(l["data: ".Length..]))
            .Where(e => e.TryGetProperty("sequence_number", out _))
            .Select(e => e.GetProperty("sequence_number").GetInt64())
            .ToList();

    private static string? ExtractDataForEvent(string sseBody, string eventType)
    {
        var lines = sseBody.Split('\n');
        for (var i = 0; i < lines.Length - 1; i++)
        {
            if (lines[i] == $"event: {eventType}" && lines[i + 1].StartsWith("data: ", StringComparison.Ordinal))
            {
                return lines[i + 1]["data: ".Length..];
            }
        }

        return null;
    }
}
