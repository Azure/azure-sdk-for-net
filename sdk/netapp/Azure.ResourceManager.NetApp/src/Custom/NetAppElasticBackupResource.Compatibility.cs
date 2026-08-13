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
    public partial class NetAppElasticBackupResource : ArmResource, IJsonModel<NetAppElasticBackupData>, IPersistableModel<NetAppElasticBackupData> { public static readonly ResourceType ResourceType = "Microsoft.NetApp/netAppAccounts/elasticBackupVaults/elasticBackups"; private readonly NetAppElasticBackupData _data; private bool _hasData; protected NetAppElasticBackupResource() { } internal NetAppElasticBackupResource(ArmClient client, ResourceIdentifier id) : base(client, id) { } internal NetAppElasticBackupResource(ArmClient client, NetAppElasticBackupData data) : this(client, data.Id) { _data = data; _hasData = true; } public virtual bool HasData => _hasData; public virtual NetAppElasticBackupData Data => _data; public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupVaultName, string backupName) => new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/elasticBackupVaults/{backupVaultName}/elasticBackups/{backupName}"); public virtual Response<NetAppElasticBackupResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual ArmOperation<NetAppElasticBackupResource> Update(WaitUntil waitUntil, NetAppElasticBackupData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticBackupResource>> UpdateAsync(WaitUntil waitUntil, NetAppElasticBackupData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); void IJsonModel<NetAppElasticBackupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException(); NetAppElasticBackupData IJsonModel<NetAppElasticBackupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticBackupData(); System.BinaryData IPersistableModel<NetAppElasticBackupData>.Write(ModelReaderWriterOptions options) => System.BinaryData.FromString("{}"); NetAppElasticBackupData IPersistableModel<NetAppElasticBackupData>.Create(System.BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticBackupData(); string IPersistableModel<NetAppElasticBackupData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J"; }
}
