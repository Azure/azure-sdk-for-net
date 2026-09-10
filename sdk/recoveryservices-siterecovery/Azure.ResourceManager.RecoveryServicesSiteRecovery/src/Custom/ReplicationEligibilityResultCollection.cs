// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// The ReplicationEligibilityResult resource is modeled as @singleton("default") in the new TypeSpec
// specification, so the MPG emitter no longer generates a Collection class for it (see
// ResourceClientProvider.cs:40 - collection construction is gated on !IsSingleton). However, the
// previous AutoRest-generated v1.x SDK exposed this Collection type as part of its public API.
// Removing it would be a binary-breaking change for consumers, so we keep the type here but mark
// every member as obsolete and have it throw NotSupportedException. Callers should migrate to
// ArmClient.GetReplicationEligibilityResult(ResourceIdentifier), passing the virtual machine id.

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
    /// Collection-shaped accessor for <see cref="ReplicationEligibilityResultResource"/> preserved only for backward
    /// compatibility. The underlying ARM resource is a singleton; use
    /// <c>ArmClient.GetReplicationEligibilityResult(ResourceIdentifier)</c> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and will be removed in a future version. The underlying ARM resource is a singleton; use ArmClient.GetReplicationEligibilityResult(ResourceIdentifier) instead.")]
    public partial class ReplicationEligibilityResultCollection : ArmCollection,
        IEnumerable<ReplicationEligibilityResultResource>,
        IAsyncEnumerable<ReplicationEligibilityResultResource>
    {
        /// <summary> Initializes a new instance of the <see cref="ReplicationEligibilityResultCollection"/> class for mocking. </summary>
        protected ReplicationEligibilityResultCollection() { }

        /// <summary> Not supported. </summary>
        public virtual Response<ReplicationEligibilityResultResource> Get(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Not supported. </summary>
        public virtual Task<Response<ReplicationEligibilityResultResource>> GetAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Not supported. </summary>
        public virtual Pageable<ReplicationEligibilityResultResource> GetAll(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Not supported. </summary>
        public virtual AsyncPageable<ReplicationEligibilityResultResource> GetAllAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Not supported. </summary>
        public virtual Response<bool> Exists(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Not supported. </summary>
        public virtual Task<Response<bool>> ExistsAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Not supported. </summary>
        public virtual NullableResponse<ReplicationEligibilityResultResource> GetIfExists(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Not supported. </summary>
        public virtual Task<NullableResponse<ReplicationEligibilityResultResource>> GetIfExistsAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        IEnumerator<ReplicationEligibilityResultResource> IEnumerable<ReplicationEligibilityResultResource>.GetEnumerator()
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        IAsyncEnumerator<ReplicationEligibilityResultResource> IAsyncEnumerable<ReplicationEligibilityResultResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");
    }
}
