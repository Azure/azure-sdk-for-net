// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class OutputItemFileSearchCallBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    // ── Factory ───────────────────────────────────────────────

    [Test]
    public void AddFileSearchCall_ReturnsOutputItemFileSearchCallBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        Assert.That(builder, Is.Not.Null);
        XAssert.IsType<OutputItemFileSearchCallBuilder>(builder);
    }

    [Test]
    public void AddFileSearchCall_AssignsOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        Assert.That(builder.OutputIndex, Is.EqualTo(0));
    }

    [Test]
    public void AddFileSearchCall_GeneratesItemIdWithFsPrefix()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        XAssert.StartsWith("fs_", builder.ItemId);
    }

    [Test]
    public void AddFileSearchCall_SharesOutputIndexWithOtherFactories()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        var fs = stream.AddOutputItemFileSearchCall();
        Assert.That(msg.OutputIndex, Is.EqualTo(0));
        Assert.That(fs.OutputIndex, Is.EqualTo(1));
    }

    // ── EmitAdded ─────────────────────────────────────────────

    [Test]
    public void EmitAdded_ReturnsOutputItemAddedEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        var evt = builder.EmitAdded();
        XAssert.IsType<ResponseOutputItemAddedEvent>(evt);
    }

    [Test]
    public void EmitAdded_ContainsInProgressFileSearchItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemFileSearchToolCall>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(ItemFileSearchToolCallStatus.InProgress));
        Assert.That(item.Queries, Is.Empty);
    }

    [Test]
    public void EmitAdded_HasCorrectOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        var evt = builder.EmitAdded();
        Assert.That(evt.OutputIndex, Is.EqualTo(0));
    }

    // ── Status events ─────────────────────────────────────────

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseFileSearchCallInProgressEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitSearching_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        var evt = builder.EmitSearching();
        XAssert.IsType<ResponseFileSearchCallSearchingEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseFileSearchCallCompletedEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    // ── EmitDone ──────────────────────────────────────────────

    [Test]
    public void EmitDone_ReturnsOutputItemDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        builder.EmitAdded();
        var evt = builder.EmitDone();
        XAssert.IsType<ResponseOutputItemDoneEvent>(evt);
    }

    [Test]
    public void EmitDone_ContainsCompletedFileSearchItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        builder.EmitAdded();
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemFileSearchToolCall>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(ItemFileSearchToolCallStatus.Completed));
    }

    // ── Sequence numbers ──────────────────────────────────────

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemFileSearchCall();
        var added = builder.EmitAdded();         // 0
        var inProg = builder.EmitInProgress();   // 1
        var searching = builder.EmitSearching(); // 2
        var completed = builder.EmitCompleted(); // 3
        var done = builder.EmitDone();           // 4
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(inProg.SequenceNumber, Is.EqualTo(1));
        Assert.That(searching.SequenceNumber, Is.EqualTo(2));
        Assert.That(completed.SequenceNumber, Is.EqualTo(3));
        Assert.That(done.SequenceNumber, Is.EqualTo(4));
    }
}
