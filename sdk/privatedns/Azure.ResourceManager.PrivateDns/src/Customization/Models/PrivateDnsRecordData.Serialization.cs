// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PrivateDns.Models;

namespace Azure.ResourceManager.PrivateDns
{
    public partial class PrivateDnsRecordData : IUtf8JsonSerializable, IJsonModel<PrivateDnsRecordData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PrivateDnsRecordData>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<PrivateDnsRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PrivateDnsRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateDnsRecordData)} does not support '{format}' format.");
            }
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
                writer.WritePropertyName("ttl"u8);
                writer.WriteNumberValue(TtlInSeconds.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(Fqdn))
            {
                writer.WritePropertyName("fqdn"u8);
                writer.WriteStringValue(Fqdn);
            }
            if (options.Format != "W" && Optional.IsDefined(IsAutoRegistered))
            {
                writer.WritePropertyName("isAutoRegistered"u8);
                writer.WriteBooleanValue(IsAutoRegistered.Value);
            }
            if (Optional.IsCollectionDefined(ARecords))
            {
                writer.WritePropertyName("aRecords"u8);
                writer.WriteStartArray();
                foreach (var item in ARecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(AaaaRecords))
            {
                writer.WritePropertyName("aaaaRecords"u8);
                writer.WriteStartArray();
                foreach (var item in AaaaRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PrivateDnsCnameRecordInfo))
            {
                writer.WritePropertyName("cnameRecord"u8);
                writer.WriteObjectValue(PrivateDnsCnameRecordInfo);
            }
            if (Optional.IsCollectionDefined(MXRecords))
            {
                writer.WritePropertyName("mxRecords"u8);
                writer.WriteStartArray();
                foreach (var item in MXRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(PtrRecords))
            {
                writer.WritePropertyName("ptrRecords"u8);
                writer.WriteStartArray();
                foreach (var item in PtrRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PrivateDnsSoaRecordInfo))
            {
                writer.WritePropertyName("soaRecord"u8);
                writer.WriteObjectValue(PrivateDnsSoaRecordInfo);
            }
            if (Optional.IsCollectionDefined(SrvRecords))
            {
                writer.WritePropertyName("srvRecords"u8);
                writer.WriteStartArray();
                foreach (var item in SrvRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TxtRecords))
            {
                writer.WritePropertyName("txtRecords"u8);
                writer.WriteStartArray();
                foreach (var item in TxtRecords)
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

        PrivateDnsRecordData IJsonModel<PrivateDnsRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PrivateDnsRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateDnsRecordData)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateDnsRecordData(document.RootElement, options);
        }

        internal static PrivateDnsRecordData DeserializePrivateDnsRecordData(JsonElement element, ModelReaderWriterOptions options = null)
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
            SystemData systemData = default;
            IDictionary<string, string> metadata = default;
            long? ttl = default;
            string fqdn = default;
            bool? isAutoRegistered = default;
            IList<PrivateDnsARecordInfo> aRecords = default;
            IList<PrivateDnsAaaaRecordInfo> aaaaRecords = default;
            PrivateDnsCnameRecordInfo privateDnsCnameRecordInfo = default;
            IList<PrivateDnsMXRecordInfo> mxRecords = default;
            IList<PrivateDnsPtrRecordInfo> ptrRecords = default;
            PrivateDnsSoaRecordInfo privateDnsSoaRecordInfo = default;
            IList<PrivateDnsSrvRecordInfo> srvRecords = default;
            IList<PrivateDnsTxtRecordInfo> txtRecords = default;
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
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
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
                        if (property0.NameEquals("ttl"u8))
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
                        if (property0.NameEquals("isAutoRegistered"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            isAutoRegistered = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("aRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
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
                        if (property0.NameEquals("aaaaRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
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
                        if (property0.NameEquals("cnameRecord"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateDnsCnameRecordInfo = PrivateDnsCnameRecordInfo.DeserializePrivateDnsCnameRecordInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("mxRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
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
                        if (property0.NameEquals("ptrRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
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
                        if (property0.NameEquals("soaRecord"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateDnsSoaRecordInfo = PrivateDnsSoaRecordInfo.DeserializePrivateDnsSoaRecordInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("srvRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
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
                        if (property0.NameEquals("txtRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
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
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new PrivateDnsRecordData(
                id,
                name,
                type,
                systemData,
                etag,
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                ttl,
                fqdn,
                isAutoRegistered,
                aRecords ?? new ChangeTrackingList<PrivateDnsARecordInfo>(),
                aaaaRecords ?? new ChangeTrackingList<PrivateDnsAaaaRecordInfo>(),
                privateDnsCnameRecordInfo,
                mxRecords ?? new ChangeTrackingList<PrivateDnsMXRecordInfo>(),
                ptrRecords ?? new ChangeTrackingList<PrivateDnsPtrRecordInfo>(),
                privateDnsSoaRecordInfo,
                srvRecords ?? new ChangeTrackingList<PrivateDnsSrvRecordInfo>(),
                txtRecords ?? new ChangeTrackingList<PrivateDnsTxtRecordInfo>(),
                serializedAdditionalRawData);
        }
        BinaryData IPersistableModel<PrivateDnsRecordData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PrivateDnsRecordData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerPrivateDnsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(PrivateDnsRecordData)} does not support '{options.Format}' format.");
            }
        }

        PrivateDnsRecordData IPersistableModel<PrivateDnsRecordData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PrivateDnsRecordData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePrivateDnsRecordData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PrivateDnsRecordData)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<PrivateDnsRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
