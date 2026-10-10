// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Endpoints;

/// <summary>
/// Route + cursor tests for the streaming reconnect endpoint
/// <c>GET /responses/{id}?stream=true&amp;starting_after=&lt;sequence_number&gt;</c> (US3, T032). The
/// endpoint replays the durable SSE stream from a cursor: only events with
/// <c>sequence_number &gt; starting_after</c> are returned (strict-<c>&gt;</c>), the replay is a
/// contiguous suffix, and a malformed cursor is ignored (full replay). This is orthogonal to crash
/// recovery — it works for any stored streaming response.
/// </summary>
public sealed class ReconnectResponsesEndpointTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public ReconnectResponsesEndpointTests()
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
    public async Task Reconnect_StartingAfter_ReturnsOnlyEventsStrictlyAfterCursor()
    {
        _handler.EventFactory = (_, ctx, ct) => FiveEventStream(ctx);
        var responseId = await CreateBgStreamingResponse();

        var seqs = await GetSequenceNumbersAsync($"/responses/{responseId}?stream=true&starting_after=1");

        // Strict-> : only events with sequence_number > 1 (i.e., 2,3,4) are replayed.
        Assert.That(seqs, Is.EqualTo(new long[] { 2, 3, 4 }));
    }

    [Test]
    public async Task Reconnect_StartingAfterZero_SkipsOnlyTheCreatedEvent()
    {
        _handler.EventFactory = (_, ctx, ct) => FiveEventStream(ctx);
        var responseId = await CreateBgStreamingResponse();

        var seqs = await GetSequenceNumbersAsync($"/responses/{responseId}?stream=true&starting_after=0");

        // starting_after=0 skips only seq 0 (response.created); the rest form a contiguous suffix.
        Assert.That(seqs, Is.EqualTo(new long[] { 1, 2, 3, 4 }));
    }

    [Test]
    public async Task Reconnect_StartingAfterLastEvent_ReturnsNoDataEvents()
    {
        _handler.EventFactory = (_, ctx, ct) => FiveEventStream(ctx);
        var responseId = await CreateBgStreamingResponse();

        var seqs = await GetSequenceNumbersAsync($"/responses/{responseId}?stream=true&starting_after=4");

        // Cursor at the terminal event: nothing strictly after it.
        Assert.That(seqs, Is.Empty);
    }

    [Test]
    public async Task Reconnect_MalformedStartingAfter_Returns400()
    {
        _handler.EventFactory = (_, ctx, ct) => FiveEventStream(ctx);
        var responseId = await CreateBgStreamingResponse();

        // A present-but-non-integer cursor is a client error: reject with 400 invalid_request
        // rather than silently full-replaying (parity with Python `_parse_starting_after`).
        var response = await _client.GetAsync(
            $"/responses/{responseId}?stream=true&starting_after=not-a-number");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var body = await response.Content.ReadAsStringAsync();
        var doc = JsonSerializer.Deserialize<JsonElement>(body);
        var error = doc.GetProperty("error");
        Assert.That(error.GetProperty("param").GetString(), Is.EqualTo("starting_after"));

        // Lock in the .NET 400 taxonomy so future drift is caught: every .NET 400 uses
        // type == code == "invalid_request_error". (F5: Python's `_parse_starting_after` uses code
        // "invalid_request"; the .NET code stays consistent with the rest of its 400 taxonomy rather
        // than diverging one path. This assertion pins the actual emitted values.)
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task Reconnect_UnknownId_WithStartingAfter_Returns404()
    {
        var response = await _client.GetAsync(
            $"/responses/{IdGenerator.NewResponseId()}?stream=true&starting_after=2");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    private async Task<long[]> GetSequenceNumbersAsync(string url)
    {
        var response = await _client.GetAsync(url);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var body = await response.Content.ReadAsStringAsync();
        return body.Split('\n')
            .Where(l => l.StartsWith("data: ", StringComparison.Ordinal))
            .Select(l => JsonSerializer.Deserialize<JsonElement>(l["data: ".Length..]))
            .Where(e => e.TryGetProperty("sequence_number", out _))
            .Select(e => e.GetProperty("sequence_number").GetInt64())
            .ToArray();
    }

    private async Task<string> CreateBgStreamingResponse()
    {
        var body = JsonSerializer.Serialize(new { model = "test", stream = true, background = true });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        var sseBody = await response.Content.ReadAsStringAsync();
        var firstDataLine = sseBody.Split('\n').FirstOrDefault(l => l.StartsWith("data: ", StringComparison.Ordinal))
            ?? throw new InvalidOperationException("No data line in SSE response");
        var evt = JsonSerializer.Deserialize<JsonElement>(firstDataLine["data: ".Length..]);
        return evt.GetProperty("response").GetProperty("id").GetString()!;
    }

    // created(0) → output_item.added(1) → output_item.done(2) → output_item.done(3) → completed(4)
    private static async IAsyncEnumerable<ResponseStreamEvent> FiveEventStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var response = new ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);

        var item = new OutputItemMessage(
            id: "msg_1",
            content: new List<MessageContent>
            {
                new MessageContentOutputTextContent("hello", Array.Empty<Annotation>(), Array.Empty<LogProb>()),
            },
            status: MessageStatus.Completed);
        yield return new ResponseOutputItemAddedEvent(1, outputIndex: 0, item: item);
        yield return new ResponseOutputItemDoneEvent();
        yield return new ResponseOutputItemDoneEvent();

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}
