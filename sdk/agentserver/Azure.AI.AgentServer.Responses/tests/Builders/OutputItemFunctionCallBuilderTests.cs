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

        Assert.IsNotNull(fc);
        XAssert.IsType<OutputItemFunctionCallBuilder>(fc);
    }

    [Test]
    public void AddFunctionCall_AssignsOutputIndex()
    {
        var stream = CreateStream();

        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        Assert.AreEqual(0, fc.OutputIndex);
    }

    [Test]
    public void AddFunctionCall_SharesOutputIndexWithAddMessage()
    {
        var stream = CreateStream();

        var msg = stream.AddOutputItemMessage();      // index 0
        var fc = stream.AddOutputItemFunctionCall("fn", "c1"); // index 1

        Assert.AreEqual(0, msg.OutputIndex);
        Assert.AreEqual(1, fc.OutputIndex);
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

        Assert.AreEqual("get_weather", fc.Name);
        Assert.AreEqual("call_001", fc.CallId);
    }

    [Test]
    public void AddFunctionCall_SharesSequenceNumberWithStream()
    {
        var stream = CreateStream();
        stream.EmitCreated();   // seq 0
        stream.EmitInProgress(); // seq 1

        var fc = stream.AddOutputItemFunctionCall("fn", "c1");
        var evt = fc.EmitAdded(); // seq 2

        Assert.AreEqual(2, evt.SequenceNumber);
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
        Assert.AreEqual(fc.ItemId, item.Id);
        Assert.AreEqual("call_001", item.CallId);
        Assert.AreEqual("get_weather", item.Name);
        Assert.AreEqual("", item.Arguments);
        Assert.AreEqual(OutputItemFunctionToolCallStatus.InProgress, item.Status);
    }

    [Test]
    public void EmitAdded_HasCorrectOutputIndex()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("fn", "c1");

        var evt = fc.EmitAdded();

        Assert.AreEqual(0, evt.OutputIndex);
    }

    // ── T014: EmitArgumentsDelta + EmitArgumentsDone ──────────

    [Test]
    public void EmitArgumentsDelta_ReturnsDeltaEvent()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        var evt = fc.EmitArgumentsDelta("{\"loc");

        XAssert.IsType<ResponseFunctionCallArgumentsDeltaEvent>(evt);
        Assert.AreEqual("{\"loc", evt.Delta);
        Assert.AreEqual(fc.ItemId, evt.ItemId);
        Assert.AreEqual(fc.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitArgumentsDone_ReturnsDoneEvent()
    {
        var stream = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("get_weather", "call_001");

        var evt = fc.EmitArgumentsDone("{\"location\":\"Seattle\"}");

        XAssert.IsType<ResponseFunctionCallArgumentsDoneEvent>(evt);
        Assert.AreEqual("{\"location\":\"Seattle\"}", evt.Arguments);
        Assert.AreEqual(fc.ItemId, evt.ItemId);
        Assert.AreEqual("get_weather", evt.Name);
        Assert.AreEqual(fc.OutputIndex, evt.OutputIndex);
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
        Assert.AreEqual(fc.OutputIndex, evt.OutputIndex);
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
        Assert.AreEqual(fc.ItemId, item.Id);
        Assert.AreEqual("call_001", item.CallId);
        Assert.AreEqual("get_weather", item.Name);
        Assert.AreEqual("{\"location\":\"Seattle\"}", item.Arguments);
        Assert.AreEqual(OutputItemFunctionToolCallStatus.Completed, item.Status);
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

        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, delta1.SequenceNumber);
        Assert.AreEqual(2, delta2.SequenceNumber);
        Assert.AreEqual(3, argsDone.SequenceNumber);
        Assert.AreEqual(4, done.SequenceNumber);
    }
}
