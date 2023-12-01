// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
public partial class ChatCompletionsOptions : IUtf8JsonSerializable
{
    // CUSTOM CODE NOTE:
    //   This customized serialization allows us to reproject the logit_bias map of Token IDs to scores as the wire-
    //   encoded, string-keyed map it must be sent as.

    void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("messages"u8);
        writer.WriteStartArray();
        foreach (var item in Messages)
        {
            writer.WriteObjectValue(item);
        }
        writer.WriteEndArray();
        if (Optional.IsCollectionDefined(Functions))
        {
            writer.WritePropertyName("functions"u8);
            writer.WriteStartArray();
            foreach (var item in Functions)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
        }
        if (Optional.IsDefined(FunctionCall))
        {
            writer.WritePropertyName("function_call"u8);
            writer.WriteObjectValue(FunctionCall);
        }
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
        // CUSTOM: serialize <int, int> to <string, int>
        if (Optional.IsCollectionDefined(TokenSelectionBiases))
        {
            writer.WritePropertyName("logit_bias"u8);
            writer.WriteStartObject();
            foreach (var item in TokenSelectionBiases)
            {
                writer.WritePropertyName($"{item.Key}");
                writer.WriteNumberValue(item.Value);
            }
            writer.WriteEndObject();
        }
        if (Optional.IsDefined(User))
        {
            writer.WritePropertyName("user"u8);
            writer.WriteStringValue(User);
        }
        if (Optional.IsDefined(ChoiceCount))
        {
            writer.WritePropertyName("n"u8);
            writer.WriteNumberValue(ChoiceCount.Value);
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
        if (Optional.IsDefined(DeploymentName))
        {
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(DeploymentName);
        }
        if (AzureExtensionsOptions != null)
        {
            // CUSTOM CODE NOTE: Extensions options currently deserialize directly into the payload (not as a
            //                      property value therein)
            ((IUtf8JsonSerializable)AzureExtensionsOptions).Write(writer);
        }
        if (Optional.IsDefined(Enhancements))
        {
            writer.WritePropertyName("enhancements"u8);
            writer.WriteObjectValue(Enhancements);
        }
        if (Optional.IsDefined(Seed))
        {
            writer.WritePropertyName("seed"u8);
            writer.WriteNumberValue(Seed.Value);
        }
        if (Optional.IsDefined(ResponseFormat))
        {
            writer.WritePropertyName("response_format"u8);
            writer.WriteStringValue(ResponseFormat.Value.ToString());
        }
        if (Optional.IsCollectionDefined(Tools))
        {
            writer.WritePropertyName("tools"u8);
            writer.WriteStartArray();
            foreach (var item in Tools)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
        }
        if (Optional.IsDefined(ToolChoice))
        {
            writer.WritePropertyName("tool_choice"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(ToolChoice);
#else
            using (JsonDocument document = JsonDocument.Parse(ToolChoice))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
        }
        writer.WriteEndObject();
    }
}
