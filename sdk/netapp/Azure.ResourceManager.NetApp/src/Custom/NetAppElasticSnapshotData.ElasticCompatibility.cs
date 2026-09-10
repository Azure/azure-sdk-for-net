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
    public partial class NetAppElasticSnapshotData : ResourceData, IJsonModel<NetAppElasticSnapshotData>, IPersistableModel<NetAppElasticSnapshotData> { public NetAppElasticSnapshotData() : base(default, default, default, default) { } internal NetAppElasticSnapshotData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, NetAppProvisioningState? provisioningState) : base(id, name, resourceType, systemData) { ElasticSnapshotProvisioningState = provisioningState; } public NetAppProvisioningState? ElasticSnapshotProvisioningState { get; set; } protected virtual ResourceData PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticSnapshotData(); protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => System.BinaryData.FromString("{}"); NetAppElasticSnapshotData IPersistableModel<NetAppElasticSnapshotData>.Create(System.BinaryData data, ModelReaderWriterOptions options) => (NetAppElasticSnapshotData)PersistableModelCreateCore(data, options); string IPersistableModel<NetAppElasticSnapshotData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J"; System.BinaryData IPersistableModel<NetAppElasticSnapshotData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options); void IJsonModel<NetAppElasticSnapshotData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); } NetAppElasticSnapshotData IJsonModel<NetAppElasticSnapshotData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticSnapshotData(); }
}
