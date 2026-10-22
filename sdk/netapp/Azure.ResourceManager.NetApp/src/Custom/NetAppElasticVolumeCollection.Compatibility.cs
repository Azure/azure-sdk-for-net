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
    public partial class NetAppElasticVolumeCollection : ArmCollection, IEnumerable<NetAppElasticVolumeResource>, IAsyncEnumerable<NetAppElasticVolumeResource> { protected NetAppElasticVolumeCollection() { } internal NetAppElasticVolumeCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { } public virtual ArmOperation<NetAppElasticVolumeResource> CreateOrUpdate(WaitUntil waitUntil, string volumeName, NetAppElasticVolumeData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticVolumeResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string volumeName, NetAppElasticVolumeData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<bool> Exists(string volumeName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<bool>> ExistsAsync(string volumeName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticVolumeResource> Get(string volumeName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticVolumeResource>> GetAsync(string volumeName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Pageable<NetAppElasticVolumeResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual AsyncPageable<NetAppElasticVolumeResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual NullableResponse<NetAppElasticVolumeResource> GetIfExists(string volumeName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<NullableResponse<NetAppElasticVolumeResource>> GetIfExistsAsync(string volumeName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public IEnumerator<NetAppElasticVolumeResource> GetEnumerator() => throw new NotSupportedException(); IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(); public IAsyncEnumerator<NetAppElasticVolumeResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => throw new NotSupportedException(); }
}
