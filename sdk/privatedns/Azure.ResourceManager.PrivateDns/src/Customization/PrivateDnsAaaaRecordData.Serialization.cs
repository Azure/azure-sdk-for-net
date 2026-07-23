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
    /// <summary> A class representing the PrivateDnsAaaaRecord data model. </summary>
    public partial class PrivateDnsAaaaRecordData : PrivateDnsBaseRecordData, IJsonModel<PrivateDnsAaaaRecordData>
    {
        /// <param name="response"> The <see cref="Response"/> to deserialize the <see cref="PrivateDnsAaaaRecordData"/> from. </param>
        internal static new PrivateDnsAaaaRecordData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializePrivateDnsAaaaRecordData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        internal static RequestContent ToRequestContent(PrivateDnsAaaaRecordData dnsAaaaRecordData)
            => dnsAaaaRecordData is null ? null : RequestContent.Create(dnsAaaaRecordData, ModelSerializationExtensions.WireOptions);

        internal static PrivateDnsAaaaRecordData DeserializePrivateDnsAaaaRecordData(JsonElement element, ModelReaderWriterOptions options)
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
            return new PrivateDnsAaaaRecordData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties,
                properties,
                eTag);
        }

        void IJsonModel<PrivateDnsAaaaRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        PrivateDnsAaaaRecordData IJsonModel<PrivateDnsAaaaRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateDnsAaaaRecordData(document.RootElement, options);
        }

        BinaryData IPersistableModel<PrivateDnsAaaaRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(this, options, AzureResourceManagerPrivateDnsContext.Default);

        PrivateDnsAaaaRecordData IPersistableModel<PrivateDnsAaaaRecordData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializePrivateDnsAaaaRecordData(document.RootElement, options);
        }

        string IPersistableModel<PrivateDnsAaaaRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
