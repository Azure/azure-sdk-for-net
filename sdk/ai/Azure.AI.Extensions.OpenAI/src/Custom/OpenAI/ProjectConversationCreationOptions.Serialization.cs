// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public partial class ProjectConversationCreationOptions : IJsonModel<ProjectConversationCreationOptions>
{
    protected virtual ProjectConversationCreationOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeProjectConversationCreationOptions(document.RootElement, options);
    }

    protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, options, AzureAIExtensionsOpenAIContext.Default);

    BinaryData IPersistableModel<ProjectConversationCreationOptions>.Write(ModelReaderWriterOptions options)
        => PersistableModelWriteCore(options);

    ProjectConversationCreationOptions IPersistableModel<ProjectConversationCreationOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        => PersistableModelCreateCore(data, options);

    string IPersistableModel<ProjectConversationCreationOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ProjectConversationCreationOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    ProjectConversationCreationOptions IJsonModel<ProjectConversationCreationOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => JsonModelCreateCore(ref reader, options);

    protected virtual ProjectConversationCreationOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeProjectConversationCreationOptions(document.RootElement, options);
    }

    protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (Optional.IsCollectionDefined(Metadata))
        {
            writer.WritePropertyName("metadata"u8);
            writer.WriteStartObject();
            foreach (KeyValuePair<string, string> item in Metadata)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
        }
        if (Optional.IsCollectionDefined(Items))
        {
            writer.WritePropertyName("items"u8);
            ResponseItemHelpers.SerializeItemsValue(writer, Items, options);
        }
        if (options.Format != "W" && _additionalBinaryDataProperties != null)
        {
            foreach (KeyValuePair<string, BinaryData> item in _additionalBinaryDataProperties)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(item.Value);
#else
                using JsonDocument document = JsonDocument.Parse(item.Value);
                JsonSerializer.Serialize(writer, document.RootElement);
#endif
            }
        }
    }

    internal static ProjectConversationCreationOptions DeserializeProjectConversationCreationOptions(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        IDictionary<string, string> metadata = new ChangeTrackingDictionary<string, string>();
        IList<ResponseItem> items = new ChangeTrackingList<ResponseItem>();
        IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("metadata"u8))
            {
                foreach (JsonProperty metadataProperty in property.Value.EnumerateObject())
                {
                    metadata.Add(metadataProperty.Name, metadataProperty.Value.ValueKind == JsonValueKind.Null ? null : metadataProperty.Value.GetString());
                }
                continue;
            }
            if (property.NameEquals("items"u8))
            {
                ResponseItemHelpers.DeserializeItemsValue(property, ref items);
                continue;
            }
            if (options.Format != "W")
            {
                additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        return new ProjectConversationCreationOptions(metadata, items, additionalProperties);
    }
}
