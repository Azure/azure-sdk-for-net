// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Network
{
    public partial class SubscriptionNetworkManagerConnectionResource : IJsonModel<NetworkManagerConnectionData>, IPersistableModel<NetworkManagerConnectionData>
    {
        NetworkManagerConnectionData IJsonModel<NetworkManagerConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetworkManagerConnectionData();
        void IJsonModel<NetworkManagerConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        NetworkManagerConnectionData IPersistableModel<NetworkManagerConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options) => new NetworkManagerConnectionData();
        string IPersistableModel<NetworkManagerConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetworkManagerConnectionData>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
    }
}
