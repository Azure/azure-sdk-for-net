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
    /// <summary> A class representing the PrivateDnsTxtRecord data model. </summary>
    public partial class PrivateDnsTxtRecordData : PrivateDnsBaseRecordData, IJsonModel<PrivateDnsTxtRecordData>
    {
        /// <param name="response"> The <see cref="Response"/> to deserialize the <see cref="PrivateDnsTxtRecordData"/> from. </param>
        internal static new PrivateDnsTxtRecordData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializePrivateDnsTxtRecordData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        internal static RequestContent ToRequestContent(PrivateDnsTxtRecordData dnsTxtRecordData)
            => dnsTxtRecordData is null ? null : RequestContent.Create(dnsTxtRecordData, ModelSerializationExtensions.WireOptions);

        internal static PrivateDnsTxtRecordData DeserializePrivateDnsTxtRecordData(JsonElement element, ModelReaderWriterOptions options)
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
            return new PrivateDnsTxtRecordData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties,
                properties,
                eTag);
        }

        void IJsonModel<PrivateDnsTxtRecordData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        PrivateDnsTxtRecordData IJsonModel<PrivateDnsTxtRecordData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateDnsTxtRecordData(document.RootElement, options);
        }

        BinaryData IPersistableModel<PrivateDnsTxtRecordData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(this, options, AzureResourceManagerPrivateDnsContext.Default);

        PrivateDnsTxtRecordData IPersistableModel<PrivateDnsTxtRecordData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializePrivateDnsTxtRecordData(document.RootElement, options);
        }

        string IPersistableModel<PrivateDnsTxtRecordData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
