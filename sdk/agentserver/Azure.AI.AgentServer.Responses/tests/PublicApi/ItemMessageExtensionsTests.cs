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
        var msg = new ItemMessage("msg1", MessageStatus.Completed, MessageRole.User, BinaryData.FromString(json));
        Assert.IsNotNull(msg.Content);
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
        Assert.AreEqual("Hello world", inputText.Text);
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
        Assert.IsEmpty(result);
    }

    [Test]
    public void GetContentExpanded_StringContent_ReturnsSingleTextContent()
    {
        var msg = new ItemMessage("msg1", MessageStatus.Completed, MessageRole.User,
            BinaryData.FromObjectAsJson("Hello world"));

        var result = msg.GetContentExpanded();

        var textContent = XAssert.Single(result);
        var inputText = XAssert.IsType<MessageContentInputTextContent>(textContent);
        Assert.AreEqual("Hello world", inputText.Text);
    }

    [Test]
    public void GetContentExpanded_ArrayContent_DeserializesCorrectly()
    {
        var json = """[{"type":"input_text","text":"Hi"},{"type":"input_text","text":"there"}]""";
        var msg = new ItemMessage("msg1", MessageStatus.Completed, MessageRole.User,
            BinaryData.FromString(json));

        var result = msg.GetContentExpanded();

        Assert.AreEqual(2, result.Count);
        XAssert.IsType<MessageContentInputTextContent>(result[0]);
        XAssert.IsType<MessageContentInputTextContent>(result[1]);
        Assert.AreEqual("Hi", ((MessageContentInputTextContent)result[0]).Text);
        Assert.AreEqual("there", ((MessageContentInputTextContent)result[1]).Text);
    }

    [Test]
    public void GetContentExpanded_NonStringNonArray_ThrowsFormatException()
    {
        var msg = new ItemMessage("msg1", MessageStatus.Completed, MessageRole.User,
            BinaryData.FromString("42"));

        var ex = Assert.Throws<FormatException>(() => msg.GetContentExpanded());
        Assert.AreEqual("Expected JSON array, object, or string for item content", ex.Message);
    }
}
