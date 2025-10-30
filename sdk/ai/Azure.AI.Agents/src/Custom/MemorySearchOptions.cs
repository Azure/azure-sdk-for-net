// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents;

[CodeGenType("MemorySearchOptions")]
[CodeGenSerialization(nameof(Items), PropertySerializationName = "items", DeserializationValueHook = nameof(DeserializeItemsValue))]
public partial class MemorySearchOptions
{
    /// <summary> Items for which to search for relevant memories. Only one of conversation_id or items should be provided. </summary>
    [CodeGenMember("Items")]
    public IList<OpenAI.Responses.ResponseItem> Items { get; }

    private static void DeserializeItemsValue(JsonProperty property, ref IList<OpenAI.Responses.ResponseItem> items)
        => ResponseItemHelpers.DeserializeItemsValue(property, ref items);
}
