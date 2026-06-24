// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Azure.AI.Extensions.OpenAI;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenType("CreateConversationBody")]
[CodeGenSerialization("Items", SerializationName = "items", DeserializationValueHook = nameof(DeserializeItemsValue), SerializationValueHook = nameof(SerializeItemsValue))]
public partial class ProjectConversationCreationOptions
{
    /// <summary>
    /// Gets the initial items to include in the conversation context.
    /// You may add up to 20 items at a time.
    /// </summary>
    [Experimental("OPENAI001")]
    [CodeGenMember("Items")]
    public IList<global::OpenAI.Responses.ResponseItem> Items { get; }

    [CodeGenMember("Metadata")]
    private global::Azure.AI.Extensions.OpenAI.InternalMetadataContainer InternalMetadata { get; set; }

    /// <summary> Gets the metadata attached to the conversation. </summary>
    public IDictionary<string, string> Metadata => InternalMetadata.AdditionalProperties;

    /// <summary> Initializes a new instance of <see cref="ProjectConversationCreationOptions"/>. </summary>
    public ProjectConversationCreationOptions()
    {
        InternalMetadata = new global::Azure.AI.Extensions.OpenAI.InternalMetadataContainer(new ChangeTrackingDictionary<string, string>(), null);
#pragma warning disable OPENAI001
        Items = new ChangeTrackingList<ResponseItem>();
#pragma warning restore OPENAI001
    }

    /// <summary> Initializes a new instance of <see cref="ProjectConversationCreationOptions"/>. </summary>
    /// <param name="metadata">
    /// A set of 16 key-value pairs that can be attached to an object. This can be
    /// useful for storing additional information about the object in a structured
    /// format and querying for objects through the API or the dashboard.
    ///
    /// Keys are strings with a maximum length of 64 characters. Values are strings
    /// with a maximum length of 512 characters.
    /// </param>
    /// <param name="items">
    /// The initial items to include in the conversation context.
    /// You may add up to 20 items at a time.
    /// </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    [Experimental("OPENAI001")]
    internal ProjectConversationCreationOptions(IDictionary<string, string> metadata, IList<ResponseItem> items, IDictionary<string, BinaryData> additionalBinaryDataProperties)
    {
        InternalMetadata = new global::Azure.AI.Extensions.OpenAI.InternalMetadataContainer(metadata, null);
        Items = items;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }

#pragma warning disable OPENAI001
    private void SerializeItemsValue(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ResponseItemHelpers.SerializeItemsValue(writer, Items, options);

    private static void DeserializeItemsValue(JsonProperty property, ref IList<ResponseItem> items)
        => ResponseItemHelpers.DeserializeItemsValue(property, ref items);
#pragma warning restore OPENAI001
    /// <summary> Converts project conversation creation options into binary content. </summary>
    /// <param name="projectConversationCreationOptions"> The <see cref="ProjectConversationCreationOptions"/> to serialize into <see cref="BinaryContent"/>. </param>
    /// <returns> The binary content representation of the project conversation creation options. </returns>
    public static implicit operator BinaryContent(ProjectConversationCreationOptions projectConversationCreationOptions)
    {
        if (projectConversationCreationOptions == null)
        {
            return null;
        }
        return BinaryContent.Create(projectConversationCreationOptions, ModelSerializationExtensions.WireOptions);
    }

    /// <summary> Writes the model to the JSON writer. </summary>
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
#pragma warning disable OPENAI001
        if (Optional.IsCollectionDefined(Items))
        {
            writer.WritePropertyName("items"u8);
            SerializeItemsValue(writer, options);
        }
#pragma warning restore OPENAI001
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
