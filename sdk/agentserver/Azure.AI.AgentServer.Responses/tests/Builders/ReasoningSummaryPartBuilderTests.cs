// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class ReasoningSummaryPartBuilderTests
{
    private static (ResponseEventStream stream, OutputItemReasoningItemBuilder reasoning) CreateReasoningScope()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
        var reasoning = stream.AddOutputItemReasoningItem();
        return (stream, reasoning);
    }

    // ── EmitAdded ─────────────────────────────────────────────

    [Test]
    public void EmitAdded_ReturnsSummaryPartAddedEvent()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var evt = summary.EmitAdded();
        XAssert.IsType<ResponseReasoningSummaryPartAddedEvent>(evt);
    }

    [Test]
    public void EmitAdded_HasCorrectBookkeepingFields()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var evt = summary.EmitAdded();
        Assert.AreEqual(reasoning.ItemId, evt.ItemId);
        Assert.AreEqual(reasoning.OutputIndex, evt.OutputIndex);
        Assert.AreEqual(summary.SummaryIndex, evt.SummaryIndex);
    }

    [Test]
    public void EmitAdded_ContainsEmptyTextPart()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var evt = summary.EmitAdded();
        Assert.AreEqual("", evt.Part.Text);
    }

    // ── EmitTextDelta ─────────────────────────────────────────

    [Test]
    public void EmitTextDelta_ReturnsSummaryTextDeltaEvent()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var evt = summary.EmitTextDelta("chunk");
        XAssert.IsType<ResponseReasoningSummaryTextDeltaEvent>(evt);
        Assert.AreEqual("chunk", evt.Delta);
    }

    [Test]
    public void EmitTextDelta_HasCorrectBookkeepingFields()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var evt = summary.EmitTextDelta("chunk");
        Assert.AreEqual(reasoning.ItemId, evt.ItemId);
        Assert.AreEqual(reasoning.OutputIndex, evt.OutputIndex);
        Assert.AreEqual(summary.SummaryIndex, evt.SummaryIndex);
    }

    [Test]
    public void EmitTextDelta_CanBeCalledMultipleTimes()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var d1 = summary.EmitTextDelta("Hello, ");
        var d2 = summary.EmitTextDelta("world!");
        Assert.AreEqual("Hello, ", d1.Delta);
        Assert.AreEqual("world!", d2.Delta);
    }

    // ── EmitTextDone ──────────────────────────────────────────

    [Test]
    public void EmitTextDone_ReturnsSummaryTextDoneEvent()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var evt = summary.EmitTextDone("Final text");
        XAssert.IsType<ResponseReasoningSummaryTextDoneEvent>(evt);
        Assert.AreEqual("Final text", evt.Text);
    }

    [Test]
    public void EmitTextDone_StoresFinalText()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        Assert.IsNull(summary.FinalText);
        summary.EmitTextDone("Final value");
        Assert.AreEqual("Final value", summary.FinalText);
    }

    [Test]
    public void EmitTextDone_HasCorrectBookkeepingFields()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var evt = summary.EmitTextDone("done");
        Assert.AreEqual(reasoning.ItemId, evt.ItemId);
        Assert.AreEqual(reasoning.OutputIndex, evt.OutputIndex);
        Assert.AreEqual(summary.SummaryIndex, evt.SummaryIndex);
    }

    // ── EmitDone ──────────────────────────────────────────────

    [Test]
    public void EmitDone_ReturnsSummaryPartDoneEvent()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        summary.EmitAdded();
        summary.EmitTextDone("Text");
        var evt = summary.EmitDone();
        XAssert.IsType<ResponseReasoningSummaryPartDoneEvent>(evt);
    }

    [Test]
    public void EmitDone_ContainsFinalTextPart()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        summary.EmitAdded();
        summary.EmitTextDone("Final text");
        var evt = summary.EmitDone();
        Assert.AreEqual("Final text", evt.Part.Text);
    }

    [Test]
    public void EmitDone_HasCorrectBookkeepingFields()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        summary.EmitAdded();
        summary.EmitTextDone("done");
        var evt = summary.EmitDone();
        Assert.AreEqual(reasoning.ItemId, evt.ItemId);
        Assert.AreEqual(reasoning.OutputIndex, evt.OutputIndex);
        Assert.AreEqual(summary.SummaryIndex, evt.SummaryIndex);
    }

    // ── Sequence numbers ──────────────────────────────────────

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var added = summary.EmitAdded();            // seq 0
        var delta = summary.EmitTextDelta("Hi");    // seq 1
        var textDone = summary.EmitTextDone("Hi");  // seq 2
        var done = summary.EmitDone();              // seq 3
        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, delta.SequenceNumber);
        Assert.AreEqual(2, textDone.SequenceNumber);
        Assert.AreEqual(3, done.SequenceNumber);
    }
}
