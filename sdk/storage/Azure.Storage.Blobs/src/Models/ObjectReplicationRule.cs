// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Contains the Object Replication Rule ID and Replication Status(
    /// <see cref="ObjectReplicationStatus"/>) of a blob.
    /// There can be more than one <see cref="ObjectReplicationRule"/> under a
    /// <see cref="ObjectReplicationPolicy"/>. Object Replication Rule IDs
    /// </summary>
    public class ObjectReplicationRule
    {
        internal ObjectReplicationRule() { }
        /// <summary>
        /// The Object Replication Rule ID.
        /// </summary>
        public string RuleId { get; internal set; }
        /// <summary>
        /// The Replication Status. See <see cref="ObjectReplicationStatus"/>.
        /// </summary>
        public ObjectReplicationStatus ReplicationStatus { get; internal set; }
    }

    /// <summary>
    /// Specifies the Replication Status of a blob. This is used when a storage account
    /// has Object Replication Policy(s) applied. See <see cref="ObjectReplicationPolicy"/>
    /// and <see cref="ObjectReplicationRule"/>.
    /// </summary>
    [Flags]
    public enum ObjectReplicationStatus
    {
        /// <summary>
        /// Object Replication to the
        /// destination completed.
        /// </summary>
        Complete = 0,

        /// <summary>
        /// Object Replication to the
        /// destination container failed.
        /// </summary>
        Failed = 1
    }
}
