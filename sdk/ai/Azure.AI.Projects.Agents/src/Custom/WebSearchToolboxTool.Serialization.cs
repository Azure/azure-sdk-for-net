// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;

[CodeGenSerialization(nameof(SearchContextSize), SerializationValueHook = nameof(SerializeSearchContextSizeValue), DeserializationValueHook = nameof(DeserializeSearchContextSizeValue))]
public partial class WebSearchToolboxTool
{
    // CUSTOM: WebSearchToolContextSize is a string-valued struct from the OpenAI library, not a model. The generated
    // code routes it through ModelReaderWriter, which throws "No ModelReaderWriterTypeBuilder found".
    // Read and write it as a JSON string instead.
    private void SerializeSearchContextSizeValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStringValue(SearchContextSize.Value.ToString());
    }

    private static void DeserializeSearchContextSizeValue(JsonProperty property, ref WebSearchToolContextSize? searchContextSize, ModelReaderWriterOptions options = null)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            searchContextSize = null;
            return;
        }
        searchContextSize = new WebSearchToolContextSize(property.Value.GetString());
    }
}
