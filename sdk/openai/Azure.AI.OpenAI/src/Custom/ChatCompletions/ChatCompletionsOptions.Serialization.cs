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
    //   We manipulate the object model of this type relative to the wire format in several places; currently, this is
    //   best facilitated by performing a complete customization of the serialization.

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
            // CUSTOM CODE NOTE:
            //   This is an important custom deserialization step for the intended merging of presets (none, auto)
            //   and named function definitions. Because presets serialize as a string instead of as object contents,
            //   the customization has to occur at this parent options level.
            writer.WritePropertyName("function_call"u8);
            if (FunctionCall.IsPredefined)
            {
                writer.WriteStringValue(FunctionCall.Name);
            }
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName("name");
                writer.WriteStringValue(FunctionCall.Name);
                writer.WriteEndObject();
            }
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
        if (Optional.IsCollectionDefined(TokenSelectionBiases))
        {
            writer.WritePropertyName("logit_bias"u8);
            SerializeTokenSelectionBiases(writer);
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
            writer.WriteObjectValue(ResponseFormat);
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
            // CUSTOM CODE NOTE:
            //   ChatCompletionsToolChoice is a fully custom type and needs integrated custom serialization here.
            writer.WritePropertyName("tool_choice"u8);
            writer.WriteObjectValue(ToolChoice);
        }
        writer.WriteEndObject();
    }
}
