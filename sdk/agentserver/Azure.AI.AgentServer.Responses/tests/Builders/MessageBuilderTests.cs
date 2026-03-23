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

        Assert.IsNotNull(builder);
        XAssert.IsType<OutputItemMessageBuilder>(builder);
    }

    [Test]
    public void AddMessage_AssignsOutputIndexStartingAtZero()
    {
        var stream = CreateStream();

        var msg = stream.AddOutputItemMessage();

        Assert.AreEqual(0, msg.OutputIndex);
    }

    [Test]
    public void AddMessage_IncrementsOutputIndex()
    {
        var stream = CreateStream();

        var msg0 = stream.AddOutputItemMessage();
        var msg1 = stream.AddOutputItemMessage();
        var msg2 = stream.AddOutputItemMessage();

        Assert.AreEqual(0, msg0.OutputIndex);
        Assert.AreEqual(1, msg1.OutputIndex);
        Assert.AreEqual(2, msg2.OutputIndex);
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

        Assert.AreNotEqual(msg0.ItemId, msg1.ItemId);
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
        Assert.AreEqual(2, evt.SequenceNumber);
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

        var item = XAssert.IsType<OutputItemOutputMessage>(evt.Item);
        Assert.AreEqual(msg.ItemId, item.Id);
        Assert.IsEmpty(item.Content);
        Assert.AreEqual(OutputItemOutputMessageStatus.InProgress, item.Status);
    }

    [Test]
    public void EmitAdded_HasCorrectOutputIndex()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();

        var evt = msg.EmitAdded();

        Assert.AreEqual(0, evt.OutputIndex);
    }

    // ── T009: EmitContentDone ─────────────────────────────────

    [Test]
    public void EmitContentDone_ReturnsContentPartDoneEvent()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitDone("Hello!");

        var evt = msg.EmitContentDone(text);

        XAssert.IsType<ResponseContentPartDoneEvent>(evt);
        Assert.AreEqual(msg.ItemId, evt.ItemId);
        Assert.AreEqual(msg.OutputIndex, evt.OutputIndex);
        Assert.AreEqual(text.ContentIndex, evt.ContentIndex);
    }

    [Test]
    public void EmitContentDone_ContainsFinalText()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitDone("Final text here");

        var evt = msg.EmitContentDone(text);

        var part = XAssert.IsType<OutputContentOutputTextContent>(evt.Part);
        Assert.AreEqual("Final text here", part.Text);
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
        text.EmitDone("test");
        msg.EmitContentDone(text);

        var evt = msg.EmitDone();

        XAssert.IsType<ResponseOutputItemDoneEvent>(evt);
        Assert.AreEqual(msg.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitDone_ContainsCompletedMessageWithAccumulatedContent()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitDone("Hello, world!");
        msg.EmitContentDone(text);

        var evt = msg.EmitDone();

        var item = XAssert.IsType<OutputItemOutputMessage>(evt.Item);
        Assert.AreEqual(msg.ItemId, item.Id);
        Assert.AreEqual(OutputItemOutputMessageStatus.Completed, item.Status);
        XAssert.Single(item.Content);

        var content = XAssert.IsType<OutputMessageContentOutputTextContent>(item.Content[0]);
        Assert.AreEqual("Hello, world!", content.Text);
    }

    [Test]
    public void EmitDone_WithNoContent_HasEmptyContentList()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();

        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitDone("test");
        msg.EmitContentDone(text);

        var evt = msg.EmitDone();

        var item = XAssert.IsType<OutputItemOutputMessage>(evt.Item);
        XAssert.Single(item.Content);
        Assert.AreEqual(OutputItemOutputMessageStatus.Completed, item.Status);
    }
}
