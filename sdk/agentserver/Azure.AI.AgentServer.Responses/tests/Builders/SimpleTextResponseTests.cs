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
        events.Add(text.EmitTextDone("Hello, world!"));   // 6: output_text.done

        events.Add(text.EmitDone());    // 7: content_part.done
        events.Add(message.EmitDone());               // 8: output_item.done
        events.Add(stream.EmitCompleted());           // 9: response.completed

        // Assert: correct number of events
        Assert.That(events.Count, Is.EqualTo(10));

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
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
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
        var addedItem = XAssert.IsType<OutputItemMessage>(addedEvt.Item);
        Assert.That(addedItem.Id, Is.EqualTo(itemId));
        Assert.That(contentAddedEvt.ItemId, Is.EqualTo(itemId));
        Assert.That(delta1Evt.ItemId, Is.EqualTo(itemId));
        Assert.That(delta2Evt.ItemId, Is.EqualTo(itemId));
        Assert.That(textDoneEvt.ItemId, Is.EqualTo(itemId));
        Assert.That(contentDoneEvt.ItemId, Is.EqualTo(itemId));

        // Assert: output index is 0 throughout
        Assert.That(addedEvt.OutputIndex, Is.EqualTo(0));
        Assert.That(contentAddedEvt.OutputIndex, Is.EqualTo(0));
        Assert.That(delta1Evt.OutputIndex, Is.EqualTo(0));
        Assert.That(delta2Evt.OutputIndex, Is.EqualTo(0));
        Assert.That(textDoneEvt.OutputIndex, Is.EqualTo(0));
        Assert.That(contentDoneEvt.OutputIndex, Is.EqualTo(0));
        Assert.That(itemDoneEvt.OutputIndex, Is.EqualTo(0));

        // Assert: content index is 0 throughout
        Assert.That(contentAddedEvt.ContentIndex, Is.EqualTo(0));
        Assert.That(delta1Evt.ContentIndex, Is.EqualTo(0));
        Assert.That(delta2Evt.ContentIndex, Is.EqualTo(0));
        Assert.That(textDoneEvt.ContentIndex, Is.EqualTo(0));
        Assert.That(contentDoneEvt.ContentIndex, Is.EqualTo(0));

        // Assert: final done message has completed status and accumulated content
        var doneItem = XAssert.IsType<OutputItemMessage>(itemDoneEvt.Item);
        Assert.That(doneItem.Id, Is.EqualTo(itemId));
        Assert.That(doneItem.Status, Is.EqualTo(MessageStatus.Completed));
        XAssert.Single(doneItem.Content);

        var finalContent = XAssert.IsType<MessageContentOutputTextContent>(doneItem.Content[0]);
        Assert.That(finalContent.Text, Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void SimpleTextResponse_WorksAsAsyncEnumerable()
    {
        // Verifies the builder pattern works naturally in an IAsyncEnumerable context
        var context = new ResponseContext("resp_test");

        var events = BuildEvents(context).ToBlockingEnumerable().ToList();

        Assert.That(events.Count, Is.EqualTo(10));
        // Verify monotonic sequence
        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> BuildEvents(ResponseContext context)
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
        yield return text.EmitTextDone("Hello, world!");

        yield return text.EmitDone();
        yield return message.EmitDone();
        yield return stream.EmitCompleted();
    }
}
