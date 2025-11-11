// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents;

internal static partial class ResponseItemHelpers
{
    internal static void DeserializeItemsValue(JsonProperty property, ref IList<OpenAI.Responses.ResponseItem> items)
    {
        if (property.Value.ValueKind == JsonValueKind.Array)
        {
            List<OpenAI.Responses.ResponseItem> deserializedItems = [];
            foreach (JsonElement serializedResponseItemElement in property.Value.EnumerateArray())
            {
                OpenAI.Responses.ResponseItem deserializedItem = ModelReaderWriter.Read<OpenAI.Responses.ResponseItem>(
                    BinaryData.FromString(serializedResponseItemElement.GetRawText()),
                    ModelReaderWriterOptions.Json,
                    OpenAI.OpenAIContext.Default);
                deserializedItems.Add(deserializedItem);
            }
            items = deserializedItems;
        }
    }
}
