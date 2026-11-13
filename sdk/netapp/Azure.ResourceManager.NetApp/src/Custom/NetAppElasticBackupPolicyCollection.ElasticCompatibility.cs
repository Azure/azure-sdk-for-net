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
    public partial class NetAppElasticBackupPolicyCollection : ArmCollection, IEnumerable<NetAppElasticBackupPolicyResource>, IAsyncEnumerable<NetAppElasticBackupPolicyResource> { protected NetAppElasticBackupPolicyCollection() { } internal NetAppElasticBackupPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { TryGetApiVersion(NetAppElasticBackupPolicyResource.ResourceType, out string netAppElasticBackupPolicyApiVersion); _elasticBackupPoliciesClientDiagnostics = new Azure.Core.Pipeline.ClientDiagnostics("Azure.ResourceManager.NetApp", NetAppElasticBackupPolicyResource.ResourceType.Namespace, Diagnostics); _elasticBackupPoliciesRestClient = new ElasticBackupPolicies(_elasticBackupPoliciesClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, netAppElasticBackupPolicyApiVersion ?? "2026-08-15-preview"); } public IEnumerator<NetAppElasticBackupPolicyResource> GetEnumerator() => GetAll().GetEnumerator(); IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator(); public IAsyncEnumerator<NetAppElasticBackupPolicyResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
}
