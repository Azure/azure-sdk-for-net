// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlDatabaseResource : IJsonModel<MySqlDatabaseData>
    {
        private static MySqlDatabaseData s_dataDeserializationInstance;
        private static MySqlDatabaseData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlDatabaseData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlDatabaseData>)Data).Write(writer, options);

        MySqlDatabaseData IJsonModel<MySqlDatabaseData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlDatabaseData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlDatabaseData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlDatabaseData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlDatabaseData IPersistableModel<MySqlDatabaseData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlDatabaseData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlDatabaseData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlDatabaseData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}