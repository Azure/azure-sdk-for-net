// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Endpoints;

public class GetResponseTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public GetResponseTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task GetJson_CompletedResponse_ReturnsFullSnapshot()
    {
        var responseId = await CreateDefaultResponse();

        var response = await _client.GetAsync($"/responses/{responseId}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("id").GetString(), Is.EqualTo(responseId));
        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(body.GetProperty("object").GetString(), Is.EqualTo("response"),
            "GET /responses/{id} must return 'object': 'response'");
    }

    [Test]
    public async Task GetJson_InFlightResponse_ReturnsPartialSnapshot()
    {
        var tcs = new TaskCompletionSource();
        _handler.EventFactory = (_, ctx, ct) => WaitingEventStream(ctx, tcs.Task, ct);

        // Create background response (returns immediately while handler runs)
        var responseId = await CreateBackgroundResponse();

        var response = await _client.GetAsync($"/responses/{responseId}");
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("in_progress"));

        tcs.SetResult();
        await Task.Delay(100);
    }

    [Test]
    public async Task GetJson_UnknownId_Returns404()
    {
        var response = await _client.GetAsync($"/responses/{IdGenerator.NewResponseId()}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        var body = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.That(body.GetProperty("error").GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task GetSse_CompletedResponse_ReplaysAllEvents()
    {
        _handler.EventFactory = (_, ctx, ct) => ThreeEventStream(ctx);

        var responseId = await CreateBgStreamingResponse();

        // GET with ?stream=true to trigger SSE replay
        var response = await _client.GetAsync($"/responses/{responseId}?stream=true");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var body = await response.Content.ReadAsStringAsync();
        XAssert.Contains("event: response.created", body);
        XAssert.Contains("event: response.completed", body);
    }

    [Test]
    public async Task GetSse_CompletedResponse_EventsHaveSequenceNumbers()
    {
        _handler.EventFactory = (_, ctx, ct) => ThreeEventStream(ctx);

        var responseId = await CreateBgStreamingResponse();

        var response = await _client.GetAsync($"/responses/{responseId}?stream=true");
        var body = await response.Content.ReadAsStringAsync();

        // Extract data lines and verify sequence numbers
        var dataLines = body.Split('\n')
            .Where(l => l.StartsWith("data: "))
            .Select(l => JsonSerializer.Deserialize<JsonElement>(l["data: ".Length..]))
            .ToList();

        Assert.That(dataLines.Count >= 2, Is.True);
        for (int i = 0; i < dataLines.Count; i++)
        {
            Assert.That(dataLines[i].GetProperty("sequence_number").GetInt32(), Is.EqualTo(i));
        }
    }

    [Test]
    public async Task GetSse_UnknownId_Returns404()
    {
        var response = await _client.GetAsync($"/responses/{IdGenerator.NewResponseId()}?stream=true");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetJson_NoAcceptHeader_ReturnsJson()
    {
        var responseId = await CreateDefaultResponse();

        // Use raw request with no Accept header
        var request = new HttpRequestMessage(HttpMethod.Get, $"/responses/{responseId}");
        request.Headers.Accept.Clear();

        var response = await _client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));
    }

    private async Task<string> CreateDefaultResponse()
    {
        var body = JsonSerializer.Serialize(new { model = "test" });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        return json.GetProperty("id").GetString()!;
    }

    private async Task<string> CreateBgStreamingResponse()
    {
        var body = JsonSerializer.Serialize(new { model = "test", stream = true, background = true });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        // For bg streaming, extract the response ID from the SSE data
        var sseBody = await response.Content.ReadAsStringAsync();
        var firstDataLine = sseBody.Split('\n')
            .FirstOrDefault(l => l.StartsWith("data: "));
        if (firstDataLine is null)
        {
            throw new InvalidOperationException("No data line in SSE response");
        }

        var evt = JsonSerializer.Deserialize<JsonElement>(firstDataLine["data: ".Length..]);
        return evt.GetProperty("response").GetProperty("id").GetString()!;
    }

    private async Task<string> CreateBackgroundResponse()
    {
        var body = JsonSerializer.Serialize(new { model = "test", background = true });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        return json.GetProperty("id").GetString()!;
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThreeEventStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);
        yield return new ResponseOutputItemDoneEvent();
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingEventStream(
        ResponseContext ctx,
        Task delayTask,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);
        await delayTask.WaitAsync(ct);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
