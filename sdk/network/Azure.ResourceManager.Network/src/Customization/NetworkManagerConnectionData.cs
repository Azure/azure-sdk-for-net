// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility type for network manager connection data. </summary>
    public partial class NetworkManagerConnectionData : ResourceData, IJsonModel<NetworkManagerConnectionData>, IPersistableModel<NetworkManagerConnectionData>, IJsonModel<SubscriptionNetworkManagerConnectionData>, IPersistableModel<SubscriptionNetworkManagerConnectionData>
    {
        /// <summary> Initializes a new instance of <see cref="NetworkManagerConnectionData"/>. </summary>
        public NetworkManagerConnectionData()
        {
        }

        /// <summary> Connection state. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.connectionState")]
        public ScopeConnectionState? ConnectionState { get; }

        /// <summary> A description of the network manager connection. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.description")]
        public string Description { get; set; }

        /// <summary> The entity tag. </summary>
        [Azure.ResourceManager.Network.WirePath("etag")]
        public ETag? ETag { get; }

        /// <summary> Network manager resource identifier. </summary>
        [Azure.ResourceManager.Network.WirePath("properties.networkManagerId")]
        public ResourceIdentifier NetworkManagerId { get; set; }

        /// <summary> Converts the compatibility type to the generated network manager connection data shape. </summary>
        public static implicit operator SubscriptionNetworkManagerConnectionData(NetworkManagerConnectionData data)
        {
            if (data is null)
            {
                return null;
            }

            return new SubscriptionNetworkManagerConnectionData
            {
                NetworkManagerId = data.NetworkManagerId,
                Description = data.Description
            };
        }

        NetworkManagerConnectionData IJsonModel<NetworkManagerConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetworkManagerConnectionData();
        void IJsonModel<NetworkManagerConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        NetworkManagerConnectionData IPersistableModel<NetworkManagerConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options) => new NetworkManagerConnectionData();
        string IPersistableModel<NetworkManagerConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetworkManagerConnectionData>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        SubscriptionNetworkManagerConnectionData IJsonModel<SubscriptionNetworkManagerConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new SubscriptionNetworkManagerConnectionData();
        void IJsonModel<SubscriptionNetworkManagerConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<SubscriptionNetworkManagerConnectionData>)(SubscriptionNetworkManagerConnectionData)this).Write(writer, options);
        SubscriptionNetworkManagerConnectionData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options) => new SubscriptionNetworkManagerConnectionData();
        string IPersistableModel<SubscriptionNetworkManagerConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Write(ModelReaderWriterOptions options) => ((IPersistableModel<SubscriptionNetworkManagerConnectionData>)(SubscriptionNetworkManagerConnectionData)this).Write(options);
    }
}
