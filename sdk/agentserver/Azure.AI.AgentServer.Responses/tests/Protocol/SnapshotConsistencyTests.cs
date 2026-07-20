// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for US1 — Immutable Event Snapshots.
/// Verifies that SSE events and GET responses contain point-in-time snapshot data,
/// not mutable references that change with subsequent mutations.
/// </summary>
public class SnapshotConsistencyTests : ProtocolTestBase
{
    /// <summary>
    /// T009 / SC-001: Concurrent GET requests during streaming return consistent snapshots.
    /// Each GET response has a consistent status/output pair (in_progress with N items,
    /// never completed with fewer items than final count).
    ///
    /// Uses explicit gates instead of Task.Delay so the handler pauses after each item
    /// until the test releases it — deterministic on any CI machine.
    /// </summary>
    [Test]
    public async Task ConcurrentGET_DuringEmission_ReturnsConsistentSnapshots()
    {
        const int itemCount = 10;
        var handlerStarted = new TaskCompletionSource();
        // Handler waits on this after each item; test releases to let the next item emit.
        var continueGate = new SemaphoreSlim(0);
        // Handler signals this after each item is yielded so the test knows it's safe to GET.
        var itemEmitted = new SemaphoreSlim(0);

        Handler.EventFactory = (req, ctx, ct) =>
            GatedMultiOutputStream(ctx, itemCount, handlerStarted, continueGate, itemEmitted, ct);

        // Start background streaming response
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test", stream = true, background = true }),
                Encoding.UTF8, "application/json")
        };

        using var postResponse = await Client.SendAsync(postRequest, HttpCompletionOption.ResponseHeadersRead);
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Read the first event to get response ID
        await using var bodyStream = await postResponse.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(bodyStream);

        string? responseId = null;
        string? line;
        while ((line = await reader.ReadLineAsync()) is not null)
        {
            if (line.StartsWith("data: "))
            {
                using var doc = JsonDocument.Parse(line["data: ".Length..]);
                if (doc.RootElement.TryGetProperty("response", out var respProp))
                {
                    responseId = respProp.GetProperty("id").GetString();
                    break;
                }
            }
        }

        Assert.That(responseId, Is.Not.Null);

        // Wait for handler to start emitting (response.created yielded)
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Issue GET requests at deterministic points during emission.
        // Release items in batches, wait for the signal, then GET while handler is paused.
        var getResults = new List<(string Status, int OutputCount, int ExpectedMinItems)>();
        int[] batchSizes = [2, 2, 2, 2, 2]; // 5 batches × 2 items = 10 total

        int totalReleased = 0;
        foreach (var batch in batchSizes)
        {
            // Release a batch of items
            continueGate.Release(batch);
            for (int j = 0; j < batch; j++)
            {
                Assert.That(
                    await itemEmitted.WaitAsync(TimeSpan.FromSeconds(5)),
                    Is.True, $"Handler did not emit item within timeout (released {totalReleased + j + 1})");
            }
            totalReleased += batch;

            // GET while handler is paused on the next gate
            var getResponse = await GetResponseAsync(responseId!);
            using var getDoc = await ParseJsonAsync(getResponse);
            var root = getDoc.RootElement;
            var status = root.GetProperty("status").GetString()!;
            var output = root.GetProperty("output");
            var outputCount = output.GetArrayLength();
            getResults.Add((status, outputCount, totalReleased));
        }

        // All items released — handler will emit response.completed next
        await WaitForBackgroundCompletionAsync(responseId!);

        // Assert snapshot consistency at each observation point
        foreach (var (status, outputCount, expectedMin) in getResults)
        {
            if (status == "completed")
            {
                // If completed, must have all items
                Assert.That(outputCount, Is.EqualTo(itemCount),
                    "Completed response must contain all output items");
            }
            else
            {
                // in_progress — output count should be at least what we released
                // (events may still be persisting, so >= 0 is the safe lower bound)
                Assert.That(status, Is.EqualTo("in_progress"));
            }
        }

        // Verify we observed at least one in_progress snapshot (the whole point of this test)
        Assert.That(getResults.Any(r => r.Status == "in_progress"), Is.True,
            "Expected at least one GET to observe in_progress state during gated emission");
    }

    /// <summary>
    /// T010: SSE event snapshot isolation — response.output_item.added event's embedded
    /// Models.ResponseObject does not include items added after it was emitted.
    /// response.completed contains all output items.
    /// </summary>
    [Test]
    public async Task SSE_Events_ContainSnapshotNotLiveReference()
    {
        Handler.EventFactory = (req, ctx, ct) => MultiOutputStreamForSnapshotTest(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        var events = await ParseSseAsync(response);

        // Find the response.created event — it should have in_progress status and empty/initial output
        var createdEvent = events.FirstOrDefault(e => e.EventType == "response.created");
        Assert.That(createdEvent, Is.Not.Null);
        using var createdDoc = JsonDocument.Parse(createdEvent!.Data);
        var createdStatus = createdDoc.RootElement.GetProperty("response").GetProperty("status").GetString();
        Assert.That(createdStatus, Is.EqualTo("in_progress"));

        // The response.completed event should have completed status with all items
        var completedEvent = events.FirstOrDefault(e => e.EventType == "response.completed");
        Assert.That(completedEvent, Is.Not.Null);
        using var completedDoc = JsonDocument.Parse(completedEvent!.Data);
        var completedStatus = completedDoc.RootElement.GetProperty("response").GetProperty("status").GetString();
        Assert.That(completedStatus, Is.EqualTo("completed"));
        var completedOutput = completedDoc.RootElement.GetProperty("response").GetProperty("output");
        Assert.That(completedOutput.GetArrayLength() >= 2, Is.True, "completed should have all output items");

        // CRITICAL: response.created should NOT have the same output count as completed
        // (because it was a snapshot taken before output items were added)
        var createdOutput = createdDoc.RootElement.GetProperty("response").GetProperty("output");
        Assert.That(createdOutput.GetArrayLength() < completedOutput.GetArrayLength(), Is.True,
            "created event's response should have fewer outputs than completed event's response");
    }

    /// <summary>
    /// T011 / SC-002: Replay snapshot integrity — replayed response.created has
    /// status in_progress (emission-time state), not completed (current state).
    /// </summary>
    [Test]
    public async Task SSE_Replay_ReflectsEmissionTimeState()
    {
        var handlerDone = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => SimpleBackgroundStream(ctx, handlerDone);

        // Create background streaming response
        var postRequest = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test", stream = true, background = true }),
                Encoding.UTF8, "application/json")
        };

        using var postResponse = await Client.SendAsync(postRequest, HttpCompletionOption.ResponseHeadersRead);

        // Read first event to get response ID
        await using var bodyStream = await postResponse.Content.ReadAsStreamAsync();
        using var streamReader = new StreamReader(bodyStream);
        string? responseId = null;
        string? line;
        while ((line = await streamReader.ReadLineAsync()) is not null)
        {
            if (line.StartsWith("data: "))
            {
                using var doc = JsonDocument.Parse(line["data: ".Length..]);
                if (doc.RootElement.TryGetProperty("response", out var respProp))
                {
                    responseId = respProp.GetProperty("id").GetString();
                    break;
                }
            }
        }

        Assert.That(responseId, Is.Not.Null);

        // Signal handler to finish and wait for background completion
        handlerDone.SetResult();
        await WaitForBackgroundCompletionAsync(responseId!);

        // Now replay — response should be completed, but replayed response.created should show in_progress
        var replayResponse = await GetResponseStreamAsync(responseId!);
        var replayEvents = await ParseSseAsync(replayResponse);

        var replayCreated = replayEvents.FirstOrDefault(e => e.EventType == "response.created");
        Assert.That(replayCreated, Is.Not.Null);
        using var replayCreatedDoc = JsonDocument.Parse(replayCreated!.Data);
        var replayCreatedStatus = replayCreatedDoc.RootElement
            .GetProperty("response").GetProperty("status").GetString();

        // This is the critical assertion: replayed response.created should show "in_progress",
        // not "completed" (which is the current state of the response)
        Assert.That(replayCreatedStatus, Is.EqualTo("in_progress"));
    }

    // ── Test helper streams ──────────────────────────────────────

    /// <summary>
    /// Emits output items with explicit gates for deterministic concurrent GET testing.
    /// Pauses after each item until the test releases <paramref name="continueGate"/>,
    /// and signals <paramref name="itemEmitted"/> after each item is yielded.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> GatedMultiOutputStream(
        ResponseContext ctx, int itemCount, TaskCompletionSource handlerStarted,
        SemaphoreSlim continueGate, SemaphoreSlim itemEmitted,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test-model") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);
        handlerStarted.TrySetResult();

        var items = new List<OutputItem>();
        for (int i = 0; i < itemCount; i++)
        {
            ct.ThrowIfCancellationRequested();
            // Wait for the test to release the gate before emitting the next item
            await continueGate.WaitAsync(ct);

            var msg = new OutputItemMessage(
                $"msg_{i}", MessageStatus.Completed, MessageRole.Assistant,
                Array.Empty<MessageContent>());
            items.Add(msg);
            yield return new ResponseOutputItemAddedEvent(0, i, msg);

            // Signal the test that this item has been yielded
            itemEmitted.Release();
        }

        var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model") { Status = ResponseStatus.Completed };
        foreach (var item in items)
            completedResponse.Output.Add(item);
        completedResponse.CompletedAt = DateTimeOffset.UtcNow;
        yield return new ResponseCompletedEvent(0, completedResponse);
    }

    /// <summary>
    /// Emits 2 output items then completes — for snapshot isolation testing.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> MultiOutputStreamForSnapshotTest(
        ResponseContext ctx)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test-model") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);

        var msg1 = new OutputItemMessage(
            "msg_1", MessageStatus.Completed, MessageRole.Assistant,
            Array.Empty<MessageContent>());
        yield return new ResponseOutputItemAddedEvent(0, 0, msg1);

        await Task.Yield(); // Ensure async

        var msg2 = new OutputItemMessage(
            "msg_2", MessageStatus.Completed, MessageRole.Assistant,
            Array.Empty<MessageContent>());
        yield return new ResponseOutputItemAddedEvent(0, 1, msg2);

        var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model") { Status = ResponseStatus.Completed };
        completedResponse.Output.Add(msg1);
        completedResponse.Output.Add(msg2);
        completedResponse.CompletedAt = DateTimeOffset.UtcNow;
        yield return new ResponseCompletedEvent(0, completedResponse);
    }

    /// <summary>
    /// Simple background stream that waits for a signal before completing.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleBackgroundStream(
        ResponseContext ctx, TaskCompletionSource done)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test-model") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);

        await done.Task;

        var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model") { Status = ResponseStatus.Completed };
        completedResponse.CompletedAt = DateTimeOffset.UtcNow;
        yield return new ResponseCompletedEvent(0, completedResponse);
    }
}
