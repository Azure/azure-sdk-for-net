// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class ResponseExtensionsTests
{
    // ── GetToolChoiceExpanded ──────────────────────────────────────────

    [Test]
    public void GetToolChoiceExpanded_NullResponse_ThrowsArgumentNullException()
    {
        Models.ResponseObject? response = null;
        Assert.Throws<ArgumentNullException>(() => response!.GetToolChoiceExpanded());
    }

    [Test]
    public void GetToolChoiceExpanded_NullToolChoice_ReturnsNull()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");
        Assert.That(response.GetToolChoiceExpanded(), Is.Null);
    }

    [Test]
    public void GetToolChoiceExpanded_Auto_ReturnsToolChoiceAllowedAuto()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o")
        {
            ToolChoice = BinaryData.FromObjectAsJson("auto"),
        };

        var result = response.GetToolChoiceExpanded();

        var allowed = XAssert.IsType<ToolChoiceAllowed>(result);
        Assert.That(allowed.Mode, Is.EqualTo(ToolChoiceAllowedMode.Auto));
    }

    [Test]
    public void GetToolChoiceExpanded_None_ReturnsNull()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o")
        {
            ToolChoice = BinaryData.FromObjectAsJson("none"),
        };

        Assert.That(response.GetToolChoiceExpanded(), Is.Null);
    }

    // ── SetToolChoice(ToolChoiceParam) ────────────────────────────────

    [Test]
    public void SetToolChoice_ToolChoiceParam_RoundTrips()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");
        var toolChoice = new ToolChoiceAllowed(ToolChoiceAllowedMode.Required, Array.Empty<IDictionary<string, BinaryData>>());

        response.SetToolChoice(toolChoice);
        var result = response.GetToolChoiceExpanded();

        var allowed = XAssert.IsType<ToolChoiceAllowed>(result);
        Assert.That(allowed.Mode, Is.EqualTo(ToolChoiceAllowedMode.Required));
    }

    [Test]
    public void SetToolChoice_NullParam_ThrowsArgumentNullException()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");
        Assert.Throws<ArgumentNullException>(() => response.SetToolChoice((ToolChoiceParam)null!));
    }

    // ── SetToolChoice(ToolChoiceOptions) ──────────────────────────────

    [Test]
    public void SetToolChoice_OptionsAuto_RoundTrips()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");

        response.SetToolChoice(ToolChoiceOptions.Auto);
        var result = response.GetToolChoiceExpanded();

        var allowed = XAssert.IsType<ToolChoiceAllowed>(result);
        Assert.That(allowed.Mode, Is.EqualTo(ToolChoiceAllowedMode.Auto));
    }

    [Test]
    public void SetToolChoice_OptionsRequired_RoundTrips()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");

        response.SetToolChoice(ToolChoiceOptions.Required);
        var result = response.GetToolChoiceExpanded();

        var allowed = XAssert.IsType<ToolChoiceAllowed>(result);
        Assert.That(allowed.Mode, Is.EqualTo(ToolChoiceAllowedMode.Required));
    }

    [Test]
    public void SetToolChoice_OptionsNone_GetReturnsNull()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");

        response.SetToolChoice(ToolChoiceOptions.None);

        Assert.That(response.GetToolChoiceExpanded(), Is.Null);
    }

    // ── GetInstructionItems ───────────────────────────────────────────

    [Test]
    public void GetInstructionItems_NullResponse_ThrowsArgumentNullException()
    {
        Models.ResponseObject? response = null;
        Assert.Throws<ArgumentNullException>(() => response!.GetInstructionItems());
    }

    [Test]
    public void GetInstructionItems_NullInstructions_ReturnsEmptyList()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");
        Assert.That(response.GetInstructionItems(), Is.Empty);
    }

    [Test]
    public void GetInstructionItems_StringInstructions_ReturnsSingleItemMessage()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o")
        {
            Instructions = BinaryData.FromObjectAsJson("You are helpful."),
        };

        var result = response.GetInstructionItems();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.Developer));
        var content = itemMsg.GetContentExpanded();
        var textContent = XAssert.Single(content);
        var inputText = XAssert.IsType<MessageContentInputTextContent>(textContent);
        Assert.That(inputText.Text, Is.EqualTo("You are helpful."));
    }

    [Test]
    public void GetInstructionItems_ArrayInstructions_DeserializesCorrectly()
    {
        var json = """[{"type":"message","role":"developer","content":[{"type":"input_text","text":"Be concise."}]}]""";
        var response = new Models.ResponseObject("resp_1", "gpt-4o")
        {
            Instructions = BinaryData.FromString(json),
        };

        var result = response.GetInstructionItems();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.Developer));
    }

    // ── SetInstructions(string) ───────────────────────────────────────

    [Test]
    public void SetInstructions_String_RoundTrips()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");

        response.SetInstructions("You are a helpful assistant.");
        var result = response.GetInstructionItems();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        var content = itemMsg.GetContentExpanded();
        var textContent = XAssert.Single(content);
        var inputText = XAssert.IsType<MessageContentInputTextContent>(textContent);
        Assert.That(inputText.Text, Is.EqualTo("You are a helpful assistant."));
    }

    [Test]
    public void SetInstructions_NullString_ThrowsArgumentNullException()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");
        Assert.Throws<ArgumentNullException>(() => response.SetInstructions((string)null!));
    }

    // ── SetInstructions(IList<Item>) ──────────────────────────────────

    [Test]
    public void SetInstructions_ItemList_RoundTrips()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");
        var items = new List<Item>
        {
            new ItemMessage(MessageRole.Developer, new List<MessageContent>
            {
                new MessageContentInputTextContent("Be helpful."),
            }),
        };

        response.SetInstructions(items);
        var result = response.GetInstructionItems();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        var content = itemMsg.GetContentExpanded();
        var textContent = XAssert.Single(content);
        var inputText = XAssert.IsType<MessageContentInputTextContent>(textContent);
        Assert.That(inputText.Text, Is.EqualTo("Be helpful."));
    }

    [Test]
    public void SetInstructions_NullItemList_ThrowsArgumentNullException()
    {
        var response = new Models.ResponseObject("resp_1", "gpt-4o");
        Assert.Throws<ArgumentNullException>(() => response.SetInstructions((IList<Item>)null!));
    }
}
