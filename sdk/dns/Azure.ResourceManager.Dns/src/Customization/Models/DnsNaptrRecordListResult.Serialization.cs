// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Dns;

namespace Azure.ResourceManager.Dns.Models
{
    internal partial class DnsNaptrRecordListResult : IUtf8JsonSerializable, IJsonModel<DnsNaptrRecordListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DnsNaptrRecordListResult>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DnsNaptrRecordListResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsNaptrRecordListResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DnsNaptrRecordListResult)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStartArray();
                foreach (var item in Value)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsDefined(NextLink))
            {
                writer.WritePropertyName("nextLink"u8);
                writer.WriteStringValue(NextLink);
            }
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
        DnsNaptrRecordListResult IJsonModel<DnsNaptrRecordListResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsNaptrRecordListResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DnsNaptrRecordListResult)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDnsNaptrRecordListResult(document.RootElement, options);
        }
        internal static DnsNaptrRecordListResult DeserializeDnsNaptrRecordListResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<DnsNaptrRecordData> value = default;
            string nextLink = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DnsNaptrRecordData> array = new List<DnsNaptrRecordData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DnsNaptrRecordData.DeserializeDnsNaptrRecordData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DnsNaptrRecordListResult(value ?? new ChangeTrackingList<DnsNaptrRecordData>(), nextLink, serializedAdditionalRawData);
        }
        BinaryData IPersistableModel<DnsNaptrRecordListResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsNaptrRecordListResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDnsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DnsNaptrRecordListResult)} does not support '{options.Format}' format.");
            }
        }

        DnsNaptrRecordListResult IPersistableModel<DnsNaptrRecordListResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DnsNaptrRecordListResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDnsNaptrRecordListResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DnsNaptrRecordListResult)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DnsNaptrRecordListResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
