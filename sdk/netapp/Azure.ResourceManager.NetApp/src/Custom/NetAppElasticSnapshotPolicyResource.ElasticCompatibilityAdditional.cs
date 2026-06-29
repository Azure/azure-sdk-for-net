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
    public partial class NetAppElasticSnapshotPolicyResource : IJsonModel<NetAppElasticSnapshotPolicyData>, IPersistableModel<NetAppElasticSnapshotPolicyData>
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string snapshotPolicyName)
            => new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/elasticSnapshotPolicies/{snapshotPolicyName}");

        public virtual Response<NetAppElasticSnapshotPolicyResource> AddTag(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticSnapshotPolicyResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<NetAppElasticSnapshotPolicyResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticSnapshotPolicyResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Pageable<NetAppElasticVolumeResource> GetElasticVolumes(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual AsyncPageable<NetAppElasticVolumeResource> GetElasticVolumesAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();

        NetAppElasticSnapshotPolicyData IJsonModel<NetAppElasticSnapshotPolicyData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticSnapshotPolicyData(default);
        void IJsonModel<NetAppElasticSnapshotPolicyData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException();
        NetAppElasticSnapshotPolicyData IPersistableModel<NetAppElasticSnapshotPolicyData>.Create(BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticSnapshotPolicyData(default);
        string IPersistableModel<NetAppElasticSnapshotPolicyData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<NetAppElasticSnapshotPolicyData>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");
    }
}
