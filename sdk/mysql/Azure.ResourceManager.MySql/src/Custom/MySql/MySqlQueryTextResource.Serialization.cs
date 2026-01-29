// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlQueryTextResource : IJsonModel<MySqlQueryTextData>
    {
        private static MySqlQueryTextData s_dataDeserializationInstance;
        private static MySqlQueryTextData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlQueryTextData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlQueryTextData>)Data).Write(writer, options);

        MySqlQueryTextData IJsonModel<MySqlQueryTextData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlQueryTextData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlQueryTextData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlQueryTextData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlQueryTextData IPersistableModel<MySqlQueryTextData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlQueryTextData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlQueryTextData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlQueryTextData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}