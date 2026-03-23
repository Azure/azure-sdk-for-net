// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class TextContentAnnotationTests
{
    private static (ResponseEventStream stream, OutputItemMessageBuilder msg) CreateMessageScope()
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
        var annotation = CreateTestAnnotation();
        var evt = text.EmitAnnotationAdded(annotation);
        XAssert.IsType<ResponseOutputTextAnnotationAddedEvent>(evt);
    }

    [Test]
    public void EmitAnnotationAdded_ContainsCorrectAnnotation()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        var annotation = CreateTestAnnotation();
        var evt = text.EmitAnnotationAdded(annotation);
        Assert.AreSame(annotation, evt.Annotation);
    }

    [Test]
    public void EmitAnnotationAdded_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        var annotation = CreateTestAnnotation();
        var evt = text.EmitAnnotationAdded(annotation);
        Assert.AreEqual(msg.ItemId, evt.ItemId);
        Assert.AreEqual(msg.OutputIndex, evt.OutputIndex);
        Assert.AreEqual(text.ContentIndex, evt.ContentIndex);
    }

    [Test]
    public void EmitAnnotationAdded_FirstAnnotationIndexIsZero()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        var annotation = CreateTestAnnotation();
        var evt = text.EmitAnnotationAdded(annotation);
        Assert.AreEqual(0, evt.AnnotationIndex);
    }

    [Test]
    public void EmitAnnotationAdded_IncrementsAnnotationIndex()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        var a1 = text.EmitAnnotationAdded(CreateTestAnnotation());
        var a2 = text.EmitAnnotationAdded(CreateTestAnnotation());
        var a3 = text.EmitAnnotationAdded(CreateTestAnnotation());
        Assert.AreEqual(0, a1.AnnotationIndex);
        Assert.AreEqual(1, a2.AnnotationIndex);
        Assert.AreEqual(2, a3.AnnotationIndex);
    }

    [Test]
    public void EmitAnnotationAdded_SharesSequenceCounterWithOtherMethods()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();
        var added = text.EmitAdded();                                // seq 0
        var delta = text.EmitDelta("Hi");                            // seq 1
        var ann = text.EmitAnnotationAdded(CreateTestAnnotation());  // seq 2
        var done = text.EmitDone("Hi");                              // seq 3
        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, delta.SequenceNumber);
        Assert.AreEqual(2, ann.SequenceNumber);
        Assert.AreEqual(3, done.SequenceNumber);
    }

    [Test]
    public void EmitAnnotationAdded_AnnotationIndexIsPerContentPart()
    {
        var (_, msg) = CreateMessageScope();
        var text1 = msg.AddTextContent();
        var text2 = msg.AddTextContent();
        var a1 = text1.EmitAnnotationAdded(CreateTestAnnotation());
        var a2 = text2.EmitAnnotationAdded(CreateTestAnnotation());
        Assert.AreEqual(0, a1.AnnotationIndex);
        Assert.AreEqual(0, a2.AnnotationIndex);
    }
}
