// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for B24 — Shutdown signal.
/// Host shutdown sets <c>IsShutdownRequested</c> and cancels the handler's CT.
/// The SDK itself emits <c>response.failed</c> for unhandled shutdown OCEs.
/// Handlers can choose to emit <c>response.incomplete</c> (handler-driven).
/// </summary>
public class ShutdownProtocolTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public ShutdownProtocolTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    // Validates: B24 — background response during shutdown → incomplete status (not cancelled/failed)
    [Test]
    public async Task Shutdown_BackgroundResponse_BecomesIncomplete()
    {
        var handlerStarted = new TaskCompletionSource();
        var handlerDone = new TaskCompletionSource();

        _handler.EventFactory = (_, ctx, ct) =>
            ShutdownAwareStream(ctx, ct, handlerStarted, handlerDone);

        // Create background response
        var body = JsonSerializer.Serialize(new { model = "test", background = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var createDoc = JsonDocument.Parse(await createResponse.Content.ReadAsStringAsync());
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // Wait for handler to start processing
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Trigger graceful host shutdown
        await _factory.StopAsync();

        // Wait for handler to finish processing shutdown
        await handlerDone.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Poll GET until terminal status appears (shutdown cleanup is async)
        JsonDocument? getDoc = null;
        var deadline = DateTime.UtcNow.AddSeconds(5);
        while (DateTime.UtcNow < deadline)
        {
            var getResponse = await _client.GetAsync($"/responses/{responseId}");
            if (getResponse.StatusCode == HttpStatusCode.OK)
            {
                getDoc = JsonDocument.Parse(await getResponse.Content.ReadAsStringAsync());
                var status = getDoc.RootElement.GetProperty("status").GetString();
                if (status is "completed" or "failed" or "incomplete" or "cancelled")
                    break;
                getDoc.Dispose();
                getDoc = null;
            }
            await Task.Delay(50);
        }

        // GET after shutdown → incomplete (not cancelled or failed)
        if (getDoc is not null)
        {
            using (getDoc)
            {
                var status = getDoc.RootElement.GetProperty("status").GetString();
                Assert.That(status, Is.EqualTo("incomplete"));

                // B24: incomplete → error is null (not an error condition)
                Assert.That(getDoc.RootElement.GetProperty("error").ValueKind, Is.EqualTo(JsonValueKind.Null));
            }
        }
    }

    // Validates: B24 — non-cooperative handler on shutdown → SDK emits response.failed (not cancelled)
    [Test]
    public async Task Shutdown_NonCooperativeHandler_EmitsFailed_NotCancelled()
    {
        var handlerStarted = new TaskCompletionSource();

        _handler.EventFactory = (_, ctx, ct) =>
            BlockingStream(ctx, ct, handlerStarted);

        var body = JsonSerializer.Serialize(new { model = "test", background = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var createDoc = JsonDocument.Parse(await createResponse.Content.ReadAsStringAsync());
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Trigger shutdown
        await _factory.StopAsync();

        // Poll GET until terminal status appears (shutdown + cancellation cleanup is async)
        JsonDocument? getDoc = null;
        var deadline = DateTime.UtcNow.AddSeconds(5);
        while (DateTime.UtcNow < deadline)
        {
            var getResponse = await _client.GetAsync($"/responses/{responseId}");
            if (getResponse.StatusCode == HttpStatusCode.OK)
            {
                getDoc = JsonDocument.Parse(await getResponse.Content.ReadAsStringAsync());
                var status = getDoc.RootElement.GetProperty("status").GetString();
                if (status is "completed" or "failed" or "incomplete" or "cancelled")
                    break;
                getDoc.Dispose();
                getDoc = null;
            }
            await Task.Delay(50);
        }

        if (getDoc is not null)
        {
            using (getDoc)
            {
                var status = getDoc.RootElement.GetProperty("status").GetString();

                // Must NOT be "cancelled" — shutdown is distinct from cancel
                Assert.That(status, Is.Not.EqualTo("cancelled"));
                // Non-cooperative handler on shutdown → SDK emits failed
                Assert.That(status, Is.EqualTo("failed"));
            }
        }
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    // ── Helper streams ──

    private static async IAsyncEnumerable<ResponseStreamEvent> ShutdownAwareStream(
        ResponseContext ctx, [EnumeratorCancellation] CancellationToken ct,
        TaskCompletionSource started, TaskCompletionSource done)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        started.TrySetResult();

        ResponseStreamEvent? incompleteEvent = null;
        try
        {
            var tcs = new TaskCompletionSource();
            ct.Register(() => tcs.TrySetResult());
            await tcs.Task;
            ct.ThrowIfCancellationRequested();
        }
        catch (OperationCanceledException)
        {
            incompleteEvent = stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);
        }

        if (incompleteEvent is not null)
        {
            done.TrySetResult();
            yield return incompleteEvent;
            yield break;
        }

        yield return stream.EmitCompleted();
        done.TrySetResult();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> BlockingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct,
        TaskCompletionSource started)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        started.TrySetResult();

        // Block until cancelled — handler doesn't cooperate, just throws on cancellation
        var tcs = new TaskCompletionSource();
        ct.Register(() => tcs.TrySetResult());
        await tcs.Task;
        ct.ThrowIfCancellationRequested();

        yield return stream.EmitCompleted();
    }
}
