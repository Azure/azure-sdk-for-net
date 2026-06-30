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
    public partial class NetAppElasticVolumePatchProperties { public NetAppElasticVolumePatchProperties(long? size = default, IEnumerable<ElasticExportPolicyRule> exportRules = default, ElasticVolumeDataProtectionPatchProperties dataProtection = default, SnapshotDirectoryVisibility? snapshotDirectoryVisibility = default, ElasticSmbEncryption? smbEncryption = default) { Size = size; ExportRules = exportRules is null ? new ChangeTrackingList<ElasticExportPolicyRule>() : new List<ElasticExportPolicyRule>(exportRules); DataProtection = dataProtection; SnapshotDirectoryVisibility = snapshotDirectoryVisibility; SmbEncryption = smbEncryption; } public long? Size { get; set; } public IList<ElasticExportPolicyRule> ExportRules { get; } public ElasticVolumeDataProtectionPatchProperties DataProtection { get; set; } public SnapshotDirectoryVisibility? SnapshotDirectoryVisibility { get; set; } public ElasticSmbEncryption? SmbEncryption { get; set; } }
}
