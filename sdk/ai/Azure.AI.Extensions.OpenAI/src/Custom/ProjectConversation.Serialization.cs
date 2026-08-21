// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Extensions.OpenAI;

public partial class ProjectConversation : IJsonModel<ProjectConversation>
{
    protected virtual ProjectConversation PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeProjectConversation(document.RootElement, options);
    }

    protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, options, AzureAIExtensionsOpenAIContext.Default);

    BinaryData IPersistableModel<ProjectConversation>.Write(ModelReaderWriterOptions options)
        => PersistableModelWriteCore(options);

    ProjectConversation IPersistableModel<ProjectConversation>.Create(BinaryData data, ModelReaderWriterOptions options)
        => PersistableModelCreateCore(data, options);

    string IPersistableModel<ProjectConversation>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ProjectConversation>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    ProjectConversation IJsonModel<ProjectConversation>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => JsonModelCreateCore(ref reader, options);

    protected virtual ProjectConversation JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeProjectConversation(document.RootElement, options);
    }

    protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WritePropertyName("id"u8);
        writer.WriteStringValue(Id);
        writer.WritePropertyName("object"u8);
        writer.WriteStringValue(Object);
        writer.WritePropertyName("metadata"u8);
        writer.WriteStartObject();
        foreach (KeyValuePair<string, string> item in Metadata)
        {
            writer.WritePropertyName(item.Key);
            writer.WriteStringValue(item.Value);
        }
        writer.WriteEndObject();
        writer.WritePropertyName("created_at"u8);
        writer.WriteNumberValue(CreatedAt, "U");
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

    internal static ProjectConversation DeserializeProjectConversation(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        string id = default;
        string objectType = default;
        IDictionary<string, string> metadata = new ChangeTrackingDictionary<string, string>();
        DateTimeOffset createdAt = default;
        IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("id"u8))
            {
                id = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("object"u8))
            {
                objectType = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("metadata"u8))
            {
                foreach (JsonProperty metadataProperty in property.Value.EnumerateObject())
                {
                    metadata.Add(metadataProperty.Name, metadataProperty.Value.ValueKind == JsonValueKind.Null ? null : metadataProperty.Value.GetString());
                }
                continue;
            }
            if (property.NameEquals("created_at"u8))
            {
                createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                continue;
            }
            if (options.Format != "W")
            {
                additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }
        return new ProjectConversation(id, objectType, metadata, createdAt, additionalProperties);
    }
}
