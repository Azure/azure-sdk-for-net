// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.Agents;
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
    public IList<global::OpenAI.Responses.ResponseItem> Items { get; }

    /// <summary> Initializes a new instance of <see cref="ProjectConversationCreationOptions"/>. </summary>
    public ProjectConversationCreationOptions()
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
        Items = new ChangeTrackingList<ResponseItem>();
    }

    /// <summary> Initializes a new instance of <see cref="ProjectConversationCreationOptions"/>. </summary>
    /// <param name="metadata">
    /// Set of 16 key-value pairs that can be attached to an object. This can be
    /// useful for storing additional information about the object in a structured
    /// format, and querying for objects via API or the dashboard.
    ///
    /// Keys are strings with a maximum length of 64 characters. Values are strings
    /// with a maximum length of 512 characters.
    /// </param>
    /// <param name="items">
    /// Initial items to include the conversation context.
    /// You may add up to 20 items at a time.
    /// </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    internal ProjectConversationCreationOptions(IDictionary<string, string> metadata, IList<ResponseItem> items, IDictionary<string, BinaryData> additionalBinaryDataProperties)
    {
        Metadata = metadata;
        Items = items;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    private void SerializeItemsValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ResponseItemHelpers.SerializeItemsValue(writer, Items, options);

    private static void DeserializeItemsValue(JsonProperty property, ref IList<ResponseItem> items)
        => ResponseItemHelpers.DeserializeItemsValue(property, ref items);
}
