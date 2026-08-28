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
    public partial class ElasticVolumeProperties { public ElasticVolumeProperties(string filePath = default, long size = default, IEnumerable<ElasticExportPolicyRule> exportRules = default, IEnumerable<ElasticProtocolType> protocolTypes = default, NetAppProvisioningState? provisioningState = default, ElasticResourceAvailabilityStatus? availabilityStatus = default, ResourceIdentifier snapshotResourceId = default, IEnumerable<ElasticMountTargetProperties> mountTargets = default, ElasticVolumeDataProtectionProperties dataProtection = default, SnapshotDirectoryVisibility? snapshotDirectoryVisibility = default, ElasticSmbEncryption? smbEncryption = default, ResourceIdentifier backupResourceId = default, ElasticVolumeRestorationState? restorationState = default) { FilePath = filePath; Size = size; ExportRules = exportRules is null ? new ChangeTrackingList<ElasticExportPolicyRule>() : new List<ElasticExportPolicyRule>(exportRules); ProtocolTypes = protocolTypes is null ? new ChangeTrackingList<ElasticProtocolType>() : new List<ElasticProtocolType>(protocolTypes); ProvisioningState = provisioningState; AvailabilityStatus = availabilityStatus; SnapshotResourceId = snapshotResourceId; MountTargets = mountTargets is null ? new ChangeTrackingList<ElasticMountTargetProperties>() : new List<ElasticMountTargetProperties>(mountTargets); DataProtection = dataProtection; SnapshotDirectoryVisibility = snapshotDirectoryVisibility; SmbEncryption = smbEncryption; BackupResourceId = backupResourceId; RestorationState = restorationState; } public string FilePath { get; set; } public long Size { get; set; } public IList<ElasticExportPolicyRule> ExportRules { get; } public IList<ElasticProtocolType> ProtocolTypes { get; } public NetAppProvisioningState? ProvisioningState { get; set; } public ElasticResourceAvailabilityStatus? AvailabilityStatus { get; set; } public ResourceIdentifier SnapshotResourceId { get; set; } public IReadOnlyList<ElasticMountTargetProperties> MountTargets { get; } public ElasticVolumeDataProtectionProperties DataProtection { get; set; } public SnapshotDirectoryVisibility? SnapshotDirectoryVisibility { get; set; } public ElasticSmbEncryption? SmbEncryption { get; set; } public ResourceIdentifier BackupResourceId { get; set; } public ElasticVolumeRestorationState? RestorationState { get; set; } }
}
