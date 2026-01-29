// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlFirewallRuleResource : IJsonModel<MySqlFirewallRuleData>
    {
        private static MySqlFirewallRuleData s_dataDeserializationInstance;
        private static MySqlFirewallRuleData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlFirewallRuleData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlFirewallRuleData>)Data).Write(writer, options);

        MySqlFirewallRuleData IJsonModel<MySqlFirewallRuleData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlFirewallRuleData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlFirewallRuleData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlFirewallRuleData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlFirewallRuleData IPersistableModel<MySqlFirewallRuleData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlFirewallRuleData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlFirewallRuleData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlFirewallRuleData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}