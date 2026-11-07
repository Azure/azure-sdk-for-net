// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    // Preserve the v1.1.1 patch SKU type and serialization contract. The TypeSpec generator no
    // longer emits this update model, but FirmwareAnalysisWorkspacePatch.Sku still exposes it.
    /// <summary> The SKU (Stock Keeping Unit) properties to be updated. </summary>
    public partial class IotFirmwareDefenseSkuUpdate : IJsonModel<IotFirmwareDefenseSkuUpdate>
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="IotFirmwareDefenseSkuUpdate"/>. </summary>
        public IotFirmwareDefenseSkuUpdate()
        {
        }

        internal IotFirmwareDefenseSkuUpdate(string name, IotFirmwareDefenseSkuTier? tier, string size, string family, int? capacity, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Name = name;
            Tier = tier;
            Size = size;
            Family = family;
            Capacity = capacity;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The name of the SKU. Ex - P3. It is typically a letter+number code. </summary>
        public string Name { get; set; }

        /// <summary> This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT. </summary>
        public IotFirmwareDefenseSkuTier? Tier { get; set; }

        /// <summary> The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code. </summary>
        public string Size { get; set; }

        /// <summary> If the service has different generations of hardware, for the same SKU, then that can be captured here. </summary>
        public string Family { get; set; }

        /// <summary> If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the resource this may be omitted. </summary>
        public int? Capacity { get; set; }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IotFirmwareDefenseSkuUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerIotFirmwareDefenseContext.Default);
                default:
                    throw new FormatException($"The model {nameof(IotFirmwareDefenseSkuUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual IotFirmwareDefenseSkuUpdate PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IotFirmwareDefenseSkuUpdate>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeIotFirmwareDefenseSkuUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(IotFirmwareDefenseSkuUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<IotFirmwareDefenseSkuUpdate>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        IotFirmwareDefenseSkuUpdate IPersistableModel<IotFirmwareDefenseSkuUpdate>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<IotFirmwareDefenseSkuUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<IotFirmwareDefenseSkuUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IotFirmwareDefenseSkuUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IotFirmwareDefenseSkuUpdate)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Tier))
            {
                writer.WritePropertyName("tier"u8);
                writer.WriteStringValue(Tier.Value.ToSerialString());
            }
            if (Optional.IsDefined(Size))
            {
                writer.WritePropertyName("size"u8);
                writer.WriteStringValue(Size);
            }
            if (Optional.IsDefined(Family))
            {
                writer.WritePropertyName("family"u8);
                writer.WriteStringValue(Family);
            }
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("capacity"u8);
                writer.WriteNumberValue(Capacity.Value);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        IotFirmwareDefenseSkuUpdate IJsonModel<IotFirmwareDefenseSkuUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual IotFirmwareDefenseSkuUpdate JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IotFirmwareDefenseSkuUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IotFirmwareDefenseSkuUpdate)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIotFirmwareDefenseSkuUpdate(document.RootElement, options);
        }

        internal static IotFirmwareDefenseSkuUpdate DeserializeIotFirmwareDefenseSkuUpdate(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IotFirmwareDefenseSkuTier? tier = default;
            string size = default;
            string family = default;
            int? capacity = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("tier"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tier = prop.Value.GetString().ToIotFirmwareDefenseSkuTier();
                    continue;
                }
                if (prop.NameEquals("size"u8))
                {
                    size = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("family"u8))
                {
                    family = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("capacity"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    capacity = prop.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new IotFirmwareDefenseSkuUpdate(name, tier, size, family, capacity, additionalBinaryDataProperties);
        }
    }
}
