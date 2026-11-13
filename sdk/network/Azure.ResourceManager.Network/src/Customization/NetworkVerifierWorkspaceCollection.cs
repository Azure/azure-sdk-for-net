// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkVerifierWorkspaceCollection
    {
        // Preserve the 1.15.0 token-only overload and its workspaceName parameter; omit the native condition.
        /// <summary> Creates or updates a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<NetworkVerifierWorkspaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string workspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, workspaceName, data, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the synchronous 1.15.0 token-only overload without adding an If-Match header.
        /// <summary> Creates or updates a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<NetworkVerifierWorkspaceResource> CreateOrUpdate(WaitUntil waitUntil, string workspaceName, NetworkVerifierWorkspaceData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, workspaceName, data, ifMatch: (ETag?)null, cancellationToken);

        // Preserve the 1.15.0 string condition and exact header contents; required arguments avoid overload ambiguity.
        /// <summary> Creates or updates a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<NetworkVerifierWorkspaceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string workspaceName, NetworkVerifierWorkspaceData data, string ifMatch, CancellationToken cancellationToken)
            => CreateOrUpdateAsync(waitUntil, workspaceName, data, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);

        // Preserve the synchronous 1.15.0 string condition while using the generated operation.
        /// <summary> Creates or updates a verifier workspace. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<NetworkVerifierWorkspaceResource> CreateOrUpdate(WaitUntil waitUntil, string workspaceName, NetworkVerifierWorkspaceData data, string ifMatch, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, workspaceName, data, ifMatch: ifMatch is null ? (ETag?)null : new ETag(ifMatch), cancellationToken);
    }
}
