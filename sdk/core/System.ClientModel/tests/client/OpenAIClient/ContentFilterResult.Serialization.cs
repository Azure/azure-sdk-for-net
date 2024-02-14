// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI;

public partial class ContentFilterResult
{
    internal static ContentFilterResult DeserializeContentFilterResult(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsUsage)}'");
        }

        ContentFilterSeverity? severity = default;
        bool? filtered = default;

        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("severity"u8))
            {
                string? severityValue = property.Value.GetString();
                if (severityValue is null)
                {
                    throw new JsonException();
                }

                severity = new ContentFilterSeverity(severityValue);
                continue;
            }

            if (property.NameEquals("filtered"u8))
            {
                filtered = property.Value.GetBoolean();
                continue;
            }
        }

        if (severity is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsUsage)}': " +
                "Missing 'severity' property.");
        }

        if (filtered is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(CompletionsUsage)}': " +
                "Missing 'filtered' property.");
        }

        return new ContentFilterResult(severity!.Value, filtered!.Value);
    }

    /// <summary> Deserializes the model from a raw response. </summary>
    /// <param name="response"> The response to deserialize the model from. </param>
    internal static ContentFilterResult FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeContentFilterResult(document.RootElement);
    }
}
