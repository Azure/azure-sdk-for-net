// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI;

public partial class CompletionsLogProbabilityModel
{
    internal static CompletionsLogProbabilityModel DeserializeCompletionsLogProbabilityModel(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Nested models should be set to null by parent model.");
        }

        IReadOnlyList<string>? tokens = default;
        IReadOnlyList<float?>? tokenLogprobs = default;
        IReadOnlyList<IDictionary<string, float?>>? topLogprobs = default;
        IReadOnlyList<int>? textOffset = default;

        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("tokens"u8))
            {
                List<string> array = new List<string>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    string? itemValue = item.GetString() ??
                        throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsLogProbabilityModel)}.'" +
                                                "'tokens' collection contains null value");
                    array.Add(itemValue);
                }
                tokens = array;
                continue;
            }
            if (property.NameEquals("token_logprobs"u8))
            {
                List<float?> array = new List<float?>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    if (item.ValueKind == JsonValueKind.Null)
                    {
                        array.Add(null);
                    }
                    else
                    {
                        array.Add(item.GetSingle());
                    }
                }
                tokenLogprobs = array;
                continue;
            }
            if (property.NameEquals("top_logprobs"u8))
            {
                List<IDictionary<string, float?>> array = new List<IDictionary<string, float?>>();
                foreach (JsonElement item in property.Value.EnumerateArray())
                {
                    if (item.ValueKind == JsonValueKind.Null)
                    {
                        throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsLogProbabilityModel)}.':  " +
                                                "'top_logprobs' collection contains null key value pair.");
                    }
                    else
                    {
                        Dictionary<string, float?> dictionary = new Dictionary<string, float?>();
                        foreach (var property0 in item.EnumerateObject())
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                dictionary.Add(property0.Name, null);
                            }
                            else
                            {
                                dictionary.Add(property0.Name, property0.Value.GetSingle());
                            }
                        }
                        array.Add(dictionary);
                    }
                }
                topLogprobs = array;
                continue;
            }
            if (property.NameEquals("text_offset"u8))
            {
                List<int> array = new List<int>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(item.GetInt32());
                }
                textOffset = array;
                continue;
            }
        }

        if (tokens is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsLogProbabilityModel)}': " +
                "Missing 'tokens' property.");
        }

        if (tokenLogprobs is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsLogProbabilityModel)}': " +
                "Missing 'token_logprobs' property.");
        }

        if (topLogprobs is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsLogProbabilityModel)}': " +
                "Missing 'top_logprobs' property.");
        }

        if (textOffset is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsLogProbabilityModel)}': " +
                "Missing 'text_offset' property.");
        }

        return new CompletionsLogProbabilityModel(tokens, tokenLogprobs, topLogprobs, textOffset);
    }

    /// <summary> Deserializes the model from a raw response. </summary>
    /// <param name="response"> The response to deserialize the model from. </param>
    internal static CompletionsLogProbabilityModel FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeCompletionsLogProbabilityModel(document.RootElement);
    }
}
