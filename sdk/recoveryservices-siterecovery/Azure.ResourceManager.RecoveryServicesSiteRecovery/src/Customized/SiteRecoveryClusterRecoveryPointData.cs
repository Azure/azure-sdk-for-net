// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServicesSiteRecovery.Models;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    /// <summary> Recovery point for a replication protection cluster. </summary>
    public partial class SiteRecoveryClusterRecoveryPointData : ResourceData, IJsonModel<SiteRecoveryClusterRecoveryPointData>
    {
        internal SiteRecoveryClusterRecoveryPointData()
        {
        }

        internal SiteRecoveryClusterRecoveryPointData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, SiteRecoveryClusterRecoveryPointProperties properties)
            : base(id, name, resourceType, systemData)
        {
            Properties = properties;
        }

        /// <summary> The recovery point properties. </summary>
        public SiteRecoveryClusterRecoveryPointProperties Properties { get; }

        /// <summary> The recovery point type. </summary>
        public string ClusterRecoveryPointType => Properties?.RecoveryPointType?.ToString();

        internal static SiteRecoveryClusterRecoveryPointData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content.ToMemory(), ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeSiteRecoveryClusterRecoveryPointData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        internal static SiteRecoveryClusterRecoveryPointData DeserializeSiteRecoveryClusterRecoveryPointData(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SiteRecoveryClusterRecoveryPointProperties properties = default;
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        id = new ResourceIdentifier(prop.Value.GetString());
                    }
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    resourceType = new ResourceType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind != JsonValueKind.Null)
                    {
                        properties = SiteRecoveryClusterRecoveryPointProperties.DeserializeSiteRecoveryClusterRecoveryPointProperties(prop.Value, options);
                    }
                    continue;
                }
            }
            return new SiteRecoveryClusterRecoveryPointData(id, name, resourceType, default, properties);
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SiteRecoveryClusterRecoveryPointData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SiteRecoveryClusterRecoveryPointData)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(ResourceType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
        }

        SiteRecoveryClusterRecoveryPointData IJsonModel<SiteRecoveryClusterRecoveryPointData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSiteRecoveryClusterRecoveryPointData(document.RootElement, options);
        }

        void IJsonModel<SiteRecoveryClusterRecoveryPointData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        SiteRecoveryClusterRecoveryPointData IPersistableModel<SiteRecoveryClusterRecoveryPointData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeSiteRecoveryClusterRecoveryPointData(document.RootElement, options);
        }

        BinaryData IPersistableModel<SiteRecoveryClusterRecoveryPointData>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options, AzureResourceManagerRecoveryServicesSiteRecoveryContext.Default);

        string IPersistableModel<SiteRecoveryClusterRecoveryPointData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
