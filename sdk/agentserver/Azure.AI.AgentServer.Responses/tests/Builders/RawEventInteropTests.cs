// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

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
        var manualEvent = new ResponseCreatedEvent { SequenceNumber = (int)(seq), Response = stream.Response };

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
        var manualItem = new OutputItemFunctionToolCall("call_raw", "manual_fn", BinaryData.FromString("{}")) { Id = "raw_item_001", Status = FunctionCallStatus.InProgress };
        var rawAddedEvent = new ResponseOutputItemAddedEvent { SequenceNumber = (int)(rawSeq), OutputIndex = (int)(1), Item = manualItem };
        events.Add(rawAddedEvent);

        var rawSeq2 = stream.NextSequenceNumber(); // 8
        var rawDoneEvent = new ResponseOutputItemDoneEvent { SequenceNumber = (int)(rawSeq2), OutputIndex = (int)(1), Item = manualItem };
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
        var response = new ResponseObject { Id = "resp_test", Model = "gpt-4o" };
        var itemId = "msg_001";

        var events = new List<ResponseStreamEvent>
        {
            new ResponseCreatedEvent { SequenceNumber = (int)(0), Response = response },
            new ResponseInProgressEvent { SequenceNumber = (int)(1), Response = response },

            new ResponseOutputItemAddedEvent { SequenceNumber = (int)(2), OutputIndex = (int)(0), Item = MessageItemFactory.OutputMessage(
                    id: itemId,
                    content: Array.Empty<ResponseContentPart>(),
                    status: MessageStatus.InProgress) },

            new ResponseContentPartAddedEvent { SequenceNumber = (int)(3), ItemId = itemId, OutputIndex = (int)(0), ContentIndex = (int)(0), Part = ResponseContentPart.CreateOutputTextPart("", Array.Empty<OpenAI.Responses.ResponseMessageAnnotation>()) },

            new ResponseTextDeltaEvent { SequenceNumber = (int)(4), ItemId = itemId, OutputIndex = (int)(0), ContentIndex = (int)(0), Delta = "Hello!" },

            new ResponseTextDoneEvent { SequenceNumber = (int)(5), ItemId = itemId, OutputIndex = (int)(0), ContentIndex = (int)(0), Text = "Hello!" },

            new ResponseContentPartDoneEvent { SequenceNumber = (int)(6), ItemId = itemId, OutputIndex = (int)(0), ContentIndex = (int)(0), Part = ResponseContentPart.CreateOutputTextPart("Hello!", Array.Empty<OpenAI.Responses.ResponseMessageAnnotation>()) },

            new ResponseOutputItemDoneEvent { SequenceNumber = (int)(7), OutputIndex = (int)(0), Item = MessageItemFactory.OutputMessage(
                    id: itemId,
                    content: new[] { ResponseContentPart.CreateOutputTextPart(text: "Hello!", annotations: Array.Empty<Annotation>()) },
                    status: MessageStatus.Completed) },

            new ResponseCompletedEvent { SequenceNumber = (int)(8), Response = response },
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
