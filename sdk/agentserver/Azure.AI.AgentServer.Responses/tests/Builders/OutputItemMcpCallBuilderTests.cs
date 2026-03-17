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
        Assert.IsNotNull(builder);
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
        Assert.AreEqual("my-server", builder.ServerLabel);
        Assert.AreEqual("tool_name", builder.Name);
    }

    [Test]
    public void EmitAdded_ContainsInProgressMcpToolCallItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("my-server", "tool_name");
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemMcpToolCall>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(MCPToolCallStatus.InProgress, item.Status);
        Assert.AreEqual("my-server", item.ServerLabel);
        Assert.AreEqual("tool_name", item.Name);
    }

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseMCPCallInProgressEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitArgumentsDelta_ReturnsDeltaEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitArgumentsDelta("{\"key");
        XAssert.IsType<ResponseMCPCallArgumentsDeltaEvent>(evt);
        Assert.AreEqual("{\"key", evt.Delta);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitArgumentsDone_ReturnsDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitArgumentsDone("{\"key\":\"value\"}");
        XAssert.IsType<ResponseMCPCallArgumentsDoneEvent>(evt);
        Assert.AreEqual("{\"key\":\"value\"}", evt.Arguments);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseMCPCallCompletedEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
    }

    [Test]
    public void EmitFailed_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpCall("srv", "fn");
        var evt = builder.EmitFailed();
        XAssert.IsType<ResponseMCPCallFailedEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
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
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(MCPToolCallStatus.Completed, item.Status);
        Assert.AreEqual("{\"key\":\"value\"}", item.Arguments);
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
        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, inProg.SequenceNumber);
        Assert.AreEqual(2, argDelta.SequenceNumber);
        Assert.AreEqual(3, argDone.SequenceNumber);
        Assert.AreEqual(4, completed.SequenceNumber);
        Assert.AreEqual(5, done.SequenceNumber);
    }
}
