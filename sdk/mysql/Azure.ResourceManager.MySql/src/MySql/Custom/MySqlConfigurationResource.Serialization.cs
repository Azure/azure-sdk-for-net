// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlConfigurationResource : IJsonModel<MySqlConfigurationData>
    {
        private static MySqlConfigurationData s_dataDeserializationInstance;
        private static MySqlConfigurationData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlConfigurationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlConfigurationData>)Data).Write(writer, options);

        MySqlConfigurationData IJsonModel<MySqlConfigurationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlConfigurationData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlConfigurationData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlConfigurationData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlConfigurationData IPersistableModel<MySqlConfigurationData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlConfigurationData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlConfigurationData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlConfigurationData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}