// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlServerSecurityAlertPolicyResource : IJsonModel<MySqlServerSecurityAlertPolicyData>
    {
        private static MySqlServerSecurityAlertPolicyData s_dataDeserializationInstance;
        private static MySqlServerSecurityAlertPolicyData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlServerSecurityAlertPolicyData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlServerSecurityAlertPolicyData>)Data).Write(writer, options);

        MySqlServerSecurityAlertPolicyData IJsonModel<MySqlServerSecurityAlertPolicyData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlServerSecurityAlertPolicyData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlServerSecurityAlertPolicyData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlServerSecurityAlertPolicyData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlServerSecurityAlertPolicyData IPersistableModel<MySqlServerSecurityAlertPolicyData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlServerSecurityAlertPolicyData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlServerSecurityAlertPolicyData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlServerSecurityAlertPolicyData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}