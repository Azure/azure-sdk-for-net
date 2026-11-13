// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

/// <summary>
/// E2E integration tests for multiple output items per response.
/// </summary>
public class MultiOutputTests
{
    // ── T017: Two message scopes ──────────────────────────────

    [Test]
    public void TwoMessages_HaveDistinctOutputIndicesAndItemIds()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });

        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());      // 0
        events.Add(stream.EmitInProgress());   // 1

        // First message
        var msg0 = stream.AddOutputItemMessage();
        events.Add(msg0.EmitAdded());          // 2
        var text0 = msg0.AddTextContent();
        events.Add(text0.EmitAdded());         // 3
        events.Add(text0.EmitTextDone("First"));   // 4
        events.Add(text0.EmitDone()); // 5
        events.Add(msg0.EmitDone());           // 6

        // Second message
        var msg1 = stream.AddOutputItemMessage();
        events.Add(msg1.EmitAdded());          // 7
        var text1 = msg1.AddTextContent();
        events.Add(text1.EmitAdded());         // 8
        events.Add(text1.EmitTextDone("Second"));  // 9
        events.Add(text1.EmitDone()); // 10
        events.Add(msg1.EmitDone());           // 11

        events.Add(stream.EmitCompleted());    // 12

        // Assert: distinct output indices
        Assert.That(msg0.OutputIndex, Is.EqualTo(0));
        Assert.That(msg1.OutputIndex, Is.EqualTo(1));

        // Assert: distinct item IDs
        Assert.That(msg1.ItemId, Is.Not.EqualTo(msg0.ItemId));

        // Assert: monotonic sequence numbers
        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }

        // Assert: correct output indices in events
        var added0 = (ResponseOutputItemAddedEvent)events[2];
        var added1 = (ResponseOutputItemAddedEvent)events[7];
        Assert.That(added0.OutputIndex, Is.EqualTo(0));
        Assert.That(added1.OutputIndex, Is.EqualTo(1));

        // Assert: each message has correct content in done event
        var done0 = XAssert.IsType<OutputItemMessage>(((ResponseOutputItemDoneEvent)events[6]).Item);
        var done1 = XAssert.IsType<OutputItemMessage>(((ResponseOutputItemDoneEvent)events[11]).Item);
        var content0 = XAssert.IsType<MessageContentOutputTextContent>(done0.Content[0]);
        var content1 = XAssert.IsType<MessageContentOutputTextContent>(done1.Content[0]);
        Assert.That(content0.Text, Is.EqualTo("First"));
        Assert.That(content1.Text, Is.EqualTo("Second"));
    }

    // ── T018: Message + Function Call ─────────────────────────

    [Test]
    public void MessagePlusFunctionCall_HaveConsecutiveOutputIndices()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });

        var events = new List<ResponseStreamEvent>();

        events.Add(stream.EmitCreated());      // 0
        events.Add(stream.EmitInProgress());   // 1

        // Message (outputIndex=0)
        var msg = stream.AddOutputItemMessage();
        events.Add(msg.EmitAdded());           // 2
        var text = msg.AddTextContent();
        events.Add(text.EmitAdded());          // 3
        events.Add(text.EmitTextDone("Hello"));    // 4
        events.Add(text.EmitDone()); // 5
        events.Add(msg.EmitDone());            // 6

        // Function call (outputIndex=1)
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_abc");
        events.Add(fc.EmitAdded());                                    // 7
        events.Add(fc.EmitArgumentsDone("{\"location\":\"Seattle\"}")); // 8
        events.Add(fc.EmitDone());                                     // 9

        events.Add(stream.EmitCompleted());    // 10

        // Assert: consecutive output indices
        Assert.That(msg.OutputIndex, Is.EqualTo(0));
        Assert.That(fc.OutputIndex, Is.EqualTo(1));

        // Assert: monotonic sequence numbers across both
        for (int i = 0; i < events.Count; i++)
        {
            Assert.That(events[i].SequenceNumber, Is.EqualTo(i));
        }

        // Assert: distinct item IDs
        Assert.That(fc.ItemId, Is.Not.EqualTo(msg.ItemId));
        XAssert.StartsWith("msg_", msg.ItemId);
        XAssert.StartsWith("fc_", fc.ItemId);
    }
}
