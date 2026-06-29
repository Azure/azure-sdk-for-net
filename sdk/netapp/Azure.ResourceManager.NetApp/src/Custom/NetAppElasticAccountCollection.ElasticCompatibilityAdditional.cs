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
    public partial class NetAppElasticAccountCollection
    {
        public virtual ArmOperation<NetAppElasticAccountResource> CreateOrUpdate(WaitUntil waitUntil, string accountName, NetAppElasticAccountData data, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<ArmOperation<NetAppElasticAccountResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string accountName, NetAppElasticAccountData data, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Response<bool> Exists(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<Response<bool>> ExistsAsync(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Pageable<NetAppElasticAccountResource> GetAll(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual AsyncPageable<NetAppElasticAccountResource> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual NullableResponse<NetAppElasticAccountResource> GetIfExists(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public virtual Task<NullableResponse<NetAppElasticAccountResource>> GetIfExistsAsync(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException();
    }
}
