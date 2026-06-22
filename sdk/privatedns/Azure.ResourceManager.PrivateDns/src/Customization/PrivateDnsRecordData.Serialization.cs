// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec generates a shared record-set data model and record-type parameters; these partials preserve the shipped per-record data and fixed-record-type APIs.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.PrivateDns.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary> A class representing the DnsRecord data model. </summary>
    public partial class PrivateDnsRecordData : PrivateDnsBaseRecordData, IJsonModel<PrivateDnsRecordData>
    {
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual new PrivateDnsRecordData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateDnsRecordData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializePrivateDnsRecordData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PrivateDnsRecordData)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual new BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateDnsRecordData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerPrivateDnsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(PrivateDnsRecordData)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<PrivateDnsRecordData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsRecordData IPersistableModel<PrivateDnsRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<PrivateDnsRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="dnsRecordData"> The <see cref="PrivateDnsRecordData"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(PrivateDnsRecordData dnsRecordData)
        {
            if (dnsRecordData == null)
            {
                return null;
            }
            return RequestContent.Create(dnsRecordData, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<PrivateDnsRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual new void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateDnsRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateDnsRecordData)} does not support writing '{format}' format.");
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsRecordData IJsonModel<PrivateDnsRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual new PrivateDnsRecordData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateDnsRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateDnsRecordData)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateDnsRecordData(document.RootElement, options);
        }

        /// <param name="response"> The <see cref="Response"/> to deserialize the <see cref="PrivateDnsRecordData"/> from. </param>
        internal static new PrivateDnsRecordData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializePrivateDnsRecordData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        internal static PrivateDnsRecordData DeserializePrivateDnsRecordData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            RecordSetProperties properties = default;
            ETag? eTag = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    id = new ResourceIdentifier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceType = new ResourceType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(prop.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerPrivateDnsContext.Default);
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = RecordSetProperties.DeserializeRecordSetProperties(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("etag"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    eTag = new ETag(prop.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new PrivateDnsRecordData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties,
                properties,
                eTag);
        }
    }
}
