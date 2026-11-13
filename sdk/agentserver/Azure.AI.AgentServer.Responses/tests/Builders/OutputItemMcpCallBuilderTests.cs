// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class OutputItemMcpCallBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    [Test]
    public void AddMcpCall_ReturnsOutputItemMcpCallBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("my-server", "tool_name");
        Assert.That(builder, Is.Not.Null);
        XAssert.IsType<OutputItemMcpCallBuilder>(builder);
    }

    [Test]
    public void AddMcpCall_GeneratesItemIdWithMcpPrefix()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("my-server", "tool_name");
        XAssert.StartsWith("mcp_", builder.ItemId);
    }

    [Test]
    public void AddMcpCall_StoresServerLabelAndName()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("my-server", "tool_name");
        Assert.That(builder.ServerLabel, Is.EqualTo("my-server"));
        Assert.That(builder.Name, Is.EqualTo("tool_name"));
    }

    [Test]
    public void EmitAdded_ContainsInProgressMcpToolCallItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("my-server", "tool_name");
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemMcpToolCall>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(MCPToolCallStatus.InProgress));
        Assert.That(item.ServerLabel, Is.EqualTo("my-server"));
        Assert.That(item.Name, Is.EqualTo("tool_name"));
    }

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseMCPCallInProgressEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitArgumentsDelta_ReturnsDeltaEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitArgumentsDelta("{\"key");
        XAssert.IsType<ResponseMCPCallArgumentsDeltaEvent>(evt);
        Assert.That(evt.Delta, Is.EqualTo("{\"key"));
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitArgumentsDone_ReturnsDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitArgumentsDone("{\"key\":\"value\"}");
        XAssert.IsType<ResponseMCPCallArgumentsDoneEvent>(evt);
        Assert.That(evt.Arguments, Is.EqualTo("{\"key\":\"value\"}"));
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseMCPCallCompletedEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
    }

    [Test]
    public void EmitFailed_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitFailed();
        XAssert.IsType<ResponseMCPCallFailedEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
    }

    [Test]
    public void EmitDone_ContainsCompletedMcpToolCallItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("my-server", "tool_name");
        builder.EmitAdded();
        builder.EmitArgumentsDone("{\"key\":\"value\"}");
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemMcpToolCall>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(MCPToolCallStatus.Completed));
        Assert.That(item.Arguments, Is.EqualTo("{\"key\":\"value\"}"));
    }

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var added = builder.EmitAdded();                     // 0
        var inProg = builder.EmitInProgress();               // 1
        var argDelta = builder.EmitArgumentsDelta("{");       // 2
        var argDone = builder.EmitArgumentsDone("{}");       // 3
        var completed = builder.EmitCompleted();             // 4
        var done = builder.EmitDone();                       // 5
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(inProg.SequenceNumber, Is.EqualTo(1));
        Assert.That(argDelta.SequenceNumber, Is.EqualTo(2));
        Assert.That(argDone.SequenceNumber, Is.EqualTo(3));
        Assert.That(completed.SequenceNumber, Is.EqualTo(4));
        Assert.That(done.SequenceNumber, Is.EqualTo(5));
    }
}
