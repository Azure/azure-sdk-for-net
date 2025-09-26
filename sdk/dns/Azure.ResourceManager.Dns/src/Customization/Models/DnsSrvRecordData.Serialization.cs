// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns
{
    public partial class DnsSrvRecordData : IUtf8JsonSerializable, IJsonModel<DnsSrvRecordData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DnsSrvRecordData>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DnsSrvRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(ETag.Value.ToString());
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format != "W")
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (options.Format != "W" && Optional.IsDefined(SystemData))
            {
                writer.WritePropertyName("systemData"u8);
                JsonSerializer.Serialize(writer, SystemData);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(TtlInSeconds))
            {
                writer.WritePropertyName("TTL"u8);
                writer.WriteNumberValue(TtlInSeconds.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState);
            }
            if (Optional.IsDefined(TargetResource))
            {
                writer.WritePropertyName("targetResource"u8);
                JsonSerializer.Serialize(writer, TargetResource);
            }
            if (Optional.IsDefined(TrafficManagementProfile))
            {
                writer.WritePropertyName("trafficManagementProfile");
                JsonSerializer.Serialize(writer, TrafficManagementProfile);
            }
            if (Optional.IsCollectionDefined(DnsSrvRecords))
            {
                writer.WritePropertyName("SRVRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsSrvRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        DnsSrvRecordData IJsonModel<DnsSrvRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsSrvRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DnsSrvRecordData)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDnsSrvRecordData(document.RootElement, options);
        }

        internal static DnsSrvRecordData DeserializeDnsSrvRecordData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ETag? etag = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            ResourceManager.Models.SystemData systemData = default;
            IDictionary<string, string> metadata = default;
            long? ttl = default;
            string fqdn = default;
            string provisioningState = default;
            WritableSubResource targetResource = default;
            WritableSubResource trafficManagementProfile = default;
            IList<DnsSrvRecordInfo> srvRecords = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                     if (property.Value.ValueKind == JsonValueKind.Null)
                     {
                         continue;
                     }
                     etag = new ETag(property.Value.GetString());
                    continue;
                }
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
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("metadata"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            Dictionary<string, string> dictionary = new Dictionary<string, string>();
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                dictionary.Add(property1.Name, property1.Value.GetString());
                            }
                            metadata = dictionary;
                            continue;
                        }
                        if (property0.NameEquals("TTL"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            ttl = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("fqdn"u8))
                        {
                            fqdn = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("targetResource"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            targetResource = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.ToString());
                            continue;
                        }
                        if (property0.NameEquals("trafficManagementProfile"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            trafficManagementProfile = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.ToString());
                            continue;
                        }
                        if (property0.NameEquals("SRVRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsSrvRecordInfo> array = new List<DnsSrvRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsSrvRecordInfo.DeserializeDnsSrvRecordInfo(item));
                            }
                            srvRecords = array;
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DnsSrvRecordData(
                id,
                name,
                type,
                systemData,
                etag,
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                ttl,
                fqdn,
                provisioningState,
                targetResource,
                trafficManagementProfile,
                srvRecords ?? new ChangeTrackingList<DnsSrvRecordInfo>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DnsSrvRecordData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsSrvRecordData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDnsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DnsSrvRecordData)} does not support '{options.Format}' format.");
            }
        }

        DnsSrvRecordData IPersistableModel<DnsSrvRecordData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsSrvRecordData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDnsSrvRecordData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DnsSrvRecordData)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DnsSrvRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
