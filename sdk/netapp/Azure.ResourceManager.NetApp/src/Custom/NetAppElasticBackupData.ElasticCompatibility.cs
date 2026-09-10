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
    public partial class NetAppElasticBackupData : ResourceData, IJsonModel<NetAppElasticBackupData>, IPersistableModel<NetAppElasticBackupData> { public NetAppElasticBackupData() : base(default, default, default, default) { } internal NetAppElasticBackupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ElasticBackupProperties properties) : base(id, name, resourceType, systemData) { Properties = properties; } public ElasticBackupProperties Properties { get; set; } protected virtual ResourceData PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticBackupData(); protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => System.BinaryData.FromString("{}"); NetAppElasticBackupData IPersistableModel<NetAppElasticBackupData>.Create(System.BinaryData data, ModelReaderWriterOptions options) => (NetAppElasticBackupData)PersistableModelCreateCore(data, options); string IPersistableModel<NetAppElasticBackupData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J"; System.BinaryData IPersistableModel<NetAppElasticBackupData>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options); void IJsonModel<NetAppElasticBackupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); } NetAppElasticBackupData IJsonModel<NetAppElasticBackupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticBackupData(); }
}
