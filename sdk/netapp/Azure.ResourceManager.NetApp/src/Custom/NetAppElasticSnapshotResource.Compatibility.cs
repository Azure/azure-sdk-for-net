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
    public partial class NetAppElasticSnapshotResource : ArmResource, IJsonModel<NetAppElasticSnapshotData>, IPersistableModel<NetAppElasticSnapshotData> { public static readonly ResourceType ResourceType = "Microsoft.NetApp/netAppAccounts/elasticCapacityPools/elasticVolumes/elasticSnapshots"; private readonly NetAppElasticSnapshotData _data; private bool _hasData; protected NetAppElasticSnapshotResource() { } internal NetAppElasticSnapshotResource(ArmClient client, ResourceIdentifier id) : base(client, id) { } internal NetAppElasticSnapshotResource(ArmClient client, NetAppElasticSnapshotData data) : this(client, data.Id) { _data = data; _hasData = true; } public virtual bool HasData => _hasData; public virtual NetAppElasticSnapshotData Data => _data; public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string elasticPoolName, string volumeName, string snapshotName) => new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/elasticCapacityPools/{elasticPoolName}/elasticVolumes/{volumeName}/elasticSnapshots/{snapshotName}"); public virtual Response<NetAppElasticSnapshotResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticSnapshotResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual ArmOperation<NetAppElasticSnapshotResource> Update(WaitUntil waitUntil, NetAppElasticSnapshotData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticSnapshotResource>> UpdateAsync(WaitUntil waitUntil, NetAppElasticSnapshotData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); void IJsonModel<NetAppElasticSnapshotData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException(); NetAppElasticSnapshotData IJsonModel<NetAppElasticSnapshotData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new NetAppElasticSnapshotData(default, default, default, default, default); System.BinaryData IPersistableModel<NetAppElasticSnapshotData>.Write(ModelReaderWriterOptions options) => System.BinaryData.FromString("{}"); NetAppElasticSnapshotData IPersistableModel<NetAppElasticSnapshotData>.Create(System.BinaryData data, ModelReaderWriterOptions options) => new NetAppElasticSnapshotData(default, default, default, default, default); string IPersistableModel<NetAppElasticSnapshotData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J"; }
}
