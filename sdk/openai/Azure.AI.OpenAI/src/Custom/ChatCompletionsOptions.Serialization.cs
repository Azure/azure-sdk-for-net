// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    [CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
    public partial class ChatCompletionsOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(DeploymentName))
            {
                writer.WritePropertyName("model"u8);
                writer.WriteStringValue(DeploymentName);
            }
            writer.WritePropertyName("messages"u8);
            writer.WriteStartArray();
            foreach (var item in Messages)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(Functions) && Functions.Count > 0)
            {
                writer.WritePropertyName("functions"u8);
                writer.WriteStartArray();
                foreach (var item in Functions)
                {
                    if (item.IsPredefined)
                    {
                        throw new ArgumentException(
                            @"Predefined function definitions such as 'auto' and 'none' cannot be provided as
                            custom functions. These should only be used to constrain the FunctionCall option.");
                    }
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(FunctionCall))
            {
                writer.WritePropertyName("function_call");

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
                if (MaxTokens != null)
                {
                    writer.WritePropertyName("max_tokens"u8);
                    writer.WriteNumberValue(MaxTokens.Value);
                }
                else
                {
                    writer.WriteNull("max_tokens");
                }
            }
            if (Optional.IsDefined(Temperature))
            {
                if (Temperature != null)
                {
                    writer.WritePropertyName("temperature"u8);
                    writer.WriteNumberValue(Temperature.Value);
                }
                else
                {
                    writer.WriteNull("temperature");
                }
            }
            if (Optional.IsDefined(NucleusSamplingFactor))
            {
                if (NucleusSamplingFactor != null)
                {
                    writer.WritePropertyName("top_p"u8);
                    writer.WriteNumberValue(NucleusSamplingFactor.Value);
                }
                else
                {
                    writer.WriteNull("top_p");
                }
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
                if (ChoiceCount != null)
                {
                    writer.WritePropertyName("n"u8);
                    writer.WriteNumberValue(ChoiceCount.Value);
                }
                else
                {
                    writer.WriteNull("n");
                }
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
                if (PresencePenalty != null)
                {
                    writer.WritePropertyName("presence_penalty"u8);
                    writer.WriteNumberValue(PresencePenalty.Value);
                }
                else
                {
                    writer.WriteNull("presence_penalty");
                }
            }
            if (Optional.IsDefined(FrequencyPenalty))
            {
                if (FrequencyPenalty != null)
                {
                    writer.WritePropertyName("frequency_penalty"u8);
                    writer.WriteNumberValue(FrequencyPenalty.Value);
                }
                else
                {
                    writer.WriteNull("frequency_penalty");
                }
            }
            if (Optional.IsDefined(InternalShouldStreamResponse))
            {
                if (InternalShouldStreamResponse != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(InternalShouldStreamResponse.Value);
                }
                else
                {
                    writer.WriteNull("stream");
                }
            }
            if (AzureExtensionsOptions != null)
            {
                // CUSTOM CODE NOTE: Extensions options currently deserialize directly into the payload (not as a
                //                      property value therein)
                ((IUtf8JsonSerializable)AzureExtensionsOptions).Write(writer);
            }
            writer.WriteEndObject();
        }
    }
}
