// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using ClientModel.Tests.ClientShared;

namespace OpenAI;

public partial class Choice
{
    internal static Choice DeserializeChoice(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Choice)}'");
        }

        string? text = default;
        int? index = default;
        OptionalProperty<ContentFilterResults> contentFilterResults = default;
        CompletionsLogProbabilityModel? logprobs = default;
        CompletionsFinishReason? finishReason = default;

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("text"u8))
            {
                text = property.Value.GetString();
                continue;
            }

            if (property.NameEquals("index"u8))
            {
                index = property.Value.GetInt32();
                continue;
            }

            if (property.NameEquals("content_filter_results"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                contentFilterResults = ContentFilterResults.DeserializeContentFilterResults(property.Value);
                continue;
            }

            if (property.NameEquals("logprobs"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    logprobs = null;
                    continue;
                }
                logprobs = CompletionsLogProbabilityModel.DeserializeCompletionsLogProbabilityModel(property.Value);
                continue;
            }

            if (property.NameEquals("finish_reason"u8))
            {
                string? finishReasonValue = property.Value.GetString();

                if (finishReasonValue is null)
                {
                    finishReason = null;
                    continue;
                }

                finishReason = new CompletionsFinishReason(finishReasonValue);
                continue;
            }
        }

        if (text is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Choice)}': Missing 'text' property.");
        }

        if (index is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Choice)}': Missing 'index' property.");
        }

        return new Choice(text, index.Value, contentFilterResults.Value, logprobs, finishReason);
    }

    /// <summary> Deserializes the model from a raw response. </summary>
    /// <param name="response"> The response to deserialize the model from. </param>
    internal static Choice FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeChoice(document.RootElement);
    }
}
