// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class ResumeReplicationContent
    {
        /// <summary> Initializes a new instance of <see cref="ResumeReplicationContent"/>. </summary>
        /// <param name="properties"> Resume replication input properties. </param>
        public ResumeReplicationContent(ResumeReplicationProperties properties) : this(properties, additionalBinaryDataProperties: null)
        {
        }
    }
}
