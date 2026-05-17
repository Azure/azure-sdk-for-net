// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    public partial class ClusterTestFailoverCleanupContent
    {
        /// <summary> Initializes a new instance of <see cref="ClusterTestFailoverCleanupContent"/>. </summary>
        /// <param name="properties"> Cluster test failover cleanup input properties. </param>
        public ClusterTestFailoverCleanupContent(ClusterTestFailoverCleanupContentProperties properties) : this(properties, additionalBinaryDataProperties: null)
        {
        }
    }
}
