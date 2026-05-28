// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Inference
{
    [CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<Azure.AI.Inference.ChatCompletionsOptions>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    public partial class ChatCompletionsOptions : IJsonModel<ChatCompletionsOptions>
    {
        // CUSTOM CODE NOTE:
        //   We manipulate the object model of this type relative to the wire format in several places; currently, this is
        //   best facilitated by performing a complete customization of the serialization.
        //TODO: Should use the property based serialization overrides here instead of the full serialization override.
        void IJsonModel<ChatCompletionsOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionsOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatCompletionsOptions)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("messages"u8);
            writer.WriteStartArray();
            foreach (var item in Messages)
            {
                writer.WriteObjectValue<ChatRequestMessage>(item, options);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(MaxTokens))
            {
                writer.WritePropertyName("max_tokens"u8);
                writer.WriteNumberValue(MaxTokens.Value);
            }
            if (Optional.IsDefined(Temperature))
            {
                writer.WritePropertyName("temperature"u8);
                writer.WriteNumberValue(Temperature.Value);
            }
            if (Optional.IsDefined(NucleusSamplingFactor))
            {
                writer.WritePropertyName("top_p"u8);
                writer.WriteNumberValue(NucleusSamplingFactor.Value);
            }
            if (Optional.IsCollectionDefined(StopSequences))
            {
                writer.WritePropertyName("stop"u8);
                writer.WriteStartArray();
                foreach (var item in StopSequences)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PresencePenalty))
            {
                writer.WritePropertyName("presence_penalty"u8);
                writer.WriteNumberValue(PresencePenalty.Value);
            }
            if (Optional.IsDefined(FrequencyPenalty))
            {
                writer.WritePropertyName("frequency_penalty"u8);
                writer.WriteNumberValue(FrequencyPenalty.Value);
            }
            if (Optional.IsDefined(InternalShouldStreamResponse))
            {
                writer.WritePropertyName("stream"u8);
                writer.WriteBooleanValue(InternalShouldStreamResponse.Value);
            }
            if (Optional.IsDefined(Seed))
            {
                writer.WritePropertyName("seed"u8);
                writer.WriteNumberValue(Seed.Value);
            }
            if (Optional.IsDefined(Model))
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(Model);
            }
            if (Optional.IsDefined(ResponseFormat))
            {
                writer.WritePropertyName("response_format"u8);
                writer.WriteObjectValue<ChatCompletionsResponseFormat>(ResponseFormat, options);
            }
            if (Optional.IsCollectionDefined(Tools))
            {
                writer.WritePropertyName("tools"u8);
                writer.WriteStartArray();
                foreach (var item in Tools)
                {
                    writer.WriteObjectValue<ChatCompletionsToolDefinition>(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ToolChoice))
            {
                // CUSTOM CODE NOTE:
                //   ChatCompletionsToolChoice is a fully custom type and needs integrated custom serialization here.
                writer.WritePropertyName("tool_choice"u8);
                writer.WriteObjectValue<ChatCompletionsToolChoice>(ToolChoice, options);
            }
            if (Optional.IsDefined(AdditionalProperties))
            {
                foreach (var item in AdditionalProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }
    }
}
