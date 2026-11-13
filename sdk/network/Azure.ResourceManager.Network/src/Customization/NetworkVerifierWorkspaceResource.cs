// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVerifierWorkspaceResource
    {
        // Preserve the 1.15.0 token-only deletion overload; select the native operation without a condition.
        /// <summary> Deletes a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => DeleteAsync(waitUntil, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the synchronous 1.15.0 token-only deletion overload without adding an If-Match header.
        /// <summary> Deletes a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Delete(waitUntil, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the 1.15.0 string condition and its exact value while using native deletion.
        /// <summary> Deletes a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken)
            => DeleteAsync(waitUntil, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);

        // Preserve the synchronous 1.15.0 string deletion signature without optional-overload ambiguity.
        /// <summary> Deletes a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken)
            => Delete(waitUntil, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);

        // Preserve the 1.15.0 token-only patch overload; omit the native condition.
        /// <summary> Updates a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<NetworkVerifierWorkspaceResource>> UpdateAsync(NetworkVerifierWorkspacePatch patch, CancellationToken cancellationToken)
            => UpdateAsync(patch, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the synchronous 1.15.0 token-only patch overload without adding an If-Match header.
        /// <summary> Updates a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetworkVerifierWorkspaceResource> Update(NetworkVerifierWorkspacePatch patch, CancellationToken cancellationToken)
            => Update(patch, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the 1.15.0 string patch condition, including quoted and weak ETags.
        /// <summary> Updates a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<NetworkVerifierWorkspaceResource>> UpdateAsync(NetworkVerifierWorkspacePatch patch, string ifMatch, CancellationToken cancellationToken)
            => UpdateAsync(patch, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);

        // Preserve the synchronous 1.15.0 string patch signature while forwarding all native arguments.
        /// <summary> Updates a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<NetworkVerifierWorkspaceResource> Update(NetworkVerifierWorkspacePatch patch, string ifMatch, CancellationToken cancellationToken)
            => Update(patch, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);
    }
}
