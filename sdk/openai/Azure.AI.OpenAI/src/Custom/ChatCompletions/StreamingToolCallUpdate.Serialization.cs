// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("FromResponse", typeof(Response))]
[CodeGenSuppress("ToRequestContent")]
public abstract partial class StreamingToolCallUpdate : IUtf8JsonSerializable
{
    // CUSTOM CODE NOTE:
    //   This customization allows us to infer that a tool call is of "function" type in streaming scenarios where
    //   the "type" discriminator is omitted. We instead use the presence of the "function" key in those situations.

    internal static StreamingToolCallUpdate DeserializeStreamingToolCallUpdate(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("type"u8))
            {
                if (property.Value.GetString() == "function")
                {
                    return StreamingFunctionToolCallUpdate.DeserializeStreamingFunctionToolCallUpdate(element);
                }
            }
            else if (property.NameEquals("function"u8))
            {
                return StreamingFunctionToolCallUpdate.DeserializeStreamingFunctionToolCallUpdate(element);
            }
        }
        return null;
    }

    void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
    {
        writer.WritePropertyName("type"u8);
        writer.WriteStringValue(Type);
        writer.WritePropertyName("id"u8);
        writer.WriteStringValue(Id);
        writer.WritePropertyName("index"u8);
        writer.WriteNumberValue(ToolCallIndex);
        if (this is StreamingFunctionToolCallUpdate streamingFunctionToolCallUpdate)
        {
            streamingFunctionToolCallUpdate.WriteDerivedDetails(writer);
        }
    }
}
