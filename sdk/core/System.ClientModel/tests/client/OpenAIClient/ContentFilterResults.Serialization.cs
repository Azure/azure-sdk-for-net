// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using ClientModel.Tests.ClientShared;

namespace OpenAI;

public partial class ContentFilterResults
{
    internal static ContentFilterResults DeserializeContentFilterResults(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(ContentFilterResults)}'");
        }

        OptionalProperty<ContentFilterResult> sexual = default;
        OptionalProperty<ContentFilterResult> violence = default;
        OptionalProperty<ContentFilterResult> hate = default;
        OptionalProperty<ContentFilterResult> selfHarm = default;

        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("sexual"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                sexual = ContentFilterResult.DeserializeContentFilterResult(property.Value);
                continue;
            }
            if (property.NameEquals("violence"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                violence = ContentFilterResult.DeserializeContentFilterResult(property.Value);
                continue;
            }
            if (property.NameEquals("hate"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                hate = ContentFilterResult.DeserializeContentFilterResult(property.Value);
                continue;
            }
            if (property.NameEquals("self_harm"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                selfHarm = ContentFilterResult.DeserializeContentFilterResult(property.Value);
                continue;
            }
        }

        return new ContentFilterResults(sexual.Value, violence.Value, hate.Value, selfHarm.Value);
    }

    /// <summary> Deserializes the model from a raw response. </summary>
    /// <param name="response"> The response to deserialize the model from. </param>
    internal static ContentFilterResults FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeContentFilterResults(document.RootElement);
    }
}
