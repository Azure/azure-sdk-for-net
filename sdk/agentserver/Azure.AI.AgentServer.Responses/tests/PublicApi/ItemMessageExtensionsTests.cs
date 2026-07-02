// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class ItemMessageExtensionsTests
{
    // ── ItemMessage.Content as BinaryData ─────────────────────────────

    [Test]
    public void Content_IsAccessibleAsBinaryData()
    {
        var json = """[{"type":"input_text","text":"Hello"}]""";
        var msg = new ItemMessage(MessageRole.User, BinaryData.FromString(json));
        Assert.That(msg.Content, Is.Not.Null);
        XAssert.Contains("Hello", msg.Content.ToString());
    }

    [Test]
    public void Content_ViaConvenienceConstructor_RoundTrips()
    {
        var content = new List<MessageContent>
        {
            new MessageContentInputTextContent("Hello world"),
        };
        var msg = new ItemMessage(MessageRole.User, content);

        var expanded = msg.GetContentExpanded();
        var textContent = XAssert.Single(expanded);
        var inputText = XAssert.IsType<MessageContentInputTextContent>(textContent);
        Assert.That(inputText.Text, Is.EqualTo("Hello world"));
    }

    // ── GetContentExpanded ────────────────────────────────────────────

    [Test]
    public void GetContentExpanded_NullMessage_ThrowsArgumentNullException()
    {
        ItemMessage? msg = null;
        Assert.Throws<ArgumentNullException>(() => msg!.GetContentExpanded());
    }

    [Test]
    public void GetContentExpanded_NullContent_ReturnsEmptyList()
    {
        // Use the internal parameterless constructor via deserialization
        var json = """{"type":"message","id":"msg1","status":"completed","role":"user"}""";
        using var doc = System.Text.Json.JsonDocument.Parse(json);
        var msg = ItemMessage.DeserializeItemMessage(doc.RootElement, System.ClientModel.Primitives.ModelReaderWriterOptions.Json);
        var result = msg.GetContentExpanded();
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void GetContentExpanded_StringContent_ReturnsSingleTextContent()
    {
        var msg = new ItemMessage(MessageRole.User,
            BinaryData.FromObjectAsJson("Hello world"));

        var result = msg.GetContentExpanded();

        var textContent = XAssert.Single(result);
        var inputText = XAssert.IsType<MessageContentInputTextContent>(textContent);
        Assert.That(inputText.Text, Is.EqualTo("Hello world"));
    }

    [Test]
    public void GetContentExpanded_ArrayContent_DeserializesCorrectly()
    {
        var json = """[{"type":"input_text","text":"Hi"},{"type":"input_text","text":"there"}]""";
        var msg = new ItemMessage(MessageRole.User,
            BinaryData.FromString(json));

        var result = msg.GetContentExpanded();

        Assert.That(result.Count, Is.EqualTo(2));
        XAssert.IsType<MessageContentInputTextContent>(result[0]);
        XAssert.IsType<MessageContentInputTextContent>(result[1]);
        Assert.That(((MessageContentInputTextContent)result[0]).Text, Is.EqualTo("Hi"));
        Assert.That(((MessageContentInputTextContent)result[1]).Text, Is.EqualTo("there"));
    }

    [Test]
    public void GetContentExpanded_NonStringNonArray_ThrowsFormatException()
    {
        var msg = new ItemMessage(MessageRole.User,
            BinaryData.FromString("42"));

        var ex = Assert.Throws<FormatException>(() => msg.GetContentExpanded());
        Assert.That(ex.Message, Is.EqualTo("Expected JSON array, object, or string for item content"));
    }
}
