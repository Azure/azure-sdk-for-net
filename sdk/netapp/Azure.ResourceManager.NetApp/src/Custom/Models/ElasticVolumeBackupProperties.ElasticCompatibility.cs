// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ElasticVolumeBackupProperties { public ElasticVolumeBackupProperties() { } public ElasticVolumeBackupProperties(ResourceIdentifier elasticBackupPolicyResourceId = default, ElasticVolumePolicyEnforcement? policyEnforcement = default, ResourceIdentifier elasticBackupVaultResourceId = default) { ElasticBackupPolicyResourceId = elasticBackupPolicyResourceId; PolicyEnforcement = policyEnforcement; ElasticBackupVaultResourceId = elasticBackupVaultResourceId; } public ResourceIdentifier ElasticBackupPolicyResourceId { get; set; } public ElasticVolumePolicyEnforcement? PolicyEnforcement { get; set; } public ResourceIdentifier ElasticBackupVaultResourceId { get; set; } }
}
