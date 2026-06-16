// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing the data model for a distributed availability group.
    /// Kept for backward compatibility; the underlying API now uses <see cref="SqlDistributedAvailabilityGroupData"/>.
    /// </summary>
    [Obsolete("This data model is obsolete and will be removed in a future release. Use SqlDistributedAvailabilityGroupData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DistributedAvailabilityGroupData : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="DistributedAvailabilityGroupData"/>. </summary>
        public DistributedAvailabilityGroupData()
        {
        }

        /// <summary> The id of the distributed availability group. </summary>
        public Guid? DistributedAvailabilityGroupId { get; }

        /// <summary> The last hardened lsn. </summary>
        public string LastHardenedLsn { get; }

        /// <summary> The link state. </summary>
        public string LinkState { get; }

        /// <summary> The primary availability group name. </summary>
        public string PrimaryAvailabilityGroupName { get; set; }

        /// <summary> The replication mode. </summary>
        public DistributedAvailabilityGroupReplicationMode? ReplicationMode { get; set; }

        /// <summary> The secondary availability group name. </summary>
        public string SecondaryAvailabilityGroupName { get; set; }

        /// <summary> The source endpoint. </summary>
        public string SourceEndpoint { get; set; }

        /// <summary> The source replica id. </summary>
        public Guid? SourceReplicaId { get; }

        /// <summary> The target database name. </summary>
        public string TargetDatabase { get; set; }

        /// <summary> The target replica id. </summary>
        public Guid? TargetReplicaId { get; }
    }
}
