// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// TypeSpec generates a shared record-set data model and record-type parameters; these partials preserve the shipped per-record data and fixed-record-type APIs.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.PrivateDns.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PrivateDns
{
    /// <summary> Describes a DNS record set (a collection of DNS records with the same name and type). </summary>
    public partial class PrivateDnsBaseRecordData : ResourceData, IJsonModel<PrivateDnsBaseRecordData>
    {
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateDnsBaseRecordData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializePrivateDnsBaseRecordData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PrivateDnsBaseRecordData)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateDnsBaseRecordData>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerPrivateDnsContext.Default);
                default:
                    throw new FormatException($"The model {nameof(PrivateDnsBaseRecordData)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<PrivateDnsBaseRecordData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsBaseRecordData IPersistableModel<PrivateDnsBaseRecordData>.Create(BinaryData data, ModelReaderWriterOptions options) => (PrivateDnsBaseRecordData)PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<PrivateDnsBaseRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="PrivateDnsBaseRecordData"> The <see cref="PrivateDnsBaseRecordData"/> to serialize into <see cref="RequestContent"/>. </param>
        internal static RequestContent ToRequestContent(PrivateDnsBaseRecordData PrivateDnsBaseRecordData)
        {
            if (PrivateDnsBaseRecordData == null)
            {
                return null;
            }
            return RequestContent.Create(PrivateDnsBaseRecordData, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="response"> The <see cref="Response"/> to deserialize the <see cref="PrivateDnsBaseRecordData"/> from. </param>
        internal static PrivateDnsBaseRecordData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializePrivateDnsBaseRecordData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<PrivateDnsBaseRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateDnsBaseRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateDnsBaseRecordData)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(ETag.Value.ToString());
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        PrivateDnsBaseRecordData IJsonModel<PrivateDnsBaseRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (PrivateDnsBaseRecordData)JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ResourceData JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PrivateDnsBaseRecordData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PrivateDnsBaseRecordData)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateDnsBaseRecordData(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static PrivateDnsBaseRecordData DeserializePrivateDnsBaseRecordData(JsonElement element, ModelReaderWriterOptions options)
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
            PrivateDnsRecordSetProperties properties = default;
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
                    properties = PrivateDnsRecordSetProperties.DeserializePrivateDnsRecordSetProperties(prop.Value, options);
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
            return new PrivateDnsBaseRecordData(
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
