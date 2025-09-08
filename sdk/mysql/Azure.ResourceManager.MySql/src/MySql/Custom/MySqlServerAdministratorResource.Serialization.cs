// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlServerAdministratorResource : IJsonModel<MySqlServerAdministratorData>
    {
        private static MySqlServerAdministratorData s_dataDeserializationInstance;
        private static MySqlServerAdministratorData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlServerAdministratorData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlServerAdministratorData>)Data).Write(writer, options);

        MySqlServerAdministratorData IJsonModel<MySqlServerAdministratorData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlServerAdministratorData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlServerAdministratorData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlServerAdministratorData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlServerAdministratorData IPersistableModel<MySqlServerAdministratorData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlServerAdministratorData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlServerAdministratorData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlServerAdministratorData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}