// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class OutputItemMcpListToolsBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    [Test]
    public void AddMcpListTools_ReturnsOutputItemMcpListToolsBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("my-server");
        Assert.That(builder, Is.Not.Null);
        XAssert.IsType<OutputItemMcpListToolsBuilder>(builder);
    }

    [Test]
    public void AddMcpListTools_GeneratesItemIdWithMcplPrefix()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("my-server");
        XAssert.StartsWith("mcpl_", builder.ItemId);
    }

    [Test]
    public void AddMcpListTools_StoresServerLabel()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("my-server");
        Assert.That(builder.ServerLabel, Is.EqualTo("my-server"));
    }

    [Test]
    public void EmitAdded_ContainsMcpListToolsItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("my-server");
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemMcpListTools>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.ServerLabel, Is.EqualTo("my-server"));
        Assert.That(item.Tools, Is.Empty);
    }

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("srv");
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseMCPListToolsInProgressEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("srv");
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseMCPListToolsCompletedEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
    }

    [Test]
    public void EmitFailed_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("srv");
        var evt = builder.EmitFailed();
        XAssert.IsType<ResponseMCPListToolsFailedEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
    }

    [Test]
    public void EmitDone_ContainsMcpListToolsItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("my-server");
        builder.EmitAdded();
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemMcpListTools>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.ServerLabel, Is.EqualTo("my-server"));
    }

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("srv");
        var added = builder.EmitAdded();         // 0
        var inProg = builder.EmitInProgress();   // 1
        var completed = builder.EmitCompleted(); // 2
        var done = builder.EmitDone();           // 3
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(inProg.SequenceNumber, Is.EqualTo(1));
        Assert.That(completed.SequenceNumber, Is.EqualTo(2));
        Assert.That(done.SequenceNumber, Is.EqualTo(3));
    }
}
