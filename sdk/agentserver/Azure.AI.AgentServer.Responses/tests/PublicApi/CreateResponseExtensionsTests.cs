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
        Assert.IsNull(request.GetConversationId());
    }

    [Test]
    public void GetConversationId_PreviousResponseIdOnly_ReturnsNull()
    {
        var request = new CreateResponse { PreviousResponseId = "caresp_abc123" };

        Assert.IsNull(request.GetConversationId());
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

        Assert.AreEqual(conversationId, request.GetConversationId());
    }

    [Test]
    public void GetConversationId_ConversationString_ReturnsIt()
    {
        var conversationId = "conv_abc123";
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString(JsonSerializer.Serialize(conversationId)),
        };

        Assert.AreEqual(conversationId, request.GetConversationId());
    }

    [Test]
    public void GetConversationId_ConversationObjectWithId_ReturnsId()
    {
        var conversationId = "conv_obj123";
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString(JsonSerializer.Serialize(new { id = conversationId })),
        };

        Assert.AreEqual(conversationId, request.GetConversationId());
    }

    [Test]
    public void GetConversationId_ConversationObjectWithoutId_ReturnsNull()
    {
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString(JsonSerializer.Serialize(new { name = "test" })),
        };

        Assert.IsNull(request.GetConversationId());
    }

    [Test]
    public void GetConversationId_ConversationEmptyString_ReturnsNull()
    {
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString(JsonSerializer.Serialize("")),
        };

        Assert.IsNull(request.GetConversationId());
    }

    [Test]
    public void GetConversationId_ConversationInvalidJson_ReturnsNull()
    {
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromString("not valid json {{{"),
        };

        Assert.IsNull(request.GetConversationId());
    }

    [Test]
    public void GetConversationId_NullConversation_ReturnsNull()
    {
        var request = new CreateResponse
        {
            PreviousResponseId = "",
            Conversation = null,
        };

        Assert.IsNull(request.GetConversationId());
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
        Assert.IsNull(request.GetToolChoiceExpanded());
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
        Assert.AreEqual(ToolChoiceAllowedMode.Auto, allowed.Mode);
        Assert.IsEmpty(allowed.Tools);
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
        Assert.AreEqual(ToolChoiceAllowedMode.Required, allowed.Mode);
        Assert.IsEmpty(allowed.Tools);
    }

    [Test]
    public void GetToolChoiceExpanded_None_ReturnsNull()
    {
        var request = new CreateResponse
        {
            ToolChoice = BinaryData.FromObjectAsJson("none"),
        };

        Assert.IsNull(request.GetToolChoiceExpanded());
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
        Assert.AreEqual(ToolChoiceAllowedMode.Auto, allowed.Mode);
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
        Assert.IsEmpty(result);
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
        Assert.AreEqual(MessageRole.User, itemMsg.Role);
        var content = itemMsg.GetContentExpanded();
        var textContent = XAssert.Single(content);
        var inputText = XAssert.IsType<MessageContentInputTextContent>(textContent);
        Assert.AreEqual("Hello world", inputText.Text);
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
        Assert.AreEqual(MessageRole.User, itemMsg.Role);
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
        Assert.AreEqual(MessageRole.User, itemMsg.Role);
    }

    [Test]
    public void GetInputExpanded_NumberValue_ThrowsFormatException()
    {
        var request = new CreateResponse
        {
            Input = BinaryData.FromString("42"),
        };

        var ex = Assert.Throws<FormatException>(() => request.GetInputExpanded());
        Assert.AreEqual("Failed to convert input items", ex.Message);
    }

    [Test]
    public void GetInputExpanded_MalformedJson_ThrowsFormatException()
    {
        var request = new CreateResponse
        {
            Input = BinaryData.FromString("{{{invalid"),
        };

        var ex = Assert.Throws<FormatException>(() => request.GetInputExpanded());
        Assert.AreEqual("Failed to convert input items", ex.Message);
        Assert.IsNotNull(ex.InnerException);
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
        Assert.AreEqual(string.Empty, request.GetInputText());
    }

    [Test]
    public void GetInputText_StringInput_ReturnsText()
    {
        var request = new CreateResponse
        {
            Input = BinaryData.FromObjectAsJson("Hello world"),
        };

        Assert.AreEqual("Hello world", request.GetInputText());
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
        Assert.AreEqual("Hello\nWorld", result);
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

        Assert.AreEqual("Look at this", request.GetInputText());
    }

    [Test]
    public void GetInputText_NonMessageItems_ReturnsEmptyString()
    {
        var json = """[{"type":"function_call_output","call_id":"call_1","output":"result"}]""";
        var request = new CreateResponse
        {
            Input = BinaryData.FromString(json),
        };

        Assert.AreEqual(string.Empty, request.GetInputText());
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
        Assert.IsNull(request.GetConversationExpanded());
    }

    [Test]
    public void GetConversationExpanded_StringId_ReturnsConversationParamWithId()
    {
        var request = new CreateResponse
        {
            Conversation = BinaryData.FromObjectAsJson("conv_abc123"),
        };

        var result = request.GetConversationExpanded();

        Assert.IsNotNull(result);
        Assert.AreEqual("conv_abc123", result.Id);
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

        Assert.IsNotNull(result);
        Assert.AreEqual("conv_xyz", result.Id);
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
}
