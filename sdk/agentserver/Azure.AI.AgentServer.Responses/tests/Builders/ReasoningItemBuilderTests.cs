// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class ReasoningItemBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    // ── Factory ───────────────────────────────────────────────

    [Test]
    public void AddReasoningItem_ReturnsReasoningItemBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        Assert.That(builder, Is.Not.Null);
        XAssert.IsType<OutputItemReasoningItemBuilder>(builder);
    }

    [Test]
    public void AddReasoningItem_AssignsOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        Assert.That(builder.OutputIndex, Is.EqualTo(0));
    }

    [Test]
    public void AddReasoningItem_IncrementsOutputIndex()
    {
        var stream = CreateStream();
        var r0 = stream.AddOutputItemReasoningItem();
        var r1 = stream.AddOutputItemReasoningItem();
        Assert.That(r0.OutputIndex, Is.EqualTo(0));
        Assert.That(r1.OutputIndex, Is.EqualTo(1));
    }

    [Test]
    public void AddReasoningItem_GeneratesItemIdWithRsPrefix()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        XAssert.StartsWith("rs_", builder.ItemId);
    }

    [Test]
    public void AddReasoningItem_SharesOutputIndexWithOtherFactories()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        var reasoning = stream.AddOutputItemReasoningItem();
        Assert.That(msg.OutputIndex, Is.EqualTo(0));
        Assert.That(reasoning.OutputIndex, Is.EqualTo(1));
    }

    // ── EmitAdded ─────────────────────────────────────────────

    [Test]
    public void EmitAdded_ReturnsOutputItemAddedEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var evt = builder.EmitAdded();
        XAssert.IsType<ResponseOutputItemAddedEvent>(evt);
    }

    [Test]
    public void EmitAdded_ContainsInProgressReasoningItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemReasoningItem>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(OutputItemReasoningItemStatus.InProgress));
        Assert.That(item.Summary, Is.Empty);
    }

    [Test]
    public void EmitAdded_HasCorrectOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var evt = builder.EmitAdded();
        Assert.That(evt.OutputIndex, Is.EqualTo(0));
    }

    // ── AddSummaryPart ────────────────────────────────────────

    [Test]
    public void AddSummaryPart_ReturnsSummaryPartBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var summary = builder.AddSummaryPart();
        Assert.That(summary, Is.Not.Null);
        XAssert.IsType<ReasoningSummaryPartBuilder>(summary);
    }

    [Test]
    public void AddSummaryPart_AssignsSummaryIndexStartingAtZero()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var summary = builder.AddSummaryPart();
        Assert.That(summary.SummaryIndex, Is.EqualTo(0));
    }

    [Test]
    public void AddSummaryPart_IncrementsSummaryIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var s0 = builder.AddSummaryPart();
        var s1 = builder.AddSummaryPart();
        Assert.That(s0.SummaryIndex, Is.EqualTo(0));
        Assert.That(s1.SummaryIndex, Is.EqualTo(1));
    }

    // ── EmitDone ──────────────────────────────────────────────

    [Test]
    public void EmitDone_ReturnsOutputItemDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        builder.EmitAdded();
        var evt = builder.EmitDone();
        XAssert.IsType<ResponseOutputItemDoneEvent>(evt);
    }

    [Test]
    public void EmitDone_ContainsCompletedReasoningItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        builder.EmitAdded();
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemReasoningItem>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(OutputItemReasoningItemStatus.Completed));
    }

    [Test]
    public void EmitDone_ContainsAccumulatedSummaries()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        builder.EmitAdded();

        var s0 = builder.AddSummaryPart();
        s0.EmitAdded();
        s0.EmitTextDone("First summary");
        s0.EmitDone();

        var s1 = builder.AddSummaryPart();
        s1.EmitAdded();
        s1.EmitTextDone("Second summary");
        s1.EmitDone();

        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemReasoningItem>(evt.Item);
        Assert.That(item.Summary.Count, Is.EqualTo(2));
        Assert.That(item.Summary[0].Text, Is.EqualTo("First summary"));
        Assert.That(item.Summary[1].Text, Is.EqualTo("Second summary"));
    }

    [Test]
    public void EmitDone_WithNoSummaries_HasEmptySummaryList()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        builder.EmitAdded();
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemReasoningItem>(evt.Item);
        Assert.That(item.Summary, Is.Empty);
    }

    // ── Sequence numbers ──────────────────────────────────────

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var added = builder.EmitAdded();    // seq 0
        var done = builder.EmitDone();      // seq 1
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(done.SequenceNumber, Is.EqualTo(1));
    }
}
