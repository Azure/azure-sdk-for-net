// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class OutputItemImageGenCallBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    [Test]
    public void AddImageGenCall_ReturnsOutputItemImageGenCallBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        Assert.IsNotNull(builder);
        XAssert.IsType<OutputItemImageGenCallBuilder>(builder);
    }

    [Test]
    public void AddImageGenCall_GeneratesItemIdWithIgPrefix()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        XAssert.StartsWith("ig_", builder.ItemId);
    }

    [Test]
    public void EmitAdded_ContainsInProgressImageGenItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitAdded();
        var item = XAssert.IsType<OutputItemImageGenToolCall>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(OutputItemImageGenToolCallStatus.InProgress, item.Status);
    }

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseImageGenCallInProgressEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitGenerating_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitGenerating();
        XAssert.IsType<ResponseImageGenCallGeneratingEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitPartialImage_ReturnsPartialImageEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitPartialImage("base64data");
        XAssert.IsType<ResponseImageGenCallPartialImageEvent>(evt);
        Assert.AreEqual("base64data", evt.PartialImageB64);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
        Assert.AreEqual(builder.OutputIndex, evt.OutputIndex);
    }

    [Test]
    public void EmitPartialImage_FirstIndexIsZero()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitPartialImage("data1");
        Assert.AreEqual(0, evt.PartialImageIndex);
    }

    [Test]
    public void EmitPartialImage_IncrementsPartialImageIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var p0 = builder.EmitPartialImage("data0");
        var p1 = builder.EmitPartialImage("data1");
        var p2 = builder.EmitPartialImage("data2");
        Assert.AreEqual(0, p0.PartialImageIndex);
        Assert.AreEqual(1, p1.PartialImageIndex);
        Assert.AreEqual(2, p2.PartialImageIndex);
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseImageGenCallCompletedEvent>(evt);
        Assert.AreEqual(builder.ItemId, evt.ItemId);
    }

    [Test]
    public void EmitDone_ContainsCompletedImageGenItem()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        builder.EmitAdded();
        var evt = builder.EmitDone();
        var item = XAssert.IsType<OutputItemImageGenToolCall>(evt.Item);
        Assert.AreEqual(builder.ItemId, item.Id);
        Assert.AreEqual(OutputItemImageGenToolCallStatus.Completed, item.Status);
    }

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var added = builder.EmitAdded();              // 0
        var inProg = builder.EmitInProgress();        // 1
        var generating = builder.EmitGenerating();    // 2
        var partial = builder.EmitPartialImage("d");  // 3
        var completed = builder.EmitCompleted();      // 4
        var done = builder.EmitDone();                // 5
        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, inProg.SequenceNumber);
        Assert.AreEqual(2, generating.SequenceNumber);
        Assert.AreEqual(3, partial.SequenceNumber);
        Assert.AreEqual(4, completed.SequenceNumber);
        Assert.AreEqual(5, done.SequenceNumber);
    }
}
