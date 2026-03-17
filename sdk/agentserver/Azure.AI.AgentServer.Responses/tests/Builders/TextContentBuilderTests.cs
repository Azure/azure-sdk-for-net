using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Builders;

public class TextContentBuilderTests
{
    private static (ResponseEventStream stream, OutputItemMessageBuilder msg) CreateMessageScope()
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

        Assert.IsNotNull(text);
        XAssert.IsType<TextContentBuilder>(text);
    }

    [Test]
    public void AddTextContent_AssignsContentIndexStartingAtZero()
    {
        var (_, msg) = CreateMessageScope();

        var text = msg.AddTextContent();

        Assert.AreEqual(0, text.ContentIndex);
    }

    [Test]
    public void AddTextContent_IncrementsContentIndex()
    {
        var (_, msg) = CreateMessageScope();

        var text0 = msg.AddTextContent();
        var text1 = msg.AddTextContent();

        Assert.AreEqual(0, text0.ContentIndex);
        Assert.AreEqual(1, text1.ContentIndex);
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
        Assert.AreEqual("", part.Text);
        Assert.IsEmpty(part.Annotations);
    }

    [Test]
    public void EmitAdded_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        var evt = text.EmitAdded();

        Assert.AreEqual(msg.ItemId, evt.ItemId);
        Assert.AreEqual(msg.OutputIndex, evt.OutputIndex);
        Assert.AreEqual(text.ContentIndex, evt.ContentIndex);
    }

    // ── T008: EmitDelta + EmitDone ────────────────────────────

    [Test]
    public void EmitDelta_ReturnsTextDeltaEvent()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        var evt = text.EmitDelta("Hello, ");

        XAssert.IsType<ResponseTextDeltaEvent>(evt);
        Assert.AreEqual("Hello, ", evt.Delta);
    }

    [Test]
    public void EmitDelta_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        var evt = text.EmitDelta("chunk");

        Assert.AreEqual(msg.ItemId, evt.ItemId);
        Assert.AreEqual(msg.OutputIndex, evt.OutputIndex);
        Assert.AreEqual(text.ContentIndex, evt.ContentIndex);
    }

    [Test]
    public void EmitDelta_CanBeCalledMultipleTimes()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        var d1 = text.EmitDelta("Hello, ");
        var d2 = text.EmitDelta("world!");

        Assert.AreEqual("Hello, ", d1.Delta);
        Assert.AreEqual("world!", d2.Delta);
    }

    [Test]
    public void EmitDone_ReturnsTextDoneEvent()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        text.EmitAdded();
        var evt = text.EmitDone("Hello, world!");

        XAssert.IsType<ResponseTextDoneEvent>(evt);
        Assert.AreEqual("Hello, world!", evt.Text);
    }

    [Test]
    public void EmitDone_StoresFinalText()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        Assert.IsNull(text.FinalText);

        text.EmitAdded();
        text.EmitDone("Final value");

        Assert.AreEqual("Final value", text.FinalText);
    }

    [Test]
    public void EmitDone_HasCorrectBookkeepingFields()
    {
        var (_, msg) = CreateMessageScope();
        var text = msg.AddTextContent();

        text.EmitAdded();
        var evt = text.EmitDone("done text");

        Assert.AreEqual(msg.ItemId, evt.ItemId);
        Assert.AreEqual(msg.OutputIndex, evt.OutputIndex);
        Assert.AreEqual(text.ContentIndex, evt.ContentIndex);
    }

    [Test]
    public void AllEmitMethods_ShareSequenceCounter()
    {
        var (stream, msg) = CreateMessageScope();

        // stream.AddOutputItemMessage() doesn't consume seq, but let's track from here
        var text = msg.AddTextContent();

        var added = text.EmitAdded();       // seq 0
        var delta = text.EmitDelta("Hi");   // seq 1
        var done = text.EmitDone("Hi");     // seq 2

        Assert.AreEqual(0, added.SequenceNumber);
        Assert.AreEqual(1, delta.SequenceNumber);
        Assert.AreEqual(2, done.SequenceNumber);
    }
}
