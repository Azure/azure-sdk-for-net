// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlQueryStatisticResource : IJsonModel<MySqlQueryStatisticData>
    {
        private static MySqlQueryStatisticData s_dataDeserializationInstance;
        private static MySqlQueryStatisticData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlQueryStatisticData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlQueryStatisticData>)Data).Write(writer, options);

        MySqlQueryStatisticData IJsonModel<MySqlQueryStatisticData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlQueryStatisticData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlQueryStatisticData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlQueryStatisticData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlQueryStatisticData IPersistableModel<MySqlQueryStatisticData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlQueryStatisticData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlQueryStatisticData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlQueryStatisticData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}