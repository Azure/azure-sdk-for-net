// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class ChatCompletionsToolCall : IUtf8JsonSerializable
{
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
        // CUSTOM CODE NOTE: streamed tool calls drop the explicit discriminators after the first SSE message. This
        // allows us to infer the discriminator from the payload.
        if (element.TryGetProperty("function", out JsonElement _))
        {
            return ChatCompletionsFunctionToolCall.DeserializeChatCompletionsFunctionToolCall(element);
        }
        return UnknownChatCompletionsToolCall.DeserializeUnknownChatCompletionsToolCall(element);
    }
}
