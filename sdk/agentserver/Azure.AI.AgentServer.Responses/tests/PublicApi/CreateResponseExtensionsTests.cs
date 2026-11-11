// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class CreateResponseExtensionsTests
{
    // ── GetConversationId ──────────────────────────────────────────────

    [Test]
    public void GetConversationId_NullRequest_ThrowsArgumentNullException()
    {
        CreateResponse? request = null;
        Assert.Throws<ArgumentNullException>(() => request!.GetConversationId());
    }

    [Test]
    public void GetConversationId_NoFields_ReturnsNull()
    {
        var request = new CreateResponse();
        Assert.That(request.GetConversationId(), Is.Null);
    }

    [Test]
    public void GetConversationId_PreviousResponseIdOnly_ReturnsNull()
    {
        var request = new CreateResponse { PreviousResponseId = "caresp_abc123" };

        Assert.That(request.GetConversationId(), Is.Null);
    }

    [Test]
    public void GetConversationId_PreviousResponseIdAndConversation_ReturnsConversationId()
    {
        var conversationId = "conv_other";
        var request = new CreateResponse
        {
            PreviousResponseId = "caresp_prev",
            ConversationOptions = new ResponseConversationOptions(conversationId),
        };

        Assert.That(request.GetConversationId(), Is.EqualTo(conversationId));
    }

    [Test]
    public void GetConversationId_ConversationString_ReturnsIt()
    {
        var conversationId = "conv_abc123";
        var request = new CreateResponse
        {
            ConversationOptions = new ResponseConversationOptions(conversationId),
        };

        Assert.That(request.GetConversationId(), Is.EqualTo(conversationId));
    }

    [Test]
    public void GetConversationId_ConversationObjectWithId_ReturnsId()
    {
        var conversationId = "conv_obj123";
        var request = new CreateResponse
        {
            ConversationOptions = new ResponseConversationOptions(conversationId),
        };

        Assert.That(request.GetConversationId(), Is.EqualTo(conversationId));
    }

    [Test]
    public void GetConversationId_ConversationEmptyString_ReturnsNull()
    {
        var request = new CreateResponse
        {
            ConversationOptions = new ResponseConversationOptions(string.Empty),
        };

        Assert.That(request.GetConversationId(), Is.Null);
    }

    [Test]
    public void GetConversationId_NullConversation_ReturnsNull()
    {
        var request = new CreateResponse
        {
            PreviousResponseId = "",
            ConversationOptions = null,
        };

        Assert.That(request.GetConversationId(), Is.Null);
    }

    // ── GetInputExpanded ──────────────────────────────────────────────

    [Test]
    public void GetInputExpanded_NullRequest_ThrowsArgumentNullException()
    {
        CreateResponse? request = null;
        Assert.Throws<ArgumentNullException>(() => request!.GetInputExpanded());
    }

    [Test]
    public void GetInputExpanded_NullInput_ReturnsEmptyList()
    {
        var request = new CreateResponse();
        var result = request.GetInputExpanded();
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void GetInputExpanded_StringInput_ReturnsSingleItemMessage()
    {
        var request = new CreateResponse
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Hello world") },
        };

        var result = request.GetInputExpanded();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.User));
        var inputText = XAssert.Single(itemMsg.Content);
        Assert.That(inputText.Kind, Is.EqualTo(ResponseContentPartKind.InputText));
        Assert.That(inputText.Text, Is.EqualTo("Hello world"));
    }

    [Test]
    public void GetInputExpanded_TypedArray_DeserializesPolymorphically()
    {
        var json = """[{"type":"message","role":"user","content":[{"type":"input_text","text":"Hi"}]}]""";
        var request = new CreateResponse();
        foreach (var __item in OpenAIJson.Items(BinaryData.FromString(json)))
        {
            request.InputItems.Add(__item);
        }

        var result = request.GetInputExpanded();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.User));
    }

    [Test]
    public void GetInputExpanded_UntypedArray_FallsBackToItemMessage()
    {
        var json = """[{"role":"user","content":[{"type":"input_text","text":"Hi"}]}]""";
        var request = new CreateResponse();
        foreach (var __item in OpenAIJson.Items(BinaryData.FromString(json)))
        {
            request.InputItems.Add(__item);
        }

        var result = request.GetInputExpanded();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.User));
    }

    [Test]
    public void GetInputExpanded_StringContent_NormalizedToArray()
    {
        // content is a plain JSON string — should be auto-expanded to array form
        var json = """[{"type":"message","role":"user","content":"Hello world"}]""";
        var request = new CreateResponse();
        foreach (var __item in OpenAIJson.Items(BinaryData.FromString(json)))
        {
            request.InputItems.Add(__item);
        }

        var result = request.GetInputExpanded();

        var itemMsg = XAssert.IsType<ItemMessage>(XAssert.Single(result));

        // Content BinaryData should now be a JSON array, not a string
        using var doc = System.Text.Json.JsonDocument.Parse(BinaryData.FromObjectAsJson(itemMsg.Content).ToMemory());
        Assert.That(doc.RootElement.ValueKind, Is.EqualTo(System.Text.Json.JsonValueKind.Array));

        // Typed Content should still expose the text part
        var textContent = XAssert.Single(itemMsg.Content);
        Assert.That(textContent.Kind, Is.EqualTo(ResponseContentPartKind.InputText));
        Assert.That(textContent.Text, Is.EqualTo("Hello world"));
    }

    [Test]
    public void GetInputExpanded_ArrayContent_RemainsUnchanged()
    {
        // content is already an array — should pass through without re-serialization
        var json = """[{"type":"message","role":"user","content":[{"type":"input_text","text":"Already expanded"}]}]""";
        var request = new CreateResponse();
        foreach (var __item in OpenAIJson.Items(BinaryData.FromString(json)))
        {
            request.InputItems.Add(__item);
        }

        var result = request.GetInputExpanded();

        var itemMsg = XAssert.IsType<ItemMessage>(XAssert.Single(result));
        using var doc = System.Text.Json.JsonDocument.Parse(BinaryData.FromObjectAsJson(itemMsg.Content).ToMemory());
        Assert.That(doc.RootElement.ValueKind, Is.EqualTo(System.Text.Json.JsonValueKind.Array));

        var textContent = XAssert.Single(itemMsg.Content);
        Assert.That(textContent.Kind, Is.EqualTo(ResponseContentPartKind.InputText));
        Assert.That(textContent.Text, Is.EqualTo("Already expanded"));
    }

    [Test]
    public void GetInputText_StringContent_ExtractsTextCorrectly()
    {
        // Ensures GetInputText works when content is a string shorthand
        var json = """
        [
            {"type":"message","role":"user","content":"First message"},
            {"type":"message","role":"user","content":[{"type":"input_text","text":"Second message"}]}
        ]
        """;
        var request = new CreateResponse();
        foreach (var __item in OpenAIJson.Items(BinaryData.FromString(json)))
        {
            request.InputItems.Add(__item);
        }

        var result = request.GetInputText();
        Assert.That(result, Is.EqualTo("First message\nSecond message"));
    }

    // ── GetInputText ──────────────────────────────────────────────────

    [Test]
    public void GetInputText_NullRequest_ThrowsArgumentNullException()
    {
        CreateResponse? request = null;
        Assert.Throws<ArgumentNullException>(() => request!.GetInputText());
    }

    [Test]
    public void GetInputText_NullInput_ReturnsEmptyString()
    {
        var request = new CreateResponse();
        Assert.That(request.GetInputText(), Is.EqualTo(string.Empty));
    }

    [Test]
    public void GetInputText_StringInput_ReturnsText()
    {
        var request = new CreateResponse
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Hello world") },
        };

        Assert.That(request.GetInputText(), Is.EqualTo("Hello world"));
    }

    [Test]
    public void GetInputText_MultipleMessages_JoinsWithNewlines()
    {
        var json = """
        [
            {"type":"message","role":"user","content":[{"type":"input_text","text":"Hello"}]},
            {"type":"message","role":"user","content":[{"type":"input_text","text":"World"}]}
        ]
        """;
        var request = new CreateResponse();
        foreach (var __item in OpenAIJson.Items(BinaryData.FromString(json)))
        {
            request.InputItems.Add(__item);
        }

        var result = request.GetInputText();
        Assert.That(result, Is.EqualTo("Hello\nWorld"));
    }

    [Test]
    public void GetInputText_MixedContent_OnlyIncludesText()
    {
        // Message with input_text and input_image — only text extracted
        var json = """
        [
            {"type":"message","role":"user","content":[
                {"type":"input_text","text":"Look at this"},
                {"type":"input_image","image_url":"https://example.com/img.png","detail":"auto"}
            ]}
        ]
        """;
        var request = new CreateResponse();
        foreach (var __item in OpenAIJson.Items(BinaryData.FromString(json)))
        {
            request.InputItems.Add(__item);
        }

        Assert.That(request.GetInputText(), Is.EqualTo("Look at this"));
    }

    [Test]
    public void GetInputText_NonMessageItems_ReturnsEmptyString()
    {
        var json = """[{"type":"function_call_output","call_id":"call_1","output":"result"}]""";
        var request = new CreateResponse();
        foreach (var __item in OpenAIJson.Items(BinaryData.FromString(json)))
        {
            request.InputItems.Add(__item);
        }

        Assert.That(request.GetInputText(), Is.EqualTo(string.Empty));
    }

    // ── GetInstructionsBinaryData ──────────────────────────────────────

    [Test]
    public void GetInstructionsBinaryData_NullRequest_ThrowsArgumentNullException()
    {
        CreateResponse? request = null;
        Assert.Throws<ArgumentNullException>(() => request!.GetInstructionsBinaryData());
    }

    [Test]
    public void GetInstructionsBinaryData_NullInstructions_ReturnsNull()
    {
        var request = new CreateResponse();
        Assert.That(request.GetInstructionsBinaryData(), Is.Null);
    }

    [Test]
    public void GetInstructionsBinaryData_WithInstructions_ReturnsJsonEncodedBinaryData()
    {
        var request = new CreateResponse { Instructions = "Be helpful and concise." };

        var result = request.GetInstructionsBinaryData();

        Assert.That(result, Is.Not.Null);
        using var doc = JsonDocument.Parse(result!.ToMemory());
        Assert.That(doc.RootElement.ValueKind, Is.EqualTo(JsonValueKind.String));
        Assert.That(doc.RootElement.GetString(), Is.EqualTo("Be helpful and concise."));
    }

    [Test]
    public void GetInstructionsBinaryData_WithSpecialCharacters_RoundTripsCorrectly()
    {
        var instructions = "Use \"quotes\" and backslashes \\ and newlines\n here.";
        var request = new CreateResponse { Instructions = instructions };

        var result = request.GetInstructionsBinaryData();

        Assert.That(result, Is.Not.Null);
        using var doc = JsonDocument.Parse(result!.ToMemory());
        Assert.That(doc.RootElement.GetString(), Is.EqualTo(instructions));
    }

    [Test]
    public void GetInstructionsBinaryData_EmptyString_ReturnsValidBinaryData()
    {
        var request = new CreateResponse { Instructions = "" };

        var result = request.GetInstructionsBinaryData();

        Assert.That(result, Is.Not.Null);
        using var doc = JsonDocument.Parse(result!.ToMemory());
        Assert.That(doc.RootElement.GetString(), Is.EqualTo(""));
    }
}
