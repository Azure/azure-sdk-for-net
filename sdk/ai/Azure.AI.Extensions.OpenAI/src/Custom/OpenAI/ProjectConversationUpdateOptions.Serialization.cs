// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Extensions.OpenAI;

public partial class ProjectConversationUpdateOptions : IJsonModel<ProjectConversationUpdateOptions>
{
    protected virtual ProjectConversationUpdateOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeProjectConversationUpdateOptions(document.RootElement, options);
    }

    protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, options, AzureAIExtensionsOpenAIContext.Default);

    BinaryData IPersistableModel<ProjectConversationUpdateOptions>.Write(ModelReaderWriterOptions options)
        => PersistableModelWriteCore(options);

    ProjectConversationUpdateOptions IPersistableModel<ProjectConversationUpdateOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        => PersistableModelCreateCore(data, options);

    string IPersistableModel<ProjectConversationUpdateOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ProjectConversationUpdateOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    ProjectConversationUpdateOptions IJsonModel<ProjectConversationUpdateOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => JsonModelCreateCore(ref reader, options);

    protected virtual ProjectConversationUpdateOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeProjectConversationUpdateOptions(document.RootElement, options);
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

    internal static ProjectConversationUpdateOptions DeserializeProjectConversationUpdateOptions(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        IDictionary<string, string> metadata = new ChangeTrackingDictionary<string, string>();
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
            if (options.Format != "W")
            {
                additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        return new ProjectConversationUpdateOptions(metadata, additionalProperties);
    }
}
