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
    public partial class NetAppElasticBackupCollection : ArmCollection, IEnumerable<NetAppElasticBackupResource>, IAsyncEnumerable<NetAppElasticBackupResource> { protected NetAppElasticBackupCollection() { } internal NetAppElasticBackupCollection(ArmClient client, ResourceIdentifier id) : base(client, id) { TryGetApiVersion(NetAppElasticBackupResource.ResourceType, out string netAppElasticBackupApiVersion); _elasticBackupsClientDiagnostics = new Azure.Core.Pipeline.ClientDiagnostics("Azure.ResourceManager.NetApp", NetAppElasticBackupResource.ResourceType.Namespace, Diagnostics); _elasticBackupsRestClient = new ElasticBackups(_elasticBackupsClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint, netAppElasticBackupApiVersion ?? "2026-08-15-preview"); } public IEnumerator<NetAppElasticBackupResource> GetEnumerator() => GetAll().GetEnumerator(); IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator(); public IAsyncEnumerator<NetAppElasticBackupResource> GetAsyncEnumerator(CancellationToken cancellationToken = default) => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken); }
}
