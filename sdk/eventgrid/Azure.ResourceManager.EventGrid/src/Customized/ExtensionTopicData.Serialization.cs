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
    // Custom model serialization paired with the GA-compat flattened model surface: the generated serializer
    // is replaced to round-trip the customized property layout.
    public partial class ExtensionTopicData : IJsonModel<ExtensionTopicData>
    {
        /// <summary> Creates the model from persisted content. </summary>
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ExtensionTopicData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeExtensionTopicData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ExtensionTopicData)} does not support reading '{options.Format}' format.");
            }
        }

        /// <summary> Writes the model into persisted content. </summary>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ExtensionTopicData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerEventGridContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ExtensionTopicData)} does not support writing '{options.Format}' format.");
            }
        }

        BinaryData IPersistableModel<ExtensionTopicData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        ExtensionTopicData IPersistableModel<ExtensionTopicData>.Create(BinaryData data, ModelReaderWriterOptions options) => (ExtensionTopicData)PersistableModelCreateCore(data, options);

        string IPersistableModel<ExtensionTopicData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static ExtensionTopicData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeExtensionTopicData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        void IJsonModel<ExtensionTopicData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
            string format = options.Format == "W" ? ((IPersistableModel<ExtensionTopicData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtensionTopicData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Description != null || SystemTopic != null)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteStartObject();
                if (Description != null)
                {
                    writer.WritePropertyName("description"u8);
                    writer.WriteStringValue(Description);
                }
                if (SystemTopic != null)
                {
                    writer.WritePropertyName("systemTopic"u8);
                    writer.WriteStringValue(SystemTopic);
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
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        ExtensionTopicData IJsonModel<ExtensionTopicData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (ExtensionTopicData)JsonModelCreateCore(ref reader, options);

        /// <summary> Creates the model from JSON. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ExtensionTopicData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtensionTopicData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeExtensionTopicData(document.RootElement, options);
        }

        internal static ExtensionTopicData DeserializeExtensionTopicData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            string description = default;
            string systemTopic = default;
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
                        foreach (JsonProperty nestedProp in prop.Value.EnumerateObject())
                        {
                            if (nestedProp.NameEquals("description"u8))
                            {
                                description = nestedProp.Value.GetString();
                                continue;
                            }
                            if (nestedProp.NameEquals("systemTopic"u8))
                            {
                                systemTopic = nestedProp.Value.GetString();
                                continue;
                            }
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ExtensionTopicData(id, name, resourceType, systemData, null, additionalBinaryDataProperties)
            {
                Description = description,
                SystemTopic = systemTopic,
            };
        }
    }
}
