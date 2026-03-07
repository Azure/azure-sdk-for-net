// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Storage
{
    public partial class ImmutabilityPolicyResource
    {
        /// <summary> Delete with ETag parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ImmutabilityPolicyResource> Delete(WaitUntil waitUntil, ETag ifMatch, CancellationToken cancellationToken)
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <summary> DeleteAsync with ETag parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<ImmutabilityPolicyResource>> DeleteAsync(WaitUntil waitUntil, ETag ifMatch, CancellationToken cancellationToken)
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <summary> ExtendImmutabilityPolicy with ETag parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ImmutabilityPolicyResource> ExtendImmutabilityPolicy(ETag ifMatch, ImmutabilityPolicyData data, CancellationToken cancellationToken)
            => ExtendImmutabilityPolicy(ifMatch.ToString(), data, cancellationToken);

        /// <summary> ExtendImmutabilityPolicyAsync with ETag parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ImmutabilityPolicyResource>> ExtendImmutabilityPolicyAsync(ETag ifMatch, ImmutabilityPolicyData data, CancellationToken cancellationToken)
            => ExtendImmutabilityPolicyAsync(ifMatch.ToString(), data, cancellationToken);

        /// <summary> LockImmutabilityPolicy with ETag parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ImmutabilityPolicyResource> LockImmutabilityPolicy(ETag ifMatch, CancellationToken cancellationToken)
            => LockImmutabilityPolicy(ifMatch.ToString(), cancellationToken);

        /// <summary> LockImmutabilityPolicyAsync with ETag parameter. Backward-compatible overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ImmutabilityPolicyResource>> LockImmutabilityPolicyAsync(ETag ifMatch, CancellationToken cancellationToken)
            => LockImmutabilityPolicyAsync(ifMatch.ToString(), cancellationToken);
    }
}
