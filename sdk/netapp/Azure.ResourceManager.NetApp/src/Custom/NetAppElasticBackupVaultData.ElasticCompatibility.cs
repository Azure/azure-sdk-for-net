// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppElasticBackupVaultData : TrackedResourceData, IJsonModel<NetAppElasticBackupVaultData>, IPersistableModel<NetAppElasticBackupVaultData> { public NetAppElasticBackupVaultData(AzureLocation location) : base(location) { } internal NetAppElasticBackupVaultData() : base(default) { } internal NetAppElasticBackupVaultData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, NetAppProvisioningState? provisioningState, ETag? eTag) : base(id, name, resourceType, systemData, tags, location) { ElasticBackupVaultProvisioningState = provisioningState; ETag = eTag; } public NetAppProvisioningState? ElasticBackupVaultProvisioningState { get; set; } public ETag? ETag { get; } protected virtual ResourceData PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticBackupVaultData(); protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => System.BinaryData.FromString("{}"); NetAppElasticBackupVaultData IPersistableModel<NetAppElasticBackupVaultData>.Create(System.BinaryData data, ModelReaderWriterOptions options) => (NetAppElasticBackupVaultData)PersistableModelCreateCore(data, options); string IPersistableModel<NetAppElasticBackupVaultData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J"; System.BinaryData IPersistableModel<NetAppElasticBackupVaultData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options); void IJsonModel<NetAppElasticBackupVaultData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); } NetAppElasticBackupVaultData IJsonModel<NetAppElasticBackupVaultData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticBackupVaultData(); protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { base.JsonModelWriteCore(writer, options); } }
}
