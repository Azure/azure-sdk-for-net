using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class OutputItemCustomToolCallBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    [Test]
    public void AddCustomToolCall_ReturnsOutputItemCustomToolCallBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("call_001", "my_tool");
        Assert.IsNotNull(builder);
        XAssert.IsType<OutputItemCustomToolCallBuilder>(builder);
    }

    [Test]
    public void AddCustomToolCall_GeneratesItemIdWithCtcPrefix()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("call_001", "my_tool");
        XAssert.StartsWith("ctc_", builder.ItemId);
    }

    [Test]
    public void AddCustomToolCall_StoresCallIdAndName()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("call_001", "my_tool");
        Assert.AreEqual("call_001", builder.CallId);
        Assert.AreEqual("my_tool", builder.Name);
    }

    [Test]
    public void EmitAdded_ContainsCustomToolCallItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("call_001", "my_tool");
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemCustomToolCall>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual("call_001", item.CallId);
        Assert.AreEqual("my_tool", item.Name);
        Assert.AreEqual("", item.Input);
    }

    [Test]
    public void EmitInputDelta_ReturnsDeltaEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("c1", "t1");
        var evt = builder.EmitInputDelta("{\"key");
        XAssert.IsType<ResponseCustomToolCallInputDeltaEvent>(evt);
        Assert.AreEqual("{\"key", evt.Delta);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitInputDelta_CanBeCalledMultipleTimes()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("c1", "t1");
        var d1 = builder.EmitInputDelta("{\"key");
        var d2 = builder.EmitInputDelta("\":\"value\"}");
        Assert.AreEqual("{\"key", d1.Delta);
        Assert.AreEqual("\":\"value\"}", d2.Delta);
    }

    [Test]
    public void EmitInputDone_ReturnsDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("c1", "t1");
        var evt = builder.EmitInputDone("{\"key\":\"value\"}");
        XAssert.IsType<ResponseCustomToolCallInputDoneEvent>(evt);
        Assert.AreEqual("{\"key\":\"value\"}", evt.Input);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
    }

    [Test]
    public void EmitDone_ContainsCompletedCustomToolCallItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("call_001", "my_tool");
        builder.EmitAdded();
        builder.EmitInputDone("{\"key\":\"value\"}");
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemCustomToolCall>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual("call_001", item.CallId);
        Assert.AreEqual("my_tool", item.Name);
        Assert.AreEqual("{\"key\":\"value\"}", item.Input);
    }

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("c1", "t1");
        var added = builder.EmitAdded();                       // 0
        var delta = builder.EmitInputDelta("{");                // 1
        var inputDone = builder.EmitInputDone("{}");           // 2
        var done = builder.EmitDone();                         // 3
        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, delta.SequenceNumber);
        Assert.AreEqual(2, inputDone.SequenceNumber);
        Assert.AreEqual(3, done.SequenceNumber);
    }
}
