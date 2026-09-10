// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// In the v1.x AutoRest-generated SDK, SiteRecoveryReplicationProtectionClusterResource
// exposed three parent-accessor methods that returned a
// SiteRecoveryClusterRecoveryPointCollection (and its Get/GetAsync convenience wrappers).
// The new TypeSpec specification no longer models the cluster recovery point sub-resource
// as an ARM resource (it does not appear in the ARM templates index), so the MPG emitter
// no longer generates a Collection class and therefore omits these accessor methods.
// Removing them would be a binary-breaking change for consumers, so we keep the signatures
// here as a partial extension of the still-live generated resource class, mark them
// obsolete, and have them throw NotSupportedException.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    public partial class SiteRecoveryReplicationProtectionClusterResource
    {
        /// <summary> Gets a collection of SiteRecoveryClusterRecoveryPointResources in the SiteRecoveryReplicationProtectionCluster. </summary>
        [Obsolete("This method is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource; use Get(string recoveryPointName, ...) / GetByReplicationProtectionCluster(...) instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SiteRecoveryClusterRecoveryPointCollection GetSiteRecoveryClusterRecoveryPoints()
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Gets the cluster recovery point. </summary>
        [Obsolete("This method is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource; use GetAsync(string recoveryPointName, ...) instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<SiteRecoveryClusterRecoveryPointResource>> GetSiteRecoveryClusterRecoveryPointAsync(string recoveryPointName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Gets the cluster recovery point. </summary>
        [Obsolete("This method is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource; use Get(string recoveryPointName, ...) instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<SiteRecoveryClusterRecoveryPointResource> GetSiteRecoveryClusterRecoveryPoint(string recoveryPointName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
    }
}
