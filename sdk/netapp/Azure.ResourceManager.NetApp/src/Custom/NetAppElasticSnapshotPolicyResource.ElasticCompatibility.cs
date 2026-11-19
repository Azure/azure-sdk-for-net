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
    public partial class NetAppElasticSnapshotPolicyResource : ArmResource { public static readonly ResourceType ResourceType = "Microsoft.NetApp/netAppAccounts/elasticSnapshotPolicies"; private readonly NetAppElasticSnapshotPolicyData _data; private bool _hasData; protected NetAppElasticSnapshotPolicyResource() { } internal NetAppElasticSnapshotPolicyResource(ArmClient client, ResourceIdentifier id) : base(client, id) { TryGetApiVersion(ResourceType, out string netAppElasticSnapshotPolicyApiVersion); _elasticSnapshotPoliciesClientDiagnostics = new Azure.Core.Pipeline.ClientDiagnostics("Azure.ResourceManager.NetApp", ResourceType.Namespace, Diagnostics); _elasticSnapshotPoliciesRestClient = new ElasticSnapshotPolicies(_elasticSnapshotPoliciesClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, netAppElasticSnapshotPolicyApiVersion ?? "2026-08-15-preview"); } internal NetAppElasticSnapshotPolicyResource(ArmClient client, NetAppElasticSnapshotPolicyData data) : this(client, data.Id) { _data = data; _hasData = true; } public virtual bool HasData => _hasData; public virtual NetAppElasticSnapshotPolicyData Data => _data; public virtual ArmOperation<NetAppElasticSnapshotPolicyResource> Update(WaitUntil waitUntil, NetAppElasticSnapshotPolicyPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticSnapshotPolicyResource>> UpdateAsync(WaitUntil waitUntil, NetAppElasticSnapshotPolicyPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticSnapshotPolicyResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticSnapshotPolicyResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticSnapshotPolicyResource> RemoveTag(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticSnapshotPolicyResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException(); }
}
