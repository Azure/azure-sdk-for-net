// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class IpamPoolResource
    {
        // Preserve the 1.15.0 token-only delete overload; native ETag null omits If-Match.
        /// <summary> Deletes the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => DeleteAsync(waitUntil, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the synchronous 1.15.0 token-only delete overload with no condition.
        /// <summary> Deletes the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Delete(waitUntil, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the released string header overload; require ifMatch to avoid optional-overload ambiguity.
        /// <summary> Deletes the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken)
            => DeleteAsync(waitUntil, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);

        // Preserve the synchronous released string header overload without changing the condition value.
        /// <summary> Deletes the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken)
            => Delete(waitUntil, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);

        // Preserve the 1.15.0 token-only patch overload; use the native implementation with no condition.
        /// <summary> Updates the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<IpamPoolResource>> UpdateAsync(IpamPoolPatch patch, CancellationToken cancellationToken)
            => UpdateAsync(patch, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the synchronous 1.15.0 token-only patch overload with no If-Match header.
        /// <summary> Updates the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<IpamPoolResource> Update(IpamPoolPatch patch, CancellationToken cancellationToken)
            => Update(patch, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the released string patch signature; require ifMatch and forward its exact value as ETag.
        /// <summary> Updates the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<IpamPoolResource>> UpdateAsync(IpamPoolPatch patch, string ifMatch, CancellationToken cancellationToken)
            => UpdateAsync(patch, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);

        // Preserve the synchronous released string patch signature without duplicating HTTP behavior.
        /// <summary> Updates the Pool resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<IpamPoolResource> Update(IpamPoolPatch patch, string ifMatch, CancellationToken cancellationToken)
            => Update(patch, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);
    }
}
