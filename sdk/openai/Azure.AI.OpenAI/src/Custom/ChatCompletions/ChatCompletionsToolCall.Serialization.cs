// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class ChatCompletionsToolCall : IUtf8JsonSerializable
{
    // CUSTOM CODE NOTE:
    //   This customization allows us to infer that a tool call is of "function" type in streaming scenarios where
    //   the "type" discriminator is omitted. We instead use the presence of the "function" key in those situations.

    internal static ChatCompletionsToolCall DeserializeChatCompletionsToolCall(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        if (element.TryGetProperty("type", out JsonElement discriminator))
        {
            switch (discriminator.GetString())
            {
                case "function": return ChatCompletionsFunctionToolCall.DeserializeChatCompletionsFunctionToolCall(element);
            }
        }
        if (element.TryGetProperty("function", out JsonElement _))
        {
            return ChatCompletionsFunctionToolCall.DeserializeChatCompletionsFunctionToolCall(element);
        }
        return UnknownChatCompletionsToolCall.DeserializeUnknownChatCompletionsToolCall(element);
    }
}
