// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI;

public partial class CompletionsUsage
{
    internal static CompletionsUsage DeserializeCompletionsUsage(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsUsage)}'");
        }

        int? completionTokens = default;
        int? promptTokens = default;
        int? totalTokens = default;

        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("completion_tokens"u8))
            {
                completionTokens = property.Value.GetInt32();
                continue;
            }
            if (property.NameEquals("prompt_tokens"u8))
            {
                promptTokens = property.Value.GetInt32();
                continue;
            }
            if (property.NameEquals("total_tokens"u8))
            {
                totalTokens = property.Value.GetInt32();
                continue;
            }
        }

        if (completionTokens is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsUsage)}': " +
                "Missing 'completion_tokens' property.");
        }

        if (promptTokens is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsUsage)}': " +
                "Missing 'prompt_tokens' property.");
        }

        if (totalTokens is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsUsage)}': " +
                "Missing 'total_tokens' property.");
        }

        return new CompletionsUsage(completionTokens.Value, promptTokens.Value, totalTokens.Value);
    }

    /// <summary> Deserializes the model from a raw response. </summary>
    /// <param name="response"> The response to deserialize the model from. </param>
    internal static CompletionsUsage FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeCompletionsUsage(document.RootElement);
    }
}
