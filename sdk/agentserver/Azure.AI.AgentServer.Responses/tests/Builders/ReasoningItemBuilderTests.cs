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
        Assert.IsNotNull(builder);
        XAssert.IsType<OutputItemReasoningItemBuilder>(builder);
    }

    [Test]
    public void AddReasoningItem_AssignsOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        Assert.AreEqual(0, builder.OutputIndex);
    }

    [Test]
    public void AddReasoningItem_IncrementsOutputIndex()
    {
        var stream = CreateStream();
        var r0 = stream.AddOutputItemReasoningItem();
        var r1 = stream.AddOutputItemReasoningItem();
        Assert.AreEqual(0, r0.OutputIndex);
        Assert.AreEqual(1, r1.OutputIndex);
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
        Assert.AreEqual(0, msg.OutputIndex);
        Assert.AreEqual(1, reasoning.OutputIndex);
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
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(OutputItemReasoningItemStatus.InProgress, item.Status);
        Assert.IsEmpty(item.Summary);
    }

    [Test]
    public void EmitAdded_HasCorrectOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var evt = builder.EmitAdded();
        Assert.AreEqual(0, evt.OutputIndex);
    }

    // ── AddSummaryPart ────────────────────────────────────────

    [Test]
    public void AddSummaryPart_ReturnsSummaryPartBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var summary = builder.AddSummaryPart();
        Assert.IsNotNull(summary);
        XAssert.IsType<ReasoningSummaryPartBuilder>(summary);
    }

    [Test]
    public void AddSummaryPart_AssignsSummaryIndexStartingAtZero()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var summary = builder.AddSummaryPart();
        Assert.AreEqual(0, summary.SummaryIndex);
    }

    [Test]
    public void AddSummaryPart_IncrementsSummaryIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var s0 = builder.AddSummaryPart();
        var s1 = builder.AddSummaryPart();
        Assert.AreEqual(0, s0.SummaryIndex);
        Assert.AreEqual(1, s1.SummaryIndex);
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
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(OutputItemReasoningItemStatus.Completed, item.Status);
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
        builder.EmitSummaryPartDone(s0);

        var s1 = builder.AddSummaryPart();
        s1.EmitAdded();
        s1.EmitTextDone("Second summary");
        builder.EmitSummaryPartDone(s1);

        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemReasoningItem>(evt.Item);
        Assert.AreEqual(2, item.Summary.Count);
        Assert.AreEqual("First summary", item.Summary[0].Text);
        Assert.AreEqual("Second summary", item.Summary[1].Text);
    }

    [Test]
    public void EmitDone_WithNoSummaries_HasEmptySummaryList()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        builder.EmitAdded();
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemReasoningItem>(evt.Item);
        Assert.IsEmpty(item.Summary);
    }

    // ── Sequence numbers ──────────────────────────────────────

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemReasoningItem();
        var added = builder.EmitAdded();    // seq 0
        var done = builder.EmitDone();      // seq 1
        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, done.SequenceNumber);
    }
}
