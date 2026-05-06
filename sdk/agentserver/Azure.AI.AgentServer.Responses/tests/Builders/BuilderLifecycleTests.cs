// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

/// <summary>
/// E2E lifecycle tests validating multi-event sequences for the new
/// builder types (refusal, reasoning, tool calls, generic output items).
/// </summary>
public class BuilderLifecycleTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    // ──────────────────────────────────────────────
    // T037: Refusal content within a message
    // ──────────────────────────────────────────────

    [Test]
    public void RefusalContentInMessage_ProducesCorrectEventSequence()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());
        events.Add(stream.EmitInProgress());

        var message = stream.AddOutputItemMessage();
        events.Add(message.EmitAdded());

        var refusal = message.AddRefusalContent();
        events.Add(refusal.EmitAdded());
        events.Add(refusal.EmitDelta("I cannot"));
        events.Add(refusal.EmitDelta(" do that."));
        events.Add(refusal.EmitRefusalDone("I cannot do that."));

        events.Add(refusal.EmitDone());
        events.Add(message.EmitDone());
        events.Add(stream.EmitCompleted());

        Assert.That(events.Count, Is.EqualTo(10));

        // Event types in order
        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseContentPartAddedEvent>(events[3]);
        XAssert.IsType<ResponseRefusalDeltaEvent>(events[4]);
        XAssert.IsType<ResponseRefusalDeltaEvent>(events[5]);
        XAssert.IsType<ResponseRefusalDoneEvent>(events[6]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[7]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[8]);
        XAssert.IsType<ResponseCompletedEvent>(events[9]);

        // Monotonic sequence numbers
        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    // ──────────────────────────────────────────────
    // T037: Reasoning with multi-part summaries
    // ──────────────────────────────────────────────

    [Test]
    public void ReasoningWithMultiPartSummaries_ProducesCorrectEventSequence()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());
        events.Add(stream.EmitInProgress());

        var reasoning = stream.AddOutputItemReasoningItem();
        events.Add(reasoning.EmitAdded());

        // First summary part
        var part1 = reasoning.AddSummaryPart();
        events.Add(part1.EmitAdded());
        events.Add(part1.EmitTextDelta("thinking"));
        events.Add(part1.EmitTextDone("thinking deeply"));
        events.Add(part1.EmitDone());

        // Second summary part
        var part2 = reasoning.AddSummaryPart();
        events.Add(part2.EmitAdded());
        events.Add(part2.EmitTextDelta("more"));
        events.Add(part2.EmitTextDone("more analysis"));
        events.Add(part2.EmitDone());

        events.Add(reasoning.EmitDone());
        events.Add(stream.EmitCompleted());

        Assert.That(events.Count, Is.EqualTo(13));

        // Verify event types
        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseReasoningSummaryPartAddedEvent>(events[3]);
        XAssert.IsType<ResponseReasoningSummaryTextDeltaEvent>(events[4]);
        XAssert.IsType<ResponseReasoningSummaryTextDoneEvent>(events[5]);
        XAssert.IsType<ResponseReasoningSummaryPartDoneEvent>(events[6]);
        XAssert.IsType<ResponseReasoningSummaryPartAddedEvent>(events[7]);
        XAssert.IsType<ResponseReasoningSummaryTextDeltaEvent>(events[8]);
        XAssert.IsType<ResponseReasoningSummaryTextDoneEvent>(events[9]);
        XAssert.IsType<ResponseReasoningSummaryPartDoneEvent>(events[10]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[11]);
        XAssert.IsType<ResponseCompletedEvent>(events[12]);

        // Monotonic sequence numbers
        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    // ──────────────────────────────────────────────
    // T038: File search lifecycle
    // ──────────────────────────────────────────────

    [Test]
    public void FileSearchLifecycle_ProducesCorrectEventSequence()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());
        events.Add(stream.EmitInProgress());

        var fileSearch = stream.AddOutputItemFileSearchCall();
        events.Add(fileSearch.EmitAdded());
        events.Add(fileSearch.EmitInProgress());
        events.Add(fileSearch.EmitSearching());
        events.Add(fileSearch.EmitCompleted());
        events.Add(fileSearch.EmitDone());

        events.Add(stream.EmitCompleted());

        Assert.That(events.Count, Is.EqualTo(8));

        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseFileSearchCallInProgressEvent>(events[3]);
        XAssert.IsType<ResponseFileSearchCallSearchingEvent>(events[4]);
        XAssert.IsType<ResponseFileSearchCallCompletedEvent>(events[5]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[6]);
        XAssert.IsType<ResponseCompletedEvent>(events[7]);

        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    // ──────────────────────────────────────────────
    // T038: Code interpreter with deltas
    // ──────────────────────────────────────────────

    [Test]
    public void CodeInterpreterWithDeltas_ProducesCorrectEventSequence()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());
        events.Add(stream.EmitInProgress());

        var ci = stream.AddOutputItemCodeInterpreterCall();
        events.Add(ci.EmitAdded());
        events.Add(ci.EmitInProgress());
        events.Add(ci.EmitCodeDelta("print("));
        events.Add(ci.EmitCodeDelta("42)"));
        events.Add(ci.EmitCodeDone("print(42)"));
        events.Add(ci.EmitCompleted());
        events.Add(ci.EmitDone());

        events.Add(stream.EmitCompleted());

        Assert.That(events.Count, Is.EqualTo(10));

        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseCodeInterpreterCallInProgressEvent>(events[3]);
        XAssert.IsType<ResponseCodeInterpreterCallCodeDeltaEvent>(events[4]);
        XAssert.IsType<ResponseCodeInterpreterCallCodeDeltaEvent>(events[5]);
        XAssert.IsType<ResponseCodeInterpreterCallCodeDoneEvent>(events[6]);
        XAssert.IsType<ResponseCodeInterpreterCallCompletedEvent>(events[7]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[8]);
        XAssert.IsType<ResponseCompletedEvent>(events[9]);

        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    // ──────────────────────────────────────────────
    // T038: MCP call with arguments streaming
    // ──────────────────────────────────────────────

    [Test]
    public void McpCallWithArguments_ProducesCorrectEventSequence()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());
        events.Add(stream.EmitInProgress());

        var mcp = stream.AddOutputItemMcpCall("my-server", "search");
        events.Add(mcp.EmitAdded());
        events.Add(mcp.EmitInProgress());
        events.Add(mcp.EmitArgumentsDelta("{\"q\":"));
        events.Add(mcp.EmitArgumentsDelta("\"test\"}"));
        events.Add(mcp.EmitArgumentsDone("{\"q\":\"test\"}"));
        events.Add(mcp.EmitCompleted());
        events.Add(mcp.EmitDone());

        events.Add(stream.EmitCompleted());

        Assert.That(events.Count, Is.EqualTo(10));

        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseMCPCallInProgressEvent>(events[3]);
        XAssert.IsType<ResponseMCPCallArgumentsDeltaEvent>(events[4]);
        XAssert.IsType<ResponseMCPCallArgumentsDeltaEvent>(events[5]);
        XAssert.IsType<ResponseMCPCallArgumentsDoneEvent>(events[6]);
        XAssert.IsType<ResponseMCPCallCompletedEvent>(events[7]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[8]);
        XAssert.IsType<ResponseCompletedEvent>(events[9]);

        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    // ──────────────────────────────────────────────
    // T038: Generic output item lifecycle
    // ──────────────────────────────────────────────

    [Test]
    public void GenericOutputItem_ProducesCorrectEventSequence()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());
        events.Add(stream.EmitInProgress());

        var funcId = IdGenerator.NewFunctionCallItemId();
        var item = new OutputItemFunctionToolCall(
            OutputItemType.FunctionCall,
            createdBy: null,
            agentReference: null,
            responseId: null,
            additionalBinaryDataProperties: null,
            id: funcId,
            callId: "call_1",
            @namespace: null,
            name: "myFunc",
            arguments: "{\"x\":1}",
            status: ItemFunctionToolCallStatus.InProgress);
        var builder = stream.AddOutputItem<OutputItemFunctionToolCall>(funcId);
        events.Add(builder.EmitAdded(item));
        events.Add(builder.EmitDone(item));

        events.Add(stream.EmitCompleted());

        Assert.That(events.Count, Is.EqualTo(5));

        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[3]);
        XAssert.IsType<ResponseCompletedEvent>(events[4]);

        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    // ──────────────────────────────────────────────
    // T039: Edge cases
    // ──────────────────────────────────────────────

    [Test]
    public void ReasoningWithZeroSummaryParts_EmitDoneSucceeds()
    {
        var stream = CreateStream();
        var reasoning = stream.AddOutputItemReasoningItem();
        var added = reasoning.EmitAdded();
        var done = reasoning.EmitDone();

        // Should succeed with empty summary list
        XAssert.IsType<ResponseOutputItemAddedEvent>(added);
        XAssert.IsType<ResponseOutputItemDoneEvent>(done);
    }

    [Test]
    public void McpCallFailed_ProducesCorrectLifecycle()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        var mcp = stream.AddOutputItemMcpCall("server", "tool");
        events.Add(mcp.EmitAdded());
        events.Add(mcp.EmitInProgress());
        events.Add(mcp.EmitFailed());
        events.Add(mcp.EmitDone());

        Assert.That(events.Count, Is.EqualTo(4));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseMCPCallInProgressEvent>(events[1]);
        XAssert.IsType<ResponseMCPCallFailedEvent>(events[2]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[3]);
    }

    [Test]
    public void MultipleOutputItems_SharedSequenceNumbers()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());

        var msg = stream.AddOutputItemMessage();
        events.Add(msg.EmitAdded());

        var fc = stream.AddOutputItemFileSearchCall();
        events.Add(fc.EmitAdded());

        // Sequence numbers should be monotonic across different builders
        Assert.That(events[0].SequenceNumber, Is.EqualTo(0));
        Assert.That(events[1].SequenceNumber, Is.EqualTo(1));
        Assert.That(events[2].SequenceNumber, Is.EqualTo(2));
    }

    [Test]
    public void MultipleOutputItems_OutputIndicesIncrement()
    {
        var stream = CreateStream();

        var msg = stream.AddOutputItemMessage();
        Assert.That(msg.OutputIndex, Is.EqualTo(0));

        var reasoning = stream.AddOutputItemReasoningItem();
        Assert.That(reasoning.OutputIndex, Is.EqualTo(1));

        var fs = stream.AddOutputItemFileSearchCall();
        Assert.That(fs.OutputIndex, Is.EqualTo(2));

        var ws = stream.AddOutputItemWebSearchCall();
        Assert.That(ws.OutputIndex, Is.EqualTo(3));

        var ci = stream.AddOutputItemCodeInterpreterCall();
        Assert.That(ci.OutputIndex, Is.EqualTo(4));

        var ig = stream.AddOutputItemImageGenCall();
        Assert.That(ig.OutputIndex, Is.EqualTo(5));

        var mcp = stream.AddOutputItemMcpCall("s", "t");
        Assert.That(mcp.OutputIndex, Is.EqualTo(6));

        var mcpl = stream.AddOutputItemMcpListTools("s");
        Assert.That(mcpl.OutputIndex, Is.EqualTo(7));

        var ctc = stream.AddOutputItemCustomToolCall("c1", "tool");
        Assert.That(ctc.OutputIndex, Is.EqualTo(8));

        var genericId = IdGenerator.NewFunctionCallItemId();
        var genericItem = new OutputItemFunctionToolCall(
            OutputItemType.FunctionCall,
            createdBy: null,
            agentReference: null,
            responseId: null,
            additionalBinaryDataProperties: null,
            id: genericId,
            callId: "c",
            @namespace: null,
            name: "f",
            arguments: "{}",
            status: ItemFunctionToolCallStatus.InProgress);
        var generic = stream.AddOutputItem<OutputItemFunctionToolCall>(genericId);
        Assert.That(generic.OutputIndex, Is.EqualTo(9));
    }

    [Test]
    public void CustomToolCall_InputDeltaAndDone_ProducesCorrectLifecycle()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        var ctc = stream.AddOutputItemCustomToolCall("call_1", "my_tool");
        events.Add(ctc.EmitAdded());
        events.Add(ctc.EmitInputDelta("{\"key\":"));
        events.Add(ctc.EmitInputDelta("\"val\"}"));
        events.Add(ctc.EmitInputDone("{\"key\":\"val\"}"));
        events.Add(ctc.EmitDone());

        Assert.That(events.Count, Is.EqualTo(5));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseCustomToolCallInputDeltaEvent>(events[1]);
        XAssert.IsType<ResponseCustomToolCallInputDeltaEvent>(events[2]);
        XAssert.IsType<ResponseCustomToolCallInputDoneEvent>(events[3]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[4]);
    }

    [Test]
    public void ImageGenCall_ProducesCorrectLifecycle()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        var ig = stream.AddOutputItemImageGenCall();
        events.Add(ig.EmitAdded());
        events.Add(ig.EmitInProgress());
        events.Add(ig.EmitPartialImage("base64chunk1"));
        events.Add(ig.EmitPartialImage("base64chunk2"));
        events.Add(ig.EmitCompleted());
        events.Add(ig.EmitDone("dGVzdC1pbWFnZS1kYXRh"));

        Assert.That(events.Count, Is.EqualTo(6));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseImageGenCallInProgressEvent>(events[1]);
        XAssert.IsType<ResponseImageGenCallPartialImageEvent>(events[2]);
        XAssert.IsType<ResponseImageGenCallPartialImageEvent>(events[3]);
        XAssert.IsType<ResponseImageGenCallCompletedEvent>(events[4]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[5]);
    }

    [Test]
    public void McpListTools_ProducesCorrectLifecycle()
    {
        var stream = CreateStream();
        var events = new List<ResponseStreamEvent>();

        var mcpl = stream.AddOutputItemMcpListTools("my-server");
        events.Add(mcpl.EmitAdded());
        events.Add(mcpl.EmitInProgress());
        events.Add(mcpl.EmitCompleted());
        events.Add(mcpl.EmitDone());

        Assert.That(events.Count, Is.EqualTo(4));
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[0]);
        XAssert.IsType<ResponseMCPListToolsInProgressEvent>(events[1]);
        XAssert.IsType<ResponseMCPListToolsCompletedEvent>(events[2]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[3]);
    }
}
