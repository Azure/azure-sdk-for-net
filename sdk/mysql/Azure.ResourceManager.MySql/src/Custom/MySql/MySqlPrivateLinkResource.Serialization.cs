// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlPrivateLinkResource : IJsonModel<MySqlPrivateLinkResourceData>
    {
        private static MySqlPrivateLinkResourceData s_dataDeserializationInstance;
        private static MySqlPrivateLinkResourceData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlPrivateLinkResourceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlPrivateLinkResourceData>)Data).Write(writer, options);

        MySqlPrivateLinkResourceData IJsonModel<MySqlPrivateLinkResourceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlPrivateLinkResourceData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlPrivateLinkResourceData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlPrivateLinkResourceData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlPrivateLinkResourceData IPersistableModel<MySqlPrivateLinkResourceData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlPrivateLinkResourceData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlPrivateLinkResourceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlPrivateLinkResourceData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}