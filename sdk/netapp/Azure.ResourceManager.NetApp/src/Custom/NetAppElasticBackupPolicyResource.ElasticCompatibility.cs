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
    public partial class NetAppElasticBackupPolicyResource : ArmResource { public static readonly ResourceType ResourceType = "Microsoft.NetApp/netAppAccounts/elasticBackupPolicies"; private readonly NetAppElasticBackupPolicyData _data; private bool _hasData; protected NetAppElasticBackupPolicyResource() { } internal NetAppElasticBackupPolicyResource(ArmClient client, ResourceIdentifier id) : base(client, id) { } internal NetAppElasticBackupPolicyResource(ArmClient client, NetAppElasticBackupPolicyData data) : this(client, data.Id) { _data = data; _hasData = true; } public virtual bool HasData => _hasData; public virtual NetAppElasticBackupPolicyData Data => _data; public virtual Response<NetAppElasticBackupPolicyResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupPolicyResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual ArmOperation<NetAppElasticBackupPolicyResource> Update(WaitUntil waitUntil, NetAppElasticBackupPolicyPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<ArmOperation<NetAppElasticBackupPolicyResource>> UpdateAsync(WaitUntil waitUntil, NetAppElasticBackupPolicyPatch patch, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticBackupPolicyResource> AddTag(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupPolicyResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticBackupPolicyResource> RemoveTag(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupPolicyResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Response<NetAppElasticBackupPolicyResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException(); public virtual Task<Response<NetAppElasticBackupPolicyResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default) => throw new NotSupportedException(); }
}
