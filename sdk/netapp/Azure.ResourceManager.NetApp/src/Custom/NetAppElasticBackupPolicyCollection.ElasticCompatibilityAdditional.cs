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
    public partial class NetAppElasticBackupPolicyCollection
    {
        public virtual ArmOperation<NetAppElasticBackupPolicyResource> CreateOrUpdate(WaitUntil waitUntil, string backupPolicyName, NetAppElasticBackupPolicyData data, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation<NetAppElasticBackupPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string backupPolicyName, NetAppElasticBackupPolicyData data, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<bool> Exists(string backupPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<bool>> ExistsAsync(string backupPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<NetAppElasticBackupPolicyResource> Get(string backupPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<NetAppElasticBackupPolicyResource>> GetAsync(string backupPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Pageable<NetAppElasticBackupPolicyResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual AsyncPageable<NetAppElasticBackupPolicyResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual NullableResponse<NetAppElasticBackupPolicyResource> GetIfExists(string backupPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<NullableResponse<NetAppElasticBackupPolicyResource>> GetIfExistsAsync(string backupPolicyName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
    }
}
