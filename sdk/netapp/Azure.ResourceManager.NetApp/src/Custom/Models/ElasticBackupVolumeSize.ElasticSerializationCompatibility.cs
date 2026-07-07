// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct ElasticBackupVolumeSize
    {
        public static ElasticBackupVolumeSize Large { get; } = new ElasticBackupVolumeSize("Large");
        public static ElasticBackupVolumeSize Regular { get; } = new ElasticBackupVolumeSize("Regular");
    }
}
