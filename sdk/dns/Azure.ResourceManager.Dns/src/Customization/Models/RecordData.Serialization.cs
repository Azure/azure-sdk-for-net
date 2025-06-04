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
    public partial class DnsRecordData : IUtf8JsonSerializable, IJsonModel<DnsRecordData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DnsRecordData>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DnsRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
            if (Optional.IsCollectionDefined(DnsARecords))
            {
                writer.WritePropertyName("ARecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsARecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DnsAaaaRecords))
            {
                writer.WritePropertyName("AAAARecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsAaaaRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DnsMXRecords))
            {
                writer.WritePropertyName("MXRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsMXRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DnsNSRecords))
            {
                writer.WritePropertyName("NSRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsNSRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DnsPtrRecords))
            {
                writer.WritePropertyName("PTRRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsPtrRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
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
            if (Optional.IsCollectionDefined(DnsTxtRecords))
            {
                writer.WritePropertyName("TXTRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsTxtRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(DnsCnameRecordInfo))
            {
                writer.WritePropertyName("CNAMERecord"u8);
                writer.WriteObjectValue(DnsCnameRecordInfo);
            }
            if (Optional.IsDefined(DnsSoaRecordInfo))
            {
                writer.WritePropertyName("DnsSOARecord"u8);
                writer.WriteObjectValue(DnsSoaRecordInfo);
            }
            if (Optional.IsCollectionDefined(DnsCaaRecords))
            {
                writer.WritePropertyName("caaRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsCaaRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DnsDSRecords))
            {
                writer.WritePropertyName("dsRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsDSRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DnsTlsaRecords))
            {
                writer.WritePropertyName("tlsaRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsTlsaRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DnsNaptrRecords))
            {
                writer.WritePropertyName("naptrRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsNaptrRecords)
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
        DnsRecordData IJsonModel<DnsRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DnsRecordData)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDnsRecordData(document.RootElement, options);
        }

        internal static DnsRecordData DeserializeDnsRecordData(JsonElement element, ModelReaderWriterOptions options = null)
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
            IList<DnsARecordInfo> aRecords = default;
            IList<DnsAaaaRecordInfo> aaaaRecords = default;
            IList<DnsMXRecordInfo> mxRecords = default;
            IList<DnsNSRecordInfo> nsRecords = default;
            IList<DnsPtrRecordInfo> ptrRecords = default;
            IList<DnsSrvRecordInfo> srvRecords = default;
            IList<DnsTxtRecordInfo> txtRecords = default;
            DnsCnameRecordInfo cnameRecord = default;
            DnsSoaRecordInfo soaRecord = default;
            IList<DnsCaaRecordInfo> caaRecords = default;
            IList<DnsDSRecordInfo> dsRecords = default;
            IList<DnsTlsaRecordInfo> tlsaRecords = default;
            IList<DnsNaptrRecordInfo> naptrRecords = default;
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
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
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
                        if (property0.NameEquals("ARecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsARecordInfo> array = new List<DnsARecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsARecordInfo.DeserializeDnsARecordInfo(item));
                            }
                            aRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("AAAARecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsAaaaRecordInfo> array = new List<DnsAaaaRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsAaaaRecordInfo.DeserializeDnsAaaaRecordInfo(item));
                            }
                            aaaaRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("MXRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsMXRecordInfo> array = new List<DnsMXRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsMXRecordInfo.DeserializeDnsMXRecordInfo(item));
                            }
                            mxRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("NSRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsNSRecordInfo> array = new List<DnsNSRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsNSRecordInfo.DeserializeDnsNSRecordInfo(item));
                            }
                            nsRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("PTRRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsPtrRecordInfo> array = new List<DnsPtrRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsPtrRecordInfo.DeserializeDnsPtrRecordInfo(item));
                            }
                            ptrRecords = array;
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
                        if (property0.NameEquals("TXTRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsTxtRecordInfo> array = new List<DnsTxtRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsTxtRecordInfo.DeserializeDnsTxtRecordInfo(item));
                            }
                            txtRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("CNAMERecord"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            cnameRecord = DnsCnameRecordInfo.DeserializeDnsCnameRecordInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("SOARecord"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            soaRecord = DnsSoaRecordInfo.DeserializeDnsSoaRecordInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("caaRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsCaaRecordInfo> array = new List<DnsCaaRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsCaaRecordInfo.DeserializeDnsCaaRecordInfo(item));
                            }
                            caaRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("dsRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsDSRecordInfo> array = new List<DnsDSRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsDSRecordInfo.DeserializeDnsDSRecordInfo(item));
                            }
                            dsRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("tlsaRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsTlsaRecordInfo> array = new List<DnsTlsaRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsTlsaRecordInfo.DeserializeDnsTlsaRecordInfo(item));
                            }
                            tlsaRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("naptrRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<DnsNaptrRecordInfo> array = new List<DnsNaptrRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(DnsNaptrRecordInfo.DeserializeDnsNaptrRecordInfo(item));
                            }
                            naptrRecords = array;
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
            return new DnsRecordData(
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
                aRecords ?? new ChangeTrackingList<DnsARecordInfo>(),
                aaaaRecords ?? new ChangeTrackingList<DnsAaaaRecordInfo>(),
                mxRecords ?? new ChangeTrackingList<DnsMXRecordInfo>(),
                nsRecords ?? new ChangeTrackingList<DnsNSRecordInfo>(),
                ptrRecords ?? new ChangeTrackingList<DnsPtrRecordInfo>(),
                srvRecords ?? new ChangeTrackingList<DnsSrvRecordInfo>(),
                txtRecords ?? new ChangeTrackingList<DnsTxtRecordInfo>(),
                cnameRecord,
                soaRecord,
                caaRecords ?? new ChangeTrackingList<DnsCaaRecordInfo>(),
                dsRecords ?? new ChangeTrackingList<DnsDSRecordInfo>(),
                tlsaRecords ?? new ChangeTrackingList<DnsTlsaRecordInfo>(),
                naptrRecords ?? new ChangeTrackingList<DnsNaptrRecordInfo>(),
                serializedAdditionalRawData);
        }
        BinaryData IPersistableModel<DnsRecordData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsRecordData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDnsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DnsRecordData)} does not support '{options.Format}' format.");
            }
        }

        DnsRecordData IPersistableModel<DnsRecordData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsRecordData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDnsRecordData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DnsRecordData)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DnsRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
