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
    public partial class NetAppElasticSnapshotPolicyCollection : ArmCollection, IEnumerable<NetAppElasticSnapshotPolicyResource>, IAsyncEnumerable<NetAppElasticSnapshotPolicyResource> { protected NetAppElasticSnapshotPolicyCollection() { } internal NetAppElasticSnapshotPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { } public virtual ArmOperation<NetAppElasticSnapshotPolicyResource> CreateOrUpdate(WaitUntil waitUntil, string snapshotPolicyName, NetAppElasticSnapshotPolicyData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticSnapshotPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string snapshotPolicyName, NetAppElasticSnapshotPolicyData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<bool> Exists(string snapshotPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<bool>> ExistsAsync(string snapshotPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticSnapshotPolicyResource> Get(string snapshotPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticSnapshotPolicyResource>> GetAsync(string snapshotPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Pageable<NetAppElasticSnapshotPolicyResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual AsyncPageable<NetAppElasticSnapshotPolicyResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual NullableResponse<NetAppElasticSnapshotPolicyResource> GetIfExists(string snapshotPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<NullableResponse<NetAppElasticSnapshotPolicyResource>> GetIfExistsAsync(string snapshotPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public IEnumerator<NetAppElasticSnapshotPolicyResource> GetEnumerator() => throw new NotSupportedException(); IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(); public IAsyncEnumerator<NetAppElasticSnapshotPolicyResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => throw new NotSupportedException(); }
}
