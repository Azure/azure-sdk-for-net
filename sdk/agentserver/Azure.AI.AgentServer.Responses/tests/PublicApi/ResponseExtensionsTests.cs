// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class ResponseExtensionsTests
{
    // ── GetInstructionItems ───────────────────────────────────────────

    [Test]
    public void GetInstructionItems_NullResponse_ThrowsArgumentNullException()
    {
        ResponseObject? response = null;
        Assert.Throws<ArgumentNullException>(() => response!.GetInstructionItems());
    }

    [Test]
    public void GetInstructionItems_NullInstructions_ReturnsEmptyList()
    {
        var response = new ResponseObject { Id = "resp_1", Model = "gpt-4o" };
        Assert.That(response.GetInstructionItems(), Is.Empty);
    }

    [Test]
    public void GetInstructionItems_StringInstructions_ReturnsSingleItemMessage()
    {
        var response = new ResponseObject { Id = "resp_1", Model = "gpt-4o", Instructions = { ResponseItem.CreateDeveloperMessageItem("You are helpful.") } };

        var result = response.GetInstructionItems();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.Developer));
        var inputText = XAssert.Single(itemMsg.Content);
        Assert.That(inputText.Kind, Is.EqualTo(ResponseContentPartKind.InputText));
        Assert.That(inputText.Text, Is.EqualTo("You are helpful."));
    }

    [Test]
    public void GetInstructionItems_ArrayInstructions_DeserializesCorrectly()
    {
        var response = new ResponseObject { Id = "resp_1", Model = "gpt-4o", Instructions = { ResponseItem.CreateDeveloperMessageItem("Be concise.") } };

        var result = response.GetInstructionItems();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        Assert.That(itemMsg.Role, Is.EqualTo(MessageRole.Developer));
    }

    // ── SetInstructions(string) ───────────────────────────────────────

    [Test]
    public void SetInstructions_String_RoundTrips()
    {
        var response = new ResponseObject { Id = "resp_1", Model = "gpt-4o" };

        response.SetInstructions("You are a helpful assistant.");
        var result = response.GetInstructionItems();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        var inputText = XAssert.Single(itemMsg.Content);
        Assert.That(inputText.Kind, Is.EqualTo(ResponseContentPartKind.InputText));
        Assert.That(inputText.Text, Is.EqualTo("You are a helpful assistant."));
    }

    [Test]
    public void SetInstructions_NullString_ThrowsArgumentNullException()
    {
        var response = new ResponseObject { Id = "resp_1", Model = "gpt-4o" };
        Assert.Throws<ArgumentNullException>(() => response.SetInstructions((string)null!));
    }

    // ── SetInstructions(IList<Item>) ──────────────────────────────────

    [Test]
    public void SetInstructions_ItemList_RoundTrips()
    {
        var response = new ResponseObject { Id = "resp_1", Model = "gpt-4o" };
        var items = new List<Item>
        {
            MessageItemFactory.Message(MessageRole.Developer, new List<ResponseContentPart>
            {
                ResponseContentPart.CreateInputTextPart("Be helpful."),
            }),
        };

        response.SetInstructions(items);
        var result = response.GetInstructionItems();

        var msg = XAssert.Single(result);
        var itemMsg = XAssert.IsType<ItemMessage>(msg);
        var inputText = XAssert.Single(itemMsg.Content);
        Assert.That(inputText.Kind, Is.EqualTo(ResponseContentPartKind.InputText));
        Assert.That(inputText.Text, Is.EqualTo("Be helpful."));
    }

    [Test]
    public void SetInstructions_NullItemList_ThrowsArgumentNullException()
    {
        var response = new ResponseObject { Id = "resp_1", Model = "gpt-4o" };
        Assert.Throws<ArgumentNullException>(() => response.SetInstructions((IList<Item>)null!));
    }
}
