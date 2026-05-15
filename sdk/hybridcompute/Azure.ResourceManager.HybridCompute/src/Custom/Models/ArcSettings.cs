// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HybridCompute.Models
{
    // Compatibility shim for the AutoRest-generated model preserved during TypeSpec migration.
    /// <summary> The ArcSettings. </summary>
    public partial class ArcSettings : ResourceData, IUtf8JsonSerializable, IJsonModel<ArcSettings>, IPersistableModel<ArcSettings>
    {
        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ArcSettings"/>. </summary>
        public ArcSettings()
        {
        }

        internal ArcSettings(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, Guid? tenantId, ResourceIdentifier gatewayResourceId, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            TenantId = tenantId;
            GatewayResourceId = gatewayResourceId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Azure resource tenant Id. </summary>
        [WirePath("properties.tenantId")]
        public Guid? TenantId { get; }

        /// <summary> Associated Gateway Resource Id. </summary>
        [WirePath("properties.gatewayResourceId")]
        public ResourceIdentifier GatewayResourceId { get; set; }

        internal ArcSettingsData ToArcSettingsData()
        {
            string tenantId = TenantId?.ToString();
            SettingsGatewayProperties gatewayProperties = GatewayResourceId is null ? default : new SettingsGatewayProperties(GatewayResourceId, null);

            return new ArcSettingsData(
                Id,
                Name,
                ResourceType,
                SystemData,
                additionalBinaryDataProperties: null,
                tenantId is null && gatewayProperties is null ? default : new SettingsProperties(tenantId, gatewayProperties, null));
        }

        internal static ArcSettings FromArcSettingsData(ArcSettingsData data)
        {
            if (data is null)
            {
                return null;
            }

            Guid? tenantId = Guid.TryParse(data.TenantId, out Guid parsedTenantId) ? parsedTenantId : default(Guid?);
            return new ArcSettings(data.Id, data.Name, data.ResourceType, data.SystemData, tenantId, data.GatewayResourceId, null);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ArcSettings>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ArcSettings>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ArcSettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ArcSettings)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(TenantId))
            {
                writer.WritePropertyName("tenantId"u8);
                writer.WriteStringValue(TenantId.Value);
            }
            writer.WritePropertyName("gatewayProperties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(GatewayResourceId))
            {
                writer.WritePropertyName("gatewayResourceId"u8);
                writer.WriteStringValue(GatewayResourceId);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        ArcSettings IJsonModel<ArcSettings>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ArcSettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ArcSettings)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeArcSettings(document.RootElement, options);
        }

        internal static ArcSettings DeserializeArcSettings(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            Guid? tenantId = default;
            ResourceIdentifier gatewayResourceId = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        resourceType = new ResourceType(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerHybridComputeContext.Default);
                    }
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        foreach (JsonProperty property0 in property.Value.EnumerateObject())
                        {
                            if (property0.NameEquals("tenantId"u8))
                            {
                                if (property0.Value.ValueKind != JsonValueKind.Null)
                                {
                                    tenantId = property0.Value.GetGuid();
                                }
                                continue;
                            }
                            if (property0.NameEquals("gatewayProperties"u8))
                            {
                                if (property0.Value.ValueKind != JsonValueKind.Null)
                                {
                                    foreach (JsonProperty property1 in property0.Value.EnumerateObject())
                                    {
                                        if (property1.NameEquals("gatewayResourceId"u8) && property1.Value.ValueKind != JsonValueKind.Null)
                                        {
                                            gatewayResourceId = new ResourceIdentifier(property1.Value.GetString());
                                            continue;
                                        }
                                    }
                                }
                                continue;
                            }
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }

            return new ArcSettings(id, name, resourceType, systemData, tenantId, gatewayResourceId, rawDataDictionary);
        }

        BinaryData IPersistableModel<ArcSettings>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ArcSettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ArcSettings)} does not support writing '{options.Format}' format.");
            }

            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            ((IJsonModel<ArcSettings>)this).Write(writer, options);
            writer.Flush();
            return BinaryData.FromBytes(stream.ToArray());
        }

        ArcSettings IPersistableModel<ArcSettings>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ArcSettings>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ArcSettings)} does not support reading '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeArcSettings(document.RootElement, options);
        }

        string IPersistableModel<ArcSettings>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
