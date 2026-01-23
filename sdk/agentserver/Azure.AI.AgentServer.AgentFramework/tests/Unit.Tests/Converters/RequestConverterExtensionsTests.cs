// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

using Azure.AI.AgentServer.AgentFramework.Converters;
using Azure.AI.AgentServer.Contracts.Generated.Responses;

using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Unit.Tests.Converters;

public class RequestConverterExtensionsTests
{
    [Test]
    public void GetInputMessages_WithStringInput_ReturnsUserMessage()
    {
        var request = CreateRequestWithStringInput("Hello!");

        var messages = request.GetInputMessages();

        Assert.That(messages.Count, Is.EqualTo(1));
        var message = messages.First();
        Assert.That(message.Role, Is.EqualTo(ChatRole.User));
    }

    [Test]
    public void GetInputMessages_WithStringInput_ParsesTextContent()
    {
        var request = CreateRequestWithStringInput("Hello, world!");

        var messages = request.GetInputMessages();

        Assert.That(messages.Count, Is.EqualTo(1));
        var message = messages.First();
        var textContent = message.Contents.OfType<TextContent>().FirstOrDefault();
        Assert.That(textContent, Is.Not.Null);
        Assert.That(textContent!.Text, Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void GetInputMessages_WithUserMessageItem_ParsesCorrectly()
    {
        var request = CreateRequestWithItems(new[]
        {
            CreateUserMessageItem("User message")
        });

        var messages = request.GetInputMessages();

        Assert.That(messages.Count, Is.EqualTo(1));
        var message = messages.First();
        Assert.That(message.Role, Is.EqualTo(ChatRole.User));
    }

    [Test]
    public void GetInputMessages_WithSystemMessageItem_ParsesCorrectly()
    {
        var request = CreateRequestWithItems(new[]
        {
            CreateSystemMessageItem("System prompt")
        });

        var messages = request.GetInputMessages();

        Assert.That(messages.Count, Is.EqualTo(1));
        var message = messages.First();
        Assert.That(message.Role, Is.EqualTo(ChatRole.System));
    }

    [Test]
    public void GetInputMessages_WithAssistantMessageItem_ParsesCorrectly()
    {
        var request = CreateRequestWithItems(new[]
        {
            CreateAssistantMessageItem("Assistant response")
        });

        var messages = request.GetInputMessages();

        Assert.That(messages.Count, Is.EqualTo(1));
        var message = messages.First();
        Assert.That(message.Role, Is.EqualTo(ChatRole.Assistant));
    }

    [Test]
    public void GetInputMessages_WithMultipleItems_ParsesAllMessages()
    {
        var request = CreateRequestWithItems(new[]
        {
            CreateSystemMessageItem("System prompt"),
            CreateUserMessageItem("User question"),
            CreateAssistantMessageItem("Assistant answer")
        });

        var messages = request.GetInputMessages();

        Assert.That(messages.Count, Is.EqualTo(3));
        Assert.That(messages.ElementAt(0).Role, Is.EqualTo(ChatRole.System));
        Assert.That(messages.ElementAt(1).Role, Is.EqualTo(ChatRole.User));
        Assert.That(messages.ElementAt(2).Role, Is.EqualTo(ChatRole.Assistant));
    }

    [Test]
    public void GetInputMessages_WithEmptyString_ReturnsMessageWithEmptyContent()
    {
        var request = CreateRequestWithStringInput("");

        var messages = request.GetInputMessages();

        Assert.That(messages.Count, Is.EqualTo(1));
    }

    [Test]
    public void GetInputMessages_PreservesMessageOrder()
    {
        var request = CreateRequestWithItems(new[]
        {
            CreateUserMessageItem("First"),
            CreateAssistantMessageItem("Second"),
            CreateUserMessageItem("Third")
        });

        var messages = request.GetInputMessages();
        var textContents = messages.Select(m =>
            m.Contents.OfType<TextContent>().FirstOrDefault()?.Text).ToList();

        Assert.That(textContents[0], Is.EqualTo("First"));
        Assert.That(textContents[1], Is.EqualTo("Second"));
        Assert.That(textContents[2], Is.EqualTo("Third"));
    }

    private static CreateResponseRequest CreateRequestWithStringInput(string input)
    {
        return new CreateResponseRequest
        {
            Input = BinaryData.FromString($"\"{input}\"")
        };
    }

    private static CreateResponseRequest CreateRequestWithItems(object[] items)
    {
        var json = JsonSerializer.Serialize(items);
        return new CreateResponseRequest
        {
            Input = BinaryData.FromString(json)
        };
    }

    private static object CreateUserMessageItem(string content)
    {
        return new
        {
            type = "message",
            role = "user",
            content = content
        };
    }

    private static object CreateSystemMessageItem(string content)
    {
        return new
        {
            type = "message",
            role = "system",
            content = content
        };
    }

    private static object CreateAssistantMessageItem(string content)
    {
        return new
        {
            type = "message",
            role = "assistant",
            content = content
        };
    }
}
