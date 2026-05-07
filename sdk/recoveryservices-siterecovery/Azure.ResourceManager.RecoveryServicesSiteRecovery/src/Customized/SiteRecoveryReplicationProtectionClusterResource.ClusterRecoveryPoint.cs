// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public partial class SiteRecoveryReplicationProtectionClusterResource
    {
        /// <summary> Gets a collection of SiteRecoveryClusterRecoveryPointResources in the SiteRecoveryReplicationProtectionCluster. </summary>
        public virtual SiteRecoveryClusterRecoveryPointCollection GetSiteRecoveryClusterRecoveryPoints()
        {
            return GetCachedClient(client => new SiteRecoveryClusterRecoveryPointCollection(client, Id));
        }

        /// <summary> Gets the cluster recovery point. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<SiteRecoveryClusterRecoveryPointResource>> GetSiteRecoveryClusterRecoveryPointAsync(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            return GetSiteRecoveryClusterRecoveryPoints().GetAsync(recoveryPointName, cancellationToken);
        }

        /// <summary> Gets the cluster recovery point. </summary>
        [ForwardsClientCalls]
        public virtual Response<SiteRecoveryClusterRecoveryPointResource> GetSiteRecoveryClusterRecoveryPoint(string recoveryPointName, CancellationToken cancellationToken = default)
        {
            return GetSiteRecoveryClusterRecoveryPoints().Get(recoveryPointName, cancellationToken);
        }
    }
}
