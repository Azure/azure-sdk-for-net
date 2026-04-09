// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for detecting direct Models.ResponseObject.Output manipulation (B30/S-033).
/// Validates that the SDK detects when a handler directly adds/removes items from
/// Models.ResponseObject.Output without emitting corresponding output_item.* builder events.
/// </summary>
public class OutputManipulationDetectionTests : ProtocolTestBase
{
    // ── T027: Direct Output manipulation detection ────────────

    [Test]
    public async Task POST_Responses_DirectOutputAdd_WithoutBuilderEvents_ReturnsBadHandlerError()
    {
        // Handler directly adds an item to Models.ResponseObject.Output without emitting output_item.added
        // → SDK detects inconsistency and fails with bad handler error (B30/S-033)
        Handler.EventFactory = (req, ctx, ct) => OutputManipulationStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        // Output manipulation detected after response.created (post-created error)
        // → response lifecycle completes as failed
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("server_error"));
        Assert.That(error.GetProperty("message").GetString()!, Is.EqualTo("An internal server error occurred."));
    }

    [Test]
    public async Task POST_Responses_Streaming_DirectOutputAdd_WithoutBuilderEvents_EmitsFailedEvent()
    {
        // Same scenario in streaming mode — bad handler detected, response.failed emitted
        Handler.EventFactory = (req, ctx, ct) => OutputManipulationStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var events = await ParseSseAsync(response);

        // Should have response.created (handler emitted it) then response.failed (SDK detected manipulation)
        XAssert.Contains(events, e => e.EventType == "response.created");
        XAssert.Contains(events, e => e.EventType == "response.failed");
        XAssert.DoesNotContain(events, e => e.EventType == "response.completed");
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> OutputManipulationStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();

        // Directly manipulate Output without using builder events (B30/S-033 violation)
        stream.Response.Output.Add(new OutputItemMessage(
            "fake-item-id",
            MessageStatus.Completed,
            Array.Empty<MessageContent>()));

        yield return stream.EmitCompleted();
    }
}
