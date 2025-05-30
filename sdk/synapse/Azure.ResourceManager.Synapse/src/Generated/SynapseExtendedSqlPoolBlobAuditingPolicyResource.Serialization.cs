// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Synapse
{
    public partial class SynapseExtendedSqlPoolBlobAuditingPolicyResource : IJsonModel<SynapseExtendedSqlPoolBlobAuditingPolicyData>
    {
        private static SynapseExtendedSqlPoolBlobAuditingPolicyData s_dataDeserializationInstance;
        private static SynapseExtendedSqlPoolBlobAuditingPolicyData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<SynapseExtendedSqlPoolBlobAuditingPolicyData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<SynapseExtendedSqlPoolBlobAuditingPolicyData>)Data).Write(writer, options);

        SynapseExtendedSqlPoolBlobAuditingPolicyData IJsonModel<SynapseExtendedSqlPoolBlobAuditingPolicyData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<SynapseExtendedSqlPoolBlobAuditingPolicyData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<SynapseExtendedSqlPoolBlobAuditingPolicyData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<SynapseExtendedSqlPoolBlobAuditingPolicyData>(Data, options, AzureResourceManagerSynapseContext.Default);

        SynapseExtendedSqlPoolBlobAuditingPolicyData IPersistableModel<SynapseExtendedSqlPoolBlobAuditingPolicyData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<SynapseExtendedSqlPoolBlobAuditingPolicyData>(data, options, AzureResourceManagerSynapseContext.Default);

        string IPersistableModel<SynapseExtendedSqlPoolBlobAuditingPolicyData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<SynapseExtendedSqlPoolBlobAuditingPolicyData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}
