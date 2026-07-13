// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// In the v1.x AutoRest-generated SDK, SiteRecoveryClusterRecoveryPoint was emitted as a
// full ARM resource type with a corresponding Collection accessor on the parent
// SiteRecoveryReplicationProtectionClusterResource. The new TypeSpec specification no
// longer models it as an ARM resource (it does not appear in the ARM templates index), so
// the MPG emitter does not generate a Collection class for it. Removing the v1.x public
// surface would be a binary-breaking change for consumers, so we keep the Collection type
// signature here, mark it obsolete, and have every member throw NotSupportedException.
// Callers should migrate to the methods on SiteRecoveryReplicationProtectionClusterResource
// that operate on the cluster recovery point payload directly.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery
{
    /// <summary>
    /// A class representing a collection of <see cref="SiteRecoveryClusterRecoveryPointResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource; use the methods on SiteRecoveryReplicationProtectionClusterResource that operate on SiteRecoveryClusterRecoveryPoint payloads directly.")]
    public partial class SiteRecoveryClusterRecoveryPointCollection : ArmCollection, IEnumerable<SiteRecoveryClusterRecoveryPointResource>, IAsyncEnumerable<SiteRecoveryClusterRecoveryPointResource>
    {
        /// <summary> Initializes a new instance of <see cref="SiteRecoveryClusterRecoveryPointCollection"/> for mocking. </summary>
        protected SiteRecoveryClusterRecoveryPointCollection() : base() { }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Response<bool> Exists(string recoveryPointName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        /// <summary> Checks to see if the resource exists in azure. </summary>
        public virtual Task<Response<bool>> ExistsAsync(string recoveryPointName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        /// <summary> Gets the cluster recovery point. </summary>
        public virtual Response<SiteRecoveryClusterRecoveryPointResource> Get(string recoveryPointName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        /// <summary> Lists the cluster recovery points. </summary>
        public virtual Pageable<SiteRecoveryClusterRecoveryPointResource> GetAll(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        /// <summary> Lists the cluster recovery points. </summary>
        public virtual AsyncPageable<SiteRecoveryClusterRecoveryPointResource> GetAllAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        /// <summary> Gets the cluster recovery point. </summary>
        public virtual Task<Response<SiteRecoveryClusterRecoveryPointResource>> GetAsync(string recoveryPointName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        /// <summary> Tries to get details for the resource. </summary>
        public virtual NullableResponse<SiteRecoveryClusterRecoveryPointResource> GetIfExists(string recoveryPointName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        /// <summary> Tries to get details for the resource. </summary>
        public virtual Task<NullableResponse<SiteRecoveryClusterRecoveryPointResource>> GetIfExistsAsync(string recoveryPointName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        IAsyncEnumerator<SiteRecoveryClusterRecoveryPointResource> IAsyncEnumerable<SiteRecoveryClusterRecoveryPointResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        IEnumerator<SiteRecoveryClusterRecoveryPointResource> IEnumerable<SiteRecoveryClusterRecoveryPointResource>.GetEnumerator()
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
    }
}
