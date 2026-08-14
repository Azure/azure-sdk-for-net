// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class RefusalContentBuilderTests
{
    private static (ResponseEventStream Stream, OutputItemMessageBuilder Msg) CreateMessageScope()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
        var msg = stream.AddOutputItemMessage();
        return (stream, msg);
    }

    // ── OutputItemMessageBuilder.AddRefusalContent() factory ────────────

    [Test]
    public void AddRefusalContent_ReturnsRefusalContentBuilder()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        Assert.That(refusal, Is.Not.Null);
        XAssert.IsType<RefusalContentBuilder>(refusal);
    }

    [Test]
    public void AddRefusalContent_AssignsContentIndexStartingAtZero()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        Assert.That(refusal.ContentIndex, Is.EqualTo(0));
    }

    [Test]
    public void AddRefusalContent_IncrementsContentIndex()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        var refusal = msg.AddRefusalContent();
        Assert.That(text.ContentIndex, Is.EqualTo(0));
        Assert.That(refusal.ContentIndex, Is.EqualTo(1));
    }

    // ── RefusalContentBuilder.EmitAdded() ─────────────────────

    [Test]
    public void EmitAdded_ReturnsContentPartAddedEvent()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        var evt = refusal.EmitAdded();
        XAssert.IsType<ResponseContentPartAddedEvent>(evt);
    }

    [Test]
    public void EmitAdded_ContainsEmptyRefusalContent()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        var evt = refusal.EmitAdded();
        var part = XAssert.IsType<OutputContentRefusalContent>(evt.Part);
        Assert.That(part.Refusal, Is.EqualTo(""));
    }

    [Test]
    public void EmitAdded_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        var evt = refusal.EmitAdded();
        Assert.That(evt.ItemId, Is.EqualTo(msg.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
        Assert.That(evt.ContentIndex, Is.EqualTo(refusal.ContentIndex));
    }

    // ── RefusalContentBuilder.EmitDelta() ─────────────────────

    [Test]
    public void EmitDelta_ReturnsRefusalDeltaEvent()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        var evt = refusal.EmitDelta("I can't ");
        XAssert.IsType<ResponseRefusalDeltaEvent>(evt);
        Assert.That(evt.Delta, Is.EqualTo("I can't "));
    }

    [Test]
    public void EmitDelta_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        var evt = refusal.EmitDelta("chunk");
        Assert.That(evt.ItemId, Is.EqualTo(msg.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
        Assert.That(evt.ContentIndex, Is.EqualTo(refusal.ContentIndex));
    }

    [Test]
    public void EmitDelta_CanBeCalledMultipleTimes()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        var d1 = refusal.EmitDelta("I can't ");
        var d2 = refusal.EmitDelta("help with that.");
        Assert.That(d1.Delta, Is.EqualTo("I can't "));
        Assert.That(d2.Delta, Is.EqualTo("help with that."));
    }

    // ── RefusalContentBuilder.EmitDone() ──────────────────────

    [Test]
    public void EmitDone_ReturnsRefusalDoneEvent()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        var evt = refusal.EmitRefusalDone("I can't help with that.");
        XAssert.IsType<ResponseRefusalDoneEvent>(evt);
        Assert.That(evt.Refusal, Is.EqualTo("I can't help with that."));
    }

    [Test]
    public void EmitDone_StoresFinalRefusal()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        Assert.That(refusal.FinalRefusal, Is.Null);
        refusal.EmitAdded();
        refusal.EmitRefusalDone("Final refusal");
        Assert.That(refusal.FinalRefusal, Is.EqualTo("Final refusal"));
    }

    [Test]
    public void EmitDone_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        var evt = refusal.EmitRefusalDone("done text");
        Assert.That(evt.ItemId, Is.EqualTo(msg.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
        Assert.That(evt.ContentIndex, Is.EqualTo(refusal.ContentIndex));
    }

    // ── RefusalContentBuilder.EmitDone (content_part.done) ─

    [Test]
    public void RefusalEmitDone_ReturnsContentPartDoneEvent()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        refusal.EmitRefusalDone("I can't help with that.");
        var evt = refusal.EmitDone();
        XAssert.IsType<ResponseContentPartDoneEvent>(evt);
    }

    [Test]
    public void RefusalEmitDone_ContainsFinalRefusalText()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        refusal.EmitRefusalDone("I can't help with that.");
        var evt = refusal.EmitDone();
        var part = XAssert.IsType<OutputContentRefusalContent>(evt.Part);
        Assert.That(part.Refusal, Is.EqualTo("I can't help with that."));
    }

    [Test]
    public void RefusalEmitDone_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        refusal.EmitRefusalDone("refused");
        var evt = refusal.EmitDone();
        Assert.That(evt.ItemId, Is.EqualTo(msg.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
        Assert.That(evt.ContentIndex, Is.EqualTo(refusal.ContentIndex));
    }

    // ── EmitDone accumulation ─────────────────────────────────

    [Test]
    public void EmitDone_AccumulatesRefusalInMessageContent()
    {
        var (_, msg) = CreateMessageScope();
        msg.EmitAdded();
        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        refusal.EmitRefusalDone("I can't help with that.");
        refusal.EmitDone();
        var evt = msg.EmitDone();
        var item = XAssert.IsType<OutputItemMessage>(evt.Item);
        XAssert.Single(item.Content);
        var content = XAssert.IsType<MessageContentRefusalContent>(item.Content[0]);
        Assert.That(content.Refusal, Is.EqualTo("I can't help with that."));
    }

    [Test]
    public void EmitDone_AccumulatesTextAndRefusalContent()
    {
        var (_, msg) = CreateMessageScope();
        msg.EmitAdded();

        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("Hello!");
        text.EmitDone();

        var refusal = msg.AddRefusalContent();
        refusal.EmitAdded();
        refusal.EmitRefusalDone("I can't help.");
        refusal.EmitDone();

        var evt = msg.EmitDone();
        var item = XAssert.IsType<OutputItemMessage>(evt.Item);
        Assert.That(item.Content.Count, Is.EqualTo(2));
        XAssert.IsType<MessageContentOutputTextContent>(item.Content[0]);
        XAssert.IsType<MessageContentRefusalContent>(item.Content[1]);
    }

    // ── Sequence numbers ──────────────────────────────────────

    [Test]
    public void AllEmitMethods_ShareSequenceCounter()
    {
        var (_, msg) = CreateMessageScope();
        var refusal = msg.AddRefusalContent();
        var added = refusal.EmitAdded();       // seq 0
        var delta = refusal.EmitDelta("Hi");   // seq 1
        var done = refusal.EmitRefusalDone("Hi");     // seq 2
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(delta.SequenceNumber, Is.EqualTo(1));
        Assert.That(done.SequenceNumber, Is.EqualTo(2));
    }
}
