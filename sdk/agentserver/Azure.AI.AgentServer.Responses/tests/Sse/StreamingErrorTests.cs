// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Sse;

public class StreamingErrorTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public StreamingErrorTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task HandlerThrowsMidStream_EmitsResponseFailedEvent()
    {
        _handler.EventFactory = (_, ctx, ct) => ThrowAfterOneEvent(ctx, ct);

        var requestBody = JsonSerializer.Serialize(new { model = "test", stream = true });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var body = await response.Content.ReadAsStringAsync();
        var events = ParseSseEvents(body);

        // Should have: response.created, then response.failed
        XAssert.Contains(events, e => e.EventType == "response.created");
        XAssert.Contains(events, e => e.EventType == "response.failed");

        // The response.failed event should have error populated
        var failedEvent = events.Last(e => e.EventType == "response.failed");
        Assert.That(failedEvent.Data.GetProperty("response").GetProperty("status").GetString(), Is.EqualTo("failed"));
        Assert.That(failedEvent.Data.GetProperty("response").GetProperty("error").GetProperty("code").GetString(), Is.EqualTo("server_error"));
    }

    [Test]
    public async Task HandlerThrowsMidStream_ErrorMessageIsGeneric()
    {
        _handler.EventFactory = (_, ctx, ct) => ThrowAfterOneEvent(ctx, ct);

        var requestBody = JsonSerializer.Serialize(new { model = "test", stream = true });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);
        var body = await response.Content.ReadAsStringAsync();
        var events = ParseSseEvents(body);

        var failedEvent = events.Last(e => e.EventType == "response.failed");
        var errorMessage = failedEvent.Data.GetProperty("response")
            .GetProperty("error").GetProperty("message").GetString();

        // Must not leak internal exception details
        XAssert.DoesNotContain("Simulated handler failure", errorMessage!);
        Assert.That(errorMessage, Is.EqualTo("An internal server error occurred."));
    }

    [Test]
    public async Task HandlerYieldsResponseFailedEventThenThrows_NoDoubleEmit()
    {
        _handler.EventFactory = (_, ctx, ct) => YieldFailedThenThrow(ctx, ct);

        var requestBody = JsonSerializer.Serialize(new { model = "test", stream = true });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);
        var body = await response.Content.ReadAsStringAsync();
        var events = ParseSseEvents(body);

        // Should have exactly one response.failed event (not two)
        var failedEvents = events.Where(e => e.EventType == "response.failed").ToList();
        XAssert.Single(failedEvents);
    }

    [Test]
    public async Task HandlerThrowsBeforeAnyEvents_StillEmitsResponseFailedEvent()
    {
        _handler.EventFactory = (_, _, _) => ThrowImmediately();

        var requestBody = JsonSerializer.Serialize(new { model = "test", stream = true });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        var events = ParseSseEvents(body);

        // Pre-response.created error: standalone error event (not response.failed)
        XAssert.Contains(events, e => e.EventType == "error");
    }

    // ── Helpers ──

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowAfterOneEvent(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        await Task.Yield();
        throw new InvalidOperationException("Simulated handler failure");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> YieldFailedThenThrow(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        await Task.Yield();

        // Handler explicitly yields a ResponseFailedEvent
        response.SetFailed(ResponseErrorCode.ServerError, "Handler-reported failure");
        yield return new ResponseFailedEvent(0, response);
        await Task.Yield();

        throw new InvalidOperationException("Post-failure throw");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowImmediately(
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.Yield();
        throw new InvalidOperationException("Immediate failure");
#pragma warning disable CS0162
        yield break;
#pragma warning restore CS0162
    }

    private record SseEvent(string EventType, JsonElement Data);

    private static List<SseEvent> ParseSseEvents(string sseBody)
    {
        var events = new List<SseEvent>();
        string? currentEventType = null;

        foreach (var line in sseBody.Split('\n'))
        {
            if (line.StartsWith("event: "))
            {
                currentEventType = line["event: ".Length..].Trim();
            }
            else if (line.StartsWith("data: ") && currentEventType is not null)
            {
                var data = JsonSerializer.Deserialize<JsonElement>(line["data: ".Length..]);
                events.Add(new SseEvent(currentEventType, data));
                currentEventType = null;
            }
        }

        return events;
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
