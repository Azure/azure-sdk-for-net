// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct ElasticBackupType
    {
        public static ElasticBackupType Manual { get; } = new ElasticBackupType("Manual");
        public static ElasticBackupType Scheduled { get; } = new ElasticBackupType("Scheduled");
    }
}
