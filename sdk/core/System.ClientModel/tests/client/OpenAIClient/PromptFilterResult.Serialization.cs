// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.ClientShared;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI;

public partial class PromptFilterResult
{
    internal static PromptFilterResult DeserializePromptFilterResult(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(PromptFilterResult)}'");
        }
        int promptIndex = default;
        OptionalProperty<ContentFilterResults> contentFilterResults = default;
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("prompt_index"u8))
            {
                promptIndex = property.Value.GetInt32();
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
        }
        return new PromptFilterResult(promptIndex, contentFilterResults.Value);
    }

    /// <summary> Deserializes the model from a raw response. </summary>
    /// <param name="response"> The response to deserialize the model from. </param>
    internal static PromptFilterResult FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializePromptFilterResult(document.RootElement);
    }
}
