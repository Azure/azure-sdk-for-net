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
        Assert.That(builder, Is.Not.Null);
        XAssert.IsType<OutputItemCodeInterpreterCallBuilder>(builder);
    }

    [Test]
    public void AddCodeInterpreterCall_AssignsOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        Assert.That(builder.OutputIndex, Is.EqualTo(0));
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
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(OutputItemCodeInterpreterToolCallStatus.InProgress));
        Assert.That(item.Code, Is.EqualTo(""));
    }

    // ── Status events ─────────────────────────────────────────

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseCodeInterpreterCallInProgressEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitInterpreting_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitInterpreting();
        XAssert.IsType<ResponseCodeInterpreterCallInterpretingEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseCodeInterpreterCallCompletedEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    // ── Code deltas ───────────────────────────────────────────

    [Test]
    public void EmitCodeDelta_ReturnsCodeDeltaEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitCodeDelta("import ");
        XAssert.IsType<ResponseCodeInterpreterCallCodeDeltaEvent>(evt);
        Assert.That(evt.Delta, Is.EqualTo("import "));
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitCodeDelta_CanBeCalledMultipleTimes()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var d1 = builder.EmitCodeDelta("import ");
        var d2 = builder.EmitCodeDelta("math\n");
        Assert.That(d1.Delta, Is.EqualTo("import "));
        Assert.That(d2.Delta, Is.EqualTo("math\n"));
    }

    [Test]
    public void EmitCodeDone_ReturnsCodeDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCodeInterpreterCall();
        var evt = builder.EmitCodeDone("import math\nprint(math.pi)");
        XAssert.IsType<ResponseCodeInterpreterCallCodeDoneEvent>(evt);
        Assert.That(evt.Code, Is.EqualTo("import math\nprint(math.pi)"));
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
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
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(OutputItemCodeInterpreterToolCallStatus.Completed));
        Assert.That(item.Code, Is.EqualTo("print('hi')"));
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
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(inProg.SequenceNumber, Is.EqualTo(1));
        Assert.That(interpreting.SequenceNumber, Is.EqualTo(2));
        Assert.That(delta1.SequenceNumber, Is.EqualTo(3));
        Assert.That(codeDone.SequenceNumber, Is.EqualTo(4));
        Assert.That(completed.SequenceNumber, Is.EqualTo(5));
        Assert.That(done.SequenceNumber, Is.EqualTo(6));
    }
}
