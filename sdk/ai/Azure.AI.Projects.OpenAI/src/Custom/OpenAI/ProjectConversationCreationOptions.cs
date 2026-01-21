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
    public IList<global::OpenAI.Responses.ResponseItem> Items { get; }

    [CodeGenMember("Metadata")]
    private global::OpenAI.InternalMetadataContainer InternalMetadata { get; set; }

    public IDictionary<string, string> Metadata => InternalMetadata.AdditionalProperties;

    /// <summary> Initializes a new instance of <see cref="ProjectConversationCreationOptions"/>. </summary>
    public ProjectConversationCreationOptions()
    {
        InternalMetadata = new global::OpenAI.InternalMetadataContainer(new ChangeTrackingDictionary<string, string>(), null);
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
        InternalMetadata = new global::OpenAI.InternalMetadataContainer(metadata, null);
        Items = items;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    private void SerializeItemsValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ResponseItemHelpers.SerializeItemsValue(writer, Items, options);

    private static void DeserializeItemsValue(JsonProperty property, ref IList<ResponseItem> items)
        => ResponseItemHelpers.DeserializeItemsValue(property, ref items);

    /// <param name="writer"> The JSON writer. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<ProjectConversationCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ProjectConversationCreationOptions)} does not support writing '{format}' format.");
        }
        if (Optional.IsDefined(InternalMetadata) && Optional.IsCollectionDefined(InternalMetadata.AdditionalProperties))
        {
            writer.WritePropertyName("metadata"u8);
            writer.WriteObjectValue(InternalMetadata, options);
        }
        if (Optional.IsCollectionDefined(Items))
        {
            writer.WritePropertyName("items"u8);
            SerializeItemsValue(writer, options);
        }
        if (options.Format != "W" && _additionalBinaryDataProperties != null)
        {
            foreach (var item in _additionalBinaryDataProperties)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
            }
        }
    }
}
