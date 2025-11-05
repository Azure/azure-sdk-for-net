// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents;

[CodeGenType("UpdateMemoriesRequest")]
[CodeGenSerialization(nameof(Items), SerializationName = "items", DeserializationValueHook = nameof(DeserializeItemsValue))]
public partial class MemoryUpdateOptions
{
    /// <summary> Initializes a new instance of <see cref="MemoryUpdateOptions"/>. </summary>
    public MemoryUpdateOptions()
    {
    }

    /// <summary> Items for which to search for relevant memories. Only one of conversation_id or items should be provided. </summary>
    [CodeGenMember("Items")]
    internal IList<OpenAI.Responses.ResponseItem> Items { get; set; }

    /// <summary> The namespace that logically groups and isolates memories, such as a user ID. </summary>
    [CodeGenMember("Scope")]
    internal string Scope { get; set; }

    /// <summary> The conversation ID from which to extract memories. Only one of conversation_id or items should be provided. </summary>
    [CodeGenMember("ConversationId")]
    internal string ConversationId { get; set; }

    internal MemoryUpdateOptions GetClone()
    {
        MemoryUpdateOptions copiedOptions = (MemoryUpdateOptions)this.MemberwiseClone();

        if (_additionalBinaryDataProperties is not null)
        {
            copiedOptions._additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (KeyValuePair<string, BinaryData> sourcePair in _additionalBinaryDataProperties)
            {
                copiedOptions._additionalBinaryDataProperties[sourcePair.Key] = sourcePair.Value;
            }
        }

        return copiedOptions;
    }

    /// <summary> Keeps track of any properties unknown to the library. </summary>
    private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

    private static void DeserializeItemsValue(JsonProperty property, ref IList<OpenAI.Responses.ResponseItem> items)
        => ResponseItemHelpers.DeserializeItemsValue(property, ref items);
}
