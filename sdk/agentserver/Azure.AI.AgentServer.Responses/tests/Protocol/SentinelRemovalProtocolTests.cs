// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for sentinel removal (US1, US2).
/// Validates that no SSE stream contains <c>data: [DONE]</c> under any scenario.
/// Validates: B26 — Terminal SSE events (no [DONE] sentinel)
/// </summary>
public class SentinelRemovalProtocolTests : ProtocolTestBase
{
    // ── US1: Live streams must not contain [DONE] sentinel ────

    [Test]
    public async Task LiveStream_Completed_NoDoneSentinel()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        XAssert.DoesNotContain("data: [DONE]", body);
    }

    [Test]
    public async Task LiveStream_Failed_NoDoneSentinel()
    {
        Handler.EventFactory = (req, ctx, ct) => FailingStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        XAssert.DoesNotContain("data: [DONE]", body);

        // Verify the stream contains a response.failed terminal event
        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "response.failed");
    }

    [Test]
    public async Task LiveStream_Incomplete_NoDoneSentinel()
    {
        Handler.EventFactory = (req, ctx, ct) => IncompleteStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        XAssert.DoesNotContain("data: [DONE]", body);

        // Verify the stream contains a response.incomplete terminal event
        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "response.incomplete");
    }

    // ── US2: Replay streams must not contain [DONE] sentinel ──

    [Test]
    public async Task ReplayStream_Completed_NoDoneSentinel()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var responseId = await CreateBackgroundStreamingResponseAsync();

        var getResponse = await GetResponseStreamAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await getResponse.Content.ReadAsStringAsync();
        XAssert.DoesNotContain("data: [DONE]", body);
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleTextStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("Hello");
        yield return text.EmitTextDone("Hello");
        yield return text.EmitDone();
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> FailingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();
        throw new InvalidOperationException("Simulated handler failure");
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> IncompleteStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();
        yield return stream.EmitIncomplete();
    }
}
