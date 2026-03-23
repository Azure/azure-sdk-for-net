// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class CodeInterpreterCallBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    // ── Factory ───────────────────────────────────────────────

    [Test]
    public void AddCodeInterpreterCall_ReturnsCodeInterpreterCallBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        Assert.IsNotNull(builder);
        XAssert.IsType<OutputItemCodeInterpreterCallBuilder>(builder);
    }

    [Test]
    public void AddCodeInterpreterCall_AssignsOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        Assert.AreEqual(0, builder.OutputIndex);
    }

    [Test]
    public void AddCodeInterpreterCall_GeneratesItemIdWithCiPrefix()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        XAssert.StartsWith("ci_", builder.ItemId);
    }

    // ── EmitAdded ─────────────────────────────────────────────

    [Test]
    public void EmitAdded_ReturnsOutputItemAddedEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitAdded();
        XAssert.IsType<ResponseOutputItemAddedEvent>(evt);
    }

    [Test]
    public void EmitAdded_ContainsInProgressCodeInterpreterItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemCodeInterpreterToolCall>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(OutputItemCodeInterpreterToolCallStatus.InProgress, item.Status);
        Assert.AreEqual("", item.Code);
    }

    // ── Status events ─────────────────────────────────────────

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseCodeInterpreterCallInProgressEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitInterpreting_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitInterpreting();
        XAssert.IsType<ResponseCodeInterpreterCallInterpretingEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseCodeInterpreterCallCompletedEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    // ── Code deltas ───────────────────────────────────────────

    [Test]
    public void EmitCodeDelta_ReturnsCodeDeltaEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitCodeDelta("import ");
        XAssert.IsType<ResponseCodeInterpreterCallCodeDeltaEvent>(evt);
        Assert.AreEqual("import ", evt.Delta);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitCodeDelta_CanBeCalledMultipleTimes()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var d1 = builder.EmitCodeDelta("import ");
        var d2 = builder.EmitCodeDelta("math\n");
        Assert.AreEqual("import ", d1.Delta);
        Assert.AreEqual("math\n", d2.Delta);
    }

    [Test]
    public void EmitCodeDone_ReturnsCodeDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitCodeDone("import math\nprint(math.pi)");
        XAssert.IsType<ResponseCodeInterpreterCallCodeDoneEvent>(evt);
        Assert.AreEqual("import math\nprint(math.pi)", evt.Code);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    // ── EmitDone ──────────────────────────────────────────────

    [Test]
    public void EmitDone_ReturnsOutputItemDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        builder.EmitAdded();
        builder.EmitCodeDone("print('hi')");
        var evt = builder.EmitDone();
        XAssert.IsType<ResponseOutputItemDoneEvent>(evt);
    }

    [Test]
    public void EmitDone_ContainsCompletedCodeInterpreterItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        builder.EmitAdded();
        builder.EmitCodeDone("print('hi')");
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemCodeInterpreterToolCall>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(OutputItemCodeInterpreterToolCallStatus.Completed, item.Status);
        Assert.AreEqual("print('hi')", item.Code);
    }

    // ── Sequence numbers ──────────────────────────────────────

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var added = builder.EmitAdded();             // 0
        var inProg = builder.EmitInProgress();       // 1
        var interpreting = builder.EmitInterpreting(); // 2
        var delta1 = builder.EmitCodeDelta("x=1");   // 3
        var codeDone = builder.EmitCodeDone("x=1");  // 4
        var completed = builder.EmitCompleted();     // 5
        var done = builder.EmitDone();               // 6
        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, inProg.SequenceNumber);
        Assert.AreEqual(2, interpreting.SequenceNumber);
        Assert.AreEqual(3, delta1.SequenceNumber);
        Assert.AreEqual(4, codeDone.SequenceNumber);
        Assert.AreEqual(5, completed.SequenceNumber);
        Assert.AreEqual(6, done.SequenceNumber);
    }
}
