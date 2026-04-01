// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

/// <summary>
/// E2E integration test: validates that building a function call response
/// produces the correct event sequence with monotonic sequence numbers.
/// </summary>
public class FunctionCallResponseTests
{
    [Test]
    public void FunctionCallResponse_ProducesCorrectEventSequence()
    {
        // Arrange
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });

        // Act
        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());                              // 0
        events.Add(stream.EmitInProgress());                           // 1

        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_abc");
        events.Add(fc.EmitAdded());                                    // 2
        events.Add(fc.EmitArgumentsDelta("{\"loc"));                   // 3
        events.Add(fc.EmitArgumentsDelta("ation\":"));                 // 4
        events.Add(fc.EmitArgumentsDelta("\"Seattle\"}"));             // 5
        events.Add(fc.EmitArgumentsDone("{\"location\":\"Seattle\"}")); // 6
        events.Add(fc.EmitDone());                                     // 7

        events.Add(stream.EmitCompleted());                            // 8

        // Assert: correct number of events
        Assert.That(events.Count, Is.EqualTo(9));

        // Assert: event types in order
        XAssert.IsType<ResponseCreatedEvent>(events[0]);
        XAssert.IsType<ResponseInProgressEvent>(events[1]);
        XAssert.IsType<ResponseOutputItemAddedEvent>(events[2]);
        XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(events[3]);
        XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(events[4]);
        XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(events[5]);
        XAssert.IsType<ResponseFunctionCallArgumentsDoneEvent>(events[6]);
        XAssert.IsType<ResponseOutputItemDoneEvent>(events[7]);
        XAssert.IsType<ResponseCompletedEvent>(events[8]);

        // Assert: monotonically increasing sequence numbers
        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }

        // Assert: consistent item ID
        var itemId = fc.ItemId;
        var addedItem = XAssert.IsType<OutputItemFunctionToolCall>(((ResponseOutputItemAddedEvent)events[2]).Item);
        Assert.That(addedItem.Id, Is.EqualTo(itemId));

        var delta1 = (ResponseFunctionCallArgumentsDeltaEvent)events[3];
        Assert.That(delta1.ItemId, Is.EqualTo(itemId));

        var argsDone = (ResponseFunctionCallArgumentsDoneEvent)events[6];
        Assert.That(argsDone.ItemId, Is.EqualTo(itemId));
        Assert.That(argsDone.Name, Is.EqualTo("get_weather"));
        Assert.That(argsDone.Arguments, Is.EqualTo("{\"location\":\"Seattle\"}"));

        // Assert: done item has full arguments
        var doneItem = XAssert.IsType<OutputItemFunctionToolCall>(((ResponseOutputItemDoneEvent)events[7]).Item);
        Assert.That(doneItem.Id, Is.EqualTo(itemId));
        Assert.That(doneItem.Arguments, Is.EqualTo("{\"location\":\"Seattle\"}"));
        Assert.That(doneItem.Status, Is.EqualTo(OutputItemFunctionToolCallStatus.Completed));
    }
}
