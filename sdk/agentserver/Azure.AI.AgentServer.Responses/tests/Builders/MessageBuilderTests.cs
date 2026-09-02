// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class MessageBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    [Test]
    public void AddMessage_ReturnsMessageBuilder()
    {
        var stream = CreateStream();

        var builder = stream.AddOutputItemMessage();

        Assert.That(builder, Is.Not.Null);
        XAssert.IsType<OutputItemMessageBuilder>(builder);
    }

    [Test]
    public void AddMessage_AssignsOutputIndexStartingAtZero()
    {
        var stream = CreateStream();

        var msg = stream.AddOutputItemMessage();

        Assert.That(msg.OutputIndex, Is.EqualTo(0));
    }

    [Test]
    public void AddMessage_IncrementsOutputIndex()
    {
        var stream = CreateStream();

        var msg0 = stream.AddOutputItemMessage();
        var msg1 = stream.AddOutputItemMessage();
        var msg2 = stream.AddOutputItemMessage();

        Assert.That(msg0.OutputIndex, Is.EqualTo(0));
        Assert.That(msg1.OutputIndex, Is.EqualTo(1));
        Assert.That(msg2.OutputIndex, Is.EqualTo(2));
    }

    [Test]
    public void AddMessage_GeneratesItemIdWithMsgPrefix()
    {
        var stream = CreateStream();

        var msg = stream.AddOutputItemMessage();

        XAssert.StartsWith("msg_", msg.ItemId);
    }

    [Test]
    public void AddMessage_GeneratesUniqueItemIds()
    {
        var stream = CreateStream();

        var msg0 = stream.AddOutputItemMessage();
        var msg1 = stream.AddOutputItemMessage();

        Assert.That(msg1.ItemId, Is.Not.EqualTo(msg0.ItemId));
    }

    [Test]
    public void MessageBuilder_SharesSequenceNumberWithStream()
    {
        var stream = CreateStream();
        // Consume seq 0 and 1 from stream
        stream.EmitCreated();
        stream.EmitInProgress();

        var msg = stream.AddOutputItemMessage();
        var evt = msg.EmitAdded();

        // Should use seq 2 (shared counter)
        Assert.That(evt.SequenceNumber, Is.EqualTo(2));
    }

    // ── T005: EmitAdded ───────────────────────────────────────

    [Test]
    public void EmitAdded_ReturnsOutputItemAddedEvent()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();

        var evt = msg.EmitAdded();

        XAssert.IsType<ResponseOutputItemAddedEvent>(evt);
    }

    [Test]
    public void EmitAdded_ContainsInProgressMessage()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();

        var evt = msg.EmitAdded();

        var item = XAssert.IsType<OutputItemMessage>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(msg.ItemId));
        Assert.That(item.Content, Is.Empty);
        Assert.That(item.Status, Is.EqualTo(MessageStatus.InProgress));
    }

    [Test]
    public void EmitAdded_HasCorrectOutputIndex()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();

        var evt = msg.EmitAdded();

        Assert.That(evt.OutputIndex, Is.EqualTo(0));
    }

    // ── T009: TextContentBuilder.EmitDone (content_part.done) ──

    [Test]
    public void TextContentEmitDone_ReturnsContentPartDoneEvent()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("Hello!");

        var evt = text.EmitDone();

        XAssert.IsType<ResponseContentPartDoneEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(msg.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
        Assert.That(evt.ContentIndex, Is.EqualTo(text.ContentIndex));
    }

    [Test]
    public void TextContentEmitDone_ContainsFinalText()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("Final text here");

        var evt = text.EmitDone();

        var part = XAssert.IsType<OutputContentOutputTextContent>(evt.Part);
        Assert.That(part.Text, Is.EqualTo("Final text here"));
    }

    // ── T010: EmitDone ────────────────────────────────────────

    [Test]
    public void EmitDone_ReturnsOutputItemDoneEvent()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("test");
        text.EmitDone();

        var evt = msg.EmitDone();

        XAssert.IsType<ResponseOutputItemDoneEvent>(evt);
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
    }

    [Test]
    public void EmitDone_ContainsCompletedMessageWithAccumulatedContent()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("Hello, world!");
        text.EmitDone();

        var evt = msg.EmitDone();

        var item = XAssert.IsType<OutputItemMessage>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(msg.ItemId));
        Assert.That(item.Status, Is.EqualTo(MessageStatus.Completed));
        XAssert.Single(item.Content);

        var content = XAssert.IsType<MessageContentOutputTextContent>(item.Content[0]);
        Assert.That(content.Text, Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void EmitDone_WithNoContent_HasEmptyContentList()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("test");
        text.EmitDone();

        var evt = msg.EmitDone();

        var item = XAssert.IsType<OutputItemMessage>(evt.Item);
        XAssert.Single(item.Content);
        Assert.That(item.Status, Is.EqualTo(MessageStatus.Completed));
    }
}
