// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Corrected copy of Generated/Models/Capabilities.Serialization.cs
// Uses renamed SupportedCapabilities property.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.ContainerInstance;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> The regional capabilities. </summary>
    public partial class Capabilities : IJsonModel<Capabilities>
    {
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual Capabilities PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<Capabilities>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeCapabilities(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(Models.Capabilities)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<Capabilities>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerContainerInstanceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(Models.Capabilities)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<Capabilities>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        Capabilities IPersistableModel<Capabilities>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<Capabilities>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<Capabilities>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<Capabilities>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Models.Capabilities)} does not support writing '{format}' format.");
            }
            if (options.Format != "W" && Optional.IsDefined(ResourceType))
            {
                writer.WritePropertyName("resourceType"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format != "W" && Optional.IsDefined(OsType))
            {
                writer.WritePropertyName("osType"u8);
                writer.WriteStringValue(OsType);
            }
            if (options.Format != "W" && Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location);
            }
            if (options.Format != "W" && Optional.IsDefined(IpAddressType))
            {
                writer.WritePropertyName("ipAddressType"u8);
                writer.WriteStringValue(IpAddressType);
            }
            if (options.Format != "W" && Optional.IsDefined(Gpu))
            {
                writer.WritePropertyName("gpu"u8);
                writer.WriteStringValue(Gpu);
            }
            if (options.Format != "W" && Optional.IsDefined(SupportedCapabilities))
            {
                writer.WritePropertyName("capabilities"u8);
                writer.WriteObjectValue(SupportedCapabilities, options);
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

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        Capabilities IJsonModel<Capabilities>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual Capabilities JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<Capabilities>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Models.Capabilities)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCapabilities(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static Capabilities DeserializeCapabilities(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string resourceType = default;
            string osType = default;
            string location = default;
            string ipAddressType = default;
            string gpu = default;
            CapabilitiesCapabilities capabilities = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("resourceType"u8))
                {
                    resourceType = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("osType"u8))
                {
                    osType = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("location"u8))
                {
                    location = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("ipAddressType"u8))
                {
                    ipAddressType = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("gpu"u8))
                {
                    gpu = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("capabilities"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    capabilities = CapabilitiesCapabilities.DeserializeCapabilitiesCapabilities(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new Capabilities(
                resourceType,
                osType,
                location,
                ipAddressType,
                gpu,
                capabilities,
                additionalBinaryDataProperties);
        }
    }
}
