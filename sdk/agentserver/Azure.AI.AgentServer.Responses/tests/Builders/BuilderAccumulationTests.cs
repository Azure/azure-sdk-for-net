// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

/// <summary>
/// Tests that builder EmitDone() calls TrackCompletedOutputItem, accumulating
/// items in the stream-owned Models.ResponseObject. Verifies that EmitCompleted() after
/// builder emission produces a terminal event with the full Output list.
/// </summary>
public class BuilderAccumulationTests
{
    private static (ResponseEventStream Stream, Models.ResponseObject Response) CreateStream()
    {
        var context = new ResponseContext("resp_acc");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
        return (stream, stream.Response);
    }

    [Test]
    public void OutputItemMessageBuilder_EmitDone_AccumulatesItemInResponse()
    {
        var (stream, response) = CreateStream();
        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("Hello");
        text.EmitDone();

        msg.EmitDone();

        XAssert.Single(response.Output);
        var output = XAssert.IsType<OutputItemMessage>(response.Output[0]);
        Assert.That(output.Id, Is.EqualTo(msg.ItemId));
    }

    [Test]
    public void OutputItemFunctionCallBuilder_EmitDone_AccumulatesItemInResponse()
    {
        var (stream, response) = CreateStream();
        var fc = stream.AddOutputItemFunctionCall("myFunc", "call_1");
        fc.EmitAdded();
        fc.EmitArgumentsDone("{\"a\":1}");

        fc.EmitDone();

        XAssert.Single(response.Output);
        var output = XAssert.IsType<OutputItemFunctionToolCall>(response.Output[0]);
        Assert.That(output.Id, Is.EqualTo(fc.ItemId));
    }

    [Test]
    public void MultipleBuilders_AccumulateItemsAtCorrectIndices()
    {
        var (stream, response) = CreateStream();

        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("Hi");
        text.EmitDone();
        msg.EmitDone();

        var fc = stream.AddOutputItemFunctionCall("fn", "c1");
        fc.EmitAdded();
        fc.EmitArgumentsDone("{}");
        fc.EmitDone();

        Assert.That(response.Output.Count, Is.EqualTo(2));
        XAssert.IsType<OutputItemMessage>(response.Output[0]);
        XAssert.IsType<OutputItemFunctionToolCall>(response.Output[1]);
    }

    [Test]
    public void EmitCompleted_AfterEmitDone_ProducesEventWithFullOutputList()
    {
        var (stream, response) = CreateStream();

        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("Result");
        text.EmitDone();
        msg.EmitDone();

        var completed = stream.EmitCompleted();

        XAssert.Single(completed.Response.Output);
        XAssert.IsType<OutputItemMessage>(completed.Response.Output[0]);
    }

    [Test]
    public void EmitCompleted_DoesNotSetOutputText()
    {
        var (stream, response) = CreateStream();

        var msg1 = stream.AddOutputItemMessage();
        msg1.EmitAdded();
        var t1 = msg1.AddTextContent();
        t1.EmitAdded();
        t1.EmitTextDone("Hello ");
        t1.EmitDone();
        msg1.EmitDone();

        var msg2 = stream.AddOutputItemMessage();
        msg2.EmitAdded();
        var t2 = msg2.AddTextContent();
        t2.EmitAdded();
        t2.EmitTextDone("World");
        t2.EmitDone();
        msg2.EmitDone();

        var completed = stream.EmitCompleted();

        // output_text is a client SDK convenience property; the server never sets it.
        Assert.That(completed.Response.OutputText, Is.Null);
    }

    [Test]
    public void EmitCompleted_OutputTextNotSetEvenWithNonMessageItems()
    {
        var (stream, response) = CreateStream();

        var fc = stream.AddOutputItemFunctionCall("fn", "c1");
        fc.EmitAdded();
        fc.EmitArgumentsDone("{}");
        fc.EmitDone();

        var msg = stream.AddOutputItemMessage();
        msg.EmitAdded();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("Only this");
        text.EmitDone();
        msg.EmitDone();

        var completed = stream.EmitCompleted();

        // output_text is a client SDK convenience property; the server never sets it.
        Assert.That(completed.Response.OutputText, Is.Null);
    }
}
