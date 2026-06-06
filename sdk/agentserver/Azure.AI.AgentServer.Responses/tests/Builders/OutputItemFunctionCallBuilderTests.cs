// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class OutputItemFunctionCallBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    // ── T012: AddFunctionCall ─────────────────────────────────

    [Test]
    public void AddFunctionCall_ReturnsOutputItemFunctionCallBuilder()
    {
        var stream = CreateStream();

        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        Assert.That(fc, Is.Not.Null);
        XAssert.IsType<OutputItemFunctionCallBuilder>(fc);
    }

    [Test]
    public void AddFunctionCall_AssignsOutputIndex()
    {
        var stream = CreateStream();

        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        Assert.That(fc.OutputIndex, Is.EqualTo(0));
    }

    [Test]
    public void AddFunctionCall_SharesOutputIndexWithAddMessage()
    {
        var stream = CreateStream();

        var msg = stream.AddOutputItemMessage();      // index 0
        var fc = stream.AddOutputItemFunctionCall("fn", "c1"); // index 1

        Assert.That(msg.OutputIndex, Is.EqualTo(0));
        Assert.That(fc.OutputIndex, Is.EqualTo(1));
    }

    [Test]
    public void AddFunctionCall_GeneratesItemIdWithFcPrefix()
    {
        var stream = CreateStream();

        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        XAssert.StartsWith("fc_", fc.ItemId);
    }

    [Test]
    public void AddFunctionCall_StoresNameAndCallId()
    {
        var stream = CreateStream();

        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        Assert.That(fc.Name, Is.EqualTo("get_weather"));
        Assert.That(fc.CallId, Is.EqualTo("call_001"));
    }

    [Test]
    public void AddFunctionCall_SharesSequenceNumberWithStream()
    {
        var stream = CreateStream();
        stream.EmitCreated();   // seq 0
        stream.EmitInProgress(); // seq 1

        var fc = stream.AddOutputItemFunctionCall("fn", "c1");
        var evt = fc.EmitAdded(); // seq 2

        Assert.That(evt.SequenceNumber, Is.EqualTo(2));
    }

    // ── T013: EmitAdded ───────────────────────────────────────

    [Test]
    public void EmitAdded_ReturnsOutputItemAddedEvent()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        var evt = fc.EmitAdded();

        XAssert.IsType<ResponseOutputItemAddedEvent>(evt);
    }

    [Test]
    public void EmitAdded_ContainsFunctionToolCallItem()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        var evt = fc.EmitAdded();

        var item = XAssert.IsType<OutputItemFunctionToolCall>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(fc.ItemId));
        Assert.That(item.CallId, Is.EqualTo("call_001"));
        Assert.That(item.Name, Is.EqualTo("get_weather"));
        Assert.That(item.Arguments, Is.EqualTo(""));
        Assert.That(item.Status, Is.EqualTo(ItemFunctionToolCallStatus.InProgress));
    }

    [Test]
    public void EmitAdded_HasCorrectOutputIndex()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("fn", "c1");

        var evt = fc.EmitAdded();

        Assert.That(evt.OutputIndex, Is.EqualTo(0));
    }

    // ── T014: EmitArgumentsDelta + EmitArgumentsDone ──────────

    [Test]
    public void EmitArgumentsDelta_ReturnsDeltaEvent()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        var evt = fc.EmitArgumentsDelta("{\"loc");

        XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(evt);
        Assert.That(evt.Delta, Is.EqualTo("{\"loc"));
        Assert.That(evt.ItemId, Is.EqualTo(fc.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(fc.OutputIndex));
    }

    [Test]
    public void EmitArgumentsDone_ReturnsDoneEvent()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        var evt = fc.EmitArgumentsDone("{\"location\":\"Seattle\"}");

        XAssert.IsType<ResponseFunctionCallArgumentsDoneEvent>(evt);
        Assert.That(evt.Arguments, Is.EqualTo("{\"location\":\"Seattle\"}"));
        Assert.That(evt.ItemId, Is.EqualTo(fc.ItemId));
        Assert.That(evt.Name, Is.EqualTo("get_weather"));
        Assert.That(evt.OutputIndex, Is.EqualTo(fc.OutputIndex));
    }

    // ── T015: EmitDone ────────────────────────────────────────

    [Test]
    public void EmitDone_ReturnsOutputItemDoneEvent()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");
        fc.EmitAdded();
        fc.EmitArgumentsDone("{\"location\":\"Seattle\"}");

        var evt = fc.EmitDone();

        XAssert.IsType<ResponseOutputItemDoneEvent>(evt);
        Assert.That(evt.OutputIndex, Is.EqualTo(fc.OutputIndex));
    }

    [Test]
    public void EmitDone_ContainsCompletedFunctionToolCall()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");
        fc.EmitAdded();
        fc.EmitArgumentsDone("{\"location\":\"Seattle\"}");

        var evt = fc.EmitDone();

        var item = XAssert.IsType<OutputItemFunctionToolCall>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(fc.ItemId));
        Assert.That(item.CallId, Is.EqualTo("call_001"));
        Assert.That(item.Name, Is.EqualTo("get_weather"));
        Assert.That(item.Arguments, Is.EqualTo("{\"location\":\"Seattle\"}"));
        Assert.That(item.Status, Is.EqualTo(ItemFunctionToolCallStatus.Completed));
    }

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("fn", "c1");

        var added = fc.EmitAdded();               // 0
        var delta1 = fc.EmitArgumentsDelta("{");   // 1
        var delta2 = fc.EmitArgumentsDelta("}");   // 2
        var argsDone = fc.EmitArgumentsDone("{}"); // 3
        var done = fc.EmitDone();                  // 4

        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(delta1.SequenceNumber, Is.EqualTo(1));
        Assert.That(delta2.SequenceNumber, Is.EqualTo(2));
        Assert.That(argsDone.SequenceNumber, Is.EqualTo(3));
        Assert.That(done.SequenceNumber, Is.EqualTo(4));
    }
}
