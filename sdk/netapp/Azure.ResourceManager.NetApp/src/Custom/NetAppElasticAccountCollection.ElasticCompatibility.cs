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
    public partial class NetAppElasticAccountCollection : ArmCollection, IEnumerable<NetAppElasticAccountResource>, IAsyncEnumerable<NetAppElasticAccountResource> { protected NetAppElasticAccountCollection() { } internal NetAppElasticAccountCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { } public virtual Task<Response<NetAppElasticAccountResource>> GetAsync(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticAccountResource> Get(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public IEnumerator<NetAppElasticAccountResource> GetEnumerator() => throw new NotSupportedException(); IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException(); public IAsyncEnumerator<NetAppElasticAccountResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => throw new NotSupportedException(); }
}
