// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class PolicySignaturesOverridesForIdpsResource
    {
        // The released Update returned a response from this same PUT; wait for native creation before projecting its result.
        /// <summary> Updates the policy signature overrides and waits for completion. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<PolicySignaturesOverridesForIdpsResource> Update(PolicySignaturesOverridesForIdpsData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<PolicySignaturesOverridesForIdpsResource> operation = CreateOrUpdate(WaitUntil.Completed, data, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        // Preserve the asynchronous 1.15.0 response contract while leaving requests and completion to the native operation.
        /// <summary> Updates the policy signature overrides and waits for completion. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<PolicySignaturesOverridesForIdpsResource>> UpdateAsync(PolicySignaturesOverridesForIdpsData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<PolicySignaturesOverridesForIdpsResource> operation = await CreateOrUpdateAsync(WaitUntil.Completed, data, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }
    }
}
