// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Network
{
    public partial class ManagementGroupNetworkManagerConnectionResource : IJsonModel<SubscriptionNetworkManagerConnectionData>, IPersistableModel<SubscriptionNetworkManagerConnectionData>
    {
        SubscriptionNetworkManagerConnectionData IJsonModel<SubscriptionNetworkManagerConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<SubscriptionNetworkManagerConnectionData>)new SubscriptionNetworkManagerConnectionData()).Create(ref reader, options);

        void IJsonModel<SubscriptionNetworkManagerConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<SubscriptionNetworkManagerConnectionData>)(SubscriptionNetworkManagerConnectionData)Data).Write(writer, options);

        SubscriptionNetworkManagerConnectionData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options)
            => ModelReaderWriter.Read<SubscriptionNetworkManagerConnectionData>(data, options, AzureResourceManagerNetworkContext.Default);

        string IPersistableModel<SubscriptionNetworkManagerConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<SubscriptionNetworkManagerConnectionData>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write((SubscriptionNetworkManagerConnectionData)Data, options, AzureResourceManagerNetworkContext.Default);
    }
}
