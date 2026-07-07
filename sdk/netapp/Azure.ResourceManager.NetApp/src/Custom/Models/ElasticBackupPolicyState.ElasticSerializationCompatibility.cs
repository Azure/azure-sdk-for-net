// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct ElasticBackupPolicyState
    {
        public static ElasticBackupPolicyState Disabled { get; } = new ElasticBackupPolicyState("Disabled");
        public static ElasticBackupPolicyState Enabled { get; } = new ElasticBackupPolicyState("Enabled");
    }
}
