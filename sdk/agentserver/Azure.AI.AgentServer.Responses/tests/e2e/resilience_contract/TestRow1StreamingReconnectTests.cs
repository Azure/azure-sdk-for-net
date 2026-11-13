// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.E2E.ResilienceContract;

/// <summary>
/// Row 1 streaming reconnect e2e (US3, T030). A client that reconnects to a durable streaming
/// response with <c>?stream=true&amp;starting_after=&lt;seq&gt;</c> receives a strict, contiguous
/// suffix of the event stream (only <c>sequence_number &gt; cursor</c>), covering both a completed
/// stream (replay a suffix) and an in-flight stream (replay buffered prefix + live-tail of events
/// emitted after the subscription starts).
/// </summary>
[NonParallelizable]
public sealed class TestRow1StreamingReconnectTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public TestRow1StreamingReconnectTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task Reconnect_AfterCompletion_ReplaysContiguousSuffix()
    {
        // created(0) added(1) done(2) added(3) done(4) completed(5)
        _handler.EventFactory = (_, ctx, ct) => SixEventStream(ctx);
        var responseId = await CreateBgStreamingResponse();

        var seqs = await ReadSeqsUntilEndAsync($"/responses/{responseId}?stream=true&starting_after=2");

        // Strict-> suffix: only events after the cursor, contiguous, strictly increasing.
        Assert.That(seqs, Is.EqualTo(new long[] { 3, 4, 5 }));
        AssertContiguousStrictlyIncreasing(seqs);
    }

    [Test]
    public async Task Reconnect_MidFlight_LiveTailsEventsEmittedAfterSubscribe()
    {
        var phase1Done = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releasePhase2 = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        _handler.EventFactory = (_, ctx, ct) => GatedTwoPhaseStream(ctx, phase1Done, releasePhase2.Task, ct);

        var responseId = await CreateBgStreamingResponse();

        // Wait until the buffered prefix (through seq 2) is durably recorded.
        await phase1Done.Task.WaitAsync(TimeSpan.FromSeconds(10));

        // Reconnect with the cursor at the last buffered event: nothing is available yet, so the
        // subscription must live-tail phase-2 events emitted only after it releases.
        var readTask = ReadSeqsUntilEndAsync($"/responses/{responseId}?stream=true&starting_after=2");

        // Give the subscription a moment to attach with an empty buffer tail, then unblock phase 2.
        await Task.Delay(100);
        releasePhase2.TrySetResult();

        var seqs = await readTask.WaitAsync(TimeSpan.FromSeconds(10));

        // Only the live-tailed phase-2 suffix (emitted after subscribe) is delivered.
        Assert.That(seqs, Is.EqualTo(new long[] { 3, 4, 5 }));
        AssertContiguousStrictlyIncreasing(seqs);
    }

    private static void AssertContiguousStrictlyIncreasing(long[] seqs)
    {
        for (var i = 1; i < seqs.Length; i++)
        {
            Assert.That(seqs[i], Is.EqualTo(seqs[i - 1] + 1),
                $"replay must be contiguous and gap-free; got [{string.Join(",", seqs)}]");
        }
    }

    private async Task<long[]> ReadSeqsUntilEndAsync(string url)
    {
        using var response = await _client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var seqs = new List<long>();
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
            if (doc.RootElement.TryGetProperty("sequence_number", out var seqProp))
            {
                seqs.Add(seqProp.GetInt64());
            }

            if (doc.RootElement.TryGetProperty("type", out var typeProp)
                && typeProp.GetString() is "response.completed" or "response.failed" or "response.incomplete")
            {
                break;
            }
        }

        return seqs.ToArray();
    }

    private async Task<string> CreateBgStreamingResponse()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test", stream = true, background = true }),
                Encoding.UTF8, "application/json"),
        };

        // Read only headers + the first data line: a gated background handler keeps the primary POST
        // SSE stream open until it completes, so buffering the whole body would deadlock. Background
        // execution continues server-side after this client-side response is disposed.
        var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
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
            if (doc.RootElement.TryGetProperty("response", out var resp)
                && resp.TryGetProperty("id", out var idProp))
            {
                return idProp.GetString()!;
            }
        }

        throw new InvalidOperationException("No response id in POST SSE stream");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> SixEventStream(ResponseContext ctx)
    {
        await Task.CompletedTask;
        var response = new ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);
        yield return new ResponseOutputItemAddedEvent(1, outputIndex: 0, item: NewItem("msg_1"));
        yield return new ResponseOutputItemDoneEvent();
        yield return new ResponseOutputItemAddedEvent(1, outputIndex: 1, item: NewItem("msg_2"));
        yield return new ResponseOutputItemDoneEvent();
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> GatedTwoPhaseStream(
        ResponseContext ctx,
        TaskCompletionSource phase1Done,
        Task releasePhase2,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);              // seq 0
        yield return new ResponseOutputItemAddedEvent(1, outputIndex: 0, item: NewItem("msg_1")); // seq 1
        yield return new ResponseOutputItemDoneEvent();                 // seq 2

        // Buffered prefix through seq 2 is now durably recorded; signal and wait for the reconnect.
        phase1Done.TrySetResult();
        await releasePhase2.WaitAsync(ct);

        yield return new ResponseOutputItemAddedEvent(1, outputIndex: 1, item: NewItem("msg_2")); // seq 3
        yield return new ResponseOutputItemDoneEvent();                 // seq 4
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);           // seq 5
    }

    private static OutputItemMessage NewItem(string id)
        => new(
            id: id,
            content: new List<MessageContent>
            {
                new MessageContentOutputTextContent("x", Array.Empty<Annotation>(), Array.Empty<LogProb>()),
            },
            status: MessageStatus.Completed);
}
