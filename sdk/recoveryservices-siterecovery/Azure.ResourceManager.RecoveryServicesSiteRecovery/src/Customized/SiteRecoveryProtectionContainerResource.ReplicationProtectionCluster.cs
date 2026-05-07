// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.RecoveryServicesSiteRecovery;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    [CodeGenSuppress("GetSiteRecoveryReplicationProtectionClusters")]
    [CodeGenSuppress("GetSiteRecoveryReplicationProtectionCluster", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSiteRecoveryReplicationProtectionClusterAsync", typeof(string), typeof(CancellationToken))]
    public partial class SiteRecoveryProtectionContainerResource
    {
        /// <summary> Gets a collection of SiteRecoveryReplicationProtectionClusterResources in the SiteRecoveryProtectionContainerResource. </summary>
        /// <returns> An object representing collection of SiteRecoveryReplicationProtectionClusterResources and their operations over a SiteRecoveryReplicationProtectionClusterResource. </returns>
        public virtual SiteRecoveryReplicationProtectionClusterResourceCollection GetSiteRecoveryReplicationProtectionClusterResources()
        {
            return GetCachedClient(client => new SiteRecoveryReplicationProtectionClusterResourceCollection(client, Id));
        }

        /// <summary> Gets the details of an ASR replication protection cluster. </summary>
        /// <param name="replicationProtectionClusterName"> Replication protection cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="replicationProtectionClusterName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="replicationProtectionClusterName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SiteRecoveryReplicationProtectionClusterResource>> GetSiteRecoveryReplicationProtectionClusterResourceAsync(string replicationProtectionClusterName, CancellationToken cancellationToken = default)
        {
            return await GetSiteRecoveryReplicationProtectionClusterResources().GetAsync(replicationProtectionClusterName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the details of an ASR replication protection cluster. </summary>
        /// <param name="replicationProtectionClusterName"> Replication protection cluster name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentNullException"> <paramref name="replicationProtectionClusterName"/> is null. </exception>
        /// <exception cref="System.ArgumentException"> <paramref name="replicationProtectionClusterName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<SiteRecoveryReplicationProtectionClusterResource> GetSiteRecoveryReplicationProtectionClusterResource(string replicationProtectionClusterName, CancellationToken cancellationToken = default)
        {
            return GetSiteRecoveryReplicationProtectionClusterResources().Get(replicationProtectionClusterName, cancellationToken);
        }
    }
}
