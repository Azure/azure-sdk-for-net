// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using ClientModel.Tests.ClientShared;

namespace OpenAI;

public partial class Completions
{
    internal static Completions DeserializeCompletions(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Completions)}'");
        }

        string? id = default;
        DateTimeOffset? created = default;
        IReadOnlyList<Choice>? choices = default;
        CompletionsUsage? usage = default;
        OptionalProperty<IReadOnlyList<PromptFilterResult>> promptAnnotations = default;

        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("id"u8))
            {
                id = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("created"u8))
            {
                created = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                continue;
            }
            if (property.NameEquals("prompt_annotations"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                List<PromptFilterResult> array = new List<PromptFilterResult>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(PromptFilterResult.DeserializePromptFilterResult(item));
                }
                promptAnnotations = array;
                continue;
            }
            if (property.NameEquals("choices"u8))
            {
                List<Choice> array = new List<Choice>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(Choice.DeserializeChoice(item));
                }
                choices = array;
                continue;
            }
            if (property.NameEquals("usage"u8))
            {
                usage = CompletionsUsage.DeserializeCompletionsUsage(property.Value);
                continue;
            }
        }

        if (id is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Completions)}': " +
                "Missing 'id' property.");
        }

        if (created is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Completions)}': " +
                "Missing 'created' property.");
        }

        if (choices is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Completions)}': " +
                "Missing 'choices' property.");
        }

        if (usage is null)
        {
            throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(Completions)}': " +
                "Missing 'usage' property.");
        }

        return new Completions(id, created!.Value, OptionalProperty.ToList(promptAnnotations), choices, usage);
    }

    /// <summary> Deserializes the model from a raw response. </summary>
    /// <param name="response"> The response to deserialize the model from. </param>
    internal static Completions FromResponse(PipelineResponse response)
    {
        using var document = JsonDocument.Parse(response.Content);
        return DeserializeCompletions(document.RootElement);
    }
}
