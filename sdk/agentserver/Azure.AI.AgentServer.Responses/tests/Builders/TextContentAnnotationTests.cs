// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class TextContentAnnotationTests
{
    private static (ResponseEventStream Stream, OutputItemMessageBuilder Msg) CreateMessageScope()
    {
        var context = new ResponseContext("resp_test");
        var stream = new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
        var msg = stream.AddOutputItemMessage();
        return (stream, msg);
    }

    private static Annotation CreateTestAnnotation()
        => new UrlCitationBody(new Uri("https://example.com"), 0, 10, "Example");

    [Test]
    public void EmitAnnotationAdded_ReturnsAnnotationAddedEvent()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("test");
        var annotation = CreateTestAnnotation();
        var evt = text.EmitAnnotationAdded(annotation);
        XAssert.IsType<ResponseOutputTextAnnotationAddedEvent>(evt);
    }

    [Test]
    public void EmitAnnotationAdded_ContainsCorrectAnnotation()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("test");
        var annotation = CreateTestAnnotation();
        var evt = text.EmitAnnotationAdded(annotation);
        Assert.That(evt.Annotation, Is.SameAs(annotation));
    }

    [Test]
    public void EmitAnnotationAdded_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("test");
        var annotation = CreateTestAnnotation();
        var evt = text.EmitAnnotationAdded(annotation);
        Assert.That(evt.ItemId, Is.EqualTo(msg.ItemId));
        Assert.That(evt.OutputIndex, Is.EqualTo(msg.OutputIndex));
        Assert.That(evt.ContentIndex, Is.EqualTo(text.ContentIndex));
    }

    [Test]
    public void EmitAnnotationAdded_FirstAnnotationIndexIsZero()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("test");
        var annotation = CreateTestAnnotation();
        var evt = text.EmitAnnotationAdded(annotation);
        Assert.That(evt.AnnotationIndex, Is.EqualTo(0));
    }

    [Test]
    public void EmitAnnotationAdded_IncrementsAnnotationIndex()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        text.EmitAdded();
        text.EmitTextDone("test");
        var a1 = text.EmitAnnotationAdded(CreateTestAnnotation());
        var a2 = text.EmitAnnotationAdded(CreateTestAnnotation());
        var a3 = text.EmitAnnotationAdded(CreateTestAnnotation());
        Assert.That(a1.AnnotationIndex, Is.EqualTo(0));
        Assert.That(a2.AnnotationIndex, Is.EqualTo(1));
        Assert.That(a3.AnnotationIndex, Is.EqualTo(2));
    }

    [Test]
    public void EmitAnnotationAdded_SharesSequenceCounterWithOtherMethods()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        var added = text.EmitAdded();                                // seq 0
        var delta = text.EmitDelta("Hi");                            // seq 1
        var done = text.EmitTextDone("Hi");                          // seq 2
        var ann = text.EmitAnnotationAdded(CreateTestAnnotation());  // seq 3
        Assert.That(added.SequenceNumber, Is.EqualTo(0));
        Assert.That(delta.SequenceNumber, Is.EqualTo(1));
        Assert.That(done.SequenceNumber, Is.EqualTo(2));
        Assert.That(ann.SequenceNumber, Is.EqualTo(3));
    }

    [Test]
    public void EmitAnnotationAdded_AnnotationIndexIsPerContentPart()
    {
        var (_, msg) = CreateMessageScope();
        var text1 = msg.AddTextContent();
        text1.EmitAdded();
        text1.EmitTextDone("test1");
        var text2 = msg.AddTextContent();
        text2.EmitAdded();
        text2.EmitTextDone("test2");
        var a1 = text1.EmitAnnotationAdded(CreateTestAnnotation());
        var a2 = text2.EmitAnnotationAdded(CreateTestAnnotation());
        Assert.That(a1.AnnotationIndex, Is.EqualTo(0));
        Assert.That(a2.AnnotationIndex, Is.EqualTo(0));
    }
}
