// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.AI.ChatProtocol;

public partial class ChatMessage
{
    internal static ChatMessage DeserializeChatMessage(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        if (element.TryGetProperty("kind", out JsonElement discriminator))
        {
            return discriminator.GetString() switch
            {
                "text" => TextChatMessage.DeserializeTextChatMessage(element),
                _ => UnknownChatMessage.DeserializeUnknownChatMessage(element),
            };
        }
        /* If kind is not specified, we assume it is a text message. */
        return TextChatMessage.DeserializeTextChatMessage(element);
    }
}
