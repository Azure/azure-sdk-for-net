// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlPrivateEndpointConnectionResource : IJsonModel<MySqlPrivateEndpointConnectionData>
    {
        private static MySqlPrivateEndpointConnectionData s_dataDeserializationInstance;
        private static MySqlPrivateEndpointConnectionData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlPrivateEndpointConnectionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlPrivateEndpointConnectionData>)Data).Write(writer, options);

        MySqlPrivateEndpointConnectionData IJsonModel<MySqlPrivateEndpointConnectionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlPrivateEndpointConnectionData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlPrivateEndpointConnectionData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlPrivateEndpointConnectionData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlPrivateEndpointConnectionData IPersistableModel<MySqlPrivateEndpointConnectionData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlPrivateEndpointConnectionData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlPrivateEndpointConnectionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlPrivateEndpointConnectionData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}