// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Inference
{
    [CodeGenSuppress("FromResponse", typeof(Response))]
    [CodeGenSuppress("ToRequestContent")]
    public partial class StreamingFunctionToolCallUpdate
    {
        // CUSTOM CODE NOTE:
        //   This is an entirely custom-code-only type created to handle tool call details within a streaming chat
        //   completions response.
        internal static StreamingFunctionToolCallUpdate DeserializeStreamingFunctionToolCallUpdate(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string id = null;
            int toolCallIndex = 0;
            string functionName = null;
            string functionArgumentsUpdate = null;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                }
                if (property.NameEquals("index"u8))
                {
                    toolCallIndex = property.Value.GetInt32();
                }
                if (property.NameEquals("function"u8))
                {
                    foreach (JsonProperty functionProperty in property.Value.EnumerateObject())
                    {
                        if (functionProperty.NameEquals("name"u8))
                        {
                            functionName = functionProperty.Value.GetString();
                        }
                        if (functionProperty.NameEquals("arguments"u8))
                        {
                            functionArgumentsUpdate = functionProperty.Value.GetString();
                        }
                    }
                }
            }

            return new StreamingFunctionToolCallUpdate(id, toolCallIndex, functionName, functionArgumentsUpdate);
        }

        internal override void WriteDerivedDetails(Utf8JsonWriter writer)
        {
            writer.WritePropertyName("function"u8);
            writer.WriteStartObject();
            if (!string.IsNullOrEmpty(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (!string.IsNullOrEmpty(ArgumentsUpdate))
            {
                writer.WritePropertyName("arguments"u8);
                writer.WriteStringValue(ArgumentsUpdate);
            }
            writer.WriteEndObject();
        }
    }
}
