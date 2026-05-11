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

/// <summary>
/// Verifies that the same handler produces consistent Models.ResponseObject state
/// across all 4 delivery modes (default, streaming, background, streaming+background).
/// </summary>
public class CrossModeConsistencyTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public CrossModeConsistencyTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task DefaultMode_ResponseHasCorrectTerminalFields()
    {
        _handler.EventFactory = (_, ctx, ct) => TextEventStream(ctx);

        var body = JsonSerializer.Serialize(new { model = "test" });

        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var json = await response.Content.ReadFromJsonAsync<JsonElement>();

        Assert.That(json.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(json.TryGetProperty("completed_at", out _), Is.True);
        Assert.That(json.TryGetProperty("output", out var output), Is.True);
        Assert.That(output.GetArrayLength() >= 1, Is.True);
    }

    [Test]
    public async Task StreamingMode_TerminalEventHasCorrectFields()
    {
        _handler.EventFactory = (_, ctx, ct) => TextEventStream(ctx);

        var body = JsonSerializer.Serialize(new { model = "test", stream = true });

        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var sse = await response.Content.ReadAsStringAsync();

        // Verify the completed event is present in the SSE stream
        XAssert.Contains("event: response.completed", sse);
        XAssert.Contains("event: response.output_item.done", sse);
    }

    [Test]
    public async Task BackgroundMode_GetReturnsMatchingResponse()
    {
        _handler.EventFactory = (_, ctx, ct) => TextEventStream(ctx);

        var body = JsonSerializer.Serialize(new { model = "test", background = true });

        var createResponse = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        var created = await createResponse.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = created.GetProperty("id").GetString()!;

        // Poll GET until the background handler completes
        JsonElement json = default;
        bool reachedTerminal = false;
        var deadline = DateTime.UtcNow.AddSeconds(10);
        while (DateTime.UtcNow < deadline)
        {
            var getResponse = await _client.GetAsync($"/responses/{responseId}");
            json = await getResponse.Content.ReadFromJsonAsync<JsonElement>();
            var status = json.GetProperty("status").GetString();
            if (status is "completed" or "failed" or "incomplete" or "cancelled")
            {
                reachedTerminal = true;
                break;
            }
            await Task.Delay(50);
        }

        Assert.That(reachedTerminal, Is.True, "Timed out waiting for background response to reach terminal status");
        Assert.That(json.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(json.TryGetProperty("completed_at", out _), Is.True);
        Assert.That(json.TryGetProperty("output", out var output), Is.True);
        Assert.That(output.GetArrayLength() >= 1, Is.True);
    }

    [Test]
    public async Task StreamingBackground_TerminalEventHasCorrectFields()
    {
        _handler.EventFactory = (_, ctx, ct) => TextEventStream(ctx);

        var body = JsonSerializer.Serialize(new { model = "test", stream = true, background = true });

        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var sse = await response.Content.ReadAsStringAsync();

        // Should have response.completed event
        XAssert.Contains("event: response.completed", sse);
    }

    /// <summary>
    /// Handler that yields output items with text content — shared across all mode tests.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> TextEventStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);

        var textContent = new MessageContentOutputTextContent(
            "Hello world", Array.Empty<Annotation>(), Array.Empty<LogProb>());
        var msg = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[] { textContent });
        yield return new ResponseOutputItemAddedEvent(0, 0, msg);
        yield return new ResponseOutputItemDoneEvent(0, 0, msg);

        var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test");
        completedResponse.Output.Add(msg);
        completedResponse.SetCompleted();
        yield return new ResponseCompletedEvent(0, completedResponse);
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
