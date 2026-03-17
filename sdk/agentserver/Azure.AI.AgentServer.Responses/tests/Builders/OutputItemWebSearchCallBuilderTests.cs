using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class OutputItemWebSearchCallBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    // ── Factory ───────────────────────────────────────────────

    [Test]
    public void AddWebSearchCall_ReturnsOutputItemWebSearchCallBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        Assert.IsNotNull(builder);
        XAssert.IsType<OutputItemWebSearchCallBuilder>(builder);
    }

    [Test]
    public void AddWebSearchCall_AssignsOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        Assert.AreEqual(0, builder.OutputIndex);
    }

    [Test]
    public void AddWebSearchCall_GeneratesItemIdWithWsPrefix()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        XAssert.StartsWith("ws_", builder.ItemId);
    }

    [Test]
    public void AddWebSearchCall_SharesOutputIndexWithOtherFactories()
    {
        var stream = CreateStream();
        var msg = stream.AddOutputItemMessage();
        var ws = stream.AddOutputItemWebSearchCall();
        Assert.AreEqual(0, msg.OutputIndex);
        Assert.AreEqual(1, ws.OutputIndex);
    }

    // ── EmitAdded ─────────────────────────────────────────────

    [Test]
    public void EmitAdded_ReturnsOutputItemAddedEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        var evt = builder.EmitAdded();
        XAssert.IsType<ResponseOutputItemAddedEvent>(evt);
    }

    [Test]
    public void EmitAdded_ContainsInProgressWebSearchItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemWebSearchToolCall>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(OutputItemWebSearchToolCallStatus.InProgress, item.Status);
    }

    [Test]
    public void EmitAdded_HasCorrectOutputIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        var evt = builder.EmitAdded();
        Assert.AreEqual(0, evt.OutputIndex);
    }

    // ── Status events ─────────────────────────────────────────

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseWebSearchCallInProgressEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitSearching_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        var evt = builder.EmitSearching();
        XAssert.IsType<ResponseWebSearchCallSearchingEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseWebSearchCallCompletedEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    // ── EmitDone ──────────────────────────────────────────────

    [Test]
    public void EmitDone_ReturnsOutputItemDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        builder.EmitAdded();
        var evt = builder.EmitDone();
        XAssert.IsType<ResponseOutputItemDoneEvent>(evt);
    }

    [Test]
    public void EmitDone_ContainsCompletedWebSearchItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        builder.EmitAdded();
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemWebSearchToolCall>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(OutputItemWebSearchToolCallStatus.Completed, item.Status);
    }

    // ── Sequence numbers ──────────────────────────────────────

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemWebSearchCall();
        var added = builder.EmitAdded();         // 0
        var inProg = builder.EmitInProgress();   // 1
        var searching = builder.EmitSearching(); // 2
        var completed = builder.EmitCompleted(); // 3
        var done = builder.EmitDone();           // 4
        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, inProg.SequenceNumber);
        Assert.AreEqual(2, searching.SequenceNumber);
        Assert.AreEqual(3, completed.SequenceNumber);
        Assert.AreEqual(4, done.SequenceNumber);
    }
}
