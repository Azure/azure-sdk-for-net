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
    public partial class PrivateDnsPtrRecordData : IUtf8JsonSerializable, IJsonModel<PrivateDnsPtrRecordData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PrivateDnsPtrRecordData>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<PrivateDnsPtrRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PrivateDnsPtrRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateDnsPtrRecordData)} does not support '{format}' format.");
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
            if (Optional.IsCollectionDefined(PrivateDnsPtrRecords))
            {
                writer.WritePropertyName("ptrRecords"u8);
                writer.WriteStartArray();
                foreach (var item in PrivateDnsPtrRecords)
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

        PrivateDnsPtrRecordData IJsonModel<PrivateDnsPtrRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PrivateDnsPtrRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateDnsPtrRecordData)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateDnsPtrRecordData(document.RootElement, options);
        }

        internal static PrivateDnsPtrRecordData DeserializePrivateDnsPtrRecordData(JsonElement element, ModelReaderWriterOptions options = null)
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
            IList<PrivateDnsPtrRecordInfo> ptrRecords = default;
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
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new PrivateDnsPtrRecordData(
                id,
                name,
                type,
                systemData,
                etag,
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                ttl,
                fqdn,
                isAutoRegistered,
                ptrRecords ?? new ChangeTrackingList<PrivateDnsPtrRecordInfo>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<PrivateDnsPtrRecordData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PrivateDnsPtrRecordData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(PrivateDnsPtrRecordData)} does not support '{options.Format}' format.");
            }
        }

        PrivateDnsPtrRecordData IPersistableModel<PrivateDnsPtrRecordData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PrivateDnsPtrRecordData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePrivateDnsPtrRecordData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PrivateDnsPtrRecordData)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<PrivateDnsPtrRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
