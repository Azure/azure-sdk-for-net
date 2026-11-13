// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class OutputItemBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    // ──────────────────────────────────────────────
    // Construction & Properties
    // ──────────────────────────────────────────────

    [Test]
    public void Constructor_SetsItemIdAndOutputIndex()
    {
        var stream = CreateStream();
        var itemId = IdGenerator.NewFunctionCallItemId();
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 3, itemId);

        Assert.That(builder.OutputIndex, Is.EqualTo(3));
        Assert.That(builder.ItemId, Is.EqualTo(itemId));
    }

    // ──────────────────────────────────────────────
    // EmitAdded
    // ──────────────────────────────────────────────

    [Test]
    public void EmitAdded_ReturnsResponseOutputItemAddedEvent()
    {
        var stream = CreateStream();
        var item = new OutputItemFunctionToolCall("call_1", "myFunc", "{}");
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 0, "fc_test");

        var ev = builder.EmitAdded(item);

        XAssert.IsType<ResponseOutputItemAddedEvent>(ev);
    }

    [Test]
    public void EmitAdded_SetsOutputIndex()
    {
        var stream = CreateStream();
        var item = new OutputItemFunctionToolCall("call_1", "myFunc", "{}");
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 5, "fc_test");

        var ev = builder.EmitAdded(item);

        Assert.That(ev.OutputIndex, Is.EqualTo(5));
    }

    [Test]
    public void EmitAdded_WrapsTheCorrectItem()
    {
        var stream = CreateStream();
        var item = new OutputItemFunctionToolCall("call_1", "myFunc", "{}");
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 0, "fc_test");

        var ev = builder.EmitAdded(item);

        Assert.That(ev.Item, Is.SameAs(item));
    }

    [Test]
    public void EmitAdded_AssignsSequenceNumber()
    {
        var stream = CreateStream();
        var item = new OutputItemFunctionToolCall("call_1", "myFunc", "{}");
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 0, "fc_test");

        var ev = builder.EmitAdded(item);

        Assert.That(ev.SequenceNumber, Is.EqualTo(0));
    }

    // ──────────────────────────────────────────────
    // EmitDone
    // ──────────────────────────────────────────────

    [Test]
    public void EmitDone_ReturnsResponseOutputItemDoneEvent()
    {
        var stream = CreateStream();
        var item = new OutputItemFunctionToolCall("call_1", "myFunc", "{}");
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 0, "fc_test");

        builder.EmitAdded(item);
        var ev = builder.EmitDone(item);

        XAssert.IsType<ResponseOutputItemDoneEvent>(ev);
    }

    [Test]
    public void EmitDone_SetsOutputIndex()
    {
        var stream = CreateStream();
        var item = new OutputItemFunctionToolCall("call_1", "myFunc", "{}");
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 7, "fc_test");

        builder.EmitAdded(item);
        var ev = builder.EmitDone(item);

        Assert.That(ev.OutputIndex, Is.EqualTo(7));
    }

    [Test]
    public void EmitDone_WrapsTheSameItem()
    {
        var stream = CreateStream();
        var item = new OutputItemFunctionToolCall("call_1", "myFunc", "{}");
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 0, "fc_test");

        builder.EmitAdded(item);
        var ev = builder.EmitDone(item);

        Assert.That(ev.Item, Is.SameAs(item));
    }

    // ──────────────────────────────────────────────
    // EmitAdded and EmitDone receive separate items
    // ──────────────────────────────────────────────

    [Test]
    public void EmitAdded_And_EmitDone_CanReceiveDifferentItems()
    {
        var stream = CreateStream();
        var addedItem = new OutputItemFunctionToolCall("call_1", "myFunc", "");
        var doneItem = new OutputItemFunctionToolCall("call_1", "myFunc", "{\"result\":1}");
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 0, "fc_test");

        var added = builder.EmitAdded(addedItem);
        var done = builder.EmitDone(doneItem);

        Assert.That(added.Item, Is.SameAs(addedItem));
        Assert.That(done.Item, Is.SameAs(doneItem));
        Assert.That(doneItem, Is.Not.SameAs(addedItem));
    }

    // ──────────────────────────────────────────────
    // Sequence number management
    // ──────────────────────────────────────────────

    [Test]
    public void EmitAdded_ThenEmitDone_SequenceNumbersIncrement()
    {
        var stream = CreateStream();
        var addedItem = new OutputItemFunctionToolCall("call_1", "myFunc", "{}");
        var doneItem = new OutputItemFunctionToolCall("call_1", "myFunc", "{}");
        var builder = new OutputItemBuilder<OutputItemFunctionToolCall>(stream, 0, "fc_test");

        var added = builder.EmitAdded(addedItem);
        var done = builder.EmitDone(doneItem);

        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(done.SequenceNumber, Is.EqualTo(1));
    }

    // ──────────────────────────────────────────────
    // Works with MCP approval response (Azure-only type)
    // ──────────────────────────────────────────────

    [Test]
    public void EmitAdded_WorksWithMcpApprovalResponse()
    {
        var stream = CreateStream();
        var item = new OutputItemMcpApprovalResponseResource("apr_1", "req_1", true);
        var builder = new OutputItemBuilder<OutputItemMcpApprovalResponseResource>(stream, 2, "apr_test");

        var ev = builder.EmitAdded(item);

        XAssert.IsType<ResponseOutputItemAddedEvent>(ev);
        Assert.That(ev.Item, Is.SameAs(item));
        Assert.That(ev.OutputIndex, Is.EqualTo(2));
    }

    [Test]
    public void EmitDone_WorksWithMcpApprovalResponse()
    {
        var stream = CreateStream();
        var item = new OutputItemMcpApprovalResponseResource("apr_1", "req_1", false);
        var builder = new OutputItemBuilder<OutputItemMcpApprovalResponseResource>(stream, 0, "apr_test");

        builder.EmitAdded(item);
        var ev = builder.EmitDone(item);

        XAssert.IsType<ResponseOutputItemDoneEvent>(ev);
        Assert.That(ev.Item, Is.SameAs(item));
    }

    // ──────────────────────────────────────────────
    // Factory: ResponseEventStream.AddOutputItem
    // ──────────────────────────────────────────────

    [Test]
    public void AddOutputItem_ReturnsBuilderWithCorrectOutputIndex()
    {
        var stream = CreateStream();
        var itemId = IdGenerator.NewFunctionCallItemId();

        var builder = stream.AddOutputItem<OutputItemFunctionToolCall>(itemId);

        Assert.That(builder.OutputIndex, Is.EqualTo(0));
    }

    [Test]
    public void AddOutputItem_IncrementsOutputIndex()
    {
        var stream = CreateStream();
        var id1 = IdGenerator.NewFunctionCallItemId();
        var id2 = IdGenerator.NewFunctionCallItemId();

        var b1 = stream.AddOutputItem<OutputItemFunctionToolCall>(id1);
        var b2 = stream.AddOutputItem<OutputItemFunctionToolCall>(id2);

        Assert.That(b1.OutputIndex, Is.EqualTo(0));
        Assert.That(b2.OutputIndex, Is.EqualTo(1));
    }

    [Test]
    public void AddOutputItem_SetsItemId()
    {
        var stream = CreateStream();
        var itemId = IdGenerator.NewFunctionCallItemId();

        var builder = stream.AddOutputItem<OutputItemFunctionToolCall>(itemId);

        Assert.That(builder.ItemId, Is.EqualTo(itemId));
    }

    // ──────────────────────────────────────────────
    // T035: AddOutputItem validation
    // ──────────────────────────────────────────────

    [Test]
    public void AddOutputItem_AcceptsNewFormatId()
    {
        var stream = CreateStream();
        var itemId = IdGenerator.NewFunctionCallItemId();

        var builder = stream.AddOutputItem<OutputItemFunctionToolCall>(itemId);

        Assert.That(builder.ItemId, Is.EqualTo(itemId));
    }

    [Test]
    public void AddOutputItem_AcceptsLegacyFormatId()
    {
        var stream = CreateStream();
        var itemId = "fc_" + new string('a', 32) + "ff00112233445566"; // 48-char body

        var builder = stream.AddOutputItem<OutputItemFunctionToolCall>(itemId);

        Assert.That(builder.ItemId, Is.EqualTo(itemId));
    }

    [Test]
    public void AddOutputItem_RejectsNullId()
    {
        var stream = CreateStream();

        Assert.Throws<ArgumentNullException>(() => stream.AddOutputItem<OutputItemFunctionToolCall>(null!));
    }

    [Test]
    public void AddOutputItem_RejectsGuid()
    {
        var stream = CreateStream();

        Assert.Throws<ArgumentException>(() =>
            stream.AddOutputItem<OutputItemFunctionToolCall>("550e8400-e29b-41d4-a716-446655440000"));
    }

    [Test]
    public void AddOutputItem_RejectsBareNumber()
    {
        var stream = CreateStream();

        Assert.Throws<ArgumentException>(() =>
            stream.AddOutputItem<OutputItemFunctionToolCall>("12345"));
    }

    [Test]
    public void AddOutputItem_RejectsWrongBodyLength()
    {
        var stream = CreateStream();

        Assert.Throws<ArgumentException>(() =>
            stream.AddOutputItem<OutputItemFunctionToolCall>("msg_tooshort"));
    }

    // ──────────────────────────────────────────────
    // Mocking support (protected parameterless ctor)
    // ──────────────────────────────────────────────

    private class TestableOutputItemBuilder : OutputItemBuilder<OutputItemFunctionToolCall>
    {
        public TestableOutputItemBuilder() : base() { }
    }

    [Test]
    public void ProtectedConstructor_AllowsSubclassing()
    {
        var builder = new TestableOutputItemBuilder();
        Assert.That(builder, Is.Not.Null);
    }
}
