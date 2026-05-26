// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Handler;

public class ModeOrchestrationTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public ModeOrchestrationTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task DefaultMode_RunsToCompletion_ReturnsJson()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    [Test]
    public async Task StreamingMode_ReturnsSseStream()
    {
        _handler.EventFactory = (_, ctx, ct) => SimpleEventStream(ctx);

        var requestBody = JsonSerializer.Serialize(new { model = "test", stream = true });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var body = await response.Content.ReadAsStringAsync();
        XAssert.Contains("event: response.created", body);
        XAssert.Contains("event: response.completed", body);
    }

    [Test]
    public async Task StreamingMode_SseHeaders_AreSet()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test", stream = true });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.Headers.CacheControl?.ToString(), Is.EqualTo("no-cache"));
    }

    [Test]
    public async Task StreamingMode_EventsContainSequenceNumbers()
    {
        _handler.EventFactory = (_, ctx, ct) => SimpleEventStream(ctx);

        var requestBody = JsonSerializer.Serialize(new { model = "test", stream = true });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);
        var body = await response.Content.ReadAsStringAsync();

        var dataLines = body.Split('\n')
            .Where(l => l.StartsWith("data: "))
            .Select(l => JsonSerializer.Deserialize<JsonElement>(l["data: ".Length..]))
            .ToList();

        // Verify monotonically increasing sequence numbers starting from 0
        for (int i = 0; i < dataLines.Count; i++)
        {
            Assert.That(dataLines[i].GetProperty("sequence_number").GetInt32(), Is.EqualTo(i));
        }
    }

    [Test]
    public async Task BackgroundMode_ReturnsImmediatelyWithInProgress()
    {
        var tcs = new TaskCompletionSource();
        _handler.EventFactory = (_, ctx, ct) => DelayedEventStream(ctx, tcs.Task, ct);

        var requestBody = JsonSerializer.Serialize(new { model = "test", background = true });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/responses", content);

        // Should return immediately with in_progress status
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("in_progress"));

        // Complete the background handler
        tcs.SetResult();
    }

    [Test]
    public async Task DefaultMode_StreamAndBackgroundFlagsPreserved()
    {
        var requestBody = JsonSerializer.Serialize(new
        {
            model = "test",
            stream = false,
            background = false,
        });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        await _client.PostAsync("/responses", content);

        Assert.That(_handler.LastRequest, Is.Not.Null);
        Assert.That(_handler.LastRequest.Stream, Is.False);
        Assert.That(_handler.LastRequest.Background, Is.False);
    }

    [Test]
    public async Task AllModes_UseTheSameHandler()
    {
        // Default mode
        var requestBody = JsonSerializer.Serialize(new { model = "test" });
        await _client.PostAsync("/responses", new StringContent(requestBody, Encoding.UTF8, "application/json"));

        // Streaming mode
        requestBody = JsonSerializer.Serialize(new { model = "test", stream = true });
        await _client.PostAsync("/responses", new StringContent(requestBody, Encoding.UTF8, "application/json"));

        Assert.That(_handler.CallCount, Is.EqualTo(2));
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleEventStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> DelayedEventStream(
        ResponseContext ctx,
        Task delayTask,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);
        await delayTask;
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
