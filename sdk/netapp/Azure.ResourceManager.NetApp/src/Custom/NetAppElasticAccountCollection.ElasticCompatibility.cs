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
    public partial class NetAppElasticAccountCollection : ArmCollection, IEnumerable<NetAppElasticAccountResource>, IAsyncEnumerable<NetAppElasticAccountResource> { protected NetAppElasticAccountCollection() { } internal NetAppElasticAccountCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { TryGetApiVersion(NetAppElasticAccountResource.ResourceType, out string netAppElasticAccountApiVersion); _elasticAccountsClientDiagnostics = new Azure.Core.Pipeline.ClientDiagnostics("Azure.ResourceManager.NetApp", NetAppElasticAccountResource.ResourceType.Namespace, Diagnostics); _elasticAccountsRestClient = new ElasticAccounts(_elasticAccountsClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, netAppElasticAccountApiVersion ?? "2026-08-15-preview"); } public virtual Task<Response<NetAppElasticAccountResource>> GetAsync(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticAccountResource> Get(string accountName, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public IEnumerator<NetAppElasticAccountResource> GetEnumerator() => GetAll().GetEnumerator(); IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator(); public IAsyncEnumerator<NetAppElasticAccountResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
}
