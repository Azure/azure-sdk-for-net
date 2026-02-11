// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.Projects.OpenAI;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("CreateConversationRequest")]
[CodeGenSerialization(nameof(Items), SerializationName = "items", DeserializationValueHook = nameof(DeserializeItemsValue), SerializationValueHook = nameof(SerializeItemsValue))]
public partial class ProjectConversationCreationOptions
{
    /// <summary>
    /// Initial items to include the conversation context.
    /// You may add up to 20 items at a time.
    /// </summary>
    [CodeGenMember("Items")]
    public IList<global::OpenAI.Responses.ResponseItem> Items { get; } = new ChangeTrackingList<ResponseItem>();

    [CodeGenMember("Metadata")]
    private global::Azure.AI.Projects.OpenAI.InternalMetadataContainer InternalMetadata { get; set; }
        = new global::Azure.AI.Projects.OpenAI.InternalMetadataContainer(new ChangeTrackingDictionary<string, string>(), null);

    public IDictionary<string, string> Metadata => InternalMetadata.AdditionalProperties;

    private void SerializeItemsValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ResponseItemHelpers.SerializeItemsValue(writer, Items, options);

    private static void DeserializeItemsValue(JsonProperty property, ref IList<ResponseItem> items)
        => ResponseItemHelpers.DeserializeItemsValue(property, ref items);
}
