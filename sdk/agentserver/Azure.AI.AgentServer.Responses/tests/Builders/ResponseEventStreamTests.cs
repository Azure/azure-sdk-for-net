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
    public void Constructor_AcceptsIResponseContextAndCreateResponse()
    {
        var context = new ResponseContext("resp_test");
        var request = new CreateResponse { Model = "gpt-4o" };

        var stream = new ResponseEventStream(context, request);

        Assert.IsNotNull(stream);
    }

    [Test]
    public void NextSequenceNumber_FirstCallReturnsZero()
    {
        var stream = CreateStream();

        var seq = stream.NextSequenceNumber();

        Assert.AreEqual(0, seq);
    }

    [Test]
    public void NextSequenceNumber_IncrementsMonotonically()
    {
        var stream = CreateStream();

        var seq0 = stream.NextSequenceNumber();
        var seq1 = stream.NextSequenceNumber();
        var seq2 = stream.NextSequenceNumber();

        Assert.AreEqual(0, seq0);
        Assert.AreEqual(1, seq1);
        Assert.AreEqual(2, seq2);
    }

    [Test]
    public void NextSequenceNumber_PostIncrementSemantics()
    {
        var stream = CreateStream();

        // First call returns current value (0), then increments
        Assert.AreEqual(0, stream.NextSequenceNumber());
        // Second call returns current value (1), then increments
        Assert.AreEqual(1, stream.NextSequenceNumber());
    }

    // ── Lifecycle Emit Methods ────────────────────────────────

    [Test]
    public void EmitCreated_ReturnsResponseCreatedEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitCreated();

        XAssert.IsType<ResponseCreatedEvent>(evt);
        Assert.AreEqual(0, evt.SequenceNumber);
        Assert.AreSame(stream.Response, evt.Response);
    }

    [Test]
    public void EmitInProgress_ReturnsResponseInProgressEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitInProgress();

        XAssert.IsType<ResponseInProgressEvent>(evt);
        Assert.AreEqual(0, evt.SequenceNumber);
        Assert.AreSame(stream.Response, evt.Response);
    }

    [Test]
    public void EmitCompleted_ReturnsResponseCompletedEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitCompleted();

        XAssert.IsType<ResponseCompletedEvent>(evt);
        Assert.AreEqual(0, evt.SequenceNumber);
        Assert.AreSame(stream.Response, evt.Response);
    }

    [Test]
    public void EmitQueued_ReturnsResponseQueuedEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitQueued();

        XAssert.IsType<ResponseQueuedEvent>(evt);
        Assert.AreEqual(0, evt.SequenceNumber);
        Assert.AreSame(stream.Response, evt.Response);
    }

    [Test]
    public void EmitFailed_ReturnsResponseFailedEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitFailed(ResponseErrorCode.ServerError, "test error");

        XAssert.IsType<ResponseFailedEvent>(evt);
        Assert.AreEqual(0, evt.SequenceNumber);
        Assert.AreSame(stream.Response, evt.Response);
    }

    [Test]
    public void EmitIncomplete_ReturnsResponseIncompleteEvent()
    {
        var stream = CreateStream();

        var evt = stream.EmitIncomplete();

        XAssert.IsType<ResponseIncompleteEvent>(evt);
        Assert.AreEqual(0, evt.SequenceNumber);
        Assert.AreSame(stream.Response, evt.Response);
    }

    [Test]
    public void EmitMethods_IncrementSequenceNumber()
    {
        var stream = CreateStream();

        var created = stream.EmitCreated();
        var inProgress = stream.EmitInProgress();
        var completed = stream.EmitCompleted();

        Assert.AreEqual(0, created.SequenceNumber);
        Assert.AreEqual(1, inProgress.SequenceNumber);
        Assert.AreEqual(2, completed.SequenceNumber);
    }

    [Test]
    public void EmitMethods_UseStreamOwnedResponse()
    {
        var stream = CreateStream();

        var evt = stream.EmitCreated();

        // Models.Response is the stream-owned Models.Response
        Assert.AreSame(stream.Response, evt.Response);
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
            Assert.AreEqual(expectedPk, pk);
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

        Assert.AreEqual("resp_t14", created.Response.Id);
        Assert.AreEqual("gpt-4o", created.Response.Model);
        Assert.AreEqual(ResponseStatus.InProgress, created.Response.Status);
    }

    [Test]
    public void Constructor_WithCreateResponse_StreamOwnsResponse()
    {
        var context = new ResponseContext("resp_own");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "test-model" });
        var created = stream.EmitCreated();

        Assert.AreSame(stream.Response, created.Response);
    }

    [Test]
    public void Constructor_WithRequest_StreamResponseIsNotExternalReference()
    {
        var context = new ResponseContext("resp_ext");
        var request = new CreateResponse { Model = "gpt-4o" };

        var stream = new ResponseEventStream(context, request);
        var evt = stream.EmitCreated();

        // The stream builds its own Models.Response — it's not the same as any externally-created instance
        var externalResponse = new Models.Response("resp_ext", "gpt-4o");
        Assert.AreNotSame(externalResponse, evt.Response);
    }

    [Test]
    public void EmitCreated_EmbedsStreamOwnedResponse()
    {
        var stream = CreateStream();

        var evt1 = stream.EmitCreated();
        var evt2 = stream.EmitInProgress();

        // Both events reference the same stream-owned response
        Assert.AreSame(evt1.Response, evt2.Response);
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

        Assert.AreEqual(ResponseStatus.Completed, evt.Response.Status);
        Assert.IsNotNull(evt.Response.CompletedAt);
        XAssert.InRange(evt.Response.CompletedAt.Value, before, after);
        Assert.AreSame(usage, evt.Response.Usage);
    }

    [Test]
    public void EmitCompleted_WithoutUsage_SetsStatusAndCompletedAtButNoUsage()
    {
        var stream = CreateStream();

        var evt = stream.EmitCompleted();

        Assert.AreEqual(ResponseStatus.Completed, evt.Response.Status);
        Assert.IsNotNull(evt.Response.CompletedAt);
        Assert.IsNull(evt.Response.Usage);
    }

    [Test]
    public void EmitCompleted_WithAccumulatedOutput_ComputesOutputText()
    {
        var stream = CreateStream();

        // Simulate accumulated output items
        var textContent = new OutputMessageContentOutputTextContent("Hello world", Array.Empty<Annotation>(), Array.Empty<LogProb>());
        var item = new OutputItemOutputMessage(
            "msg_1",
            new OutputMessageContent[] { textContent },
            OutputItemOutputMessageStatus.Completed);
        stream.TrackCompletedOutputItem(item, 0);

        var evt = stream.EmitCompleted();

        Assert.AreEqual("Hello world", evt.Response.OutputText);
    }

    // ── T016: EmitFailed Tests ────────────────────────────────

    [Test]
    public void EmitFailed_WithCodeAndMessage_SetsErrorFields()
    {
        var stream = CreateStream();

        var evt = stream.EmitFailed(ResponseErrorCode.RateLimitExceeded, "Too many requests");

        Assert.AreEqual(ResponseStatus.Failed, evt.Response.Status);
        Assert.IsNotNull(evt.Response.Error);
        Assert.AreEqual(ResponseErrorCode.RateLimitExceeded, evt.Response.Error.Code);
        Assert.AreEqual("Too many requests", evt.Response.Error.Message);
        Assert.IsNull(evt.Response.CompletedAt);
    }

    [Test]
    public void EmitFailed_WithDefaults_UsesServerErrorAndDefaultMessage()
    {
        var stream = CreateStream();

        var evt = stream.EmitFailed();

        Assert.AreEqual(ResponseStatus.Failed, evt.Response.Status);
        Assert.IsNotNull(evt.Response.Error);
        Assert.AreEqual(ResponseErrorCode.ServerError, evt.Response.Error.Code);
        Assert.AreEqual("An internal server error occurred.", evt.Response.Error.Message);
    }

    [Test]
    public void EmitFailed_ComputesOutputTextFromAccumulated()
    {
        var stream = CreateStream();

        var textContent = new OutputMessageContentOutputTextContent("partial", Array.Empty<Annotation>(), Array.Empty<LogProb>());
        var item = new OutputItemOutputMessage(
            "msg_1",
            new OutputMessageContent[] { textContent },
            OutputItemOutputMessageStatus.Completed);
        stream.TrackCompletedOutputItem(item, 0);

        var evt = stream.EmitFailed(ResponseErrorCode.ServerError, "err");

        Assert.AreEqual("partial", evt.Response.OutputText);
    }

    // ── T017: EmitIncomplete Tests ────────────────────────────

    [Test]
    public void EmitIncomplete_WithReason_SetsIncompleteDetails()
    {
        var stream = CreateStream();

        var evt = stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);

        Assert.AreEqual(ResponseStatus.Incomplete, evt.Response.Status);
        Assert.IsNotNull(evt.Response.IncompleteDetails);
        Assert.AreEqual(ResponseIncompleteDetailsReason.MaxOutputTokens, evt.Response.IncompleteDetails.Reason);
        Assert.IsNull(evt.Response.CompletedAt);
    }

    [Test]
    public void EmitIncomplete_WithoutReason_LeavesIncompleteDetailsNull()
    {
        var stream = CreateStream();

        var evt = stream.EmitIncomplete();

        Assert.AreEqual(ResponseStatus.Incomplete, evt.Response.Status);
        Assert.IsNull(evt.Response.IncompleteDetails);
        Assert.IsNull(evt.Response.CompletedAt);
    }

    [Test]
    public void EmitIncomplete_ComputesOutputTextFromAccumulated()
    {
        var stream = CreateStream();

        var textContent = new OutputMessageContentOutputTextContent("so far", Array.Empty<Annotation>(), Array.Empty<LogProb>());
        var item = new OutputItemOutputMessage(
            "msg_1",
            new OutputMessageContent[] { textContent },
            OutputItemOutputMessageStatus.Completed);
        stream.TrackCompletedOutputItem(item, 0);

        var evt = stream.EmitIncomplete(ResponseIncompleteDetailsReason.MaxOutputTokens);

        Assert.AreEqual("so far", evt.Response.OutputText);
    }
}
