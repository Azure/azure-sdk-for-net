// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for B33 — Token usage on terminal events.
/// Verifies that when the handler provides <see cref="ResponseUsage"/> in
/// terminal events, it appears in the wire-format response body and SSE events.
/// </summary>
public class TokenUsageProtocolTests : ProtocolTestBase
{
    /// <summary>
    /// B33: Non-streaming response body includes usage when handler provides it.
    /// </summary>
    [Test]
    public async Task NonStreaming_CompletedResponse_IncludesUsage()
    {
        Handler.EventFactory = (req, ctx, ct) => CompletedWithUsageStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(response);
        var root = doc.RootElement;

        Assert.That(root.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(root.TryGetProperty("usage", out var usage), Is.True,
            "Completed response must include 'usage' when handler provides it");
        Assert.That(usage.GetProperty("input_tokens").GetInt32(), Is.EqualTo(10));
        Assert.That(usage.GetProperty("output_tokens").GetInt32(), Is.EqualTo(5));
        Assert.That(usage.GetProperty("total_tokens").GetInt32(), Is.EqualTo(15));
    }

    /// <summary>
    /// B33: Streaming response.completed event includes usage when handler provides it.
    /// </summary>
    [Test]
    public async Task Streaming_CompletedEvent_IncludesUsage()
    {
        Handler.EventFactory = (req, ctx, ct) => CompletedWithUsageStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var events = await ParseSseAsync(response);

        // Find the response.completed event
        var completedEvent = events.FirstOrDefault(e => e.EventType == "response.completed");
        Assert.That(completedEvent, Is.Not.Null, "Must have a response.completed event");

        using var doc = JsonDocument.Parse(completedEvent!.Data);
        var responseObj = doc.RootElement.GetProperty("response");

        Assert.That(responseObj.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(responseObj.TryGetProperty("usage", out var usage), Is.True,
            "response.completed event must include 'usage' when handler provides it");
        Assert.That(usage.GetProperty("input_tokens").GetInt32(), Is.EqualTo(10));
        Assert.That(usage.GetProperty("output_tokens").GetInt32(), Is.EqualTo(5));
        Assert.That(usage.GetProperty("total_tokens").GetInt32(), Is.EqualTo(15));
    }

    /// <summary>
    /// B33: GET /responses/{id} on a completed background response includes usage.
    /// </summary>
    [Test]
    public async Task GET_CompletedBackgroundResponse_IncludesUsage()
    {
        Handler.EventFactory = (req, ctx, ct) => CompletedWithUsageStream(ctx);

        var responseId = await CreateBackgroundResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(getResponse);
        var root = doc.RootElement;

        Assert.That(root.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(root.TryGetProperty("usage", out var usage), Is.True,
            "Persisted completed response must include 'usage'");
        Assert.That(usage.GetProperty("input_tokens").GetInt32(), Is.EqualTo(10));
        Assert.That(usage.GetProperty("output_tokens").GetInt32(), Is.EqualTo(5));
        Assert.That(usage.GetProperty("total_tokens").GetInt32(), Is.EqualTo(15));
    }

    /// <summary>
    /// B33: When handler does not provide usage, response omits the field (null).
    /// </summary>
    [Test]
    public async Task NonStreaming_CompletedResponse_WithoutUsage_OmitsField()
    {
        // Default handler completes without usage
        var response = await PostResponsesAsync(new { model = "test" });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(response);
        var root = doc.RootElement;

        Assert.That(root.GetProperty("status").GetString(), Is.EqualTo("completed"));
        // Usage should be null/absent when handler doesn't provide it
        if (root.TryGetProperty("usage", out var usage))
        {
            Assert.That(usage.ValueKind, Is.EqualTo(JsonValueKind.Null));
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CompletedWithUsageStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        var usage = new ResponseUsage(
            10,
            new ResponseUsageInputTokensDetails(0),
            5,
            new ResponseUsageOutputTokensDetails(0),
            15);

        yield return stream.EmitCompleted(usage);
    }
}
