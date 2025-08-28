// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlWaitStatisticResource : IJsonModel<MySqlWaitStatisticData>
    {
        private static MySqlWaitStatisticData s_dataDeserializationInstance;
        private static MySqlWaitStatisticData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlWaitStatisticData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlWaitStatisticData>)Data).Write(writer, options);

        MySqlWaitStatisticData IJsonModel<MySqlWaitStatisticData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlWaitStatisticData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlWaitStatisticData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlWaitStatisticData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlWaitStatisticData IPersistableModel<MySqlWaitStatisticData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlWaitStatisticData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlWaitStatisticData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlWaitStatisticData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}