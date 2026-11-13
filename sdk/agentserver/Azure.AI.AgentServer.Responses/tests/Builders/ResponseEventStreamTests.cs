// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class ResponseEventStreamTests
{
    private static ResponseEventStream CreateStream()
    {
        return new ResponseEventStream(new ResponseContext("resp_test"), new CreateResponse { Model = "gpt-4o" });
    }

    [Test]
    public void Constructor_AcceptsResponseContextAndCreateResponse()
    {
        var context = new ResponseContext("resp_test");
        var request = new CreateResponse { Model = "gpt-4o" };

        var stream = new ResponseEventStream(context, request);

        Assert.That(stream, Is.Not.Null);
    }

    [Test]
    public void NextSequenceNumber_FirstCallReturnsZero()
    {
        var stream = CreateStream();

        var seq = stream.NextSequenceNumber();

        Assert.That(seq, Is.EqualTo(0));
    }

    [Test]
    public void NextSequenceNumber_IncrementsMonotonically()
    {
        var stream = CreateStream();

        var seq0 = stream.NextSequenceNumber();
        var seq1 = stream.NextSequenceNumber();
        var seq2 = stream.NextSequenceNumber();

        Assert.That(seq0, Is.EqualTo(0));
        Assert.That(seq1, Is.EqualTo(1));
        Assert.That(seq2, Is.EqualTo(2));
    }

    [Test]
    public void NextSequenceNumber_PostIncrementSemantics()
    {
        var stream = CreateStream();

        // First call returns current value (0), then increments
        Assert.That(stream.NextSequenceNumber(), Is.EqualTo(0));
        // Second call returns current value (1), then increments
        Assert.That(stream.NextSequenceNumber(), Is.EqualTo(1));
    }

    // ── Lifecycle Emit Methods ────────────────────────────────

    [Test]
    public void EmitCreated_ReturnsResponseCreatedEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitCreated();

        XAssert.IsType<ResponseCreatedEvent>(evt);
        Assert.That(evt.SequenceNumber, Is.EqualTo(0));
        Assert.That(evt.Response, Is.SameAs(stream.Response));
    }

    [Test]
    public void EmitInProgress_ReturnsResponseInProgressEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitInProgress();

        XAssert.IsType<ResponseInProgressEvent>(evt);
        Assert.That(evt.SequenceNumber, Is.EqualTo(0));
        Assert.That(evt.Response, Is.SameAs(stream.Response));
    }

    [Test]
    public void EmitCompleted_ReturnsResponseCompletedEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitCompleted();

        XAssert.IsType<ResponseCompletedEvent>(evt);
        Assert.That(evt.SequenceNumber, Is.EqualTo(0));
        Assert.That(evt.Response, Is.SameAs(stream.Response));
    }

    [Test]
    public void EmitQueued_ReturnsResponseQueuedEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitQueued();

        XAssert.IsType<ResponseQueuedEvent>(evt);
        Assert.That(evt.SequenceNumber, Is.EqualTo(0));
        Assert.That(evt.Response, Is.SameAs(stream.Response));
    }

    [Test]
    public void EmitFailed_ReturnsResponseFailedEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitFailed(ResponseErrorCode.ServerError, "test error");

        XAssert.IsType<ResponseFailedEvent>(evt);
        Assert.That(evt.SequenceNumber, Is.EqualTo(0));
        Assert.That(evt.Response, Is.SameAs(stream.Response));
    }

    [Test]
    public void EmitIncomplete_ReturnsResponseIncompleteEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitIncomplete();

        XAssert.IsType<ResponseIncompleteEvent>(evt);
        Assert.That(evt.SequenceNumber, Is.EqualTo(0));
        Assert.That(evt.Response, Is.SameAs(stream.Response));
    }

    [Test]
    public void EmitMethods_IncrementSequenceNumber()
    {
        var stream = CreateStream();

        var created = stream.EmitCreated();
        var inProgress = stream.EmitInProgress();
        var completed = stream.EmitCompleted();

        Assert.That(created.SequenceNumber, Is.EqualTo(0));
        Assert.That(inProgress.SequenceNumber, Is.EqualTo(1));
        Assert.That(completed.SequenceNumber, Is.EqualTo(2));
    }

    [Test]
    public void EmitMethods_UseStreamOwnedResponse()
    {
        var stream = CreateStream();

        var evt = stream.EmitCreated();

        // Models.ResponseObject is the stream-owned Models.ResponseObject
        Assert.That(evt.Response, Is.SameAs(stream.Response));
    }

    // ── T037: Partition key colocation ────────────────────────

    [Test]
    public void AllItemIds_SharePartitionKey_WithResponseId()
    {
        // Use a real-format response ID so partition keys propagate
        var responseId = IdGenerator.NewResponseId();
        var expectedPk = IdGenerator.ExtractPartitionKey(responseId);
        var context = new ResponseContext(responseId);
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });

        var msg = stream.AddOutputItemMessage();
        var fc = stream.AddOutputItemFunctionCall("fn", "call1");
        var rs = stream.AddOutputItemReasoningItem();
        var fs = stream.AddOutputItemFileSearchCall();
        var ws = stream.AddOutputItemWebSearchCall();
        var ci = stream.AddOutputItemCodeInterpreterCall();
        var ig = stream.AddOutputItemImageGenCall();
        var mcp = stream.AddOutputItemMcpCall("server", "tool");
        var mcpl = stream.AddOutputItemMcpListTools("server");
        var ctc = stream.AddOutputItemCustomToolCall("c1", "tool");

        // Extract ItemId from each builder and verify partition key matches response
        var itemIds = new[]
        {
            msg.ItemId, fc.ItemId, rs.ItemId, fs.ItemId, ws.ItemId,
            ci.ItemId, ig.ItemId, mcp.ItemId, mcpl.ItemId, ctc.ItemId
        };

        foreach (var itemId in itemIds)
        {
            var pk = IdGenerator.ExtractPartitionKey(itemId);
            Assert.That(pk, Is.EqualTo(expectedPk));
        }
    }

    // ── T014: Constructor & Ownership Tests ───────────────────

    [Test]
    public void Constructor_WithRequest_BuildsResponseFromContextAndRequest()
    {
        var context = new ResponseContext("resp_t14");
        var request = new CreateResponse { Model = "gpt-4o" };

        var stream = new ResponseEventStream(context, request);
        var created = stream.EmitCreated();

        Assert.That(created.Response.Id, Is.EqualTo("resp_t14"));
        Assert.That(created.Response.Model, Is.EqualTo("gpt-4o"));
        Assert.That(created.Response.Status, Is.EqualTo(ResponseStatus.InProgress));
    }

    [Test]
    public void Constructor_WithCreateResponse_StreamOwnsResponse()
    {
        var context = new ResponseContext("resp_own");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "test-model" });
        var created = stream.EmitCreated();

        Assert.That(created.Response, Is.SameAs(stream.Response));
    }

    [Test]
    public void Constructor_WithRequest_StreamResponseIsNotExternalReference()
    {
        var context = new ResponseContext("resp_ext");
        var request = new CreateResponse { Model = "gpt-4o" };

        var stream = new ResponseEventStream(context, request);
        var evt = stream.EmitCreated();

        // The stream builds its own Models.ResponseObject — it's not the same as any externally-created instance
        var externalResponse = new Models.ResponseObject("resp_ext", "gpt-4o");
        Assert.That(evt.Response, Is.Not.SameAs(externalResponse));
    }

    [Test]
    public void EmitCreated_EmbedsStreamOwnedResponse()
    {
        var stream = CreateStream();

        var evt1 = stream.EmitCreated();
        var evt2 = stream.EmitInProgress();

        // Both events reference the same stream-owned response
        Assert.That(evt2.Response, Is.SameAs(evt1.Response));
    }

    // ── T015: EmitCompleted Tests ─────────────────────────────

    [Test]
    public void EmitCompleted_WithUsage_SetsStatusCompletedAtAndUsage()
    {
        var stream = CreateStream();
        var usage = new ResponseUsage(10, new ResponseUsageInputTokensDetails(0), 5, new ResponseUsageOutputTokensDetails(0), 15);

        var before = DateTimeOffset.UtcNow;
        var evt = stream.EmitCompleted(usage);
        var after = DateTimeOffset.UtcNow;

        Assert.That(evt.Response.Status, Is.EqualTo(ResponseStatus.Completed));
        Assert.That(evt.Response.CompletedAt, Is.Not.Null);
        XAssert.InRange(evt.Response.CompletedAt!.Value, before, after);
        Assert.That(evt.Response.Usage, Is.SameAs(usage));
    }

    [Test]
    public void EmitCompleted_WithoutUsage_SetsStatusAndCompletedAtButNoUsage()
    {
        var stream = CreateStream();

        var evt = stream.EmitCompleted();

        Assert.That(evt.Response.Status, Is.EqualTo(ResponseStatus.Completed));
        Assert.That(evt.Response.CompletedAt, Is.Not.Null);
        Assert.That(evt.Response.Usage, Is.Null);
    }

    [Test]
    public void EmitCompleted_WithAccumulatedOutput_DoesNotSetOutputText()
    {
        var stream = CreateStream();

        // Simulate accumulated output items
        var textContent = new MessageContentOutputTextContent("Hello world", Array.Empty<Annotation>(), Array.Empty<LogProb>());
        var item = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[] { textContent });
        stream.TrackCompletedOutputItem(item, 0);

        var evt = stream.EmitCompleted();

        // output_text is a client SDK convenience property; the server never sets it.
        Assert.That(evt.Response.OutputText, Is.Null);
    }

    // ── T016: EmitFailed Tests ────────────────────────────────

    [Test]
    public void EmitFailed_WithCodeAndMessage_SetsErrorFields()
    {
        var stream = CreateStream();

        var evt = stream.EmitFailed(ResponseErrorCode.RateLimitExceeded, "Too many requests");

        Assert.That(evt.Response.Status, Is.EqualTo(ResponseStatus.Failed));
        Assert.That(evt.Response.Error, Is.Not.Null);
        Assert.That(evt.Response.Error.Code, Is.EqualTo(ResponseErrorCode.RateLimitExceeded));
        Assert.That(evt.Response.Error.Message, Is.EqualTo("Too many requests"));
        Assert.That(evt.Response.CompletedAt, Is.Null);
    }

    [Test]
    public void EmitFailed_WithDefaults_UsesServerErrorAndDefaultMessage()
    {
        var stream = CreateStream();

        var evt = stream.EmitFailed();

        Assert.That(evt.Response.Status, Is.EqualTo(ResponseStatus.Failed));
        Assert.That(evt.Response.Error, Is.Not.Null);
        Assert.That(evt.Response.Error.Code, Is.EqualTo(ResponseErrorCode.ServerError));
        Assert.That(evt.Response.Error.Message, Is.EqualTo("An internal server error occurred."));
    }

    [Test]
    public void EmitFailed_DoesNotSetOutputText()
    {
        var stream = CreateStream();

        var textContent = new MessageContentOutputTextContent("partial", Array.Empty<Annotation>(), Array.Empty<LogProb>());
        var item = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[] { textContent });
        stream.TrackCompletedOutputItem(item, 0);

        var evt = stream.EmitFailed(ResponseErrorCode.ServerError, "err");

        // output_text is a client SDK convenience property; the server never sets it.
        Assert.That(evt.Response.OutputText, Is.Null);
    }

    // ── T017: EmitIncomplete Tests ────────────────────────────

    [Test]
    public void EmitIncomplete_WithReason_SetsIncompleteDetails()
    {
        var stream = CreateStream();

        var evt = stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);

        Assert.That(evt.Response.Status, Is.EqualTo(ResponseStatus.Incomplete));
        Assert.That(evt.Response.IncompleteDetails, Is.Not.Null);
        Assert.That(evt.Response.IncompleteDetails.Reason, Is.EqualTo(ResponseIncompleteDetailsReason.MaxOutputTokens));
        Assert.That(evt.Response.CompletedAt, Is.Null);
    }

    [Test]
    public void EmitIncomplete_WithoutReason_LeavesIncompleteDetailsNull()
    {
        var stream = CreateStream();

        var evt = stream.EmitIncomplete();

        Assert.That(evt.Response.Status, Is.EqualTo(ResponseStatus.Incomplete));
        Assert.That(evt.Response.IncompleteDetails, Is.Null);
        Assert.That(evt.Response.CompletedAt, Is.Null);
    }

    [Test]
    public void EmitIncomplete_DoesNotSetOutputText()
    {
        var stream = CreateStream();

        var textContent = new MessageContentOutputTextContent("so far", Array.Empty<Annotation>(), Array.Empty<LogProb>());
        var item = new OutputItemMessage(
            "msg_1",
            MessageStatus.Completed,
            new MessageContent[] { textContent });
        stream.TrackCompletedOutputItem(item, 0);

        var evt = stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);

        // output_text is a client SDK convenience property; the server never sets it.
        Assert.That(evt.Response.OutputText, Is.Null);
    }
}
