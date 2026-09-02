// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using OpenAI.Responses;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

/// <summary>
/// Builds <see cref="MessageResponseItem"/> instances for tests.
/// </summary>
/// <remarks>
/// <see cref="MessageResponseItem"/> has no public constructor — OpenAI exposes the
/// role-specific <c>ResponseItem.Create*MessageItem</c> factories instead. These helpers keep
/// the role a parameter so the table-driven tests can stay table-driven.
/// </remarks>
internal static class MessageItemFactory
{
    public static MessageResponseItem Message(MessageRole role, IEnumerable<ResponseContentPart> content)
    {
        MessageResponseItem item = role switch
        {
            MessageRole.User => ResponseItem.CreateUserMessageItem(content),
            MessageRole.Developer => ResponseItem.CreateDeveloperMessageItem(content),
            MessageRole.System => ResponseItem.CreateSystemMessageItem(content),
            MessageRole.Assistant => ResponseItem.CreateAssistantMessageItem(content),
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, "Unsupported message role."),
        };

        return item;
    }

    public static MessageResponseItem Message(MessageRole role, BinaryData content)
        => Message(role, ParseContent(content));

    public static MessageResponseItem Message(MessageRole role, string content)
        => Message(role, new[] { ResponseContentPart.CreateInputTextPart(content) });

    public static MessageResponseItem OutputMessage(
        string id,
        MessageStatus status,
        MessageRole role,
        IEnumerable<ResponseContentPart> content)
    {
        MessageResponseItem item = Message(role, content);
        item.Id = id;
        item.Status = status;
        return item;
    }

    public static MessageResponseItem OutputMessage(
        string id,
        MessageStatus status,
        IEnumerable<ResponseContentPart> content)
        => OutputMessage(id, status, MessageRole.Assistant, content);

    private static List<ResponseContentPart> ParseContent(BinaryData content)
    {
        var parts = new List<ResponseContentPart>();
        using var document = System.Text.Json.JsonDocument.Parse(content);
        if (document.RootElement.ValueKind == System.Text.Json.JsonValueKind.String)
        {
            parts.Add(ResponseContentPart.CreateInputTextPart(document.RootElement.GetString()!));
            return parts;
        }

        foreach (var element in document.RootElement.EnumerateArray())
        {
            parts.Add(ModelReaderWriter.Read<ResponseContentPart>(
                BinaryData.FromString(element.GetRawText()),
                ModelReaderWriterOptions.Json,
                AzureAIAgentServerResponsesContext.Default)!);
        }

        return parts;
    }
}
