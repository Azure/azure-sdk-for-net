// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlVirtualNetworkRuleResource : IJsonModel<MySqlVirtualNetworkRuleData>
    {
        private static MySqlVirtualNetworkRuleData s_dataDeserializationInstance;
        private static MySqlVirtualNetworkRuleData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlVirtualNetworkRuleData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlVirtualNetworkRuleData>)Data).Write(writer, options);

        MySqlVirtualNetworkRuleData IJsonModel<MySqlVirtualNetworkRuleData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlVirtualNetworkRuleData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlVirtualNetworkRuleData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlVirtualNetworkRuleData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlVirtualNetworkRuleData IPersistableModel<MySqlVirtualNetworkRuleData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlVirtualNetworkRuleData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlVirtualNetworkRuleData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlVirtualNetworkRuleData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}