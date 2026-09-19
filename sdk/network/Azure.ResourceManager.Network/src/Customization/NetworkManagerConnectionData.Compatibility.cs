// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkManagerConnectionData type. </summary>
    [CodeGenSerialization(nameof(ETag), "etag")]
    public partial class NetworkManagerConnectionData : IJsonModel<SubscriptionNetworkManagerConnectionData>, IPersistableModel<SubscriptionNetworkManagerConnectionData>
    {
        /// <summary> The entity tag. </summary>
        [CodeGenMember("ETag")]
        public ETag? ETag { get; }

        /// <summary> Converts the neutral connection data to the former subscription-specific compatibility type. </summary>
        public static implicit operator SubscriptionNetworkManagerConnectionData(NetworkManagerConnectionData data)
        {
            if (data is null)
            {
                return null;
            }

            return new SubscriptionNetworkManagerConnectionData(
                data.Id,
                data.Name,
                data.ResourceType.ToString(),
                data.ETag?.ToString(),
                data._additionalBinaryDataProperties,
                data.Properties,
                data.SystemData);
        }

        SubscriptionNetworkManagerConnectionData IJsonModel<SubscriptionNetworkManagerConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<SubscriptionNetworkManagerConnectionData>)new SubscriptionNetworkManagerConnectionData()).Create(ref reader, options);

        void IJsonModel<SubscriptionNetworkManagerConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<SubscriptionNetworkManagerConnectionData>)(SubscriptionNetworkManagerConnectionData)this).Write(writer, options);

        SubscriptionNetworkManagerConnectionData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => ModelReaderWriter.Read<SubscriptionNetworkManagerConnectionData>(data, options, AzureResourceManagerNetworkContext.Default);

        string IPersistableModel<SubscriptionNetworkManagerConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write((SubscriptionNetworkManagerConnectionData)this, options, AzureResourceManagerNetworkContext.Default);
    }
}
