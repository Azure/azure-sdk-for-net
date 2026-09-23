// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    // The previous GA version mistakenly exposed this subscription-specific data type. This facade is retained solely to
    // mitigate breaking changes and converts to the canonical NetworkManagerConnectionData for generated operations.
    /// <summary> Represents subscription network manager connection data. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete. Please use NetworkManagerConnectionData instead.")]
    public partial class SubscriptionNetworkManagerConnectionData : NetworkChildResource, IJsonModel<SubscriptionNetworkManagerConnectionData>, IPersistableModel<SubscriptionNetworkManagerConnectionData>
    {
        private NetworkManagerConnectionProperties _properties;

        /// <summary> Initializes a new instance of <see cref="SubscriptionNetworkManagerConnectionData"/>. </summary>
        public SubscriptionNetworkManagerConnectionData()
        {
        }

        internal SubscriptionNetworkManagerConnectionData(
            ResourceIdentifier id,
            string name,
            string resourceType,
            string eTag,
            IDictionary<string, BinaryData> additionalBinaryDataProperties,
            NetworkManagerConnectionProperties properties,
            SystemData systemData)
            : base(id, name, resourceType, eTag, additionalBinaryDataProperties)
        {
            _properties = properties;
            SystemData = systemData;
        }

        /// <summary> The system metadata related to this resource. </summary>
        [WirePath("systemData")]
        public SystemData SystemData { get; }

        /// <summary> Network Manager Id. </summary>
        [WirePath("properties.networkManagerId")]
        public ResourceIdentifier NetworkManagerId
        {
            get => Properties.NetworkManagerId;
            set => Properties.NetworkManagerId = value;
        }

        /// <summary> Connection state. </summary>
        [WirePath("properties.connectionState")]
        public ScopeConnectionState? ConnectionState => _properties?.ConnectionState;

        /// <summary> A description of the network manager connection. </summary>
        [WirePath("properties.description")]
        public string Description
        {
            get => Properties.Description;
            set => Properties.Description = value;
        }

        private NetworkManagerConnectionProperties Properties => _properties ??= new NetworkManagerConnectionProperties();

        internal NetworkManagerConnectionData ToNetworkManagerConnectionData()
            => new NetworkManagerConnectionData(
                Id,
                Name,
                Type is null ? default : new ResourceType(Type),
                SystemData,
                _properties,
                ETag is null ? default : new ETag(ETag),
                _additionalBinaryDataProperties);

        /// <inheritdoc />
        protected override NetworkChildResource PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
            => ModelReaderWriter.Read<SubscriptionNetworkManagerConnectionData>(data, options, AzureResourceManagerNetworkContext.Default);

        /// <inheritdoc />
        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write(this, options, AzureResourceManagerNetworkContext.Default);

        BinaryData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);

        SubscriptionNetworkManagerConnectionData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => (SubscriptionNetworkManagerConnectionData)PersistableModelCreateCore(data, options);

        string IPersistableModel<SubscriptionNetworkManagerConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<SubscriptionNetworkManagerConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <inheritdoc />
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            base.JsonModelWriteCore(writer, options);
            if (_properties is not null)
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(_properties, options);
            }
            if (options.Format != "W" && SystemData is not null)
            {
                writer.WritePropertyName("systemData"u8);
                ((IJsonModel<SystemData>)SystemData).Write(writer, options);
            }
        }

        SubscriptionNetworkManagerConnectionData IJsonModel<SubscriptionNetworkManagerConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => (SubscriptionNetworkManagerConnectionData)JsonModelCreateCore(ref reader, options);

        /// <inheritdoc />
        protected override NetworkChildResource JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return Deserialize(document.RootElement, options);
        }

        private static SubscriptionNetworkManagerConnectionData Deserialize(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ResourceIdentifier id = default;
            string name = default;
            string resourceType = default;
            string eTag = default;
            NetworkManagerConnectionProperties properties = default;
            SystemData systemData = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.ValueKind == JsonValueKind.Null ? default : new ResourceIdentifier(property.Value.GetString());
                }
                else if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                }
                else if (property.NameEquals("type"u8))
                {
                    resourceType = property.Value.GetString();
                }
                else if (property.NameEquals("etag"u8))
                {
                    eTag = property.Value.GetString();
                }
                else if (property.NameEquals("properties"u8) && property.Value.ValueKind != JsonValueKind.Null)
                {
                    properties = NetworkManagerConnectionProperties.DeserializeNetworkManagerConnectionProperties(property.Value, options);
                }
                else if (property.NameEquals("systemData"u8) && property.Value.ValueKind != JsonValueKind.Null)
                {
                    systemData = ModelReaderWriter.Read<SystemData>(
                        new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())),
                        ModelSerializationExtensions.WireOptions,
                        AzureResourceManagerNetworkContext.Default);
                }
                else if (options.Format != "W")
                {
                    additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }

            return new SubscriptionNetworkManagerConnectionData(id, name, resourceType, eTag, additionalProperties, properties, systemData);
        }
    }
}
