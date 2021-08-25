// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Contains Object Replication Policy ID and the respective list of
    /// <see cref="ObjectReplicationRule"/>(s). This is used when retrieving the
    /// Object Replication Properties on the source blob. The policy id for the
    /// destination blob is set in ObjectReplicationDestinationPolicyId of the respective
    /// method responses. (e.g. <see cref="BlobProperties.ObjectReplicationDestinationPolicyId"/>,
    /// <see cref="BlobDownloadDetails.ObjectReplicationDestinationPolicyId"/>).
    /// </summary>
    public class ObjectReplicationPolicy
    {
        internal ObjectReplicationPolicy() { }
        /// <summary>
        /// The Object Replication Policy ID.
        /// </summary>
        public string PolicyId { get; internal set; }
        /// <summary>
        /// The Rule ID(s) and respective Replication Status(s) that are under
        /// the Policy ID.
        /// </summary>
        public IList<ObjectReplicationRule> Rules { get; internal set; }
    }
}
