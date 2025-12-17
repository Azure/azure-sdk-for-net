// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlServerResource : IJsonModel<MySqlServerData>
    {
        private static MySqlServerData s_dataDeserializationInstance;
        private static MySqlServerData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlServerData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlServerData>)Data).Write(writer, options);

        MySqlServerData IJsonModel<MySqlServerData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlServerData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlServerData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlServerData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlServerData IPersistableModel<MySqlServerData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlServerData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlServerData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlServerData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}