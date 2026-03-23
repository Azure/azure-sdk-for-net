// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

/// <summary>
/// E2E integration test: validates that building a simple text response
/// produces the correct 10-event sequence with monotonic sequence numbers,
/// correct indices, and consistent IDs.
/// </summary>
public class SimpleTextResponseTests
{
    [Test]
    public void SimpleTextResponse_ProducesCorrect10EventSequence()
    {
        // Arrange
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });

        // Act: build the full event sequence
        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());             // 0: response.created
        events.Add(stream.EmitInProgress());          // 1: response.in_progress

        var message = stream.AddOutputItemMessage();
        events.Add(message.EmitAdded());              // 2: output_item.added

        var text = message.AddTextContent();
        events.Add(text.EmitAdded());                 // 3: content_part.added
        events.Add(text.EmitDelta("Hello, "));        // 4: output_text.delta
        events.Add(text.EmitDelta("world!"));         // 5: output_text.delta
        events.Add(text.EmitDone("Hello, world!"));   // 6: output_text.done

        events.Add(message.EmitContentDone(text));    // 7: content_part.done
        events.Add(message.EmitDone());               // 8: output_item.done
        events.Add(stream.EmitCompleted());           // 9: response.completed

        // Assert: correct number of events
        Assert.AreEqual(10, events.Count);

        // Assert: event types in order
        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseContentPartAddedEvent>(events[3]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[4]);
        XAssert.IsType<ResponseTextDeltaEvent>(events[5]);
        XAssert.IsType<ResponseTextDoneEvent>(events[6]);
        XAssert.IsType<ResponseContentPartDoneEvent>(events[7]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[8]);
        XAssert.IsType<ResponseCompletedEvent>(events[9]);

        // Assert: monotonically increasing sequence numbers
        for (int i = 0; i < events.Count; i++)
        {
            Assert.AreEqual(i, events[i].SequenceNumber);
        }

        // Assert: consistent item ID across related events
        var addedEvt = (ResponseOutputItemAddedEvent)events[2];
        var contentAddedEvt = (ResponseContentPartAddedEvent)events[3];
        var delta1Evt = (ResponseTextDeltaEvent)events[4];
        var delta2Evt = (ResponseTextDeltaEvent)events[5];
        var textDoneEvt = (ResponseTextDoneEvent)events[6];
        var contentDoneEvt = (ResponseContentPartDoneEvent)events[7];
        var itemDoneEvt = (ResponseOutputItemDoneEvent)events[8];

        var itemId = message.ItemId;
        var addedItem = XAssert.IsType<OutputItemOutputMessage>(addedEvt.Item);
        Assert.AreEqual(itemId, addedItem.Id);
        Assert.AreEqual(itemId, contentAddedEvt.ItemId);
        Assert.AreEqual(itemId, delta1Evt.ItemId);
        Assert.AreEqual(itemId, delta2Evt.ItemId);
        Assert.AreEqual(itemId, textDoneEvt.ItemId);
        Assert.AreEqual(itemId, contentDoneEvt.ItemId);

        // Assert: output index is 0 throughout
        Assert.AreEqual(0, addedEvt.OutputIndex);
        Assert.AreEqual(0, contentAddedEvt.OutputIndex);
        Assert.AreEqual(0, delta1Evt.OutputIndex);
        Assert.AreEqual(0, delta2Evt.OutputIndex);
        Assert.AreEqual(0, textDoneEvt.OutputIndex);
        Assert.AreEqual(0, contentDoneEvt.OutputIndex);
        Assert.AreEqual(0, itemDoneEvt.OutputIndex);

        // Assert: content index is 0 throughout
        Assert.AreEqual(0, contentAddedEvt.ContentIndex);
        Assert.AreEqual(0, delta1Evt.ContentIndex);
        Assert.AreEqual(0, delta2Evt.ContentIndex);
        Assert.AreEqual(0, textDoneEvt.ContentIndex);
        Assert.AreEqual(0, contentDoneEvt.ContentIndex);

        // Assert: final done message has completed status and accumulated content
        var doneItem = XAssert.IsType<OutputItemOutputMessage>(itemDoneEvt.Item);
        Assert.AreEqual(itemId, doneItem.Id);
        Assert.AreEqual(OutputItemOutputMessageStatus.Completed, doneItem.Status);
        XAssert.Single(doneItem.Content);

        var finalContent = XAssert.IsType<OutputMessageContentOutputTextContent>(doneItem.Content[0]);
        Assert.AreEqual("Hello, world!", finalContent.Text);
    }

    [Test]
    public void SimpleTextResponse_WorksAsAsyncEnumerable()
    {
        // Verifies the builder pattern works naturally in an IAsyncEnumerable context
        var context = new ResponseContext("resp_test");

        var events = BuildEvents(context).ToBlockingEnumerable().ToList();

        Assert.AreEqual(10, events.Count);
        // Verify monotonic sequence
        for (int i = 0; i < events.Count; i++)
        {
            Assert.AreEqual(i, events[i].SequenceNumber);
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> BuildEvents(IResponseContext context)
    {
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();
        yield return text.EmitDelta("Hello, ");
        yield return text.EmitDelta("world!");
        yield return text.EmitDone("Hello, world!");

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();
        yield return stream.EmitCompleted();
    }
}
