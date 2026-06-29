// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
#pragma warning disable SA1402

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppElasticAccountResource : IJsonModel<NetAppElasticAccountData>, IPersistableModel<NetAppElasticAccountData>
    {
        public static readonly ResourceType ResourceType = "Microsoft.NetApp/netAppAccounts";
        private readonly NetAppElasticAccountData _data;
        private bool _hasData;

        internal NetAppElasticAccountResource(ArmClient client, NetAppElasticAccountData data) : this(client, data.Id)
        {
            _data = data;
            _hasData = true;
        }

        public virtual bool HasData => _hasData;
        public virtual NetAppElasticAccountData Data => _data;

        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName)
            => new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}");

        public virtual Response<NetAppElasticAccountResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticAccountResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual ArmOperation<NetAppElasticAccountResource> Update(WaitUntil waitUntil, NetAppElasticAccountPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation<NetAppElasticAccountResource>> UpdateAsync(WaitUntil waitUntil, NetAppElasticAccountPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<NetAppElasticAccountResource> AddTag(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticAccountResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<NetAppElasticAccountResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticAccountResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<NetAppElasticAccountResource> RemoveTag(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticAccountResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual NetAppElasticBackupPolicyCollection GetNetAppElasticBackupPolicies() => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Response<NetAppElasticBackupPolicyResource> GetNetAppElasticBackupPolicy(string backupPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Task<Response<NetAppElasticBackupPolicyResource>> GetNetAppElasticBackupPolicyAsync(string backupPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual NetAppElasticBackupVaultCollection GetNetAppElasticBackupVaults() => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Response<NetAppElasticBackupVaultResource> GetNetAppElasticBackupVault(string backupVaultName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Task<Response<NetAppElasticBackupVaultResource>> GetNetAppElasticBackupVaultAsync(string backupVaultName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual NetAppElasticCapacityPoolCollection GetNetAppElasticCapacityPools() => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Response<NetAppElasticCapacityPoolResource> GetNetAppElasticCapacityPool(string elasticPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Task<Response<NetAppElasticCapacityPoolResource>> GetNetAppElasticCapacityPoolAsync(string elasticPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual NetAppElasticSnapshotPolicyCollection GetNetAppElasticSnapshotPolicies() => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Response<NetAppElasticSnapshotPolicyResource> GetNetAppElasticSnapshotPolicy(string snapshotPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        [ForwardsClientCalls]
        public virtual Task<Response<NetAppElasticSnapshotPolicyResource>> GetNetAppElasticSnapshotPolicyAsync(string snapshotPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        NetAppElasticAccountData IJsonModel<NetAppElasticAccountData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticAccountData(default);
        void IJsonModel<NetAppElasticAccountData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();
        NetAppElasticAccountData IPersistableModel<NetAppElasticAccountData>.Create(BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticAccountData(default);
        string IPersistableModel<NetAppElasticAccountData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetAppElasticAccountData>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
    }
}
