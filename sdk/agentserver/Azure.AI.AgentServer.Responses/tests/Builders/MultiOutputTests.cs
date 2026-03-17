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
        events.Add(text0.EmitDone("First"));   // 4
        events.Add(msg0.EmitContentDone(text0)); // 5
        events.Add(msg0.EmitDone());           // 6

        // Second message
        var msg1 = stream.AddOutputItemMessage();
        events.Add(msg1.EmitAdded());          // 7
        var text1 = msg1.AddTextContent();
        events.Add(text1.EmitAdded());         // 8
        events.Add(text1.EmitDone("Second"));  // 9
        events.Add(msg1.EmitContentDone(text1)); // 10
        events.Add(msg1.EmitDone());           // 11

        events.Add(stream.EmitCompleted());    // 12

        // Assert: distinct output indices
        Assert.AreEqual(0, msg0.OutputIndex);
        Assert.AreEqual(1, msg1.OutputIndex);

        // Assert: distinct item IDs
        Assert.AreNotEqual(msg0.ItemId, msg1.ItemId);

        // Assert: monotonic sequence numbers
        for (int i = 0; i < events.Count; i++)
        {
            Assert.AreEqual(i, events[i].SequenceNumber);
        }

        // Assert: correct output indices in events
        var added0 = (ResponseOutputItemAddedEvent)events[2];
        var added1 = (ResponseOutputItemAddedEvent)events[7];
        Assert.AreEqual(0, added0.OutputIndex);
        Assert.AreEqual(1, added1.OutputIndex);

        // Assert: each message has correct content in done event
        var done0 = XAssert.IsType<OutputItemOutputMessage>(((ResponseOutputItemDoneEvent)events[6]).Item);
        var done1 = XAssert.IsType<OutputItemOutputMessage>(((ResponseOutputItemDoneEvent)events[11]).Item);
        var content0 = XAssert.IsType<OutputMessageContentOutputTextContent>(done0.Content[0]);
        var content1 = XAssert.IsType<OutputMessageContentOutputTextContent>(done1.Content[0]);
        Assert.AreEqual("First", content0.Text);
        Assert.AreEqual("Second", content1.Text);
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
        events.Add(text.EmitDone("Hello"));    // 4
        events.Add(msg.EmitContentDone(text)); // 5
        events.Add(msg.EmitDone());            // 6

        // Function call (outputIndex=1)
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_abc");
        events.Add(fc.EmitAdded());                                    // 7
        events.Add(fc.EmitArgumentsDone("{\"location\":\"Seattle\"}")); // 8
        events.Add(fc.EmitDone());                                     // 9

        events.Add(stream.EmitCompleted());    // 10

        // Assert: consecutive output indices
        Assert.AreEqual(0, msg.OutputIndex);
        Assert.AreEqual(1, fc.OutputIndex);

        // Assert: monotonic sequence numbers across both
        for (int i = 0; i < events.Count; i++)
        {
            Assert.AreEqual(i, events[i].SequenceNumber);
        }

        // Assert: distinct item IDs
        Assert.AreNotEqual(msg.ItemId, fc.ItemId);
        XAssert.StartsWith("msg_", msg.ItemId);
        XAssert.StartsWith("fc_", fc.ItemId);
    }
}
