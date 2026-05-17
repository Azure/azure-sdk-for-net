// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class PauseReplicationContent
    {
        /// <summary> Initializes a new instance of <see cref="PauseReplicationContent"/>. </summary>
        /// <param name="properties"> Pause replication input properties. </param>
        public PauseReplicationContent(PauseReplicationProperties properties) : this(properties, additionalBinaryDataProperties: null)
        {
        }
    }
}
