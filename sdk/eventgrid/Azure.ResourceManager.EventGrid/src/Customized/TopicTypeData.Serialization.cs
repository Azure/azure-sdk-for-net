// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventGrid
{
    public partial class TopicTypeData : IJsonModel<TopicTypeData>, IPersistableModel<TopicTypeData>
    {
        /// <summary> Creates the model from persisted content. </summary>
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TopicTypeData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeTopicTypeData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(TopicTypeData)} does not support reading '{options.Format}' format.");
            }
        }

        /// <summary> Writes the model into persisted content. </summary>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TopicTypeData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default);
                default:
                    throw new FormatException($"The model {nameof(TopicTypeData)} does not support writing '{options.Format}' format.");
            }
        }

        BinaryData IPersistableModel<TopicTypeData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        TopicTypeData IPersistableModel<TopicTypeData>.Create(BinaryData data, ModelReaderWriterOptions options) => (TopicTypeData)PersistableModelCreateCore(data, options);

        string IPersistableModel<TopicTypeData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static TopicTypeData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeTopicTypeData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        void IJsonModel<TopicTypeData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <summary> Writes the model into JSON. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TopicTypeData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TopicTypeData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            TopicTypeProperties properties = new TopicTypeProperties(
                Provider,
                DisplayName,
                Description,
                ResourceRegionType,
                ProvisioningState,
                SupportedLocations,
                SourceResourceFormat,
                SupportedScopesForSource,
                AreRegionalAndGlobalSourcesSupported,
                AdditionalEnforcedPermissions,
                null);
            writer.WritePropertyName("properties"u8);
            writer.WriteObjectValue(properties, options);

            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (KeyValuePair<string, BinaryData> item in _additionalBinaryDataProperties)
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

        TopicTypeData IJsonModel<TopicTypeData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (TopicTypeData)JsonModelCreateCore(ref reader, options);

        /// <summary> Creates the model from JSON. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<TopicTypeData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TopicTypeData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTopicTypeData(document.RootElement, options);
        }

        internal static TopicTypeData DeserializeTopicTypeData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            TopicTypeProperties properties = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        resourceType = new ResourceType(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerEventGridContext.Default);
                    }
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = TopicTypeProperties.DeserializeTopicTypeProperties(prop.Value, options);
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }

            return new TopicTypeData(id, name, resourceType, systemData, properties, additionalBinaryDataProperties);
        }
    }
}
