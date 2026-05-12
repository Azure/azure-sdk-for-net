// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class TextContentBuilderTests
{
    private static (ResponseEventStream Stream, OutputItemMessageBuilder Msg) CreateMessageScope()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
        var msg = stream.AddOutputItemMessage();
        return (stream, msg);
    }

    // ── T006: AddTextContent ──────────────────────────────────

    [Test]
    public void AddTextContent_ReturnsTextContentBuilder()
    {
        var (_, msg) = CreateMessageScope();

        var text = msg.AddTextContent();

        Assert.That(text, Is.Not.Null);
        XAssert.IsType<TextContentBuilder>(text);
    }

    [Test]
    public void AddTextContent_AssignsContentIndexStartingAtZero()
    {
        var (_, msg) = CreateMessageScope();

        var text = msg.AddTextContent();

        Assert.That(text.ContentIndex, Is.EqualTo(0));
    }

    [Test]
    public void AddTextContent_IncrementsContentIndex()
    {
        var (_, msg) = CreateMessageScope();

        var text0 = msg.AddTextContent();
        var text1 = msg.AddTextContent();

        Assert.That(text0.ContentIndex, Is.EqualTo(0));
        Assert.That(text1.ContentIndex, Is.EqualTo(1));
    }

    // ── T007: EmitAdded ───────────────────────────────────────

    [Test]
    public void EmitAdded_ReturnsContentPartAddedEvent()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        var evt = text.EmitAdded();

        XAssert.IsType<ResponseContentPartAddedEvent>(evt);
    }

    [Test]
    public void EmitAdded_ContainsEmptyTextContent()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        var evt = text.EmitAdded();

        var part = XAssert.IsType<OutputContentOutputTextContent>(evt.Part);
        Assert.That(part.Text, Is.EqualTo(""));
        Assert.That(part.Annotations, Is.Empty);
    }

    [Test]
    public void EmitAdded_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        var evt = text.EmitAdded();

        Assert.That(evt.ItemId, Is.EqualTo(msg.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
        Assert.That(evt.ContentIndex, Is.EqualTo(text.ContentIndex));
    }

    // ── T008: EmitDelta + EmitDone ────────────────────────────

    [Test]
    public void EmitDelta_ReturnsTextDeltaEvent()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        text.EmitAdded();

        var evt = text.EmitDelta("Hello, ");

        XAssert.IsType<ResponseTextDeltaEvent>(evt);
        Assert.That(evt.Delta, Is.EqualTo("Hello, "));
    }

    [Test]
    public void EmitDelta_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        text.EmitAdded();

        var evt = text.EmitDelta("chunk");

        Assert.That(evt.ItemId, Is.EqualTo(msg.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
        Assert.That(evt.ContentIndex, Is.EqualTo(text.ContentIndex));
    }

    [Test]
    public void EmitDelta_CanBeCalledMultipleTimes()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        text.EmitAdded();

        var d1 = text.EmitDelta("Hello, ");
        var d2 = text.EmitDelta("world!");

        Assert.That(d1.Delta, Is.EqualTo("Hello, "));
        Assert.That(d2.Delta, Is.EqualTo("world!"));
    }

    [Test]
    public void EmitDone_ReturnsTextDoneEvent()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        text.EmitAdded();
        var evt = text.EmitTextDone("Hello, world!");

        XAssert.IsType<ResponseTextDoneEvent>(evt);
        Assert.That(evt.Text, Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void EmitDone_StoresFinalText()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        Assert.That(text.FinalText, Is.Null);

        text.EmitAdded();
        text.EmitTextDone("Final value");

        Assert.That(text.FinalText, Is.EqualTo("Final value"));
    }

    [Test]
    public void EmitDone_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        text.EmitAdded();
        var evt = text.EmitTextDone("done text");

        Assert.That(evt.ItemId, Is.EqualTo(msg.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
        Assert.That(evt.ContentIndex, Is.EqualTo(text.ContentIndex));
    }

    [Test]
    public void AllEmitMethods_ShareSequenceCounter()
    {
        var (stream, msg) = CreateMessageScope();

        // stream.AddOutputItemMessage() doesn't consume seq, but let's track from here
        var text = msg.AddTextContent();

        var added = text.EmitAdded();       // seq 0
        var delta = text.EmitDelta("Hi");   // seq 1
        var done = text.EmitTextDone("Hi");     // seq 2

        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(delta.SequenceNumber, Is.EqualTo(1));
        Assert.That(done.SequenceNumber, Is.EqualTo(2));
    }
}
