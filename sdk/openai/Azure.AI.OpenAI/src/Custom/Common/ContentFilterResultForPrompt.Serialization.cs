// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI;

public partial class ContentFilterResultForPrompt
{
    internal static ContentFilterResultForPrompt DeserializeContentFilterResultForPrompt(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        int? promptIndex = default;
        InternalAzureContentFilterResultForPromptContentFilterResults contentFilterResults = default;
        IDictionary<string, BinaryData> serializedAdditionalRawData = default;
        Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
        foreach (var property in element.EnumerateObject())
        {
            if (property.NameEquals("prompt_index"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                promptIndex = property.Value.GetInt32();
                continue;
            }
            if (property.NameEquals("content_filter_results"u8)
                // CUSTOMIZATION: some models, such as gpt-4o, observationally use a different, singular label
                || property.NameEquals("content_filter_result"u8))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                contentFilterResults = InternalAzureContentFilterResultForPromptContentFilterResults.DeserializeInternalAzureContentFilterResultForPromptContentFilterResults(property.Value, options);
                continue;
            }
            if (options.Format != "W")
            {
                rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        serializedAdditionalRawData = rawDataDictionary;
        return new ContentFilterResultForPrompt(promptIndex, contentFilterResults, serializedAdditionalRawData);
    }
}