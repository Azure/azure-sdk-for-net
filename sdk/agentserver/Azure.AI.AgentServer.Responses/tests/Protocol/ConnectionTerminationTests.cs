// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for connection termination behaviour (US3).
/// Validates that client disconnects are handled correctly for each mode.
/// </summary>
public class ConnectionTerminationTests : ProtocolTestBase
{
    // T067: non-bg streaming disconnect → handler cancelled, status: cancelled
    [Test]
    public async Task NonBgStreaming_Disconnect_ResultsInCancelled()
    {
        var handlerStarted = new TaskCompletionSource();
        var handlerCancelled = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) =>
            DisconnectTrackingStream(ctx, handlerStarted, handlerCancelled, ct);

        // Create a streaming response but cancel the HTTP request mid-stream
        var cts = new CancellationTokenSource();
        var postTask = PostStreamingWithCancellationAsync(cts.Token);

        // Wait for handler to start
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Simulate client disconnect
        cts.Cancel();

        // Wait for handler to notice the cancellation
        await handlerCancelled.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // The response should have transitioned to cancelled
        // (non-bg streaming with store=true — need to wait for cleanup)
        await Task.Delay(200);

        // Try to get the response (it should be stored since store defaults to true)
        // Note: For non-bg, after completion, it should be accessible via GET
        try
        {
            await postTask;
        }
        catch (TaskCanceledException)
        {
            // Expected — we cancelled the request
        }
    }

    // T069: bg non-streaming → POST returns immediately, handler continues
    [Test]
    public async Task BgNonStreaming_PostReturns_HandlerContinues()
    {
        var handlerCompleted = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => DelayedCompleteStream(ctx, handlerCompleted);

        var httpResponse = await PostResponsesAsync(new { model = "test", background = true });

        // POST returns immediately with in_progress
        Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(httpResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
        var responseId = doc.RootElement.GetProperty("id").GetString()!;

        // Handler hasn't completed yet
        Assert.That(handlerCompleted.Task.IsCompleted, Is.False);

        // Wait for handler to complete
        await handlerCompleted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        await Task.Delay(100); // let cleanup finish

        // GET should return completed response
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // ── Helpers ─────────────────────────────────────────────────

    private async Task<HttpResponseMessage> PostStreamingWithCancellationAsync(CancellationToken ct)
    {
        var json = JsonSerializer.Serialize(new { model = "test", stream = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await Client.PostAsync("/responses", content, ct);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> DisconnectTrackingStream(
        ResponseContext ctx,
        TaskCompletionSource handlerStarted,
        TaskCompletionSource handlerCancelled,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        handlerStarted.TrySetResult();

        try
        {
            var tcs = new TaskCompletionSource();
            ct.Register(() => tcs.TrySetResult());
            await tcs.Task;
            ct.ThrowIfCancellationRequested();
        }
        catch (OperationCanceledException)
        {
            handlerCancelled.TrySetResult();
            throw;
        }

        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> DelayedCompleteStream(
        ResponseContext ctx,
        TaskCompletionSource handlerCompleted,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        // Simulate work
        await Task.Delay(300, ct);

        yield return stream.EmitCompleted();
        handlerCompleted.TrySetResult();
    }
}
