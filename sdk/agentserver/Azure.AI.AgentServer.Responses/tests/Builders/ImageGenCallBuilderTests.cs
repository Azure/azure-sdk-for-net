// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class ImageGenCallBuilderTests
{
    private static ResponseEventStream CreateStream()
    {
        var context = new ResponseContext("resp_test");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }

    [Test]
    public void AddImageGenCall_ReturnsImageGenCallBuilder()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        Assert.That(builder, Is.Not.Null);
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
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(ImageGenerationCallStatus.InProgress));
    }

    [Test]
    public void EmitInProgress_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitInProgress();
        XAssert.IsType<ResponseImageGenCallInProgressEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitGenerating_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitGenerating();
        XAssert.IsType<ResponseImageGenCallGeneratingEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitPartialImage_ReturnsPartialImageEvent()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitPartialImage("YmFzZTY0ZGF0YQ==");
        XAssert.IsType<ResponseImageGenCallPartialImageEvent>(evt);
        Assert.That(Convert.ToBase64String(evt.PartialImageBytes.ToArray()), Is.EqualTo("YmFzZTY0ZGF0YQ=="));
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(builder.OutputIndex));
    }

    [Test]
    public void EmitPartialImage_FirstIndexIsZero()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitPartialImage("ZGF0YTE=");
        Assert.That(evt.PartialImageIndex, Is.EqualTo(0));
    }

    [Test]
    public void EmitPartialImage_IncrementsPartialImageIndex()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var p0 = builder.EmitPartialImage("ZGF0YTA=");
        var p1 = builder.EmitPartialImage("ZGF0YTE=");
        var p2 = builder.EmitPartialImage("ZGF0YTI=");
        Assert.That(p0.PartialImageIndex, Is.EqualTo(0));
        Assert.That(p1.PartialImageIndex, Is.EqualTo(1));
        Assert.That(p2.PartialImageIndex, Is.EqualTo(2));
    }

    [Test]
    public void EmitCompleted_ReturnsCorrectEventType()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var evt = builder.EmitCompleted();
        XAssert.IsType<ResponseImageGenCallCompletedEvent>(evt);
        Assert.That(evt.ItemId, Is.EqualTo(builder.ItemId));
    }

    [Test]
    public void EmitDone_ContainsCompletedImageGenItemWithResult()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        builder.EmitAdded();
        builder.EmitCompleted();
        var evt = builder.EmitDone("dGVzdC1pbWFnZS1kYXRh");
        var item = XAssert.IsType<OutputItemImageGenToolCall>(evt.Item);
        Assert.That(item.Id, Is.EqualTo(builder.ItemId));
        Assert.That(item.Status, Is.EqualTo(ImageGenerationCallStatus.Completed));
        Assert.That(Convert.ToBase64String(item.ImageResultBytes.ToArray()), Is.EqualTo("dGVzdC1pbWFnZS1kYXRh"));
    }

    [Test]
    public void AllMethods_ShareMonotonicSequenceNumbers()
    {
        var stream = CreateStream();
        var builder = stream.AddOutputItemImageGenCall();
        var added = builder.EmitAdded();              // 0
        var inProg = builder.EmitInProgress();        // 1
        var generating = builder.EmitGenerating();    // 2
        var partial = builder.EmitPartialImage("ZA==");  // 3
        var completed = builder.EmitCompleted();      // 4
        var done = builder.EmitDone("cg==");             // 5
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(inProg.SequenceNumber, Is.EqualTo(1));
        Assert.That(generating.SequenceNumber, Is.EqualTo(2));
        Assert.That(partial.SequenceNumber, Is.EqualTo(3));
        Assert.That(completed.SequenceNumber, Is.EqualTo(4));
        Assert.That(done.SequenceNumber, Is.EqualTo(5));
    }
}
