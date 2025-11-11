// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents;

[CodeGenType("CreateConversationRequest1")]
[CodeGenSerialization(nameof(Items), SerializationName = "items", DeserializationValueHook = nameof(DeserializeItemsValue))]
public partial class AgentConversationCreationOptions
{
    /// <summary>
    /// Initial items to include the conversation context.
    /// You may add up to 20 items at a time.
    /// </summary>
    [CodeGenMember("Items")]
    public IList<OpenAI.Responses.ResponseItem> Items { get; }

    /// <summary> Initializes a new instance of <see cref="AgentConversationCreationOptions"/>. </summary>
    public AgentConversationCreationOptions()
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
        Items = new ChangeTrackingList<OpenAI.Responses.ResponseItem>();
    }

    private static void DeserializeItemsValue(JsonProperty property, ref IList<OpenAI.Responses.ResponseItem> items)
        => ResponseItemHelpers.DeserializeItemsValue(property, ref items);
}
