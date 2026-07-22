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
    public partial class NetAppElasticCapacityPoolCollection : ArmCollection, IEnumerable<NetAppElasticCapacityPoolResource>, IAsyncEnumerable<NetAppElasticCapacityPoolResource> { protected NetAppElasticCapacityPoolCollection() { } internal NetAppElasticCapacityPoolCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { } public virtual ArmOperation<NetAppElasticCapacityPoolResource> CreateOrUpdate(WaitUntil waitUntil, string elasticPoolName, NetAppElasticCapacityPoolData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticCapacityPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string elasticPoolName, NetAppElasticCapacityPoolData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<bool> Exists(string elasticPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<bool>> ExistsAsync(string elasticPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticCapacityPoolResource> Get(string elasticPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticCapacityPoolResource>> GetAsync(string elasticPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Pageable<NetAppElasticCapacityPoolResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual AsyncPageable<NetAppElasticCapacityPoolResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual NullableResponse<NetAppElasticCapacityPoolResource> GetIfExists(string elasticPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<NullableResponse<NetAppElasticCapacityPoolResource>> GetIfExistsAsync(string elasticPoolName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public IEnumerator<NetAppElasticCapacityPoolResource> GetEnumerator() => throw new NotSupportedException(); IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(); public IAsyncEnumerator<NetAppElasticCapacityPoolResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => throw new NotSupportedException(); }
}
