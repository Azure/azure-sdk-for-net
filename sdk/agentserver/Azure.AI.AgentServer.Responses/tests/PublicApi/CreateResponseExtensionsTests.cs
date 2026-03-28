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
            Conversation = BinaryData.FromString(JsonSerializer.Serialize(conversationId)),
        };

        Assert.That(request.GetConversationId(), Is.EqualTo(conversationId));
    }

    [Test]
    public void GetConversationId_ConversationString_ReturnsIt()
    {
        var conversationId = "conv_abc123";
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString(JsonSerializer.Serialize(conversationId)),
        };

        Assert.That(request.GetConversationId(), Is.EqualTo(conversationId));
    }

    [Test]
    public void GetConversationId_ConversationObjectWithId_ReturnsId()
    {
        var conversationId = "conv_obj123";
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString(JsonSerializer.Serialize(new { id = conversationId })),
        };

        Assert.That(request.GetConversationId(), Is.EqualTo(conversationId));
    }

    [Test]
    public void GetConversationId_ConversationObjectWithoutId_ReturnsNull()
    {
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString(JsonSerializer.Serialize(new { name = "test" })),
        };

        Assert.That(request.GetConversationId(), Is.Null);
    }

    [Test]
    public void GetConversationId_ConversationEmptyString_ReturnsNull()
    {
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString(JsonSerializer.Serialize("")),
        };

        Assert.That(request.GetConversationId(), Is.Null);
    }

    [Test]
    public void GetConversationId_ConversationInvalidJson_ReturnsNull()
    {
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString("not valid json {{{"),
        };

        Assert.That(request.GetConversationId(), Is.Null);
    }

    [Test]
    public void GetConversationId_NullConversation_ReturnsNull()
    {
        var request = new CreateResponse
        {
            PreviousResponseId = "",
            Conversation = null,
        };

        Assert.That(request.GetConversationId(), Is.Null);
    }

    // ── GetToolChoiceExpanded ──────────────────────────────────────────

    [Test]
    public void GetToolChoiceExpanded_NullRequest_ThrowsArgumentNullException()
    {
        CreateResponse? request = null;
        Assert.Throws<ArgumentNullException>(() => request!.GetToolChoiceExpanded());
    }

    [Test]
    public void GetToolChoiceExpanded_NullToolChoice_ReturnsNull()
    {
        var request = new CreateResponse();
        Assert.That(request.GetToolChoiceExpanded(), Is.Null);
    }

    [Test]
    public void GetToolChoiceExpanded_Auto_ReturnsToolChoiceAllowedAuto()
    {
        var request = new CreateResponse
        {
            ToolChoice = BinaryData.FromObjectAsJson("auto"),
        };

        var result = request.GetToolChoiceExpanded();

        var allowed = XAssert.IsType<ToolChoiceAllowed>(result);
        Assert.That(allowed.Mode, Is.EqualTo(ToolChoiceAllowedMode.Auto));
        Assert.That(allowed.Tools, Is.Empty);
    }

    [Test]
    public void GetToolChoiceExpanded_Required_ReturnsToolChoiceAllowedRequired()
    {
        var request = new CreateResponse
        {
            ToolChoice = BinaryData.FromObjectAsJson("required"),
        };

        var result = request.GetToolChoiceExpanded();

        var allowed = XAssert.IsType<ToolChoiceAllowed>(result);
        Assert.That(allowed.Mode, Is.EqualTo(ToolChoiceAllowedMode.Required));
        Assert.That(allowed.Tools, Is.Empty);
    }

    [Test]
    public void GetToolChoiceExpanded_None_ReturnsNull()
    {
        var request = new CreateResponse
        {
            ToolChoice = BinaryData.FromObjectAsJson("none"),
        };

        Assert.That(request.GetToolChoiceExpanded(), Is.Null);
    }

    [Test]
    public void GetToolChoiceExpanded_ObjectForm_DeserializesCorrectly()
    {
        var json = """{"type":"allowed_tools","mode":"auto","tools":[]}""";
        var request = new CreateResponse
        {
            ToolChoice = BinaryData.FromString(json),
        };

        var result = request.GetToolChoiceExpanded();

        var allowed = XAssert.IsType<ToolChoiceAllowed>(result);
        Assert.That(allowed.Mode, Is.EqualTo(ToolChoiceAllowedMode.Auto));
    }

    [Test]
    public void GetToolChoiceExpanded_UnrecognizedString_ThrowsFormatException()
    {
        var request = new CreateResponse
        {
            ToolChoice = BinaryData.FromObjectAsJson("invalid_value"),
        };

        Assert.Throws<FormatException>(() => request.GetToolChoiceExpanded());
    }

    [Test]
    public void GetToolChoiceExpanded_NumberValue_ThrowsFormatException()
    {
        var request = new CreateResponse
        {
            ToolChoice = BinaryData.FromString("42"),
        };

        Assert.Throws<FormatException>(() => request.GetToolChoiceExpanded());
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
            Input = BinaryData.FromObjectAsJson("Hello world"),
        };

        var result = request.GetInputExpanded();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.User));
        var content = itemMsg.GetContentExpanded();
        var textContent = XAssert.Single(content);
        var inputText = XAssert.IsType<MessageContentInputTextContent>(textContent);
        Assert.That(inputText.Text, Is.EqualTo("Hello world"));
    }

    [Test]
    public void GetInputExpanded_TypedArray_DeserializesPolymorphically()
    {
        var json = """[{"type":"message","role":"user","content":[{"type":"input_text","text":"Hi"}]}]""";
        var request = new CreateResponse
        {
            Input = BinaryData.FromString(json),
        };

        var result = request.GetInputExpanded();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.User));
    }

    [Test]
    public void GetInputExpanded_UntypedArray_FallsBackToItemMessage()
    {
        var json = """[{"role":"user","content":[{"type":"input_text","text":"Hi"}]}]""";
        var request = new CreateResponse
        {
            Input = BinaryData.FromString(json),
        };

        var result = request.GetInputExpanded();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.User));
    }

    [Test]
    public void GetInputExpanded_NumberValue_ThrowsFormatException()
    {
        var request = new CreateResponse
        {
            Input = BinaryData.FromString("42"),
        };

        var ex = Assert.Throws<FormatException>(() => request.GetInputExpanded());
        Assert.That(ex.Message, Is.EqualTo("Expected a string or array for Input, but got Number."));
    }

    [Test]
    public void GetInputExpanded_MalformedJson_ThrowsFormatException()
    {
        var request = new CreateResponse
        {
            Input = BinaryData.FromString("{{{invalid"),
        };

        var ex = Assert.Throws<FormatException>(() => request.GetInputExpanded());
        Assert.That(ex.Message, Is.EqualTo("Failed to convert input items"));
        Assert.That(ex.InnerException, Is.Not.Null);
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
            Input = BinaryData.FromObjectAsJson("Hello world"),
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
        var request = new CreateResponse
        {
            Input = BinaryData.FromString(json),
        };

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
        var request = new CreateResponse
        {
            Input = BinaryData.FromString(json),
        };

        Assert.That(request.GetInputText(), Is.EqualTo("Look at this"));
    }

    [Test]
    public void GetInputText_NonMessageItems_ReturnsEmptyString()
    {
        var json = """[{"type":"function_call_output","call_id":"call_1","output":"result"}]""";
        var request = new CreateResponse
        {
            Input = BinaryData.FromString(json),
        };

        Assert.That(request.GetInputText(), Is.EqualTo(string.Empty));
    }

    // ── GetConversationExpanded ────────────────────────────────────────

    [Test]
    public void GetConversationExpanded_NullRequest_ThrowsArgumentNullException()
    {
        CreateResponse? request = null;
        Assert.Throws<ArgumentNullException>(() => request!.GetConversationExpanded());
    }

    [Test]
    public void GetConversationExpanded_NullConversation_ReturnsNull()
    {
        var request = new CreateResponse();
        Assert.That(request.GetConversationExpanded(), Is.Null);
    }

    [Test]
    public void GetConversationExpanded_StringId_ReturnsConversationParamWithId()
    {
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromObjectAsJson("conv_abc123"),
        };

        var result = request.GetConversationExpanded();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo("conv_abc123"));
    }

    [Test]
    public void GetConversationExpanded_ObjectForm_Deserialized()
    {
        var json = """{"id":"conv_xyz"}""";
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString(json),
        };

        var result = request.GetConversationExpanded();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo("conv_xyz"));
    }

    [Test]
    public void GetConversationExpanded_UnexpectedShape_ThrowsFormatException()
    {
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString("42"),
        };

        Assert.Throws<FormatException>(() => request.GetConversationExpanded());
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
