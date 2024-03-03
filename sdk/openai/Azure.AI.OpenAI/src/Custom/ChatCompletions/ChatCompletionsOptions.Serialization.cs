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
        if (!(Functions is ChangeTrackingList<FunctionDefinition> changeTrackingList && changeTrackingList.IsUndefined))
        {
            writer.WritePropertyName("functions"u8);
            writer.WriteStartArray();
            foreach (var item in Functions)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
        }
        if (FunctionCall != null)
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
        if (MaxTokens.HasValue)
        {
            writer.WritePropertyName("max_tokens"u8);
            writer.WriteNumberValue(MaxTokens.Value);
        }
        if (Temperature.HasValue)
        {
            writer.WritePropertyName("temperature"u8);
            writer.WriteNumberValue(Temperature.Value);
        }
        if (NucleusSamplingFactor.HasValue)
        {
            writer.WritePropertyName("top_p"u8);
            writer.WriteNumberValue(NucleusSamplingFactor.Value);
        }
        if (!(TokenSelectionBiases is ChangeTrackingDictionary<int, int> changeTrackingList0 && changeTrackingList0.IsUndefined))
        {
            writer.WritePropertyName("logit_bias"u8);
            SerializeTokenSelectionBiases(writer);
        }
        if (User != null)
        {
            writer.WritePropertyName("user"u8);
            writer.WriteStringValue(User);
        }
        if (ChoiceCount.HasValue)
        {
            writer.WritePropertyName("n"u8);
            writer.WriteNumberValue(ChoiceCount.Value);
        }
        if (!(StopSequences is ChangeTrackingList<string> changeTrackingList1 && changeTrackingList1.IsUndefined))
        {
            writer.WritePropertyName("stop"u8);
            writer.WriteStartArray();
            foreach (var item in StopSequences)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
        }
        if (PresencePenalty.HasValue)
        {
            writer.WritePropertyName("presence_penalty"u8);
            writer.WriteNumberValue(PresencePenalty.Value);
        }
        if (FrequencyPenalty.HasValue)
        {
            writer.WritePropertyName("frequency_penalty"u8);
            writer.WriteNumberValue(FrequencyPenalty.Value);
        }
        if (InternalShouldStreamResponse.HasValue)
        {
            writer.WritePropertyName("stream"u8);
            writer.WriteBooleanValue(InternalShouldStreamResponse.Value);
        }
        if (DeploymentName != null)
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
        if (Enhancements != null)
        {
            writer.WritePropertyName("enhancements"u8);
            writer.WriteObjectValue(Enhancements);
        }
        if (Seed.HasValue)
        {
            writer.WritePropertyName("seed"u8);
            writer.WriteNumberValue(Seed.Value);
        }
        if (ResponseFormat != null)
        {
            writer.WritePropertyName("response_format"u8);
            writer.WriteObjectValue(ResponseFormat);
        }
        if (!(Tools is ChangeTrackingList<ChatCompletionsToolDefinition> changeTrackingList2 && changeTrackingList2.IsUndefined))
        {
            writer.WritePropertyName("tools"u8);
            writer.WriteStartArray();
            foreach (var item in Tools)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
        }
        if (ToolChoice != null)
        {
            // CUSTOM CODE NOTE:
            //   ChatCompletionsToolChoice is a fully custom type and needs integrated custom serialization here.
            writer.WritePropertyName("tool_choice"u8);
            writer.WriteObjectValue(ToolChoice);
        }
        writer.WriteEndObject();
    }
}
