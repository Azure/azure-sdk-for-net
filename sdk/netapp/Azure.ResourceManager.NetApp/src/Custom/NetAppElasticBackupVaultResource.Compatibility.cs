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
    public partial class NetAppElasticBackupVaultResource : ArmResource, IJsonModel<NetAppElasticBackupVaultData>, IPersistableModel<NetAppElasticBackupVaultData> { public static readonly ResourceType ResourceType = "Microsoft.NetApp/netAppAccounts/elasticBackupVaults"; private readonly NetAppElasticBackupVaultData _data; private bool _hasData; protected NetAppElasticBackupVaultResource() { } internal NetAppElasticBackupVaultResource(ArmClient client, ResourceIdentifier id) : base(client, id) { } internal NetAppElasticBackupVaultResource(ArmClient client, NetAppElasticBackupVaultData data) : this(client, data.Id) { _data = data; _hasData = true; } public virtual bool HasData => _hasData; public virtual NetAppElasticBackupVaultData Data => _data; public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupVaultName) => new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/elasticBackupVaults/{backupVaultName}"); public virtual Response<NetAppElasticBackupVaultResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupVaultResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticBackupVaultResource> AddTag(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupVaultResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticBackupVaultResource> RemoveTag(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupVaultResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticBackupVaultResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupVaultResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual ArmOperation<NetAppElasticBackupVaultResource> Update(WaitUntil waitUntil, NetAppElasticBackupVaultPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticBackupVaultResource>> UpdateAsync(WaitUntil waitUntil, NetAppElasticBackupVaultPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual NetAppElasticBackupCollection GetNetAppElasticBackups() => throw new NotSupportedException(); [ForwardsClientCalls] public virtual Response<NetAppElasticBackupResource> GetNetAppElasticBackup(string backupName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); [ForwardsClientCalls] public virtual Task<Response<NetAppElasticBackupResource>> GetNetAppElasticBackupAsync(string backupName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); void IJsonModel<NetAppElasticBackupVaultData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException(); NetAppElasticBackupVaultData IJsonModel<NetAppElasticBackupVaultData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticBackupVaultData(default); System.BinaryData IPersistableModel<NetAppElasticBackupVaultData>.Write(ModelReaderWriterOptions options) => System.BinaryData.FromString("{}"); NetAppElasticBackupVaultData IPersistableModel<NetAppElasticBackupVaultData>.Create(System.BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticBackupVaultData(default); string IPersistableModel<NetAppElasticBackupVaultData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J"; }
}
