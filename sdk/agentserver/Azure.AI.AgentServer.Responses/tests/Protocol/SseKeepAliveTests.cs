// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Text;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for User Story 5 — SSE Keep-Alive Disabled by Default.
/// Verifies B28 (no keep-alive by default) and B28 opt-in via env var.
/// </summary>
public class SseKeepAliveTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private string? _previousSseEnv;

    [SetUp]
    public void SetUp()
    {
        _previousSseEnv = Environment.GetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL");
    }

    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", _previousSseEnv);
        FoundryEnvironment.Reload();
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T051: Default configuration — SSE stream contains no keep-alive comments
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task Default_NoKeepAliveCommentsInSseStream()
    {
        // Arrange: default configuration (SseKeepAliveInterval = Timeout.InfiniteTimeSpan)
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", null);
        FoundryEnvironment.Reload();

        _handler.EventFactory = (req, ctx, ct) => SlowStream(ctx, delay: TimeSpan.FromMilliseconds(200), ct);
        using var factory = new TestWebApplicationFactory(_handler);
        using var client = factory.CreateClient();

        // Act: create a streaming response
        var json = System.Text.Json.JsonSerializer.Serialize(new { model = "test", stream = true });
        var response = await client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));

        // Assert: no keep-alive comments in the SSE output
        var body = await response.Content.ReadAsStringAsync();
        XAssert.DoesNotContain(": keep-alive", body);

        // Verify we got actual events (not an empty response)
        XAssert.Contains("event: response.created", body);
        XAssert.Contains("event: response.completed", body);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T052: Keep-alive interval configured — keep-alive comments present
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task ConfiguredKeepAlive_KeepAliveCommentsPresent()
    {
        // Arrange: set env var for 1-second keep-alive, handler takes 3 seconds
        Environment.SetEnvironmentVariable("SSE_KEEPALIVE_INTERVAL", "1");
        FoundryEnvironment.Reload();

        _handler.EventFactory = (req, ctx, ct) => SlowStream(ctx, delay: TimeSpan.FromSeconds(3), ct);
        using var factory = new TestWebApplicationFactory(_handler);
        using var client = factory.CreateClient();

        // Act: create a streaming response
        var json = System.Text.Json.JsonSerializer.Serialize(new { model = "test", stream = true });
        var response = await client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));

        // Assert: keep-alive comments should be present
        var body = await response.Content.ReadAsStringAsync();
        XAssert.Contains(": keep-alive", body);

        // Also verify actual events are present
        XAssert.Contains("event: response.created", body);
        XAssert.Contains("event: response.completed", body);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Handler that yields response.created, delays, then yields response.completed.
    /// The delay gives the keep-alive timer a chance to fire (if configured).
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> SlowStream(
        ResponseContext ctx, TimeSpan delay,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        await Task.Delay(delay, ct);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}
