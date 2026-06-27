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
    public partial class NetAppElasticBackupCollection
    {
        public virtual ArmOperation<NetAppElasticBackupResource> CreateOrUpdate(WaitUntil waitUntil, string backupName, NetAppElasticBackupData data, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation<NetAppElasticBackupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string backupName, NetAppElasticBackupData data, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<bool> Exists(string backupName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<bool>> ExistsAsync(string backupName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<NetAppElasticBackupResource> Get(string backupName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticBackupResource>> GetAsync(string backupName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Pageable<NetAppElasticBackupResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual AsyncPageable<NetAppElasticBackupResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual NullableResponse<NetAppElasticBackupResource> GetIfExists(string backupName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<NullableResponse<NetAppElasticBackupResource>> GetIfExistsAsync(string backupName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
    }
}
