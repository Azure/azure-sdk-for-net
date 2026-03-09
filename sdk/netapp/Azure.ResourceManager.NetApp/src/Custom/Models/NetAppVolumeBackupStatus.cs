// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeBackupStatus
    {
        public NetAppRelationshipStatus? RelationshipStatus => VolumeBackupRelationshipStatus.HasValue ? new NetAppRelationshipStatus(VolumeBackupRelationshipStatus.Value.ToString()) : (NetAppRelationshipStatus?)null;
    }
}
