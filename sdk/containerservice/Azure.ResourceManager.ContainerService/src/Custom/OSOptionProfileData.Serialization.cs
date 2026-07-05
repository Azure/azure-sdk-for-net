// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ContainerService
{
    public partial class OSOptionProfileData : IUtf8JsonSerializable, IJsonModel<OSOptionProfileData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OSOptionProfileData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<OSOptionProfileData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSOptionProfileData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OSOptionProfileData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            writer.WritePropertyName("osOptionPropertyList"u8);
            writer.WriteStartArray();
            foreach (var item in OSOptionPropertyList)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        OSOptionProfileData IJsonModel<OSOptionProfileData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSOptionProfileData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OSOptionProfileData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOSOptionProfileData(document.RootElement, options);
        }

        internal static OSOptionProfileData DeserializeOSOptionProfileData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Azure.ResourceManager.Models.SystemData systemData = default;
            IReadOnlyList<ContainerServiceOSOptionProperty> osOptionPropertyList = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<Azure.ResourceManager.Models.SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerContainerServiceContext.Default);
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("osOptionPropertyList"u8))
                        {
                            List<ContainerServiceOSOptionProperty> array = new List<ContainerServiceOSOptionProperty>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ContainerServiceOSOptionProperty.DeserializeContainerServiceOSOptionProperty(item, options));
                            }
                            osOptionPropertyList = array;
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new OSOptionProfileData(
                id,
                name,
                type,
                systemData,
                osOptionPropertyList,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<OSOptionProfileData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSOptionProfileData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerContainerServiceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(OSOptionProfileData)} does not support writing '{options.Format}' format.");
            }
        }

        OSOptionProfileData IPersistableModel<OSOptionProfileData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OSOptionProfileData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeOSOptionProfileData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OSOptionProfileData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<OSOptionProfileData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
