// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Network
{
    // The obsolete generic interfaces are intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
    public partial class ManagementGroupNetworkManagerConnectionResource : IJsonModel<SubscriptionNetworkManagerConnectionData>, IPersistableModel<SubscriptionNetworkManagerConnectionData>
#pragma warning restore CS0618
    {
        // Restores the mistakenly exposed GA subscription-specific overload solely to mitigate breaking changes and delegates
        // to the canonical generated overload accepting NetworkManagerConnectionData.
        /// <summary> Updates the management group network manager connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete and will be removed in a future release. Use UpdateAsync with NetworkManagerConnectionData instead.")]
        public virtual Task<ArmOperation<ManagementGroupNetworkManagerConnectionResource>> UpdateAsync(WaitUntil waitUntil, SubscriptionNetworkManagerConnectionData data, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, data?.ToNetworkManagerConnectionData(), cancellationToken);

        // Restores the mistakenly exposed GA subscription-specific overload solely to mitigate breaking changes and delegates
        // to the canonical generated overload accepting NetworkManagerConnectionData.
        /// <summary> Updates the management group network manager connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete and will be removed in a future release. Use Update with NetworkManagerConnectionData instead.")]
        public virtual ArmOperation<ManagementGroupNetworkManagerConnectionResource> Update(WaitUntil waitUntil, SubscriptionNetworkManagerConnectionData data, CancellationToken cancellationToken = default)
            => Update(waitUntil, data?.ToNetworkManagerConnectionData(), cancellationToken);

        // The obsolete generic interface signature is intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
        SubscriptionNetworkManagerConnectionData IJsonModel<SubscriptionNetworkManagerConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<SubscriptionNetworkManagerConnectionData>)new SubscriptionNetworkManagerConnectionData()).Create(ref reader, options);
#pragma warning restore CS0618

        // The obsolete generic interface signature is intentionally retained for binary and source compatibility with the previous GA.
#pragma warning disable CS0618
        void IJsonModel<SubscriptionNetworkManagerConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<SubscriptionNetworkManagerConnectionData>)(SubscriptionNetworkManagerConnectionData)Data).Write(writer, options);
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
            => ModelReaderWriter.Write((SubscriptionNetworkManagerConnectionData)Data, options, AzureResourceManagerNetworkContext.Default);
#pragma warning restore CS0618
    }
}
