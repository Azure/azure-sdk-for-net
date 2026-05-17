// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// In the v1.x AutoRest-generated SDK, SiteRecoveryProtectionContainerResource exposed three
// parent-accessor methods for the replication-protection-cluster child:
//   - GetSiteRecoveryReplicationProtectionClusterResources()  (returning the Collection)
//   - GetSiteRecoveryReplicationProtectionClusterResource(name, ct)        (single Get)
//   - GetSiteRecoveryReplicationProtectionClusterResourceAsync(name, ct)   (single GetAsync)
// The new MPG TypeSpec emitter renamed these accessors to drop the "Resource" suffix
// (GetSiteRecoveryReplicationProtectionClusters / *Cluster / *ClusterAsync), matching the
// renamed collection class. The underlying ARM resource and all of its operations are
// unchanged. Removing the old method signatures would be a binary-breaking change, so we
// keep them here as obsolete forwarding shims that delegate to the new generated methods.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public partial class SiteRecoveryProtectionContainerResource
    {
        /// <summary>
        /// Gets a collection of SiteRecoveryReplicationProtectionClusterResources in the
        /// SiteRecoveryProtectionContainer. Preserved only for backward compatibility; new
        /// code should use <see cref="GetSiteRecoveryReplicationProtectionClusters"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SiteRecoveryReplicationProtectionClusterResourceCollection GetSiteRecoveryReplicationProtectionClusterResources()
        {
            return GetSiteRecoveryReplicationProtectionClusters();
        }

        /// <summary>
        /// Gets the details of an ASR replication protection cluster. Preserved only for
        /// backward compatibility; new code should use
        /// <see cref="GetSiteRecoveryReplicationProtectionClusterAsync"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<SiteRecoveryReplicationProtectionClusterResource>> GetSiteRecoveryReplicationProtectionClusterResourceAsync(string replicationProtectionClusterName, CancellationToken cancellationToken = default)
        {
            return await GetSiteRecoveryReplicationProtectionClusterAsync(replicationProtectionClusterName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the details of an ASR replication protection cluster. Preserved only for
        /// backward compatibility; new code should use
        /// <see cref="GetSiteRecoveryReplicationProtectionCluster"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SiteRecoveryReplicationProtectionClusterResource> GetSiteRecoveryReplicationProtectionClusterResource(string replicationProtectionClusterName, CancellationToken cancellationToken = default)
        {
            return GetSiteRecoveryReplicationProtectionCluster(replicationProtectionClusterName, cancellationToken);
        }
    }
}
