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

        /// <summary> The name of the target database. </summary>
        [WirePath("properties.targetDatabase")]
        public string TargetDatabase { get; set; }
        /// <summary> The source endpoint. </summary>
        [WirePath("properties.sourceEndpoint")]
        public string SourceEndpoint { get; set; }
        /// <summary> The primary availability group name. </summary>
        [WirePath("properties.primaryAvailabilityGroupName")]
        public string PrimaryAvailabilityGroupName { get; set; }
        /// <summary> The secondary availability group name. </summary>
        [WirePath("properties.secondaryAvailabilityGroupName")]
        public string SecondaryAvailabilityGroupName { get; set; }
        /// <summary> The replication mode of a distributed availability group. Parameter will be ignored during link creation. </summary>
        [WirePath("properties.replicationMode")]
        public DistributedAvailabilityGroupReplicationMode? ReplicationMode { get; set; }
        /// <summary> The distributed availability group id. </summary>
        [WirePath("properties.distributedAvailabilityGroupId")]
        public Guid? DistributedAvailabilityGroupId { get; }
        /// <summary> The source replica id. </summary>
        [WirePath("properties.sourceReplicaId")]
        public Guid? SourceReplicaId { get; }
        /// <summary> The target replica id. </summary>
        [WirePath("properties.targetReplicaId")]
        public Guid? TargetReplicaId { get; }
        /// <summary> The link state. </summary>
        [WirePath("properties.linkState")]
        public string LinkState { get; }
        /// <summary> The last hardened lsn. </summary>
        [WirePath("properties.lastHardenedLsn")]
        public string LastHardenedLsn { get; }

        internal DistributedAvailabilityGroupData(
            Azure.Core.ResourceIdentifier id,
            string name,
            Azure.Core.ResourceType resourceType,
            Azure.ResourceManager.Models.SystemData systemData,
            string targetDatabase,
            string sourceEndpoint,
            string primaryAvailabilityGroupName,
            string secondaryAvailabilityGroupName,
            DistributedAvailabilityGroupReplicationMode? replicationMode,
            Guid? distributedAvailabilityGroupId,
            Guid? sourceReplicaId,
            Guid? targetReplicaId,
            string linkState,
            string lastHardenedLsn,
            System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData)
            : base(id, name, resourceType, systemData)
        {
            TargetDatabase = targetDatabase;
            SourceEndpoint = sourceEndpoint;
            PrimaryAvailabilityGroupName = primaryAvailabilityGroupName;
            SecondaryAvailabilityGroupName = secondaryAvailabilityGroupName;
            ReplicationMode = replicationMode;
            DistributedAvailabilityGroupId = distributedAvailabilityGroupId;
            SourceReplicaId = sourceReplicaId;
            TargetReplicaId = targetReplicaId;
            LinkState = linkState;
            LastHardenedLsn = lastHardenedLsn;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal System.Collections.Generic.IDictionary<string, System.BinaryData> _serializedAdditionalRawData;
    }
}
