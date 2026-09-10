// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct ElasticBackupSnapshotUsage
    {
        public static ElasticBackupSnapshotUsage CreateNewSnapshot { get; } = new ElasticBackupSnapshotUsage("CreateNewSnapshot");
        public static ElasticBackupSnapshotUsage UseExistingSnapshot { get; } = new ElasticBackupSnapshotUsage("UseExistingSnapshot");
    }
}
