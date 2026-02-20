// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using System.Text.Json;

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.Json;

using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Converters;

/// <summary>
/// Provides extension methods for converting request objects to AI framework types.
/// </summary>
public static class RequestConverterExtensions
{
    private static readonly JsonSerializerOptions Json = JsonExtensions.DefaultJsonSerializerOptions;

    /// <summary>
    /// Converts a create response request to a collection of chat messages.
    /// </summary>
    /// <param name="request">The create response request to convert.</param>
    /// <returns>A read-only collection of chat messages extracted from the request input.</returns>
    public static IReadOnlyCollection<ChatMessage> GetInputMessages(this CreateResponseRequest request)
    {
        var items = request.Input.ToObject<IList<ItemParam>>();
        if (items is { Count: > 0 })
        {
            var messages = items
                .Select(item =>
                    {
                        ChatRole role;
                        BinaryData? rawContent;
                        switch (item)
                        {
                            case ResponsesAssistantMessageItemParam assistantMessage:
                                role = ChatRole.Assistant;
                                rawContent = assistantMessage.Content;
                                break;
                            case ResponsesSystemMessageItemParam systemMessage:
                                role = ChatRole.System;
                                rawContent = systemMessage.Content;
                                break;
                            case ResponsesUserMessageItemParam userMessage:
                                role = ChatRole.User;
                                rawContent = userMessage.Content;
                                break;
                            case UnknownItemParam unknownItem:
                                role = ChatRole.User;
                                rawContent = unknownItem.TryParseImplicitUserContent();
                                break;
                            default:
                                return null;
                        }

                        var content = rawContent == null
                            ? null
                            : rawContent.ToObject<IList<ItemContent>>() ??
                              [new ItemContentInputText(rawContent.ToString())];

                        var aiContents = (content ?? ReadOnlyCollection<ItemContent>.Empty)
                            .Select(c => c is ItemContentInputText textContent ? textContent : null)
                            .Where(c => c != null)
                            .Select(AIContent (c) => new TextContent(c!.Text))
                            .ToList();
                        return new ChatMessage(role, aiContents);
                    }
                )
                .Where(msg => msg != null)
                .ToList();
            return messages as IReadOnlyCollection<ChatMessage>;
        }

        var strMessage = request.Input.ToString();
        return [new ChatMessage(ChatRole.User, strMessage)];
    }

    private static BinaryData? TryParseImplicitUserContent(this UnknownItemParam item)
    {
        return item.SerializedAdditionalRawData.TryGetValue("content", out var rawContent) ? rawContent : null;
    }
}
