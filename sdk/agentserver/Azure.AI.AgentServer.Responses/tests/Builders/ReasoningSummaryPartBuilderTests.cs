// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class ReasoningSummaryPartBuilderTests
{
    private static (ResponseEventStream Stream, OutputItemReasoningItemBuilder Reasoning) CreateReasoningScope()
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
        Assert.That(evt.ItemId, Is.EqualTo(reasoning.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(reasoning.OutputIndex));
        Assert.That(evt.SummaryIndex, Is.EqualTo(summary.SummaryIndex));
    }

    [Test]
    public void EmitAdded_ContainsEmptyTextPart()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        var evt = summary.EmitAdded();
        Assert.That(evt.Part.Text, Is.EqualTo(""));
    }

    // ── EmitTextDelta ─────────────────────────────────────────

    [Test]
    public void EmitTextDelta_ReturnsSummaryTextDeltaEvent()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        summary.EmitAdded();
        var evt = summary.EmitTextDelta("chunk");
        XAssert.IsType<ResponseReasoningSummaryTextDeltaEvent>(evt);
        Assert.That(evt.Delta, Is.EqualTo("chunk"));
    }

    [Test]
    public void EmitTextDelta_HasCorrectBookkeepingFields()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        summary.EmitAdded();
        var evt = summary.EmitTextDelta("chunk");
        Assert.That(evt.ItemId, Is.EqualTo(reasoning.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(reasoning.OutputIndex));
        Assert.That(evt.SummaryIndex, Is.EqualTo(summary.SummaryIndex));
    }

    [Test]
    public void EmitTextDelta_CanBeCalledMultipleTimes()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        summary.EmitAdded();
        var d1 = summary.EmitTextDelta("Hello, ");
        var d2 = summary.EmitTextDelta("world!");
        Assert.That(d1.Delta, Is.EqualTo("Hello, "));
        Assert.That(d2.Delta, Is.EqualTo("world!"));
    }

    // ── EmitTextDone ──────────────────────────────────────────

    [Test]
    public void EmitTextDone_ReturnsSummaryTextDoneEvent()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        summary.EmitAdded();
        var evt = summary.EmitTextDone("Final text");
        XAssert.IsType<ResponseReasoningSummaryTextDoneEvent>(evt);
        Assert.That(evt.Text, Is.EqualTo("Final text"));
    }

    [Test]
    public void EmitTextDone_StoresFinalText()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        Assert.That(summary.FinalText, Is.Null);
        summary.EmitAdded();
        summary.EmitTextDone("Final value");
        Assert.That(summary.FinalText, Is.EqualTo("Final value"));
    }

    [Test]
    public void EmitTextDone_HasCorrectBookkeepingFields()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        summary.EmitAdded();
        var evt = summary.EmitTextDone("done");
        Assert.That(evt.ItemId, Is.EqualTo(reasoning.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(reasoning.OutputIndex));
        Assert.That(evt.SummaryIndex, Is.EqualTo(summary.SummaryIndex));
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
        Assert.That(evt.Part.Text, Is.EqualTo("Final text"));
    }

    [Test]
    public void EmitDone_HasCorrectBookkeepingFields()
    {
        var (_, reasoning) = CreateReasoningScope();
        var summary = reasoning.AddSummaryPart();
        summary.EmitAdded();
        summary.EmitTextDone("done");
        var evt = summary.EmitDone();
        Assert.That(evt.ItemId, Is.EqualTo(reasoning.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(reasoning.OutputIndex));
        Assert.That(evt.SummaryIndex, Is.EqualTo(summary.SummaryIndex));
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
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(delta.SequenceNumber, Is.EqualTo(1));
        Assert.That(textDone.SequenceNumber, Is.EqualTo(2));
        Assert.That(done.SequenceNumber, Is.EqualTo(3));
    }
}
