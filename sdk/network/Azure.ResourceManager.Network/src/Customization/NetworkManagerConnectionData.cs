// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // The generator emits the canonical shared model without the former subscription-specific model interfaces and
    // emits its ETag member without the released wire mapping. This partial restores the mistakenly exposed GA
    // IJsonModel and IPersistableModel interfaces for SubscriptionNetworkManagerConnectionData and preserves the
    // canonical nullable Azure.ETag member solely to mitigate breaking changes.
    [CodeGenSerialization(nameof(ETag), "etag")]
    // The obsolete generic interfaces are intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
    public partial class NetworkManagerConnectionData : IJsonModel<SubscriptionNetworkManagerConnectionData>, IPersistableModel<SubscriptionNetworkManagerConnectionData>
#pragma warning restore CS0618
    {
        /// <summary> The entity tag. </summary>
        [CodeGenMember("ETag")]
        public ETag? ETag { get; }

        // The obsolete return type is intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
        /// <summary> Converts network manager connection data to subscription network manager connection data. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This conversion is obsolete. Please use NetworkManagerConnectionData instead.")]
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
#pragma warning restore CS0618

        // The obsolete generic interface signature is intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
        SubscriptionNetworkManagerConnectionData IJsonModel<SubscriptionNetworkManagerConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<SubscriptionNetworkManagerConnectionData>)new SubscriptionNetworkManagerConnectionData()).Create(ref reader, options);
#pragma warning restore CS0618

        // The obsolete generic interface signature is intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
        void IJsonModel<SubscriptionNetworkManagerConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<SubscriptionNetworkManagerConnectionData>)(SubscriptionNetworkManagerConnectionData)this).Write(writer, options);
#pragma warning restore CS0618

        // The obsolete generic interface signature is intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
        SubscriptionNetworkManagerConnectionData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => ModelReaderWriter.Read<SubscriptionNetworkManagerConnectionData>(data, options, AzureResourceManagerNetworkContext.Default);
#pragma warning restore CS0618

        // The obsolete generic interface signature is intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
        string IPersistableModel<SubscriptionNetworkManagerConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
#pragma warning restore CS0618

        // The obsolete generic interface signature is intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
        BinaryData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write((SubscriptionNetworkManagerConnectionData)this, options, AzureResourceManagerNetworkContext.Default);
#pragma warning restore CS0618
    }
}
