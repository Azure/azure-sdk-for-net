// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class Completions
{
    // CUSTOM CODE NOTE:
    //   This fully customized deserialization allows us to support the legacy 'prompt_annotations' field name
    //   for 'prompt_filter_results' until all model versions fully migrate.

    internal static Completions DeserializeCompletions(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= new ModelReaderWriterOptions("W");

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        string id = default;
        DateTimeOffset created = default;
        Optional<IReadOnlyList<ContentFilterResultsForPrompt>> promptFilterResults = default;
        IReadOnlyList<Choice> choices = default;
        CompletionsUsage usage = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
            // CUSTOM CODE NOTE: temporary, custom handling of forked keys for prompt filter results
            if (property.NameEquals("prompt_annotations"u8) || property.NameEquals("prompt_filter_results"))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                List<ContentFilterResultsForPrompt> array = new List<ContentFilterResultsForPrompt>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    array.Add(ContentFilterResultsForPrompt.DeserializeContentFilterResultsForPrompt(item));
                }
                promptFilterResults = array;
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
            if (options.Format != "W")
            {
                additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = additionalPropertiesDictionary;
        return new Completions(id, created, Optional.ToList(promptFilterResults), choices, usage, serializedAdditionalRawData);
    }
}
