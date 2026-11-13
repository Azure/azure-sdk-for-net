// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for SSE wire-format headers (B27 / SSE Response Headers).
/// Verifies Content-Type includes charset and Connection: keep-alive is set.
/// </summary>
public sealed class SseHeadersProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task StreamingPost_HasCorrectContentType()
    {
        // B27: Content-Type: text/event-stream; charset=utf-8
        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.Content.Headers.ContentType?.ToString(), Is.EqualTo("text/event-stream; charset=utf-8"));
    }

    [Test]
    public async Task StreamingPost_HasConnectionKeepAlive()
    {
        // B27: Connection: keep-alive
        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.Headers.Contains("Connection"), Is.True, "Response should include Connection header");
        XAssert.Contains("keep-alive",
            response.Headers.GetValues("Connection"));
    }

    [Test]
    public async Task StreamingPost_HasCacheControlNoCache()
    {
        // Existing behaviour preserved: Cache-Control: no-cache
        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.Headers.CacheControl?.NoCache == true
            || (response.Headers.Contains("Cache-Control")
                && response.Headers.GetValues("Cache-Control").Any(v => v.Contains("no-cache"))), Is.True,
            "Response should include Cache-Control: no-cache");
    }

    [Test]
    public async Task SseReplay_HasCorrectContentType()
    {
        // B27: Replay GET also has correct Content-Type
        // SSE replay requires background+streaming
        var responseId = await CreateBackgroundStreamingResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        // Now request the SSE replay
        var replayResponse = await GetResponseStreamAsync(responseId);

        Assert.That(replayResponse.Content.Headers.ContentType?.ToString(), Is.EqualTo("text/event-stream; charset=utf-8"));
    }

    [Test]
    public async Task SseReplay_HasConnectionKeepAlive()
    {
        // B27: Replay GET also has Connection: keep-alive
        // SSE replay requires background+streaming
        var responseId = await CreateBackgroundStreamingResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var replayResponse = await GetResponseStreamAsync(responseId);

        Assert.That(replayResponse.Headers.Contains("Connection"), Is.True, "Replay response should include Connection header");
        XAssert.Contains("keep-alive",
            replayResponse.Headers.GetValues("Connection"));
    }
}
