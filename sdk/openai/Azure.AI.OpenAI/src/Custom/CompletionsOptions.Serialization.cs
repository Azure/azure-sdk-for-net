// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    [CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
    public partial class CompletionsOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("prompt"u8);
            writer.WriteStartArray();
            foreach (var item in Prompts)
            {
                writer.WriteStringValue(item);
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
            if (Optional.IsCollectionDefined(TokenSelectionBiases))
            {
                writer.WritePropertyName("logit_bias"u8);
                writer.WriteStartObject();
                foreach (KeyValuePair<int, int> keyValuePair in TokenSelectionBiases)
                {
                    writer.WritePropertyName($"{keyValuePair.Key}");
                    writer.WriteNumberValue(keyValuePair.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(User))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(User);
            }
            if (Optional.IsDefined(ChoicesPerPrompt))
            {
                writer.WritePropertyName("n"u8);
                writer.WriteNumberValue(ChoicesPerPrompt.Value);
            }
            if (Optional.IsDefined(LogProbabilityCount))
            {
                writer.WritePropertyName("logprobs"u8);
                writer.WriteNumberValue(LogProbabilityCount.Value);
            }
            if (Optional.IsDefined(Echo))
            {
                writer.WritePropertyName("echo"u8);
                writer.WriteBooleanValue(Echo.Value);
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
            if (Optional.IsDefined(GenerationSampleCount))
            {
                writer.WritePropertyName("best_of"u8);
                writer.WriteNumberValue(GenerationSampleCount.Value);
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
            writer.WriteEndObject();
        }
    }
}
