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
        Assert.IsNotNull(builder);
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
        Assert.AreEqual("my-server", builder.ServerLabel);
    }

    [Test]
    public void EmitAdded_ContainsMcpListToolsItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("my-server");
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemMcpListTools>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual("my-server", item.ServerLabel);
        Assert.IsEmpty(item.Tools);
    }

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("srv");
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseMCPListToolsInProgressEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("srv");
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseMCPListToolsCompletedEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
    }

    [Test]
    public void EmitFailed_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("srv");
        var evt = builder.EmitFailed();
        XAssert.IsType<ResponseMCPListToolsFailedEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
    }

    [Test]
    public void EmitDone_ContainsMcpListToolsItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemMcpListTools("my-server");
        builder.EmitAdded();
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemMcpListTools>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual("my-server", item.ServerLabel);
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
        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, inProg.SequenceNumber);
        Assert.AreEqual(2, completed.SequenceNumber);
        Assert.AreEqual(3, done.SequenceNumber);
    }
}
