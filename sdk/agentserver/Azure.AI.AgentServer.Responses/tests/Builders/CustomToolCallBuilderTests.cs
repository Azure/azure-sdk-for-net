// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class CustomToolCallBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    [Test]
    public void AddCustomToolCall_ReturnsCustomToolCallBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("call_001", "my_tool");
        Assert.That(builder, Is.Not.Null);
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
        Assert.That(builder.CallId, Is.EqualTo("call_001"));
        Assert.That(builder.Name, Is.EqualTo("my_tool"));
    }

    [Test]
    public void EmitAdded_ContainsCustomToolCallItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("call_001", "my_tool");
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemCustomToolCall>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.CallId, Is.EqualTo("call_001"));
        Assert.That(item.Name, Is.EqualTo("my_tool"));
        Assert.That(item.Input, Is.EqualTo(""));
    }

    [Test]
    public void EmitInputDelta_ReturnsDeltaEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("c1", "t1");
        var evt = builder.EmitInputDelta("{\"key");
        XAssert.IsType<ResponseCustomToolCallInputDeltaEvent>(evt);
        Assert.That(evt.Delta, Is.EqualTo("{\"key"));
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitInputDelta_CanBeCalledMultipleTimes()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("c1", "t1");
        var d1 = builder.EmitInputDelta("{\"key");
        var d2 = builder.EmitInputDelta("\":\"value\"}");
        Assert.That(d1.Delta, Is.EqualTo("{\"key"));
        Assert.That(d2.Delta, Is.EqualTo("\":\"value\"}"));
    }

    [Test]
    public void EmitInputDone_ReturnsDoneEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemCustomToolCall("c1", "t1");
        var evt = builder.EmitInputDone("{\"key\":\"value\"}");
        XAssert.IsType<ResponseCustomToolCallInputDoneEvent>(evt);
        Assert.That(evt.Input, Is.EqualTo("{\"key\":\"value\"}"));
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
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
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.CallId, Is.EqualTo("call_001"));
        Assert.That(item.Name, Is.EqualTo("my_tool"));
        Assert.That(item.Input, Is.EqualTo("{\"key\":\"value\"}"));
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
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(delta.SequenceNumber, Is.EqualTo(1));
        Assert.That(inputDone.SequenceNumber, Is.EqualTo(2));
        Assert.That(done.SequenceNumber, Is.EqualTo(3));
    }
}
