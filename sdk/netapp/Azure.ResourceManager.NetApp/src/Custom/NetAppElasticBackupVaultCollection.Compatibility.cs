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
    public partial class NetAppElasticBackupVaultCollection : ArmCollection, IEnumerable<NetAppElasticBackupVaultResource>, IAsyncEnumerable<NetAppElasticBackupVaultResource> { protected NetAppElasticBackupVaultCollection() { } internal NetAppElasticBackupVaultCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { } public virtual ArmOperation<NetAppElasticBackupVaultResource> CreateOrUpdate(WaitUntil waitUntil, string backupVaultName, NetAppElasticBackupVaultData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticBackupVaultResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string backupVaultName, NetAppElasticBackupVaultData data, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<bool> Exists(string backupVaultName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<bool>> ExistsAsync(string backupVaultName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticBackupVaultResource> Get(string backupVaultName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupVaultResource>> GetAsync(string backupVaultName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Pageable<NetAppElasticBackupVaultResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual AsyncPageable<NetAppElasticBackupVaultResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual NullableResponse<NetAppElasticBackupVaultResource> GetIfExists(string backupVaultName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<NullableResponse<NetAppElasticBackupVaultResource>> GetIfExistsAsync(string backupVaultName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public IEnumerator<NetAppElasticBackupVaultResource> GetEnumerator() => throw new NotSupportedException(); IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(); public IAsyncEnumerator<NetAppElasticBackupVaultResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => throw new NotSupportedException(); }
}
