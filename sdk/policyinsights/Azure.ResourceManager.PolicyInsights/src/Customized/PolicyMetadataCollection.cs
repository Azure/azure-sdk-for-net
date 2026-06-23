// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.PolicyInsights.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PolicyInsights
{
    public partial class PolicyMetadataCollection : IEnumerable<SlimPolicyMetadata>, IAsyncEnumerable<SlimPolicyMetadata>
    {
        /// <summary>
        /// [Obsolete] Get a list of the policy metadata resources. The host of this operation has moved to <see cref="TenantResource"/>.
        /// </summary>
        /// <param name="policyQuerySettings"> Optional OData query settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported on PolicyMetadataCollection. Use TenantResource.GetAllAsync(PolicyQuerySettings, CancellationToken) instead.")]
        public virtual AsyncPageable<SlimPolicyMetadata> GetAllAsync(PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PolicyMetadataCollection.GetAllAsync is no longer supported. Use TenantResource.GetAllAsync(PolicyQuerySettings, CancellationToken) instead.");
        }

        /// <summary>
        /// [Obsolete] Get a list of the policy metadata resources. The host of this operation has moved to <see cref="TenantResource"/>.
        /// </summary>
        /// <param name="policyQuerySettings"> Optional OData query settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported on PolicyMetadataCollection. Use TenantResource.GetAll(PolicyQuerySettings, CancellationToken) instead.")]
        public virtual Pageable<SlimPolicyMetadata> GetAll(PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PolicyMetadataCollection.GetAll is no longer supported. Use TenantResource.GetAll(PolicyQuerySettings, CancellationToken) instead.");
        }

        // ===== Explicit interface implementations for GA compatibility (obsolete + throw) =====
        // GA's PolicyMetadataCollection implemented IEnumerable<SlimPolicyMetadata> and IAsyncEnumerable<SlimPolicyMetadata>
        // by forwarding to GetAll()/GetAllAsync(). The underlying operation has moved to TenantResource;
        // these explicit implementations are kept for binary compatibility only and now throw.
        IEnumerator<SlimPolicyMetadata> IEnumerable<SlimPolicyMetadata>.GetEnumerator()
            => throw new NotSupportedException("Enumerating PolicyMetadataCollection directly is no longer supported. Use TenantResource.GetAll(PolicyQuerySettings, CancellationToken) instead.");

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotSupportedException("Enumerating PolicyMetadataCollection directly is no longer supported. Use TenantResource.GetAll(PolicyQuerySettings, CancellationToken) instead.");

        IAsyncEnumerator<SlimPolicyMetadata> IAsyncEnumerable<SlimPolicyMetadata>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => throw new NotSupportedException("Enumerating PolicyMetadataCollection directly is no longer supported. Use TenantResource.GetAllAsync(PolicyQuerySettings, CancellationToken) instead.");
    }
}
