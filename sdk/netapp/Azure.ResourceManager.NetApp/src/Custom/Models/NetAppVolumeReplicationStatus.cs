// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeReplicationStatus
    {
        public NetAppRelationshipStatus? RelationshipStatus => VolumeReplicationRelationshipStatus.HasValue ? new NetAppRelationshipStatus(VolumeReplicationRelationshipStatus.Value.ToString()) : (NetAppRelationshipStatus?)null;
    }
}
