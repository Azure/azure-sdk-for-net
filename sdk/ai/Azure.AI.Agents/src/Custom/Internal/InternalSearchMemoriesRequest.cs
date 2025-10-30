// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents;

[CodeGenType("SearchMemoriesRequest")]
[CodeGenSerialization(nameof(Items), PropertySerializationName = "items", DeserializationValueHook = nameof(DeserializeItemsValue))]
internal partial class InternalSearchMemoriesRequest
{
    /// <summary> Items for which to search for relevant memories. Only one of conversation_id or items should be provided. </summary>
    [CodeGenMember("Items")]
    public IList<OpenAI.Responses.ResponseItem> Items { get; }

    private static void DeserializeItemsValue(JsonProperty property, ref IList<OpenAI.Responses.ResponseItem> items)
        => ResponseItemHelpers.DeserializeItemsValue(property, ref items);
}
