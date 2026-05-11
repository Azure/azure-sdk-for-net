// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds method overloads accepting ETag directly (prior GA used Azure.ETag type)
// instead of string. The generated methods use string for If-Match headers.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Storage
{
    public partial class ImmutabilityPolicyResource
    {
        // Backward-compatible overload: Delete with ETag parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ImmutabilityPolicyResource> Delete(WaitUntil waitUntil, ETag ifMatch, CancellationToken cancellationToken = default)
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        // Backward-compatible overload: DeleteAsync with ETag parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<ImmutabilityPolicyResource>> DeleteAsync(WaitUntil waitUntil, ETag ifMatch, CancellationToken cancellationToken = default)
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        // Backward-compatible overload: ExtendImmutabilityPolicy with ETag parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ImmutabilityPolicyResource> ExtendImmutabilityPolicy(ETag ifMatch, ImmutabilityPolicyData data, CancellationToken cancellationToken = default)
            => ExtendImmutabilityPolicy(ifMatch.ToString(), data, cancellationToken);

        // Backward-compatible overload: ExtendImmutabilityPolicyAsync with ETag parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ImmutabilityPolicyResource>> ExtendImmutabilityPolicyAsync(ETag ifMatch, ImmutabilityPolicyData data, CancellationToken cancellationToken = default)
            => ExtendImmutabilityPolicyAsync(ifMatch.ToString(), data, cancellationToken);

        // Backward-compatible overload: LockImmutabilityPolicy with ETag parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ImmutabilityPolicyResource> LockImmutabilityPolicy(ETag ifMatch, CancellationToken cancellationToken = default)
            => LockImmutabilityPolicy(ifMatch.ToString(), cancellationToken);

        // Backward-compatible overload: LockImmutabilityPolicyAsync with ETag parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ImmutabilityPolicyResource>> LockImmutabilityPolicyAsync(ETag ifMatch, CancellationToken cancellationToken = default)
            => LockImmutabilityPolicyAsync(ifMatch.ToString(), cancellationToken);
    }
}
