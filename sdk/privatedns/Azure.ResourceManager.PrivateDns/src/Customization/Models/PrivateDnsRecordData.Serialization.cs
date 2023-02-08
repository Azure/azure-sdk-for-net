// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PrivateDns.Models;

namespace Azure.ResourceManager.PrivateDns
{
    public partial class PrivateDnsRecordData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag");
                writer.WriteStringValue(ETag.Value.ToString());
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata");
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
                writer.WritePropertyName("ttl");
                writer.WriteNumberValue(TtlInSeconds.Value);
            }
            if (Optional.IsCollectionDefined(ARecords))
            {
                writer.WritePropertyName("aRecords");
                writer.WriteStartArray();
                foreach (var item in ARecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(AaaaRecords))
            {
                writer.WritePropertyName("aaaaRecords");
                writer.WriteStartArray();
                foreach (var item in AaaaRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PrivateDnsCnameRecordInfo))
            {
                writer.WritePropertyName("cnameRecord");
                writer.WriteObjectValue(PrivateDnsCnameRecordInfo);
            }
            if (Optional.IsCollectionDefined(MXRecords))
            {
                writer.WritePropertyName("mxRecords");
                writer.WriteStartArray();
                foreach (var item in MXRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(PtrRecords))
            {
                writer.WritePropertyName("ptrRecords");
                writer.WriteStartArray();
                foreach (var item in PtrRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PrivateDnsSoaRecordInfo))
            {
                writer.WritePropertyName("soaRecord");
                writer.WriteObjectValue(PrivateDnsSoaRecordInfo);
            }
            if (Optional.IsCollectionDefined(SrvRecords))
            {
                writer.WritePropertyName("srvRecords");
                writer.WriteStartArray();
                foreach (var item in SrvRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TxtRecords))
            {
                writer.WritePropertyName("txtRecords");
                writer.WriteStartArray();
                foreach (var item in TxtRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static PrivateDnsRecordData DeserializePrivateDnsRecordData(JsonElement element)
        {
            Optional<ETag> etag = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<IDictionary<string, string>> metadata = default;
            Optional<long> ttl = default;
            Optional<string> fqdn = default;
            Optional<bool> isAutoRegistered = default;
            Optional<IList<PrivateDnsARecordInfo>> aRecords = default;
            Optional<IList<PrivateDnsAaaaRecordInfo>> aaaaRecords = default;
            Optional<PrivateDnsCnameRecordInfo> privateDnsCnameRecordInfo = default;
            Optional<IList<PrivateDnsMXRecordInfo>> mxRecords = default;
            Optional<IList<PrivateDnsPtrRecordInfo>> ptrRecords = default;
            Optional<PrivateDnsSoaRecordInfo> privateDnsSoaRecordInfo = default;
            Optional<IList<PrivateDnsSrvRecordInfo>> srvRecords = default;
            Optional<IList<PrivateDnsTxtRecordInfo>> txtRecords = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    etag = new ETag(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("metadata"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
                        if (property0.NameEquals("ttl"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            ttl = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("fqdn"))
                        {
                            fqdn = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("isAutoRegistered"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            isAutoRegistered = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("aRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<PrivateDnsARecordInfo> array = new List<PrivateDnsARecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PrivateDnsARecordInfo.DeserializePrivateDnsARecordInfo(item));
                            }
                            aRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("aaaaRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<PrivateDnsAaaaRecordInfo> array = new List<PrivateDnsAaaaRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PrivateDnsAaaaRecordInfo.DeserializePrivateDnsAaaaRecordInfo(item));
                            }
                            aaaaRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("cnameRecord"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            privateDnsCnameRecordInfo = PrivateDnsCnameRecordInfo.DeserializePrivateDnsCnameRecordInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("mxRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<PrivateDnsMXRecordInfo> array = new List<PrivateDnsMXRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PrivateDnsMXRecordInfo.DeserializePrivateDnsMXRecordInfo(item));
                            }
                            mxRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("ptrRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<PrivateDnsPtrRecordInfo> array = new List<PrivateDnsPtrRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PrivateDnsPtrRecordInfo.DeserializePrivateDnsPtrRecordInfo(item));
                            }
                            ptrRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("soaRecord"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            privateDnsSoaRecordInfo = PrivateDnsSoaRecordInfo.DeserializePrivateDnsSoaRecordInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("srvRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<PrivateDnsSrvRecordInfo> array = new List<PrivateDnsSrvRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PrivateDnsSrvRecordInfo.DeserializePrivateDnsSrvRecordInfo(item));
                            }
                            srvRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("txtRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<PrivateDnsTxtRecordInfo> array = new List<PrivateDnsTxtRecordInfo>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PrivateDnsTxtRecordInfo.DeserializePrivateDnsTxtRecordInfo(item));
                            }
                            txtRecords = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new PrivateDnsRecordData(id, name, type, systemData.Value, Optional.ToNullable(etag), Optional.ToDictionary(metadata), Optional.ToNullable(ttl), fqdn.Value, Optional.ToNullable(isAutoRegistered), Optional.ToList(aRecords), Optional.ToList(aaaaRecords), privateDnsCnameRecordInfo.Value, Optional.ToList(mxRecords), Optional.ToList(ptrRecords), privateDnsSoaRecordInfo.Value, Optional.ToList(srvRecords), Optional.ToList(txtRecords));
        }
    }
}
