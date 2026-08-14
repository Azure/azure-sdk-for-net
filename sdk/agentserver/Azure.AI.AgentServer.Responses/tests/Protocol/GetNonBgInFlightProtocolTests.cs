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
/// Protocol tests for B16 — Non-background in-flight GET returns 404.
/// JSON GET for a non-background response that is still in-flight returns 404.
/// After completion, the response is retrievable (200).
/// </summary>
public class GetNonBgInFlightProtocolTests : ProtocolTestBase
{
    // Validates: B16 — non-bg default mode: GET during in-flight → 404, after → 200
    [Test]
    public async Task GET_NonBgDefault_DuringInFlight_Returns404_AfterCompletion_Returns200()
    {
        var handlerStarted = new TaskCompletionSource();
        var handlerGate = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) =>
            GatedStream(ctx, handlerStarted, handlerGate.Task, ct);

        // Start the POST in the background (non-bg mode blocks until handler completes)
        var postTask = Task.Run(() => PostResponsesAsync(new { model = "test" }));

        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var responseId = Handler.LastContext!.ResponseId;

        // GET during in-flight → 404
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        // Release handler
        handlerGate.TrySetResult();
        await postTask;

        // GET after completion → 200 with completed status
        var getAfter = await GetResponseAsync(responseId);
        Assert.That(getAfter.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getAfter);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // Validates: B16 — non-bg streaming mode: GET during stream → 404
    [Test]
    public async Task GET_NonBgStreaming_DuringInFlight_Returns404()
    {
        var handlerStarted = new TaskCompletionSource();
        var handlerGate = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) =>
            GatedStream(ctx, handlerStarted, handlerGate.Task, ct);

        var cts = new CancellationTokenSource();
        var json = JsonSerializer.Serialize(new { model = "test", stream = true });
        var postContent = new StringContent(json, Encoding.UTF8, "application/json");
        var postTask = Client.PostAsync("/responses", postContent, cts.Token);

        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var responseId = Handler.LastContext!.ResponseId;

        // GET during streaming → 404
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        // Cleanup
        handlerGate.TrySetResult();
        try
        { await postTask; }
        catch (TaskCanceledException) { }
    }

    // Validates: B16 contrast — background in-flight GET → 200 (not 404)
    [Test]
    public async Task GET_Background_DuringInFlight_Returns200()
    {
        var handlerGate = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) =>
            WaitingStream(ctx, handlerGate.Task, ct);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // GET during bg in-flight → 200 with in_progress
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString() is "queued" or "in_progress", Is.True);

        handlerGate.TrySetResult();
        await WaitForBackgroundCompletionAsync(responseId);
    }

    // ── Helper streams ──

    private static async IAsyncEnumerable<ResponseStreamEvent> GatedStream(
        ResponseContext ctx, TaskCompletionSource started, Task gate,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        started.TrySetResult();
        await gate.WaitAsync(ct);
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingStream(
        ResponseContext ctx, Task waitTask,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await waitTask.WaitAsync(ct);
        yield return stream.EmitCompleted();
    }
}
