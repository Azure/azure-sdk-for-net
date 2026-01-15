// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlServerKeyResource : IJsonModel<MySqlServerKeyData>
    {
        private static MySqlServerKeyData s_dataDeserializationInstance;
        private static MySqlServerKeyData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlServerKeyData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlServerKeyData>)Data).Write(writer, options);

        MySqlServerKeyData IJsonModel<MySqlServerKeyData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlServerKeyData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlServerKeyData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlServerKeyData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlServerKeyData IPersistableModel<MySqlServerKeyData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlServerKeyData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlServerKeyData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlServerKeyData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}