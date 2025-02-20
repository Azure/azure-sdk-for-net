// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Inference
{
    public partial class StreamingChatResponseMessageUpdate : IUtf8JsonSerializable, IJsonModel<StreamingChatResponseMessageUpdate>
    {
        internal static StreamingChatResponseMessageUpdate DeserializeStreamingChatResponseMessageUpdate(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ChatRole? role = default;
            string content = default;
            List<StreamingChatResponseToolCallUpdate> toolCalls = new List<StreamingChatResponseToolCallUpdate>();
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("role"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    role = new ChatRole(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("content"u8))
                {
                    content = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tool_calls"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<StreamingChatResponseToolCallUpdate> array = new List<StreamingChatResponseToolCallUpdate>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(StreamingChatResponseToolCallUpdate.DeserializeStreamingChatResponseToolCallUpdate(item, options));
                    }
                    toolCalls = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;

            if (toolCalls.Count == 0)
            {
                toolCalls.Add(null);
            }

            return new StreamingChatResponseMessageUpdate(role, content, toolCalls, serializedAdditionalRawData);
        }
    }
}
