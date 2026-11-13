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
    public partial class ElasticBackupProperties { public ElasticBackupProperties(DateTimeOffset? createdOn = default, DateTimeOffset? snapshotCreationOn = default, DateTimeOffset? completionOn = default, NetAppProvisioningState? provisioningState = default, long? size = default, string label = default, ElasticBackupType? backupType = default, string failureReason = default, ResourceIdentifier elasticVolumeResourceId = default, ElasticBackupSnapshotUsage? snapshotUsage = default, ResourceIdentifier elasticSnapshotResourceId = default, ResourceIdentifier elasticBackupPolicyResourceId = default, ElasticBackupVolumeSize? volumeSize = default) { CreatedOn = createdOn; SnapshotCreationOn = snapshotCreationOn; CompletionOn = completionOn; ProvisioningState = provisioningState; Size = size; Label = label; BackupType = backupType; FailureReason = failureReason; ElasticVolumeResourceId = elasticVolumeResourceId; SnapshotUsage = snapshotUsage; ElasticSnapshotResourceId = elasticSnapshotResourceId; ElasticBackupPolicyResourceId = elasticBackupPolicyResourceId; VolumeSize = volumeSize; } public DateTimeOffset? CreatedOn { get; set; } public DateTimeOffset? SnapshotCreationOn { get; set; } public DateTimeOffset? CompletionOn { get; set; } public NetAppProvisioningState? ProvisioningState { get; set; } public long? Size { get; set; } public string Label { get; set; } public ElasticBackupType? BackupType { get; set; } public string FailureReason { get; set; } public ResourceIdentifier ElasticVolumeResourceId { get; set; } public ElasticBackupSnapshotUsage? SnapshotUsage { get; set; } public ResourceIdentifier ElasticSnapshotResourceId { get; set; } public ResourceIdentifier ElasticBackupPolicyResourceId { get; set; } public ElasticBackupVolumeSize? VolumeSize { get; set; } }
}
