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
    public partial class NetAppElasticBackupPolicyData : TrackedResourceData, IJsonModel<NetAppElasticBackupPolicyData>, IPersistableModel<NetAppElasticBackupPolicyData> { public NetAppElasticBackupPolicyData(AzureLocation location) : base(location) { } internal NetAppElasticBackupPolicyData() : base(default) { } internal NetAppElasticBackupPolicyData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ElasticBackupPolicyProperties properties, ETag? eTag) : base(id, name, resourceType, systemData, tags, location) { Properties = properties; ETag = eTag; } public ElasticBackupPolicyProperties Properties { get; set; } public ETag? ETag { get; } protected virtual ResourceData PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticBackupPolicyData(); protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => System.BinaryData.FromString("{}"); NetAppElasticBackupPolicyData IPersistableModel<NetAppElasticBackupPolicyData>.Create(System.BinaryData data, ModelReaderWriterOptions options) => (NetAppElasticBackupPolicyData)PersistableModelCreateCore(data, options); string IPersistableModel<NetAppElasticBackupPolicyData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J"; System.BinaryData IPersistableModel<NetAppElasticBackupPolicyData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options); void IJsonModel<NetAppElasticBackupPolicyData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); JsonModelWriteCore(writer, options); writer.WriteEndObject(); } NetAppElasticBackupPolicyData IJsonModel<NetAppElasticBackupPolicyData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticBackupPolicyData(); protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { base.JsonModelWriteCore(writer, options); } }
}
