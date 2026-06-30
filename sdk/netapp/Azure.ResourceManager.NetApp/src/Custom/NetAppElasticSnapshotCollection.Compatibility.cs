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
    public partial class NetAppElasticSnapshotCollection : ArmCollection, IEnumerable<NetAppElasticSnapshotResource>, IAsyncEnumerable<NetAppElasticSnapshotResource> { protected NetAppElasticSnapshotCollection() { } internal NetAppElasticSnapshotCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { } public virtual ArmOperation<NetAppElasticSnapshotResource> CreateOrUpdate(WaitUntil waitUntil, string snapshotName, NetAppElasticSnapshotData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticSnapshotResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string snapshotName, NetAppElasticSnapshotData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<bool> Exists(string snapshotName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<bool>> ExistsAsync(string snapshotName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticSnapshotResource> Get(string snapshotName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticSnapshotResource>> GetAsync(string snapshotName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Pageable<NetAppElasticSnapshotResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual AsyncPageable<NetAppElasticSnapshotResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual NullableResponse<NetAppElasticSnapshotResource> GetIfExists(string snapshotName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<NullableResponse<NetAppElasticSnapshotResource>> GetIfExistsAsync(string snapshotName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public IEnumerator<NetAppElasticSnapshotResource> GetEnumerator() => throw new NotSupportedException(); IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(); public IAsyncEnumerator<NetAppElasticSnapshotResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => throw new NotSupportedException(); }
}
