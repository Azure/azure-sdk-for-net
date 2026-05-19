// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The three forwarders below are a *legitimate* exception to MPG migration rule 4.5
// ("rename, don't hide-and-replace"). The v1.x AutoRest accessor names cannot be reproduced
// via `@@clientName` in client.tsp, so the custom forwarders are the least-bad way to
// preserve binary compatibility against the 1.3.1 baseline.
//
// v1.x SDK (AutoRest) exposed these three accessors on `SiteRecoveryProtectionContainerResource`:
//   - GetSiteRecoveryReplicationProtectionClusterResources()           -> Collection
//   - GetSiteRecoveryReplicationProtectionClusterResource(name, ct)    -> single Get
//   - GetSiteRecoveryReplicationProtectionClusterResourceAsync(name, ct)
// MPG (TypeSpec) strips the "Resource" suffix from synthesized parent-accessor names and emits:
//   - GetSiteRecoveryReplicationProtectionClusters()
//   - GetSiteRecoveryReplicationProtectionCluster(name, ct)
//   - GetSiteRecoveryReplicationProtectionClusterAsync(name, ct)
//
// Why @@clientName does NOT solve this (verified by experiment in the PR #59061 review fix-up):
//   1. `@@clientName(ReplicationProtectionClusterOperationGroup.listByReplicationProtectionContainers, "GetSiteRecoveryReplicationProtectionClusterResources", "csharp")`
//      collides with the existing rename on `ReplicationProtectionClustersOperationGroup.list`
//      (CS0111: duplicate REST-op method name on the RestOperations class).
//   2. `@@clientName(ReplicationProtectionClusters.get, ...)` is ignored by MPG when
//      synthesizing the parent-resource single-getter accessor.
//   3. Renaming the resource model `ReplicationProtectionCluster` to end with "Resource" so the
//      accessor naturally re-acquires the "Resource" suffix would cascade into the
//      synthesized `*Data` and `*Properties` class names (v1.x baseline kept those *without*
//      the "Resource" suffix: `SiteRecoveryReplicationProtectionClusterData`,
//      `SiteRecoveryReplicationProtectionClusterProperties`), producing two fresh ApiCompat
//      breaks in exchange for fixing one.
//
// The three forwarders below are therefore retained, marked `EditorBrowsable.Never` so they do
// not surface in IntelliSense, and documented to steer new code to the MPG-named members.

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
