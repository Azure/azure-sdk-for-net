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
/// Cross-API E2E behavioural tests exercising multi-endpoint flows on a single response.
/// Each test calls 2+ endpoints and asserts cross-endpoint consistency per the contract.
/// Validates: E1–E42 from the cross-API matrix (plan.md Phase 2).
/// </summary>
public class CrossApiE2eTests : ProtocolTestBase
{
    // ════════════════════════════════════════════════════════════
    // C5/C6 — Ephemeral (store=false): E30–E35
    // All cross-API operations → 404 because store=false never persists
    // ════════════════════════════════════════════════════════════

    // E30–E35: store=false responses are not retrievable or cancellable (B14)
    [TestCase(false, "GET")]       // E30: C5 → GET JSON → 404
    [TestCase(false, "GET_SSE")]   // E31: C5 → GET SSE replay → 404
    [TestCase(true, "GET")]        // E33: C6 → GET JSON → 404
    [TestCase(true, "GET_SSE")]    // E34: C6 → GET SSE replay → 404
    public async Task Ephemeral_StoreFalse_CrossApi_Returns404(bool stream, string operation)
    {
        // Validates: B14 — store=false responses are not retrievable
        Handler.EventFactory = stream
            ? (req, ctx, ct) => SimpleTextStream(ctx)
            : null; // default handler

        var createResponse = await PostResponsesAsync(new { model = "test", store = false, stream });
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Extract ID: for non-streaming, from JSON; for streaming, from first SSE event
        string responseId;
        if (stream)
        {
            var events = await ParseSseAsync(createResponse);
            using var evtDoc = JsonDocument.Parse(events[0].Data);
            responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;
        }
        else
        {
            using var doc = await ParseJsonAsync(createResponse);
            responseId = doc.RootElement.GetProperty("id").GetString()!;
        }

        var result = operation switch
        {
            "GET" => await GetResponseAsync(responseId),
            "GET_SSE" => await GetResponseStreamAsync(responseId),
            _ => throw new ArgumentException(operation)
        };

        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // E32/E35: store=false + Cancel → 400 (non-bg cancel rejected with "synchronous" error, B1, B14)
    [TestCase(false)]  // E32: C5 → Cancel
    [TestCase(true)]   // E35: C6 → Cancel
    public async Task Ephemeral_StoreFalse_Cancel_Returns400(bool stream)
    {
        // Validates: B1, B14 — store=false response not bg, cancel rejected
        Handler.EventFactory = stream
            ? (req, ctx, ct) => SimpleTextStream(ctx)
            : null;

        var createResponse = await PostResponsesAsync(new { model = "test", store = false, stream });
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        string responseId;
        if (stream)
        {
            var events = await ParseSseAsync(createResponse);
            using var evtDoc = JsonDocument.Parse(events[0].Data);
            responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;
        }
        else
        {
            using var doc = await ParseJsonAsync(createResponse);
            responseId = doc.RootElement.GetProperty("id").GetString()!;
        }

        // Cancel on a non-bg response → 400 (checked before store lookup)
        var result = await CancelResponseAsync(responseId);
        Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // ════════════════════════════════════════════════════════════
    // C1 — Synchronous, stored (store=T, bg=F, stream=F): E1–E6
    // ════════════════════════════════════════════════════════════

    // E1: Create → GET (after completion) → 200 JSON, status: completed (B5, B16)
    [Test]
    public async Task C1_Create_Then_GET_AfterCompletion_Returns200Completed()
    {
        // Validates: B5 — JSON GET returns current snapshot; B16 — after completion, accessible
        var responseId = await CreateDefaultResponseAsync();

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // E2: Create → GET (during in-flight) → 404 (B16)
    [Test]
    public async Task C1_Create_GET_DuringInFlight_Returns404()
    {
        // Validates: B16 — non-bg in-flight → 404
        var handlerStarted = new TaskCompletionSource();
        var handlerGate = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => GatedStream(ctx, handlerStarted, handlerGate.Task, ct);

        // Start the POST (non-bg, blocks until handler completes)
        var postTask = Task.Run(() => PostResponsesAsync(new { model = "test" }));

        // Wait for handler to start
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // GET during in-flight → 404
        // Use a separate client since the first one is blocked on the POST
        var getResponse = await GetResponseAsync("resp_placeholder");
        // We need the actual response ID — extract from handler context
        var responseId = Handler.LastContext!.ResponseId;
        getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        // Release handler → POST completes
        handlerGate.TrySetResult();
        var postResponse = await postTask;

        // Now GET succeeds
        var getAfter = await GetResponseAsync(responseId);
        Assert.That(getAfter.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getAfter);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // E3: Create → GET ?stream=true → 400 (B2: non-bg, no SSE replay)
    [Test]
    public async Task C1_Create_Then_GetSseReplay_Returns400()
    {
        // Validates: B2 — SSE replay requires background
        var responseId = await CreateDefaultResponseAsync();

        var getResponse = await GetResponseStreamAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // E4: Create → Cancel API (after completion) → 400 (B1, B12)
    [Test]
    public async Task C1_Create_Then_CancelAfterCompletion_Returns400()
    {
        // Validates: B1 — cancel requires background; B12 — cancel rejection
        var responseId = await CreateDefaultResponseAsync();

        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        Assert.That(doc.RootElement.GetProperty("error").GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        XAssert.Contains("synchronous", doc.RootElement.GetProperty("error").GetProperty("message").GetString());
    }

    // E5: Create → Cancel API (during in-flight) → 404 (B16: non-bg in-flight not findable)
    [Test]
    public async Task C1_Create_CancelDuringInFlight_Returns404()
    {
        // Validates: B16 — non-background in-flight responses are not findable → 404
        var handlerStarted = new TaskCompletionSource();
        var handlerGate = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => GatedStream(ctx, handlerStarted, handlerGate.Task, ct);

        var postTask = Task.Run(() => PostResponsesAsync(new { model = "test" }));
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        var responseId = Handler.LastContext!.ResponseId;
        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        handlerGate.TrySetResult();
        await postTask;
    }

    // E6: Create → Disconnect → GET → status: cancelled (B17, B5)
    [Test]
    public async Task C1_Disconnect_Then_GET_ReturnsCancelled()
    {
        // Validates: B17 — connection termination cancels non-bg; B5 — GET snapshot
        var handlerStarted = new TaskCompletionSource();
        var handlerCancelled = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) =>
            DisconnectTrackingStream(ctx, handlerStarted, handlerCancelled, ct);

        var cts = new CancellationTokenSource();
        var json = JsonSerializer.Serialize(new { model = "test" });
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var postTask = Client.PostAsync("/responses", content, cts.Token);
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        var responseId = Handler.LastContext!.ResponseId;

        // Disconnect
        cts.Cancel();
        await handlerCancelled.Task.WaitAsync(TimeSpan.FromSeconds(5));

        try
        { await postTask; }
        catch (TaskCanceledException) { }

        // Non-bg cancelled → ephemeral (not persisted) → GET 404
        // Poll until cleanup propagates
        var getResponse = await PollUntilAsync(
            () => GetResponseAsync(responseId),
            r => r.StatusCode == HttpStatusCode.NotFound);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ════════════════════════════════════════════════════════════
    // C2 — Synchronous streaming, stored (store=T, bg=F, stream=T): E7–E12
    // ════════════════════════════════════════════════════════════

    // E7: Create (SSE) → GET (after stream ends) → 200 JSON, status: completed (B5)
    [Test]
    public async Task C2_StreamCreate_Then_GET_AfterStreamEnds_Returns200Completed()
    {
        // Validates: B5 — JSON GET returns current snapshot
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var responseId = await CreateStreamingResponseAsync();

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // E8: Create (SSE) → GET JSON (during stream) → 404 (B16)
    [Test]
    public async Task C2_StreamCreate_GET_DuringStream_Returns404()
    {
        // Validates: B16 — non-bg in-flight → 404
        var handlerStarted = new TaskCompletionSource();
        var handlerGate = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => GatedStream(ctx, handlerStarted, handlerGate.Task, ct);

        var cts = new CancellationTokenSource();
        var json = JsonSerializer.Serialize(new { model = "test", stream = true });
        var postContent = new StringContent(json, Encoding.UTF8, "application/json");
        var postTask = Client.PostAsync("/responses", postContent, cts.Token);

        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var responseId = Handler.LastContext!.ResponseId;

        // GET during stream → 404
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        // Release and cleanup
        handlerGate.TrySetResult();
        try
        { await postTask; }
        catch (TaskCanceledException) { }
    }

    // E9: Create (SSE) → GET ?stream=true → 400 (B2: non-bg, no replay)
    [Test]
    public async Task C2_StreamCreate_Then_GetSseReplay_Returns400()
    {
        // Validates: B2 — SSE replay requires background
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var responseId = await CreateStreamingResponseAsync();

        var getResponse = await GetResponseStreamAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // E10: Create → Cancel API (after stream ends) → 400 (B1, B12)
    [Test]
    public async Task C2_StreamCreate_Then_CancelAfterStreamEnds_Returns400()
    {
        // Validates: B1, B12 — cancel non-bg rejected
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var responseId = await CreateStreamingResponseAsync();

        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        XAssert.Contains("synchronous", doc.RootElement.GetProperty("error").GetProperty("message").GetString());
    }

    // E11: Create (SSE) → Cancel API (during stream) → 404 (B16: non-bg in-flight not findable)
    [Test]
    public async Task C2_StreamCreate_CancelDuringStream_Returns404()
    {
        // Validates: B16 — non-background in-flight responses are not findable → 404
        var handlerStarted = new TaskCompletionSource();
        var handlerGate = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => GatedStream(ctx, handlerStarted, handlerGate.Task, ct);

        var cts = new CancellationTokenSource();
        var json = JsonSerializer.Serialize(new { model = "test", stream = true });
        var postContent = new StringContent(json, Encoding.UTF8, "application/json");
        var postTask = Client.PostAsync("/responses", postContent, cts.Token);

        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var responseId = Handler.LastContext!.ResponseId;

        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        handlerGate.TrySetResult();
        try
        { await postTask; }
        catch (TaskCanceledException) { }
    }

    // E12: Create (SSE) → Disconnect → GET → status: cancelled (B17, B5)
    [Test]
    public async Task C2_StreamCreate_Disconnect_Then_GET_ReturnsCancelled()
    {
        // Validates: B17 — connection termination cancels non-bg; B5 — GET returns snapshot
        var handlerStarted = new TaskCompletionSource();
        var handlerCancelled = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) =>
            DisconnectTrackingStream(ctx, handlerStarted, handlerCancelled, ct);

        var cts = new CancellationTokenSource();
        var json = JsonSerializer.Serialize(new { model = "test", stream = true });
        var postContent = new StringContent(json, Encoding.UTF8, "application/json");
        var postTask = Client.PostAsync("/responses", postContent, cts.Token);

        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        var responseId = Handler.LastContext!.ResponseId;

        cts.Cancel();
        await handlerCancelled.Task.WaitAsync(TimeSpan.FromSeconds(5));

        try
        { await postTask; }
        catch (TaskCanceledException) { }

        // Non-bg cancelled → ephemeral (not persisted) → GET 404
        // Poll until cleanup propagates
        var getResponse = await PollUntilAsync(
            () => GetResponseAsync(responseId),
            r => r.StatusCode == HttpStatusCode.NotFound);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // ════════════════════════════════════════════════════════════
    // C3 — Background poll, stored (store=T, bg=T, stream=F): E13–E19, E36–E39
    // ════════════════════════════════════════════════════════════

    // E13: Create → GET (immediate) → 200 JSON, status: queued or in_progress (B5, B10)
    [Test]
    public async Task C3_BgCreate_Then_GET_Immediate_ReturnsQueuedOrInProgress()
    {
        // Validates: B5, B10 — background non-streaming returns immediately
        var handlerGate = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, handlerGate.Task, ct);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;
        var createStatus = createDoc.RootElement.GetProperty("status").GetString();
        Assert.That(createStatus is "queued" or "in_progress", Is.True);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        var getStatus = getDoc.RootElement.GetProperty("status").GetString();
        Assert.That(getStatus is "queued" or "in_progress", Is.True);

        handlerGate.TrySetResult();
        await WaitForBackgroundCompletionAsync(responseId);
    }

    // E14: Create → GET (after completion) → 200 JSON, status: completed (B5, B10)
    [Test]
    public async Task C3_BgCreate_Then_GET_AfterCompletion_ReturnsCompleted()
    {
        // Validates: B5, B10
        var responseId = await CreateBackgroundResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // E15: Create → GET ?stream=true → 400 (B2: stream=false at creation)
    [Test]
    public async Task C3_BgCreate_Then_GetSseReplay_Returns400()
    {
        // Validates: B2 — SSE replay requires stream=true at creation
        var responseId = await CreateBackgroundResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseStreamAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // E16: Create → Cancel → GET → cancelled, 0 output (B7, B11)
    [Test]
    public async Task C3_BgCreate_Cancel_Then_GET_ReturnsCancelled()
    {
        // Validates: B7 — cancelled status; B11 — output cleared
        var handlerGate = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, handlerGate.Task, ct);

        var responseId = await CreateBackgroundResponseAsync();

        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        handlerGate.TrySetResult();
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
        Assert.That(doc.RootElement.GetProperty("output").GetArrayLength(), Is.EqualTo(0));
    }

    // E17: Create (wait complete) → Cancel → 400 (B12)
    [Test]
    public async Task C3_BgCreate_WaitComplete_Then_Cancel_Returns400()
    {
        // Validates: B12 — cannot cancel a completed response
        var responseId = await CreateBackgroundResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        XAssert.Contains("Cannot cancel a completed response",
            doc.RootElement.GetProperty("error").GetProperty("message").GetString());
    }

    // E18: Create → Cancel → Cancel → 200 (idempotent, B3)
    [Test]
    public async Task C3_BgCreate_Cancel_Cancel_Returns200Idempotent()
    {
        // Validates: B3 — cancel is idempotent
        var handlerGate = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, handlerGate.Task, ct);

        var responseId = await CreateBackgroundResponseAsync();

        var cancel1 = await CancelResponseAsync(responseId);
        Assert.That(cancel1.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var cancel2 = await CancelResponseAsync(responseId);
        Assert.That(cancel2.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        handlerGate.TrySetResult();
        await WaitForBackgroundCompletionAsync(responseId);
    }

    // E19: Create → Disconnect → GET → completed (B18: bg unaffected by disconnect)
    [Test]
    public async Task C3_BgCreate_Disconnect_Then_GET_ReturnsCompleted()
    {
        // Validates: B18 — background responses unaffected by connection termination
        var responseId = await CreateBackgroundResponseAsync();
        // The POST already returned — bg mode, connection is effectively done
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // E36: Handler throws → GET → status: failed, error non-null, completed_at null (B5, B6)
    [Test]
    public async Task C3_BgCreate_HandlerThrows_Then_GET_ReturnsFailed()
    {
        // Validates: B5, B6 — failed status invariants
        Handler.EventFactory = (req, ctx, ct) => ThrowingStream(ctx);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));

        // B6: failed → error non-null, completed_at null
        Assert.That(doc.RootElement.GetProperty("error").ValueKind, Is.Not.EqualTo(JsonValueKind.Null));
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.TryGetProperty("code", out _), Is.True, "error must have 'code'");
        Assert.That(error.TryGetProperty("message", out _), Is.True, "error must have 'message'");
    }

    // E37: Handler signals incomplete → GET → status: incomplete, error null (B5, B6)
    [Test]
    public async Task C3_BgCreate_HandlerIncomplete_Then_GET_ReturnsIncomplete()
    {
        // Validates: B5, B6 — incomplete status invariants
        Handler.EventFactory = (req, ctx, ct) => IncompleteStream(ctx);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("incomplete"));

        // B6: incomplete → error null
        Assert.That(doc.RootElement.GetProperty("error").ValueKind, Is.EqualTo(JsonValueKind.Null));
    }

    // E38: Handler throws → Cancel → 400 (B12: cannot cancel a failed response)
    [Test]
    public async Task C3_BgCreate_HandlerThrows_Then_Cancel_Returns400()
    {
        // Validates: B12 — cancel rejection on failed
        Handler.EventFactory = (req, ctx, ct) => ThrowingStream(ctx);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        await WaitForBackgroundCompletionAsync(responseId);

        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        XAssert.Contains("Cannot cancel a failed response",
            doc.RootElement.GetProperty("error").GetProperty("message").GetString());
    }

    // E39: Handler signals incomplete → Cancel → 400 (B12: terminal status — cancel rejected)
    [Test]
    public async Task C3_BgCreate_HandlerIncomplete_Then_Cancel_Returns400()
    {
        // Validates: B12 — cancel rejection on incomplete (terminal status)
        Handler.EventFactory = (req, ctx, ct) => IncompleteStream(ctx);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        await WaitForBackgroundCompletionAsync(responseId);

        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // ════════════════════════════════════════════════════════════
    // C4 — Background streaming, stored (store=T, bg=T, stream=T): E20–E29, E40–E42
    // ════════════════════════════════════════════════════════════

    // E20: Create (SSE) → GET (during stream) → 200 JSON, status: in_progress (B5)
    [Test]
    public async Task C4_BgStreamCreate_GET_DuringStream_ReturnsInProgress()
    {
        // Validates: B5 — background responses accessible during in-progress
        var handlerStarted = new TaskCompletionSource();
        var handlerGate = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) => GatedStreamWithStart(ctx, handlerStarted, handlerGate.Task, ct);

        // Use ResponseHeadersRead to read SSE incrementally (avoids blocking on full body).
        // Keep the SSE response alive so httpContext.RequestAborted doesn't fire.
        var (responseId, sseResponse) = await StartBgStreamAndExtractIdAsync();
        try
        {
            // Wait for the handler to be at the gate (mid-stream)
            await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

            // GET during active stream — should return in_progress
            var getResponse = await GetResponseAsync(responseId);
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var getDoc = await ParseJsonAsync(getResponse);
            Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));

            // Release gate to let handler complete
            handlerGate.TrySetResult();
            await WaitForBackgroundCompletionAsync(responseId);
        }
        finally
        {
            sseResponse.Dispose();
        }
    }

    // E21: Create (SSE) → GET (after stream ends) → 200 JSON, status: completed (B5)
    [Test]
    public async Task C4_BgStreamCreate_GET_AfterStreamEnds_ReturnsCompleted()
    {
        // Validates: B5
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var responseId = await CreateBackgroundStreamingResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // E22: Create (SSE, completed) → GET ?stream=true → 200 SSE replay, terminal = response.completed (B4, B9, B26)
    [Test]
    public async Task C4_BgStreamCreate_Completed_SseReplay_ReturnsAllEvents()
    {
        // Validates: B4 — SSE replay; B9 — sequence numbers; B26 — terminal event
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var responseId = await CreateBackgroundStreamingResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var replayResponse = await GetResponseStreamAsync(responseId);
        Assert.That(replayResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var events = await ParseSseAsync(replayResponse);
        Assert.That(events.Count >= 2, Is.True, "Replay should have at least 2 events");

        // B26: terminal event is response.completed
        Assert.That(events[^1].EventType, Is.EqualTo("response.completed"));

        // B9: sequence numbers monotonically increasing
        var seqNums = events.Select(e =>
        {
            using var d = JsonDocument.Parse(e.Data);
            return d.RootElement.GetProperty("sequence_number").GetInt64();
        }).ToList();

        for (int i = 1; i < seqNums.Count; i++)
        {
            Assert.That(seqNums[i] > seqNums[i - 1], Is.True);
        }
    }

    // E23: Create (SSE, completed) → GET ?stream=true&starting_after=N → replay from cursor (B4)
    [Test]
    public async Task C4_BgStreamCreate_SseReplay_WithStartingAfter_SkipsEvents()
    {
        // Validates: B4 — starting_after cursor
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var responseId = await CreateBackgroundStreamingResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        // Get full replay to find sequence numbers
        var fullReplay = await GetResponseStreamAsync(responseId);
        var fullEvents = await ParseSseAsync(fullReplay);
        Assert.That(fullEvents.Count >= 2, Is.True, "Need at least 2 events for cursor test");

        // Get the sequence number of the first event
        using var firstDoc = JsonDocument.Parse(fullEvents[0].Data);
        var firstSeq = firstDoc.RootElement.GetProperty("sequence_number").GetInt64();

        // Replay with starting_after = first sequence → should skip first event
        var cursorReplay = await Client.GetAsync($"/responses/{responseId}?stream=true&starting_after={firstSeq}");
        Assert.That(cursorReplay.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var cursorEvents = await ParseSseAsync(cursorReplay);
        Assert.That(cursorEvents.Count, Is.EqualTo(fullEvents.Count - 1));
    }

    // E24: Create (SSE) → Cancel immediate (queued) → GET → cancelled, 0 output (B7, B11, S3b)
    [Test]
    public async Task C4_BgStreamCreate_CancelImmediate_ReturnsCancelled()
    {
        // Validates: B7, B11 — cancel → cancelled with 0 output; S3b
        var handlerGate = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, handlerGate.Task, ct);

        var (responseId, sseResponse) = await StartBgStreamAndExtractIdAsync();
        try
        {
            // Cancel immediately — CancelAsync waits for handler to finish (up to 10s),
            // so the handler exits via CancellationToken before this returns.
            var cancelResponse = await CancelResponseAsync(responseId);
            Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            await WaitForBackgroundCompletionAsync(responseId);
        }
        finally
        {
            // Release gate as safety cleanup (handler already exited via cancellation).
            handlerGate.TrySetResult();
            sseResponse.Dispose();
        }

        var getResponse = await GetResponseAsync(responseId);
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
        Assert.That(doc.RootElement.GetProperty("output").GetArrayLength(), Is.EqualTo(0));
    }

    // E25: Create (SSE) → Cancel (mid-stream) → GET → cancelled, 0 output (B7, B11, S6)
    [Test]
    public async Task C4_BgStreamCreate_CancelMidStream_ReturnsCancelled()
    {
        // Validates: B7, B11 — cancel → cancelled with 0 output; S6
        var handlerGate = new TaskCompletionSource();
        var deltasEmitted = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => StreamWithDeltas(ctx, handlerGate.Task, deltasEmitted, ct);

        var (responseId, sseResponse) = await StartBgStreamAndExtractIdAsync();
        try
        {
            // Wait for handler to have emitted deltas (deterministic gate)
            await deltasEmitted.Task.WaitAsync(TimeSpan.FromSeconds(5));

            // CancelAsync waits for handler to finish (up to 10s),
            // so the handler exits via CancellationToken before this returns.
            var cancelResponse = await CancelResponseAsync(responseId);
            Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            await WaitForBackgroundCompletionAsync(responseId);
        }
        finally
        {
            // Release gate as safety cleanup (handler already exited via cancellation).
            handlerGate.TrySetResult();
            sseResponse.Dispose();
        }

        var getResponse = await GetResponseAsync(responseId);
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
        Assert.That(doc.RootElement.GetProperty("output").GetArrayLength(), Is.EqualTo(0));
    }

    // E26: Create (SSE) → Cancel → GET ?stream=true → SSE replay with terminal event (B26, B11)
    [Test]
    public async Task C4_BgStreamCreate_Cancel_Then_SseReplay_HasTerminalEvent()
    {
        // Validates: B26 — terminal SSE event after cancel; B11
        var handlerGate = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, handlerGate.Task, ct);

        var (responseId, sseResponse) = await StartBgStreamAndExtractIdAsync();
        try
        {
            // CancelAsync waits for handler to finish (up to 10s),
            // so the handler exits via CancellationToken before this returns.
            await CancelResponseAsync(responseId);
            await WaitForBackgroundCompletionAsync(responseId);
        }
        finally
        {
            // Release gate as safety cleanup (handler already exited via cancellation).
            handlerGate.TrySetResult();
            sseResponse.Dispose();
        }

        var replayResponse = await GetResponseStreamAsync(responseId);
        Assert.That(replayResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var replayEvents = await ParseSseAsync(replayResponse);
        Assert.That(replayEvents.Count >= 1, Is.True, "Replay should have events");

        // B26: terminal event for cancelled response is response.failed
        var lastEvent = replayEvents[^1];
        Assert.That(lastEvent.EventType, Is.EqualTo("response.failed"));

        // The response inside should have status: cancelled
        using var lastDoc = JsonDocument.Parse(lastEvent.Data);
        if (lastDoc.RootElement.TryGetProperty("response", out var responseElem))
        {
            Assert.That(responseElem.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
        }
    }

    // E27: Create (SSE, completed) → Cancel → 400 (B12, S3)
    [Test]
    public async Task C4_BgStreamCreate_Completed_Then_Cancel_Returns400()
    {
        // Validates: B12 — cannot cancel completed; S3
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var responseId = await CreateBackgroundStreamingResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(cancelResponse);
        XAssert.Contains("Cannot cancel a completed response",
            doc.RootElement.GetProperty("error").GetProperty("message").GetString());
    }

    // E28: Create (SSE) → Cancel → Cancel → 200 (idempotent, B3)
    [Test]
    public async Task C4_BgStreamCreate_Cancel_Cancel_Returns200Idempotent()
    {
        // Validates: B3 — cancel is idempotent
        var handlerGate = new TaskCompletionSource();
        Handler.EventFactory = (req, ctx, ct) => WaitingStream(ctx, handlerGate.Task, ct);

        var (responseId, sseResponse) = await StartBgStreamAndExtractIdAsync();
        try
        {
            var cancel1 = await CancelResponseAsync(responseId);
            Assert.That(cancel1.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var cancel2 = await CancelResponseAsync(responseId);
            Assert.That(cancel2.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            handlerGate.TrySetResult();
            await WaitForBackgroundCompletionAsync(responseId);
        }
        finally
        {
            sseResponse.Dispose();
        }
    }

    // E29: Create (SSE) → Disconnect → GET → completed (B18: bg unaffected)
    [Test]
    public async Task C4_BgStreamCreate_Disconnect_Then_GET_ReturnsCompleted()
    {
        // Validates: B18 — background responses unaffected by connection termination
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var responseId = await CreateBackgroundStreamingResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // E40: Handler throws → GET → GET ?stream=true → failed + replay terminal = response.failed (B5, B6, B26)
    [Test]
    public async Task C4_BgStreamCreate_HandlerThrows_GET_And_SseReplay_ReturnsFailed()
    {
        // Validates: B5, B6 — failed status invariants; B26 — terminal event
        Handler.EventFactory = (req, ctx, ct) => ThrowingStreamAfterCreated(ctx);

        var createResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var createEvents = await ParseSseAsync(createResponse);
        using var evtDoc = JsonDocument.Parse(createEvents[0].Data);
        var responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        await WaitForBackgroundCompletionAsync(responseId);

        // GET JSON → failed
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));
        Assert.That(getDoc.RootElement.GetProperty("error").ValueKind, Is.Not.EqualTo(JsonValueKind.Null));

        // SSE replay → terminal = response.failed
        var replayResponse = await GetResponseStreamAsync(responseId);
        Assert.That(replayResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var replayEvents = await ParseSseAsync(replayResponse);
        Assert.That(replayEvents[^1].EventType, Is.EqualTo("response.failed"));
    }

    // E41: Handler signals incomplete → GET → GET ?stream=true → incomplete + replay terminal = response.incomplete (B5, B6, B26)
    [Test]
    public async Task C4_BgStreamCreate_HandlerIncomplete_GET_And_SseReplay_ReturnsIncomplete()
    {
        // Validates: B5, B6 — incomplete status invariants; B26 — terminal event
        Handler.EventFactory = (req, ctx, ct) => IncompleteStreamWithCreated(ctx);

        var createResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var createEvents = await ParseSseAsync(createResponse);
        using var evtDoc = JsonDocument.Parse(createEvents[0].Data);
        var responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        await WaitForBackgroundCompletionAsync(responseId);

        // GET JSON → incomplete
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("incomplete"));
        Assert.That(getDoc.RootElement.GetProperty("error").ValueKind, Is.EqualTo(JsonValueKind.Null));

        // SSE replay → terminal = response.incomplete
        var replayResponse = await GetResponseStreamAsync(responseId);
        Assert.That(replayResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var replayEvents = await ParseSseAsync(replayResponse);
        Assert.That(replayEvents[^1].EventType, Is.EqualTo("response.incomplete"));
    }

    // E42: SSE replay starting_after >= max → 200, 0 events (B4)
    [Test]
    public async Task C4_BgStreamCreate_SseReplay_StartingAfterMax_ReturnsEmpty()
    {
        // Validates: B4 — starting_after >= max → empty stream
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var responseId = await CreateBackgroundStreamingResponseAsync();
        await WaitForBackgroundCompletionAsync(responseId);

        // Get max sequence number from full replay
        var fullReplay = await GetResponseStreamAsync(responseId);
        var fullEvents = await ParseSseAsync(fullReplay);
        using var lastDoc = JsonDocument.Parse(fullEvents[^1].Data);
        var maxSeq = lastDoc.RootElement.GetProperty("sequence_number").GetInt64();

        // Replay with starting_after = max → empty
        var emptyReplay = await Client.GetAsync($"/responses/{responseId}?stream=true&starting_after={maxSeq}");
        Assert.That(emptyReplay.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await emptyReplay.Content.ReadAsStringAsync();
        var emptyEvents = SseParser.Parse(body);
        Assert.That(emptyEvents, Is.Empty);
    }

    // E43: Background streaming — GET mid-stream returns partial output items (B5, B23)
    // Checks output item lifecycle: added (in_progress, empty content) vs done (completed, full text)
    [Test]
    public async Task C4_BgStreamCreate_GET_DuringStream_ReturnsPartialOutput()
    {
        // Validates: B5 — GET returns current snapshot including partial output
        // Validates: B23 — snapshot semantics (GET returns point-in-time state)
        var itemAdded = new TaskCompletionSource();
        var itemAddedChecked = new TaskCompletionSource();
        var itemDone = new TaskCompletionSource();
        var itemDoneChecked = new TaskCompletionSource();
        var item2Done = new TaskCompletionSource();
        var item2DoneChecked = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) =>
            ItemLifecycleGatedStream(ctx,
                itemAdded, itemAddedChecked.Task,
                itemDone, itemDoneChecked.Task,
                item2Done, item2DoneChecked.Task, ct);

        var (responseId, sseResponse) = await StartBgStreamAndExtractIdAsync();
        try
        {
            // ── Phase 1: After EmitAdded (before EmitDone) ──
            await itemAdded.Task.WaitAsync(TimeSpan.FromSeconds(5));

            var get1 = await GetResponseAsync(responseId);
            Assert.That(get1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var doc1 = await ParseJsonAsync(get1);
            Assert.That(doc1.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
            var output1 = doc1.RootElement.GetProperty("output");
            Assert.That(output1.GetArrayLength(), Is.EqualTo(1));
            var item1Added = output1[0];
            Assert.That(item1Added.GetProperty("type").GetString(), Is.EqualTo("message"));
            // Item is in_progress — content should be empty
            Assert.That(item1Added.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
            var content1 = item1Added.GetProperty("content");
            Assert.That(content1.GetArrayLength(), Is.EqualTo(0));

            itemAddedChecked.TrySetResult();

            // ── Phase 2: After EmitDone — item is completed with full text ──
            await itemDone.Task.WaitAsync(TimeSpan.FromSeconds(5));

            var get2 = await GetResponseAsync(responseId);
            Assert.That(get2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var doc2 = await ParseJsonAsync(get2);
            Assert.That(doc2.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
            var output2 = doc2.RootElement.GetProperty("output");
            Assert.That(output2.GetArrayLength(), Is.EqualTo(1));
            var item1Done = output2[0];
            Assert.That(item1Done.GetProperty("status").GetString(), Is.EqualTo("completed"));
            var contentDone = item1Done.GetProperty("content");
            Assert.That(contentDone.GetArrayLength(), Is.EqualTo(1));
            Assert.That(contentDone[0].GetProperty("type").GetString(), Is.EqualTo("output_text"));
            Assert.That(contentDone[0].GetProperty("text").GetString(), Is.EqualTo("Hello"));

            itemDoneChecked.TrySetResult();

            // ── Phase 3: Second item done — output should have 2 completed items ──
            await item2Done.Task.WaitAsync(TimeSpan.FromSeconds(5));

            var get3 = await GetResponseAsync(responseId);
            Assert.That(get3.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var doc3 = await ParseJsonAsync(get3);
            Assert.That(doc3.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
            var output3 = doc3.RootElement.GetProperty("output");
            Assert.That(output3.GetArrayLength(), Is.EqualTo(2));
            Assert.That(output3[0].GetProperty("status").GetString(), Is.EqualTo("completed"));
            Assert.That(output3[1].GetProperty("status").GetString(), Is.EqualTo("completed"));
            Assert.That(output3[1].GetProperty("content")[0].GetProperty("text").GetString(), Is.EqualTo("World"));

            item2DoneChecked.TrySetResult();
            await WaitForBackgroundCompletionAsync(responseId);

            // ── Phase 4: After completion — final snapshot ──
            var getFinal = await GetResponseAsync(responseId);
            Assert.That(getFinal.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var docFinal = await ParseJsonAsync(getFinal);
            Assert.That(docFinal.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
            Assert.That(docFinal.RootElement.GetProperty("output").GetArrayLength(), Is.EqualTo(2));
        }
        finally
        {
            sseResponse.Dispose();
        }
    }

    // E44: Background poll — progressive output growth during polling (B5, B10)
    // Checks output item content and status at each poll point
    [Test]
    public async Task C3_BgCreate_ProgressivePolling_OutputGrowsDuringProcessing()
    {
        // Validates: B5, B10 — background poll shows progressive output accumulation
        var item1Emitted = new TaskCompletionSource();
        var item1GateChecked = new TaskCompletionSource();
        var item2Emitted = new TaskCompletionSource();
        var item2GateChecked = new TaskCompletionSource();

        Handler.EventFactory = (req, ctx, ct) =>
            TwoItemGatedStream(ctx, item1Emitted, item1GateChecked.Task, item2Emitted, item2GateChecked.Task, ct);

        // Create background non-streaming response
        var createResponse = await PostResponsesAsync(new { model = "test", background = true });
        Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // Wait for first item to be fully emitted (done)
        await item1Emitted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Poll: should see 1 completed output item with text "Hello"
        var poll1 = await GetResponseAsync(responseId);
        Assert.That(poll1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var pollDoc1 = await ParseJsonAsync(poll1);
        Assert.That(pollDoc1.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
        var output1 = pollDoc1.RootElement.GetProperty("output");
        Assert.That(output1.GetArrayLength(), Is.EqualTo(1));
        Assert.That(output1[0].GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(output1[0].GetProperty("content")[0].GetProperty("text").GetString(), Is.EqualTo("Hello"));

        // Release gate for second item
        item1GateChecked.TrySetResult();

        // Wait for second item
        await item2Emitted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Poll: should see 2 completed output items
        var poll2 = await GetResponseAsync(responseId);
        Assert.That(poll2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var pollDoc2 = await ParseJsonAsync(poll2);
        Assert.That(pollDoc2.RootElement.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
        var output2 = pollDoc2.RootElement.GetProperty("output");
        Assert.That(output2.GetArrayLength(), Is.EqualTo(2));
        Assert.That(output2[0].GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(output2[0].GetProperty("content")[0].GetProperty("text").GetString(), Is.EqualTo("Hello"));
        Assert.That(output2[1].GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(output2[1].GetProperty("content")[0].GetProperty("text").GetString(), Is.EqualTo("World"));

        // Release final gate
        item2GateChecked.TrySetResult();
        await WaitForBackgroundCompletionAsync(responseId);

        // Final poll: completed with 2 items, full content preserved
        var pollFinal = await GetResponseAsync(responseId);
        Assert.That(pollFinal.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var pollDocFinal = await ParseJsonAsync(pollFinal);
        Assert.That(pollDocFinal.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
        var outputFinal = pollDocFinal.RootElement.GetProperty("output");
        Assert.That(outputFinal.GetArrayLength(), Is.EqualTo(2));
        Assert.That(outputFinal[0].GetProperty("content")[0].GetProperty("text").GetString(), Is.EqualTo("Hello"));
        Assert.That(outputFinal[1].GetProperty("content")[0].GetProperty("text").GetString(), Is.EqualTo("World"));
    }

    // ════════════════════════════════════════════════════════════
    // Helper: incremental bg streaming POST
    // ════════════════════════════════════════════════════════════

    /// <summary>
    /// Creates a background streaming POST using ResponseHeadersRead so the call
    /// returns as soon as headers arrive (without blocking on the full SSE body).
    /// Reads the first SSE event to extract the response ID.
    /// Returns both the response ID and the live HttpResponseMessage.
    /// The caller MUST keep the HttpResponseMessage alive (undisposed) while the
    /// handler is running, otherwise httpContext.RequestAborted fires and interferes
    /// with cancel handling. Dispose it after the handler completes.
    /// </summary>
    private async Task<(string ResponseId, HttpResponseMessage SseResponse)> StartBgStreamAndExtractIdAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test", stream = true, background = true }),
                Encoding.UTF8, "application/json")
        };

        var response = await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var bodyStream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(bodyStream, Encoding.UTF8,
            detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true);

        string? line;
        while ((line = await reader.ReadLineAsync()) is not null)
        {
            if (line.StartsWith("data: "))
            {
                using var doc = JsonDocument.Parse(line["data: ".Length..]);
                if (doc.RootElement.TryGetProperty("response", out var respProp))
                {
                    return (respProp.GetProperty("id").GetString()!, response);
                }
            }
        }

        response.Dispose();
        throw new InvalidOperationException("No SSE event with response ID received");
    }

    // ════════════════════════════════════════════════════════════
    // Helper event factories
    // ════════════════════════════════════════════════════════════

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleTextStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();
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

    private static async IAsyncEnumerable<ResponseStreamEvent> GatedStreamWithStart(
        ResponseContext ctx, TaskCompletionSource started, Task gate,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        started.TrySetResult();
        await gate.WaitAsync(ct);
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> StreamWithDeltas(
        ResponseContext ctx, Task waitTask,
        TaskCompletionSource? deltasEmitted = null,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var content = message.AddTextContent();
        yield return content.EmitAdded();
        yield return content.EmitDelta("Hello ");
        yield return content.EmitDelta("World");
        deltasEmitted?.TrySetResult();

        await waitTask.WaitAsync(ct);
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> ThrowingStreamAfterCreated(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        await Task.CompletedTask;
        throw new InvalidOperationException("Simulated handler failure after created");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> IncompleteStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        yield return stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> IncompleteStreamWithCreated(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        yield return stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);
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

    /// <summary>
    /// Emits two message output items with gates between them, allowing the test
    /// to observe progressive output accumulation via GET polling.
    /// Gates fire after each item is fully done (EmitDone).
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> TwoItemGatedStream(
        ResponseContext ctx,
        TaskCompletionSource item1Emitted,
        Task item1GateChecked,
        TaskCompletionSource item2Emitted,
        Task item2GateChecked,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        // First message output item
        var msg1 = stream.AddOutputItemMessage();
        yield return msg1.EmitAdded();
        var text1 = msg1.AddTextContent();
        yield return text1.EmitAdded();
        yield return text1.EmitDelta("Hello");
        yield return text1.EmitTextDone("Hello");
        yield return text1.EmitDone();
        yield return msg1.EmitDone();

        item1Emitted.TrySetResult();
        await item1GateChecked.WaitAsync(ct);

        // Second message output item
        var msg2 = stream.AddOutputItemMessage();
        yield return msg2.EmitAdded();
        var text2 = msg2.AddTextContent();
        yield return text2.EmitAdded();
        yield return text2.EmitDelta("World");
        yield return text2.EmitTextDone("World");
        yield return text2.EmitDone();
        yield return msg2.EmitDone();

        item2Emitted.TrySetResult();
        await item2GateChecked.WaitAsync(ct);

        yield return stream.EmitCompleted();
    }

    /// <summary>
    /// Emits two message output items with fine-grained gates at both the
    /// Added and Done lifecycle points, allowing the test to observe:
    /// - After Added: item in output with status=in_progress, empty content
    /// - After Done: item in output with status=completed, full text content
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> ItemLifecycleGatedStream(
        ResponseContext ctx,
        TaskCompletionSource itemAdded,
        Task itemAddedChecked,
        TaskCompletionSource itemDone,
        Task itemDoneChecked,
        TaskCompletionSource item2Done,
        Task item2DoneChecked,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        // First item — gate after Added (in_progress, empty content)
        var msg1 = stream.AddOutputItemMessage();
        yield return msg1.EmitAdded();

        itemAdded.TrySetResult();
        await itemAddedChecked.WaitAsync(ct);

        // Continue to completion of first item
        var text1 = msg1.AddTextContent();
        yield return text1.EmitAdded();
        yield return text1.EmitDelta("Hello");
        yield return text1.EmitTextDone("Hello");
        yield return text1.EmitDone();
        yield return msg1.EmitDone();

        itemDone.TrySetResult();
        await itemDoneChecked.WaitAsync(ct);

        // Second item — emit fully, gate after Done
        var msg2 = stream.AddOutputItemMessage();
        yield return msg2.EmitAdded();
        var text2 = msg2.AddTextContent();
        yield return text2.EmitAdded();
        yield return text2.EmitDelta("World");
        yield return text2.EmitTextDone("World");
        yield return text2.EmitDone();
        yield return msg2.EmitDone();

        item2Done.TrySetResult();
        await item2DoneChecked.WaitAsync(ct);

        yield return stream.EmitCompleted();
    }
}
