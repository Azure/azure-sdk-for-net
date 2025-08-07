// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Inference
{
    [CodeGenSuppress("FromResponse", typeof(Response))]
    [CodeGenSuppress("ToRequestContent")]
    public abstract partial class StreamingToolCallUpdate : IUtf8JsonSerializable
    {
        // CUSTOM CODE NOTE:
        //   Like StreamingChatCompletionsUpdate, StreamingToolCallUpdate is an entirely custom abstraction for streamed
        //   response content related to Chat Completions -- this instance, for tool calls. Its deserialization defers to
        //   the appropriate concrete type and its serialization (unused) writes common/partial contents before deferring
        //   to concrete types' additional data serialization.

        internal static StreamingToolCallUpdate DeserializeStreamingToolCallUpdate(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            foreach (JsonProperty property in element.EnumerateObject())
            {
                // CUSTOM CODE NOTE:
                //   "type" is superficially the JSON discriminator for possible tool call categories, but it does not
                //   appear on every streamed delta message. To account for this without maintaining state, we instead
                //   allow the deserialization to infer the type based on the presence of the named/typed key. This is
                //   consistent across all existing patterns of the form:
                //   {
                //     "type": "<foo>"
                //     "<foo>": { ... }
                //   }
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
}
