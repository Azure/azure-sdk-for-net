// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Handler;

/// <summary>
/// Verifies that background mode responses emit proper terminal events
/// that can be replayed via GET with ?stream=true.
/// </summary>
public class BackgroundTerminalEventTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public BackgroundTerminalEventTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task BackgroundSuccess_GetSseIncludesResponseCompleted()
    {
        _handler.EventFactory = (_, ctx, ct) => SuccessStream(ctx);

        var body = JsonSerializer.Serialize(new { model = "test", background = true, stream = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        // Read the SSE response from the POST to get the response ID
        var sseContent = await createResponse.Content.ReadAsStringAsync();
        var firstDataLine = sseContent.Split('\n')
            .FirstOrDefault(l => l.StartsWith("data: "));
        var created = JsonSerializer.Deserialize<JsonElement>(firstDataLine!["data: ".Length..]);
        var responseId = created.GetProperty("response").GetProperty("id").GetString()!;

        var getResponse = await _client.GetAsync($"/responses/{responseId}?stream=true");
        var sse = await getResponse.Content.ReadAsStringAsync();

        XAssert.Contains("event: response.completed", sse);
    }

    [Test]
    public async Task BackgroundFailure_GetSseIncludesResponseFailed()
    {
        _handler.EventFactory = (_, ctx, ct) => FailingStream(ctx);

        var body = JsonSerializer.Serialize(new { model = "test", background = true, stream = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        // Read the SSE response from the POST to get the response ID
        var sseContent = await createResponse.Content.ReadAsStringAsync();
        var firstDataLine = sseContent.Split('\n')
            .FirstOrDefault(l => l.StartsWith("data: "));
        var created = JsonSerializer.Deserialize<JsonElement>(firstDataLine!["data: ".Length..]);
        var responseId = created.GetProperty("response").GetProperty("id").GetString()!;

        var getResponse = await _client.GetAsync($"/responses/{responseId}?stream=true");
        var sse = await getResponse.Content.ReadAsStringAsync();

        XAssert.Contains("event: response.failed", sse);
    }

    [Test]
    public async Task BackgroundSuccess_TerminalEventResponseHasCompletedAtAndStatus()
    {
        _handler.EventFactory = (_, ctx, ct) => SuccessStream(ctx);

        var body = JsonSerializer.Serialize(new { model = "test", background = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        var created = await createResponse.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = created.GetProperty("id").GetString()!;

        // Wait for background completion
        await Task.Delay(200);

        var getResponse = await _client.GetAsync($"/responses/{responseId}");
        var json = await getResponse.Content.ReadFromJsonAsync<JsonElement>();

        Assert.That(json.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(json.TryGetProperty("completed_at", out _), Is.True);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> SuccessStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> FailingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        throw new InvalidOperationException("Simulated handler failure");
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
