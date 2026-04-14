// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

/// <summary>
/// Tests for raw event interop — mixing NextSequenceNumber() with Emit* methods
/// and manually constructed events.
/// </summary>
public class RawEventInteropTests
{
    // ── T019: NextSequenceNumber raw interop ──────────────────

    [Test]
    public void NextSequenceNumber_CanBeUsedForManualEvents()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });

        // Use NextSequenceNumber() for a manually constructed event
        var seq = stream.NextSequenceNumber();
        var manualEvent = new ResponseCreatedEvent(seq, stream.Response);

        Assert.That(manualEvent.SequenceNumber, Is.EqualTo(0));

        // Subsequent Emit* calls continue the sequence
        var inProgress = stream.EmitInProgress();
        Assert.That(inProgress.SequenceNumber, Is.EqualTo(1));
    }

    [Test]
    public void NextSequenceNumber_InterleavedWithEmitMethods()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });

        var created = stream.EmitCreated();           // 0
        var rawSeq = stream.NextSequenceNumber();     // 1
        var inProgress = stream.EmitInProgress();     // 2

        Assert.That(created.SequenceNumber, Is.EqualTo(0));
        Assert.That(rawSeq, Is.EqualTo(1));
        Assert.That(inProgress.SequenceNumber, Is.EqualTo(2));
    }

    // ── T020: Mixed builder + raw events ──────────────────────

    [Test]
    public void MixedBuilderAndRawEvents_MaintainMonotonicSequence()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });

        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());      // 0
        events.Add(stream.EmitInProgress());   // 1

        // Use builder for message
        var msg = stream.AddOutputItemMessage();
        events.Add(msg.EmitAdded());           // 2

        var text = msg.AddTextContent();
        events.Add(text.EmitAdded());          // 3
        events.Add(text.EmitTextDone("Hello"));    // 4
        events.Add(text.EmitDone()); // 5
        events.Add(msg.EmitDone());            // 6

        // Use raw event for a custom output item manually
        var rawSeq = stream.NextSequenceNumber(); // 7
        var manualItem = new OutputItemFunctionToolCall("call_raw", "manual_fn", "{}");
        manualItem.Id = "raw_item_001";
        var rawAddedEvent = new ResponseOutputItemAddedEvent(rawSeq, 1, manualItem);
        events.Add(rawAddedEvent);

        var rawSeq2 = stream.NextSequenceNumber(); // 8
        var rawDoneEvent = new ResponseOutputItemDoneEvent(rawSeq2, 1, manualItem);
        events.Add(rawDoneEvent);

        events.Add(stream.EmitCompleted());    // 9

        // Assert: all 10 events with monotonic sequence numbers
        Assert.That(events.Count, Is.EqualTo(10));
        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    // ── T021: Regression — raw events without builders ────────

    [Test]
    public void RawEventsWithoutBuilders_StillWorkIdentically()
    {
        // This test validates that the existing pattern of hand-built events
        // still works correctly — zero breaking changes
        var response = new Models.ResponseObject("resp_test", "gpt-4o");
        var itemId = "msg_001";

        var events = new List<ResponseStreamEvent>
        {
            new ResponseCreatedEvent(sequenceNumber: 0, response: response),
            new ResponseInProgressEvent(sequenceNumber: 1, response: response),

            new ResponseOutputItemAddedEvent(
                sequenceNumber: 2, outputIndex: 0,
                item: new OutputItemMessage(
                    id: itemId,
                    content: Array.Empty<MessageContent>(),
                    status: MessageStatus.InProgress)),

            new ResponseContentPartAddedEvent(
                sequenceNumber: 3, itemId: itemId, outputIndex: 0, contentIndex: 0,
                part: new OutputContentOutputTextContent(
                    text: "", annotations: Array.Empty<Annotation>(),
                    logprobs: Array.Empty<LogProb>())),

            new ResponseTextDeltaEvent(
                sequenceNumber: 4, itemId: itemId, outputIndex: 0, contentIndex: 0,
                delta: "Hello!", logprobs: Array.Empty<ResponseLogProb>()),

            new ResponseTextDoneEvent(
                sequenceNumber: 5, itemId: itemId, outputIndex: 0, contentIndex: 0,
                text: "Hello!", logprobs: Array.Empty<ResponseLogProb>()),

            new ResponseContentPartDoneEvent(
                sequenceNumber: 6, itemId: itemId, outputIndex: 0, contentIndex: 0,
                part: new OutputContentOutputTextContent(
                    text: "Hello!", annotations: Array.Empty<Annotation>(),
                    logprobs: Array.Empty<LogProb>())),

            new ResponseOutputItemDoneEvent(
                sequenceNumber: 7, outputIndex: 0,
                item: new OutputItemMessage(
                    id: itemId,
                    content: new[] { new MessageContentOutputTextContent(
                        text: "Hello!",
                        annotations: Array.Empty<Annotation>(),
                        logprobs: Array.Empty<LogProb>()) },
                    status: MessageStatus.Completed)),

            new ResponseCompletedEvent(sequenceNumber: 8, response: response),
        };

        // Assert: all events created successfully
        Assert.That(events.Count, Is.EqualTo(9));

        // Assert: types are correct
        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseContentPartAddedEvent>(events[3]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[4]);
        XAssert.IsType<ResponseTextDoneEvent>(events[5]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[6]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[7]);
        XAssert.IsType<ResponseCompletedEvent>(events[8]);

        // Assert: sequence numbers are as assigned
        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }
}
