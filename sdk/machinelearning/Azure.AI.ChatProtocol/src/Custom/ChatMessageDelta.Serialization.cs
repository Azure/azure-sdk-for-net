// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.AI.ChatProtocol;

public partial class ChatMessageDelta
{
    internal static ChatMessageDelta DeserializeChatMessageDelta(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        if (element.TryGetProperty("kind", out JsonElement discriminator))
        {
            return discriminator.GetString() switch
            {
                "text" => TextChatMessageDelta.DeserializeTextChatMessageDelta(element),
                _ => UnknownChatMessageDelta.DeserializeUnknownChatMessageDelta(element),
            };
        }
        /* If kind is not specified, we assume it is a text message. */
        return TextChatMessageDelta.DeserializeTextChatMessageDelta(element);
    }
}
