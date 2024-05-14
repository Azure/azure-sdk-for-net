// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Dns.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Dns
{
    public partial class DnsRecordData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(ETag.Value.ToString());
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
            if (Optional.IsDefined(TargetResource))
            {
                writer.WritePropertyName("targetResource"u8);
                JsonSerializer.Serialize(writer, TargetResource);
            }
            if (Optional.IsDefined(TrafficManagementProfile))
            {
                writer.WritePropertyName("trafficManagementProfile"u8);
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
                writer.WritePropertyName("SOARecord"u8);
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
                writer.WritePropertyName("DSRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsDSRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DnsTlsaRecords))
            {
                writer.WritePropertyName("TLSARecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsTlsaRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DnsNaptrRecords))
            {
                writer.WritePropertyName("NAPTRRecords"u8);
                writer.WriteStartArray();
                foreach (var item in DnsNaptrRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static DnsRecordData DeserializeDnsRecordData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ETag> etag = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<IDictionary<string, string>> metadata = default;
            Optional<long> ttl = default;
            Optional<string> fqdn = default;
            Optional<string> provisioningState = default;
            Optional<WritableSubResource> targetResource = default;
            Optional<WritableSubResource> trafficManagementProfile = default;
            Optional<IList<DnsARecordInfo>> aRecords = default;
            Optional<IList<DnsAaaaRecordInfo>> aaaaRecords = default;
            Optional<IList<DnsMXRecordInfo>> mxRecords = default;
            Optional<IList<DnsNSRecordInfo>> nsRecords = default;
            Optional<IList<DnsPtrRecordInfo>> ptrRecords = default;
            Optional<IList<DnsSrvRecordInfo>> srvRecords = default;
            Optional<IList<DnsTxtRecordInfo>> txtRecords = default;
            Optional<DnsCnameRecordInfo> cnameRecord = default;
            Optional<DnsSoaRecordInfo> soaRecord = default;
            Optional<IList<DnsCaaRecordInfo>> caaRecords = default;
            Optional<IList<DnsDSRecordInfo>> dsRecords = default;
            Optional<IList<DnsTlsaRecordInfo>> tlsARecords = default;
            Optional<IList<DnsNaptrRecordInfo>> naptrRecords = default;
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
                        property.ThrowNonNullablePropertyIsNull();
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
                            targetResource = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("trafficManagementProfile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            trafficManagementProfile = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
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
                        if (property0.NameEquals("DSRecords"u8))
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
                        if (property0.NameEquals("TLSARecords"u8))
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
                            tlsARecords = array;
                            continue;
                        }
                        if (property0.NameEquals("NAPTRRecords"u8))
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
            }
            return new DnsRecordData(id, name, type, systemData.Value, Optional.ToNullable(etag), Optional.ToDictionary(metadata), Optional.ToNullable(ttl), fqdn.Value, provisioningState.Value, targetResource, trafficManagementProfile, Optional.ToList(aRecords), Optional.ToList(aaaaRecords), Optional.ToList(mxRecords), Optional.ToList(nsRecords), Optional.ToList(ptrRecords), Optional.ToList(srvRecords), Optional.ToList(txtRecords), cnameRecord.Value, soaRecord.Value, Optional.ToList(caaRecords), Optional.ToList(dsRecords), Optional.ToList(tlsARecords), Optional.ToList(naptrRecords));
        }
    }
}
