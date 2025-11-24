// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlAdvisorResource : IJsonModel<MySqlAdvisorData>
    {
        private static MySqlAdvisorData s_dataDeserializationInstance;
        private static MySqlAdvisorData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlAdvisorData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlAdvisorData>)Data).Write(writer, options);

        MySqlAdvisorData IJsonModel<MySqlAdvisorData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlAdvisorData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlAdvisorData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlAdvisorData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlAdvisorData IPersistableModel<MySqlAdvisorData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlAdvisorData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlAdvisorData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlAdvisorData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}