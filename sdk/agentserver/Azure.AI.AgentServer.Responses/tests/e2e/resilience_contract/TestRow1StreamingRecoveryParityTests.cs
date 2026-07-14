// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Row 1, Path C streaming recovery parity (US3, T078). Mirrors the Python
/// <c>test_output_item_slot_reconciliation.py</c> and <c>test_reset_event_content.py</c> contracts:
/// on a crash-recovery re-invocation of a streaming response the resumed builder must (a) allocate
/// new output-item slots <em>past</em> the already-emitted (seeded) items so indices never collide,
/// and (b) emit a <c>response.in_progress</c> reset event carrying the exact prior output items as the
/// client-visible resumption payload. Resilience must also engage even while only keep-alive frames
/// have been emitted (the recovery entry is written at acceptance, before the first real event),
/// which the sibling <c>RecoveryRegistrationLifecycleTests</c> covers.
/// </summary>
[NonParallelizable]
public sealed class TestRow1StreamingRecoveryParityTests : CrashRecoveryE2ETestBase
{
    [Test]
    public async Task RecoveredStream_NewOutputItems_ContinuePastSeededSlots()
    {
        var responseId = IdGenerator.NewResponseId();
        // Prior lifetime emitted two output items (slots 0 and 1) before the crash.
        await SeedDurableEnvelopeWithOutputAsync(responseId, outputItems: 2);
        await SeedInterruptedStreamAsync(responseId, outputItems: 2);
        await RegisterStreamingReinvokeAsync(responseId);

        var completed = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => ResumeWithOneNewItem(ctx, completed, ct),
        };

        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await completed.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await WaitForStatusAsync(client, responseId, "completed");

        var body = await ReadFullStreamAsync(client, responseId);

        // The recovered builder must allocate the next slot at index 2 (past the two seeded items),
        // never re-using index 0 or 1.
        var addedIndices = OutputItemAddedIndices(body);
        Assert.That(addedIndices, Does.Contain(2L),
            $"recovered output item must land at slot 2 (past seeded 0,1); got [{string.Join(",", addedIndices)}]");
        Assert.That(addedIndices.Count(i => i == 2L), Is.EqualTo(1), "no slot collision at the reused index");

        // The final durable response envelope must carry all three items (two seeded + one new).
        var get = await client.GetAsync($"/responses/{responseId}");
        using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("output").GetArrayLength(), Is.EqualTo(3),
            "recovered response must contain the two seeded items plus the one newly emitted item");
    }

    [Test]
    public async Task RecoveredStream_ResetInProgress_CarriesExactPriorOutput()
    {
        var responseId = IdGenerator.NewResponseId();
        await SeedDurableEnvelopeWithOutputAsync(responseId, outputItems: 2);
        await SeedInterruptedStreamAsync(responseId, outputItems: 2);
        await RegisterStreamingReinvokeAsync(responseId);

        var completed = new TaskCompletionSource();
        var handler = new TestHandler
        {
            EventFactory = (_, ctx, ct) => ResumeWithOneNewItem(ctx, completed, ct),
        };

        using var factory = NewRecoveringHost(handler);
        using var client = factory.CreateClient();

        await completed.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await WaitForStatusAsync(client, responseId, "completed");

        var body = await ReadFullStreamAsync(client, responseId);

        var resetPayload = ExtractDataForEvent(body, "response.in_progress");
        Assert.That(resetPayload, Is.Not.Null, "recovery must emit a response.in_progress reset event");
        using var resetDoc = JsonDocument.Parse(resetPayload!);
        var output = resetDoc.RootElement.GetProperty("response").GetProperty("output");

        // The reset payload must carry exactly the two prior (seeded) items with their original ids.
        Assert.That(output.GetArrayLength(), Is.EqualTo(2),
            "the reset in_progress must carry exactly the seeded prior output items");
        var ids = output.EnumerateArray().Select(e => e.GetProperty("id").GetString()).ToList();
        Assert.That(ids, Is.EquivalentTo(new[] { "msg_seed_0", "msg_seed_1" }));
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ResumeWithOneNewItem(
        ResponseContext ctx,
        TaskCompletionSource completed,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        Assert.That(ctx.IsRecovery, Is.True);
        var stream = new ResponseEventStream(ctx, ctx.PersistedResponse!);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // One new item — the builder must allocate the slot past the seeded items.
        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();
        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("resumed");
        yield return text.EmitTextDone("resumed");
        yield return text.EmitDone();
        yield return message.EmitDone();

        await Task.Yield();
        yield return stream.EmitCompleted();
        completed.TrySetResult();
    }

    private static async Task<string> ReadFullStreamAsync(HttpClient client, string responseId)
    {
        using var response = await client.GetAsync($"/responses/{responseId}?stream=true");
        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        return await response.Content.ReadAsStringAsync();
    }

    private static List<long> OutputItemAddedIndices(string sseBody)
    {
        var indices = new List<long>();
        var lines = sseBody.Split('\n');
        for (var i = 0; i < lines.Length - 1; i++)
        {
            if (lines[i] == "event: response.output_item.added" &&
                lines[i + 1].StartsWith("data: ", StringComparison.Ordinal))
            {
                using var doc = JsonDocument.Parse(lines[i + 1]["data: ".Length..]);
                if (doc.RootElement.TryGetProperty("output_index", out var idx))
                {
                    indices.Add(idx.GetInt64());
                }
            }
        }

        return indices;
    }

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
